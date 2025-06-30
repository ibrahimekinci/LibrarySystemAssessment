using LibrarySystem.UI.Abstracts;
using System;

namespace LibrarySystem.UI.Forms
{
    public partial class UnauthorizedWarningForm : FormBase
    {
        public override string FormTitle => "Un Authorized Page";
        public UnauthorizedWarningForm()
        {
            InitializeComponent();
        }

        private void btnGoHomePage_Click(object sender, EventArgs e)
        {
            RiderectToHomePage();
        }
    }
}
