using System;

namespace LibrarySystem.UI.Forms
{
    public partial class UnauthorizedWarningForm : FormBase
    {
        public override string FormTitle => "Library System - UnAuthorized Page";
        protected override bool IsLoggedInRequired() => false;
        public UnauthorizedWarningForm()
        {
            InitializeComponent();
        }

        private void btnGoHomePage_Click(object sender, EventArgs e)
        {
            RiderectToDashboard();
        }
    }
}
