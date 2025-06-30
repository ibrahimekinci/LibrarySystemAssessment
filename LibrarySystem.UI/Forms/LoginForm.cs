using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.UI.Abstracts;
using System;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class LoginForm : FormBase
    {
        public override string FormTitle => "Login";
        private readonly IUserService _service = new UserService();
        public LoginForm()
        {
            if (CurrentUser?.UID > 0)
            {
                RiderectToHomePage();
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
            CurrentUser = user;
            RiderectToHomePage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
