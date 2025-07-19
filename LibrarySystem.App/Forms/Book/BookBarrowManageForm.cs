using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookBarrowManageForm : BaseForm
    {
        public override string FormTitle => "Book Barrrowing Form";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public Action BeforeFormClosing { get; set; }
        private readonly BookViewDto _book;
        public BookBarrowManageForm(BookViewDto book, Action beforeFormClosing = null)
        {
            InitializeComponent();
            _book = book ?? throw new ArgumentNullException(nameof(book), "Book cannot be null for barrowing operation");
            BeforeFormClosing = beforeFormClosing;

            dtpReturnDate.Focus();
            dtpReturnDate.MinDate = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now.AddDays(7); // Default return date is 7 days from now
            dtpReturnDate.MaxDate = DateTime.Now.AddDays(30); // Maximum return date is 30 days from now

            txtIsbn.Text = _book.ISBN;
            txtBookName.Text = _book.BookName;
            txtAuthor.Text = _book.AuthorName;
            txtPublisher.Text = _book.Publisher;
            txtPublishYear.Text = _book.PublishYear.ToString();
            txtCategory.Text = _book.CategoryName;
            txtLanguage.Text = _book.LanguageName;
            txtPages.Text = _book.Pages.ToString();
        }
        private void CloseTheFormDialog()
        {
            BeforeFormClosing?.Invoke();
            this.Close();
        }

        private void btnBarrow_Click(object sender, EventArgs e)
        {
            var dto = new BarrowCreateDto
            {
                BorrowDate = DateTime.Now,
                ISBN = _book.ISBN,
                UID = UserManager.CurrentUser.UID,
                ReturnDate = dtpReturnDate.Value
            };

            var errors = dto.ValidateAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var result = BookLoanService.BorrowBook(dto);
            if (result > 0)
            {
                ShowInformation("You have successfully borrowed the book.", "Success");
            }
            else
            {
                ShowError("Failed to borrow the book.", "Error");
            }
            CloseTheFormDialog();
        }
    }
}
