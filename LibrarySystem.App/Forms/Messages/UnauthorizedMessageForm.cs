using LibrarySystem.App.Forms.Abstracts;
using System;

namespace LibrarySystem.App.Forms.Messages
{
    public partial class UnauthorizedMessageForm : BaseForm
    {
        public override string FormTitle => "Library System - UnAuthorized Page";
        protected override bool IsLoggedInRequired() => false;
        public UnauthorizedMessageForm()
        {
            InitializeComponent();
        }
        private void btnGoHomePage_Click(object sender, EventArgs e)
        {
            RiderectToDashboard();
        }
    }
}
