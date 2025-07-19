using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookReserveForm : BaseForm
    {
        public override string FormTitle => "Book Reserve";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public BookReserveForm()
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
            var result = BookService.GetAvailableBooks();
            if (result == null || result.Count == 0)
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
            var btnReserve = new DataGridViewButtonColumn
            {
                Name = "btnReserve",
                HeaderText = "Reserve",
                Text = "Reserve",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Insert(0, btnReserve);
        }
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var isbn = Convert.ToString(dgv.Rows[e.RowIndex].Cells["ISBN"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "btnReserve")
            {
                var confirm = MessageBox.Show("Are you sure you want to reserve this book?", "Confirm Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var success = false;
                    var selected = BookService.GetAvailableBookByISBN(isbn);
                    if (selected != null)
                    {
                        var dto = new ReserveCreateDto()
                        {
                            ISBN = selected.ISBN,
                            ReservedDate = DateTime.Now,
                            UID = UserManager.CurrentUser.UID
                        };

                        success = 0 < ReserveService.ReserveBook(dto);
                    }
                    else
                    {
                        ShowInformation("Book is not available.");
                        RefreshDgv();
                    }


                    if (success)
                        RefreshDgv();
                    else
                        MessageBox.Show("Failed to delete author. Make sure you have all deleted the records that are realated with this record. Such as books.");
                }

            }
        }
    }
}


