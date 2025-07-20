using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
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
            var result = UserService.GetAll();
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
                    var success = false;

                    try
                    {
                        success = UserService.Delete(id);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                    if (success)
                        RefreshDgv();
                    else
                        MessageBox.Show("Failed to delete User. Make sure you have all deleted the records that are realated with this user.");
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

                        success = UserService.ResetPassword(dto);
                        if (success)
                        {
                            MessageBox.Show($"Password reset successfully. New password: {dto.NewPassword}");
                        }
                        else
                        {
                            MessageBox.Show("Failed to reset password. Please try again.");
                        }

                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }

                    if (success)
                        RefreshDgv();
                    else
                        MessageBox.Show("Failed to delete User. Make sure you have all deleted the records that are realated with this user.");
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var selectedUser = UserService.GetById(id);
                if (selectedUser != null)
                {
                    using (var form = new UserManageForm(OperationType.UserUpdate, selectedUser, RefreshDgv))
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                    RefreshDgv();
                }
            }
        }
    }
}