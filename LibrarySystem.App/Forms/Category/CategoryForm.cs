using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Category
{
    public partial class CategoryForm : BaseForm
    {
        public override string FormTitle => "Category";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public CategoryForm()
        {
            InitializeComponent();
        }
        protected override void LoadFormData()
        {
            lnkTitle.Text = FormTitle;
            dgv.CellContentClick += Dgv_CellContentClick;
            btnNew.Click += (s, e) =>
            {
                using (var form = new CategoryManageForm(OperationType.CategoryCreate, RefreshDgv))
                {
                    form.ShowDialog();
                }
            };
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dgv.Columns.Clear();
            var result = CategoryService.GetAllCategories();
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
            var editButton = new DataGridViewButtonColumn
            {
                Name = "btnEdit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };

            var deleteButton = new DataGridViewButtonColumn
            {
                Name = "btnDelete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Insert(0, editButton);
            dgv.Columns.Insert(1, deleteButton);
        }
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["CID"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this Category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var success = false;

                    try
                    {
                        success = CategoryService.DeleteCategory(id);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                    if (success)
                        RefreshDgv();
                    else
                        MessageBox.Show("Failed to delete Category. Make sure you have all deleted the records that are realated with this record.");
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var selectedCategory = CategoryService.GetById(id);
                if (selectedCategory != null)
                {
                    using (var form = new CategoryManageForm(OperationType.CategoryEdit, selectedCategory, RefreshDgv))
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Category not found.");
                    RefreshDgv();
                }
            }
        }
    }
}