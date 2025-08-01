using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = BookService.GetAvailableBooks();
                if (!result.Success || result.Data == null || result.Data.Count() == 0)
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
                    try
                    {
                        var selectedBookResult = BookService.GetAvailableBookByISBN(isbn);
                        if (selectedBookResult != null && selectedBookResult.Success && selectedBookResult.Data != null)
                        {
                            var dto = new BookReservationService.ReserveCreateDto()
                            {
                                ISBN = selectedBookResult.Data.ISBN,
                                ReservedDate = DateTime.Now,
                                UID = SessionManager.UID
                            };

                            var resultReserve = BookReservationService.Reserve(dto);
                            if (resultReserve.Success)
                                FormManager.ShowFormInMdi<BookReservationsForm>(OperationType.ViewMyReservations);
                            else
                                ShowError(resultReserve.Message);
                        }
                        else
                        {
                            ShowError("Book is not available.");
                            RefreshDgv();
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                        MessageBox.Show("Failed to delete author. Make sure you have all deleted the records that are realated with this record. Such as books.");
                    }
                }

            }
        }
    }
}


