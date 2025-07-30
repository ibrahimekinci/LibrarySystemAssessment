using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Language
{
    public partial class LanguageManageForm : BaseForm
    {
        private readonly string _formTitle = "Language Manage Form";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private readonly OperationType _operationType;
        private readonly LanguageViewDto _Language;
        public Action BeforeFormClosing { get; set; }
        public LanguageManageForm(OperationType operationType, Action beforeFormClosing = null)
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            _operationType = operationType;
            _formTitle = "Language Create Form";
            BeforeFormClosing = beforeFormClosing;
            if (operationType != OperationType.LanguageCreate)
                throw new ArgumentException("Invalid operation type for LanguageManageForm", nameof(operationType));
            InitializeUIForCreate();
        }
        public LanguageManageForm(OperationType operationType, LanguageViewDto Language, Action beforeFormClosing = null)
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            if (operationType != OperationType.LanguageEdit)
                throw new ArgumentException("Invalid operation type for LanguageManageForm", nameof(operationType));

            if (Language == null || Language.LID <= 0)
                throw new ArgumentNullException(nameof(Language), "Language cannot be null for edit operation");

            _operationType = operationType;
            _formTitle = "Language Update Form";
            _Language = Language;
            BeforeFormClosing = beforeFormClosing;
            InitializeUIForEdit();
        }
        private void InitializeUIForCreate()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnCreate_Click;
            txt.Text = string.Empty;
            btn.Text = "Create";
            lnkTitle.Text = "Language Create Form";
        }
        private void InitializeUIForEdit()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnEdit_Click;
            txt.Text = _Language.LanguageName;
            btn.Text = "Update";
            lnkTitle.Text = "Language Edit Form";
        }
        private void CloseTheFormDialog()
        {
            BeforeFormClosing?.Invoke();
            this.Close();
        }
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            var dto = new LanguageCreateDto { LanguageName = txt.Text.Trim() };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }
            var result = LanguageService.Add(dto);
            if (result > 0)
            {
                ShowInformation("Language create successfully.", "Success");
            }
            else
            {
                ShowError("Failed to update Language.", "Error");
            }
            CloseTheFormDialog();
        }
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var dto = new LanguageUpdateDto { LID = _Language.LID, LanguageName = txt.Text.Trim() };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var result = LanguageService.Update(dto);
            if (result)
            {
                ShowInformation("Language updated successfully.", "Success");
            }
            else
            {
                ShowError("Failed to update Language.", "Error");
            }
            CloseTheFormDialog();
        }
    }
}
