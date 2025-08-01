using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.App.Forms.BookManage
{
    public partial class BookManageForm : BaseForm
    {
        private readonly string _formTitle = "Book Manage Form";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private readonly OperationType _operationType;
        private readonly BookViewDto _book;
        public Action BeforeFormClosing { get; set; }
        public BookManageForm(OperationType operationType, Action beforeFormClosing = null)
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            _operationType = operationType;
            _formTitle = "Book Create Form";
            BeforeFormClosing = beforeFormClosing;
            if (operationType != OperationType.BookCreate)
                throw new ArgumentException("Invalid operation type for BookManageForm", nameof(operationType));
            InitializeUIForCreate();
        }
        public BookManageForm(OperationType operationType, BookViewDto book, Action beforeFormClosing = null)
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            if (operationType != OperationType.BookEdit)
                throw new ArgumentException("Invalid operation type for BookManageForm", nameof(operationType));

            if (book == null || string.IsNullOrEmpty(book.ISBN))
                throw new ArgumentNullException(nameof(book), "Book cannot be null for edit operation");

            _operationType = operationType;
            _formTitle = "Book Update Form";
            _book = book;
            BeforeFormClosing = beforeFormClosing;
            InitializeUIForEdit();
        }
        private void InitializeUIForCreate()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnCreate_Click;
            txtBookName.Text = string.Empty;
            btn.Text = "Create";
            txtISBN.Enabled = true;
        }
        private void InitializeUIForEdit()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnEdit_Click;
            btn.Text = "Update";
            txtISBN.Enabled = false; // ISBN should not be editable in edit mode

        }
        protected override void LoadFormData()
        {
            LoadCategories();
            LoadLanguages();
            LoadAuthors();
            if (_operationType == OperationType.BookCreate)
            {
                txtISBN.Focus();
                ntxtPublishYear.Text = "2025";
                ntxtPages.Text = "400";
            }
            else if (_operationType == OperationType.BookEdit && _book != null)
            {
                txtBookName.Focus();
                cbCategory.SelectedValue = _book.Category;
                cbLanguage.SelectedValue = _book.Language;
                cbAuthor.SelectedValue = _book.Author;
                txtISBN.Text = _book.ISBN;
                txtBookName.Text = _book.BookName;
                ntxtPublishYear.Text = _book.PublishYear.ToString();
                ntxtPages.Text = _book.Pages.ToString();
                txtPublisher.Text = _book.Publisher;
            }
        }
        private void LoadCategories()
        {
            try
            {
                var result = CategoryService.GetAll();
                if (result.Success && result.Data != null)
                {
                    var categories = result.Data.ToList();
                    categories?.Insert(0, new CategoryService.CategoryViewDto { CID = 0, CategoryName = "Choose" });
                    cbCategory.DataSource = categories;
                    cbCategory.DisplayMember = "CategoryName";
                    cbCategory.ValueMember = "CID";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void LoadLanguages()
        {
            try
            {
                var result = LanguageService.GetAll();
                if (result.Success && result.Data != null)
                {
                    var languages = result.Data.ToList();
                    languages?.Insert(0, new LanguageService.LanguageViewDto { LID = 0, LanguageName = "Choose" });
                    cbLanguage.DataSource = languages;
                    cbLanguage.DisplayMember = "LanguageName";
                    cbLanguage.ValueMember = "LID";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void LoadAuthors()
        {
            try
            {
                var result = AuthorService.GetAll();
                if (result.Success && result.Data != null)
                {
                    var authors = result.Data.ToList();
                    authors?.Insert(0, new AuthorService.AuthorViewDto { AID = 0, AuthorName = "Choose" });
                    cbAuthor.DataSource = authors;
                    cbAuthor.DisplayMember = "AuthorName";
                    cbAuthor.ValueMember = "AID";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void CloseTheFormDialog()
        {
            BeforeFormClosing?.Invoke();
            this.Close();
        }
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            var dto = new BookDto
            {
                ISBN = txtISBN.Text.Trim(),
                BookName = txtBookName.Text.Trim(),
                Author = Convert.ToInt32(cbAuthor.SelectedValue),
                Category = Convert.ToInt32(cbCategory.SelectedValue),
                Language = Convert.ToInt32(cbLanguage.SelectedValue),
                PublishYear = Convert.ToInt32(ntxtPublishYear.Text.Trim()),
                Pages = Convert.ToInt32(ntxtPages.Text.Trim()),
                Publisher = txtPublisher.Text.Trim()
            };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var dtoSoap = Mapper.Map<BookService.BookDto>(dto);
            try
            {
                var result = BookService.Add(dtoSoap);
                if (result.Success)
                {
                    ShowInformation(result.Message, "Success");
                }
                else
                {
                    ShowError(result.Message, "Api Error");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            CloseTheFormDialog();
        }
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var dto = new BookDto
            {
                ISBN = _book.ISBN,
                BookName = txtBookName.Text.Trim(),
                Author = Convert.ToInt32(cbAuthor.SelectedValue),
                Category = Convert.ToInt32(cbCategory.SelectedValue),
                Language = Convert.ToInt32(cbLanguage.SelectedValue),
                PublishYear = Convert.ToInt32(ntxtPublishYear.Text.Trim()),
                Pages = Convert.ToInt32(ntxtPages.Text.Trim()),
                Publisher = txtPublisher.Text.Trim()
            };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var dtoSoap = Mapper.Map<BookService.BookDto>(dto);
            try
            {
                var result = BookService.Update(dtoSoap);
                if (result.Success)
                {
                    ShowInformation(result.Message, "Success");
                }
                else
                {
                    ShowError(result.Message, "Api Error");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            CloseTheFormDialog();
        }
    }
}
