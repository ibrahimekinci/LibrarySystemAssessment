using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.UI.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class LoginForm : FormBase
    {
        public override string FormTitle => "Library System - Login";
        protected override bool IsLoggedInRequired() => false;
        private readonly IUserService _service = new UserService();
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
            if (UserManager.IsUserLoggedIn())
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

            var user = _service.Authenticate(username, password);
            if (user == null || user.UID < 1)
            {
                MessageBox.Show("Invalid username or password", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserManager.CurrentUser = user;
            ShowDashboard();
        }
        private void ShowDashboard()
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
            this.Hide();
        }
    }
}
