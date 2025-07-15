using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using LibrarySystem.UI.Helpers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class DashboardForm : FormBase
    {
        public override string FormTitle => "Home Page";
        private static readonly IReadOnlyList<UserLevelEnum> authorizedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => authorizedUserLevels;

        public DashboardForm()
        {
            InitializeComponent();
            lnkWelcome.Text = $"🙍 Hello {UserManager.CurrentUser.UserName}, How are you today ?";
            lnkWelcome.Anchor = AnchorStyles.None; // Remove any anchors
            lnkWelcome.Left = (this.ClientSize.Width - lnkWelcome.Width) / 2;
        }

        private void lnkBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookBrowsingForm>();
        }

        private void lnkSearchBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookSearchForm>();
        }
    }
}
