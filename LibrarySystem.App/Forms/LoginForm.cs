using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using System;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms
{
    public partial class LoginForm : BaseForm
    {
        public override string FormTitle => "Library System - Login";
        protected override bool IsLoggedInRequired() => false;
        protected override void InitializeUIAdditional()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Dock = DockStyle.None;
            this.IsMdiContainer = false;
            this.WindowState = FormWindowState.Normal;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.ShowIcon = true;
            BackgroundImage = Properties.Resources.bg2;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        public LoginForm()
        {
            if (SessionManager.IsUserLoggedIn())
            {
                ShowDashboard();
                return;
            }
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = AuthenticationService.Login(username, password);
            if (result == null)
            {
                ShowError("Please try again.");
                return;
            }
            if (result.UID < 1)
            {
                ShowError("Invalid login.");
                return;
            }

            SessionManager.SetUser(result);

            //var result = AuthenticationService.Login(username, password);
            //if (result == null)
            //{
            //    ShowError("Please try again.");
            //    return;
            //}
            //if (!result.Success || result.Data == null || result.Data.UID < 1)
            //{
            //    MessageBox.Show(result.Message, "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //SessionManager.SetUser(result.Data);
            ShowDashboard();
        }
        private void ShowDashboard()
        {
            RiderectToDashboard();
        }
        protected override void RiderectToDashboard()
        {
            FormManager.ShowForm<MainMdiForm>();
            this.Hide();
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
