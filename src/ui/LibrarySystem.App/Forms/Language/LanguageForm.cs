using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Language
{
    public partial class LanguageForm : BaseForm
    {
        public override string FormTitle => "Language";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public LanguageForm()
        {
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

        }
        protected override void LoadFormData()
        {
            lnkTitle.Text = FormTitle;
            dgv.CellContentClick += Dgv_CellContentClick;
            btnNew.Click += (s, e) =>
            {
                using (var form = new LanguageManageForm(OperationType.LanguageCreate, RefreshDgv))
                {
                    form.ShowDialog();
                }
            };
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dgv.Width = this.Width - 40;
            dgv.Columns.Clear();
            try
            {
                var result = LanguageService.GetAll();
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

            var id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["LID"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this Language?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var result = LanguageService.Delete(id);
                        if (!result.Success)
                            ShowError(result.Message);
                    }
                    catch (Exception ex)
                    {
                        ShowError("Failed to delete Language.");
                        HandleException(ex);
                    }

                    RefreshDgv();
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var result = LanguageService.GetById(id);
                if (result != null && result.Success && result.Data != null)
                {
                    var selectedDto = Mapper.Map<LanguageViewDto>(result.Data);
                    using (var form = new LanguageManageForm(OperationType.LanguageEdit, selectedDto, RefreshDgv))
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    ShowError("Language not found.");
                    RefreshDgv();
                }
            }
        }
    }
}