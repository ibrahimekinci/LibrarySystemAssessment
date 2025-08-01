using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookBorrowForm : BaseForm
    {
        public override string FormTitle => "Book Borrow";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public BookBorrowForm()
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
            var btnBorrow = new DataGridViewButtonColumn
            {
                Name = "btnBorrow",
                HeaderText = "Borrow",
                Text = "Borrow",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Insert(0, btnBorrow);
        }
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var isbn = Convert.ToString(dgv.Rows[e.RowIndex].Cells["ISBN"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "btnBorrow")
            {
                try
                {
                    var result = BookService.GetAvailableBookByISBN(isbn);
                    if (result != null && result.Success && result.Data != null)
                    {
                        var selectedDto = Mapper.Map<BookViewDto>(result.Data);
                        using (var form = new BookBorrowManageForm(selectedDto, RefreshDgv))
                        {
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        ShowInformation("Book is not available.");
                        RefreshDgv();
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
    }
}

