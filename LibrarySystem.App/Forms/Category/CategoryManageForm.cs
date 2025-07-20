using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Category
{
    public partial class CategoryManageForm : BaseForm
    {
        private readonly string _formTitle = "Category Manage Form";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private readonly OperationType _operationType;
        private readonly CategoryViewDto _category;
        public Action BeforeFormClosing { get; set; }
        public CategoryManageForm(OperationType operationType, Action beforeFormClosing = null)
        {
            InitializeComponent();
            if (!AuthorizetionCheck())
                return;

            _operationType = operationType;
            _formTitle = "Category Create Form";
            BeforeFormClosing = beforeFormClosing;
            if (operationType != OperationType.CategoryCreate)
                throw new ArgumentException("Invalid operation type for CategoryManageForm", nameof(operationType));
            InitializeUIForCreate();
        }
        public CategoryManageForm(OperationType operationType, CategoryViewDto category, Action beforeFormClosing = null)
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            if (operationType != OperationType.CategoryEdit)
                throw new ArgumentException("Invalid operation type for CategoryManageForm", nameof(operationType));

            if (category == null || category.CID <= 0)
                throw new ArgumentNullException(nameof(category), "Category cannot be null for edit operation");

            _operationType = operationType;
            _formTitle = "Category Update Form";
            _category = category;
            BeforeFormClosing = beforeFormClosing;
            InitializeUIForEdit();
        }
        private void InitializeUIForCreate()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnCreate_Click;
            txt.Text = string.Empty;
            btn.Text = "Create";
            lnkTitle.Text = "Category Create Form";
        }
        private void InitializeUIForEdit()
        {
            lnkTitle.Text = FormTitle;
            btn.Click += btnEdit_Click;
            txt.Text = _category.CategoryName;
            btn.Text = "Update";
            lnkTitle.Text = "Category Edit Form";
        }
        private void CloseTheFormDialog()
        {
            BeforeFormClosing?.Invoke();
            this.Close();
        }
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            var dto = new CategoryCreateDto { CategoryName = txt.Text.Trim() };

            var errors = dto.ValidateAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }
            var result = CategoryService.Add(dto);
            if (result > 0)
            {
                ShowInformation("Category create successfully.", "Success");
            }
            else
            {
                ShowError("Failed to update Category.", "Error");
            }
            CloseTheFormDialog();
        }
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var dto = new CategoryUpdateDto { CID = _category.CID, CategoryName = txt.Text.Trim() };

            var errors = dto.ValidateAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var result = CategoryService.Update(dto);
            if (result)
            {
                ShowInformation("Category updated successfully.", "Success");
            }
            else
            {
                ShowError("Failed to update Category.", "Error");
            }
            CloseTheFormDialog();
        }
    }
}
