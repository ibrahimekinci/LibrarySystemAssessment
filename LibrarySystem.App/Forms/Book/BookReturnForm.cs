using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookReturnForm : BaseForm
    {
        public override string FormTitle => "Book Return";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public BookReturnForm()
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

        }
        protected override void LoadFormData()
        {
            lnkTitle.Text = FormTitle;
            dgv.CellContentClick += Dgv_CellContentClick;
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dgv.Width = this.Width - 40;
            dgv.Columns.Clear();
            try
            {
                var result = BookLoanService.GetUnreturnedLoansByUserId(SessionManager.UID);
                if (!result.Success || result.Data == null || result.Data.Rows.Count == 0)
                {
                    dgv.DataSource = null;
                    lblMessage.Visible = true;
                }
                else
                {
                    dgv.DataSource = result.Data;
                    AddActionButtons();
                    lblMessage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void AddActionButtons()
        {
            var btnReturn = new DataGridViewButtonColumn
            {
                Name = "btnReturn",
                HeaderText = "Return",
                Text = "Return",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Insert(0, btnReturn);
        }
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["BID"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "btnReturn")
            {
                var confirm = MessageBox.Show("Are you sure you want to return this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var success = false;
                    try
                    {
                        var result = BookLoanService.GetById(id);
                        if (result != null && result.Success && result.Data != null && result.Data.ActualReturnDate <= new DateTime(2001, 1, 1))
                        {
                            var dto = new BookLoanService.BorrowReturnDto()
                            {
                                ActualReturnDate = DateTime.Now,
                                BID = result.Data.BID
                            };

                            //0.2 aud late panalty per day
                            if (dto.ActualReturnDate > result.Data.ReturnDate)
                            {
                                dto.LateFee = (dto.ActualReturnDate - result.Data.ReturnDate).Days * 0.2m;
                            }
                            else
                            {
                                dto.LateFee = 0m;
                            }

                            var resultReturn = BookLoanService.Return(dto);
                            if (resultReturn != null)
                                success = resultReturn.Success;
                        }
                        if (!success)
                        {
                            ShowError("The book loan could not be found. Please try again with the updated list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Failed to delete author.");
                        HandleException(ex);
                    }
                    RefreshDgv();
                }
            }
        }
    }
}