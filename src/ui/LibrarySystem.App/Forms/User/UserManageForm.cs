using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.User
{
    public partial class UserManageForm : BaseForm
    {
        private readonly string _formTitle = "User Manage";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private Action BeforeFormClosing;
        private UserViewDto _user;
        OperationType _operationType;
        public UserManageForm(OperationType operationType)
        {
            if (operationType != OperationType.ProfileUpdate)
                throw new ArgumentException("Invalid operation type for UserManageForm", nameof(operationType));
            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            _operationType = operationType;
            var authenticatedUser = SessionManager.GetUser();
            _user = new UserViewDto()
            {
                UID = authenticatedUser.UID,
                UserName = authenticatedUser.UserName,
                UserLevel = authenticatedUser.UserLevel,
                Email = authenticatedUser.Email,
                PhoneNumber = authenticatedUser.PhoneNumber,

            };
            _formTitle = $"Profile Update ({_user.UID})";
        }
        public UserManageForm(OperationType operationType, Action beforeFormClosing)
        {
            if (operationType != OperationType.UserCreate)
                throw new ArgumentException("Invalid operation type for UserManageForm", nameof(operationType));

            if (!SessionManager.IsLoggedInAsManager())
                throw new UnauthorizedAccessException("UserManageForm");

            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            _operationType = operationType;
            BeforeFormClosing = beforeFormClosing;
            _formTitle = "Create User";
        }
        public UserManageForm(OperationType operationType, UserViewDto user, Action beforeFormClosing)
        {
            if (operationType != OperationType.UserUpdate)
                throw new ArgumentException("Invalid operation type for UserManageForm", nameof(operationType));
            if (!SessionManager.IsLoggedInAsManager())
                throw new UnauthorizedAccessException("UserManageForm");

            InitializeComponent();

            if (!AuthorizetionCheck())
                return;

            _operationType = operationType;
            _user = user ?? throw new ArgumentNullException(nameof(user), "User cannot be null for UserManageForm");
            BeforeFormClosing = beforeFormClosing;
            _formTitle = $"Update User ({user.UID})";
            _user = user;
        }
        protected override void LoadFormData()
        {
            lnkTitle.Text = FormTitle;

            cbUserLevel.DisplayMember = "Value";
            cbUserLevel.ValueMember = "Key";
            cbUserLevel.DataSource = Enum.GetValues(typeof(UserLevelEnum))
                .Cast<UserLevelEnum>()
                .Select(e => new KeyValuePair<int, string>((int)e, e.ToString())).Where(e => e.Key > 0)
                .ToList();

            cbUserLevel.SelectedIndex = 0; // Default to first item

            if (_operationType == OperationType.UserCreate)
            {
                InitUIforCreateUser();
            }
            else
            {
                cbUserLevel.SelectedValue = (int)_user.UserLevel;
                txtUserName.Text = _user.UserName;
                txtPhone.Text = _user.PhoneNumber;
                txtEmail.Text = _user.Email;

                if (_operationType == OperationType.UserUpdate)
                {
                    InitUIforUpdateUser();
                }
                else if (_operationType == OperationType.ProfileUpdate)
                {
                    InitUIforMyProfileUpdate();
                }
            }
        }

        private void InitUIforCreateUser()
        {
            cbUserLevel.Enabled = true;
            btnSave.Text = "Create User";
            btnResetPassword.Visible = false;
            txtUserName.Enabled = true;
            btnSave.Click += btnCreate_Click;
        }
        private void InitUIforUpdateUser()
        {
            cbUserLevel.Enabled = true;
            btnSave.Text = "Update User";
            btnResetPassword.Visible = true;
            txtUserName.Enabled = true;
            btnSave.Click += btnEdit_Click;
        }
        private void InitUIforMyProfileUpdate()
        {
            cbUserLevel.Enabled = false;
            btnSave.Text = "Update Profile";
            btnResetPassword.Visible = true;
            txtUserName.Enabled = false;
            btnSave.Click += btnUpdateMyProfile_Click;
        }
        private void CloseTheFormDialog()
        {
            BeforeFormClosing?.Invoke();
            this.Close();
        }
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            var dto = new UserCreateDto()
            {
                UserName = txtUserName.Text.Trim(),
                Password = Guid.NewGuid().ToString("d").Substring(1, 8),
                PhoneNumber = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                // Ensure a valid value is selected
                UserLevel = (UserLevelEnum)(cbUserLevel.SelectedValue ?? 0)
            };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var dtoSoap = Mapper.Map<UserService.UserCreateDto>(dto);
            try
            {
                var result = UserService.Register(dtoSoap);
                if (result.Success)
                {
                    ShowInformation(result.Message, "Success");
                }
                else
                {
                    ShowError(result.Message, "Error");
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
            var dto = new UserUpdateDto()
            {
                UID = _user.UID,
                UserName = txtUserName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                // Ensure a valid value is selected
                UserLevel = (UserLevelEnum)(cbUserLevel.SelectedValue ?? 0)
            };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var dtoSoap = Mapper.Map<UserService.UserUpdateDto>(dto);
            try
            {
                var result = UserService.UpdateUser(dtoSoap);
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
        private void btnUpdateMyProfile_Click(object sender, System.EventArgs e)
        {
            var dto = new UserUpdateDto()
            {
                UID = _user.UID,
                UserName = _user.UserName,
                PhoneNumber = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                UserLevel = _user.UserLevel
            };

            var errors = dto.CheckValidityAndGetErrors();
            if (errors != null)
            {
                ShowError(errors, "Validation Error");
                return;
            }

            var dtoSoap = Mapper.Map<UserService.UserUpdateDto>(dto);
            try
            {
                var resultUserUpdate = UserService.UpdateUser(dtoSoap);
                if (resultUserUpdate.Success)
                {
                    ShowInformation("Your profile updated successfully.", "Success");
                    var userViewResult = UserService.GetById(SessionManager.UID);
                    if (userViewResult.Success)
                    {
                        var authenticatedUser = new AuthenticatedUserDto()
                        {
                            UID = userViewResult.Data.UID,
                            UserName = userViewResult.Data.UserName,
                            Email = userViewResult.Data.Email,
                            PhoneNumber = userViewResult.Data.PhoneNumber,
                            UserLevel = SessionManager.UserLevel,
                            Token = SessionManager.Token
                        };
                        SessionManager.SetUser(authenticatedUser);
                    }
                    else
                    {
                        ShowError(userViewResult.Message);
                    }
                }
                else
                {
                    ShowError("Failed to update your profile.", "Api Error");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to reset the password?", "Confirm Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var dto = new UserPasswordUpdateDto()
                    {
                        UID = _user.UID,
                        NewPassword = Guid.NewGuid().ToString("d").Substring(1, 8)
                    };
                    var dtoSoap = Mapper.Map<UserService.UserPasswordUpdateDto>(dto);
                    var result = UserService.ResetPassword(dtoSoap);
                    if (result.Success)
                    {
                        ShowInformation($"Password reset successfully. New password: {dto.NewPassword}", "Success");

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
            }
        }
    }
}
