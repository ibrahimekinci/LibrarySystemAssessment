using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Author
{
    public partial class AuthorManageForm : BaseForm
    {
        private readonly string _formTitle = "Author Manage Form";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private readonly OperationType _operationType;
        private readonly AuthorViewDto _autor;
        public Action BeforeFormClosing { get; set; }
        public AuthorManageForm(OperationType operationType, Action beforeFormClosing = null)
        {
            InitializeComponent();
            _operationType = operationType;
            _formTitle = "Author Create Form";
            BeforeFormClosing = beforeFormClosing;
            if (operationType != OperationType.AuthorCreate)
                throw new ArgumentException("Invalid operation type for AuthorManageForm", nameof(operationType));
            InitializeUIForCreate();
        }
        public AuthorManageForm(OperationType operationType, AuthorViewDto autor, Action beforeFormClosing = null)
        {
            InitializeComponent();
            if (operationType != OperationType.AuthorEdit)
                throw new ArgumentException("Invalid operation type for AuthorManageForm", nameof(operationType));

            if (autor == null || autor.AID <= 0)
                throw new ArgumentNullException(nameof(autor), "Author cannot be null for edit operation");

            _operationType = operationType;
            _formTitle = "Author Update Form";
            _autor = autor;
            BeforeFormClosing = beforeFormClosing;
            InitializeUIForEdit();
        }
        private void InitializeUIForCreate()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnCreate_Click;
            txt.Text = string.Empty;
            btn.Text = "Create";
            lnkTitle.Text = "Author Create Form";
        }
        private void InitializeUIForEdit()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnEdit_Click;
            txt.Text = _autor.AuthorName;
            btn.Text = "Update";
            lnkTitle.Text = "Author Edit Form";
        }
        private void CloseTheFormDialog()
        {
            BeforeFormClosing?.Invoke();
            this.Close();
        }
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            var dto = new AuthorCreateDto { AuthorName = txt.Text.Trim() };

            var errors = dto.ValidateAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }
            var result = AuthorService.AddAuthor(dto);
            if (result > 0)
            {
                ShowInformation("Author create successfully.", "Success");
            }
            else
            {
                ShowError("Failed to update author.", "Error");
            }
            CloseTheFormDialog();
        }
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var dto = new AuthorUpdateDto { AID = _autor.AID, AuthorName = txt.Text.Trim() };

            var errors = dto.ValidateAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var result = AuthorService.UpdateAuthor(dto);
            if (result)
            {
                ShowInformation("Author updated successfully.", "Success");
            }
            else
            {
                ShowError("Failed to update author.", "Error");
            }
            CloseTheFormDialog();
        }
    }
}
