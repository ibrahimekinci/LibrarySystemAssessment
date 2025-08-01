using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.User
{
    public partial class UserForm : BaseForm
    {
        private readonly string _formTitle = "Users";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public UserForm()
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
                using (var form = new UserManageForm(OperationType.UserCreate, RefreshDgv))
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
                var result = UserService.GetAll();
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

            var resetPasswordButton = new DataGridViewButtonColumn
            {
                Name = "btnResetPassword",
                HeaderText = "Reset Password",
                Text = "Reset Password",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Insert(0, editButton);
            dgv.Columns.Insert(1, deleteButton);
            dgv.Columns.Insert(2, resetPasswordButton);
        }
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["UID"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this User?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var result = UserService.Delete(id);
                        if (!result.Success)
                            ShowError(result.Message);
                    }
                    catch (Exception ex)
                    {
                        ShowError("Failed to delete User.");
                        HandleException(ex);
                    }

                    RefreshDgv();
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name == "btnResetPassword")
            {
                var confirm = MessageBox.Show("Are you sure you want to reset the password?", "Confirm Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var success = false;

                    try
                    {
                        var dto = new UserPasswordUpdateDto()
                        {
                            UID = id,
                            NewPassword = Guid.NewGuid().ToString("d").Substring(1, 8)
                        };

                        var dtoSoap = Mapper.Map<UserService.UserPasswordUpdateDto>(dto);
                        var result = UserService.ResetPassword(dtoSoap);

                        if (result.Success)
                        {
                            ShowInformation($"Password reset successfully. New password: {dto.NewPassword}", "Success");
                            success = result.Success;
                        }
                        else
                        {
                            ShowError(result.Message, "Api Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Failed to delete User.");
                        HandleException(ex);
                    }

                    RefreshDgv();
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var result = UserService.GetById(id);

                if (result != null && result.Success && result.Data != null)
                {
                    var selectedDto = Mapper.Map<UserViewDto>(result.Data);
                    using (var form = new UserManageForm(OperationType.UserUpdate, selectedDto, RefreshDgv))
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    ShowError("Please try again.");
                    RefreshDgv();
                }
            }
        }
    }
}