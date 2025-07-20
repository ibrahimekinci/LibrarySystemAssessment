using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
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
            var result = BookLoanService.GetUnreturnedLoansByUserId(UserManager.CurrentUser.UID);
            if (result == null || result.Rows.Count == 0)
            {
                dgv.DataSource = null;
                lblMessage.Visible = true;
            }
            else
            {
                dgv.DataSource = result;
                AddActionButtons();
                lblMessage.Visible = false;
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
                    var selected = BookLoanService.GetById(id);
                    if (selected != null || selected.ActualReturnDate <= new DateTime(2001, 1, 1))
                    {
                        var dto = new BarrowReturnDto()
                        {
                            ActualReturnDate = DateTime.Now,
                            BID = selected.BID
                        };

                        //2 aud late panalty per day
                        if (dto.ActualReturnDate <= selected.ReturnDate)
                            dto.LateFee = 0;
                        else
                            dto.LateFee = (dto.ActualReturnDate - selected.ReturnDate).Days * 2;

                        try
                        {
                            success = BookLoanService.Return(dto);
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);
                        }

                        if (success)
                            RefreshDgv();
                        else
                            MessageBox.Show("The book loan could not found. Please try again with the updated list.");
                    }

                    if (success)
                        RefreshDgv();
                    else
                    {
                        ShowError("The book loan could not be found. Please try again with the updated list.");
                        RefreshDgv();
                    }
                }

            }
        }
    }
}