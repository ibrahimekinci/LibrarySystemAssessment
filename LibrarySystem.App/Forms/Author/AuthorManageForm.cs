using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.App.Forms.Abstracts;
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
            if (!AuthorizetionCheck())
                return;
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

            if (!AuthorizetionCheck())
                return;

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

            string errorMessage = dto.CheckValidityAndGetErrors();
            if (!String.IsNullOrEmpty(errorMessage))
            {
                ShowError(errorMessage, "Validation Error");
                return;
            }

            var dtoSoap = Mapper.Map<AuthorService.AuthorCreateDto>(dto);
            try
            {
                var result = AuthorService.Add(dtoSoap);
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
            var dto = new AuthorUpdateDto { AID = _autor.AID, AuthorName = txt.Text.Trim() };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }
            var dtoSoap = Mapper.Map<AuthorService.AuthorUpdateDto>(dto);
            try
            {
                var result = AuthorService.Update(dtoSoap);
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
