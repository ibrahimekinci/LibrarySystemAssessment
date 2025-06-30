using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using LibrarySystem.UI.Abstracts;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class MenuOutlineForm : FormBaseAuthorizedRequired
    {
        public override string FormTitle => "Home Page";
        private List<UserLevelEnum> authorizedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override List<UserLevelEnum> AuthorizedUserLevels => authorizedUserLevels;

        public MenuOutlineForm() : base(CurrentUser)
        {
            InitializeComponent();
        }
        public MenuOutlineForm(UserViewDto user) : base(user)
        {
            InitializeComponent();
            lnkWelcome.Text = $"🙍 Hello {CurrentUser.UserName}, How are you today ?";

            lnkWelcome.Anchor = AnchorStyles.None; // Remove any anchors
            lnkWelcome.Left = (this.ClientSize.Width - lnkWelcome.Width) / 2;
        }

        private void lnkBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowForm<BookBrowsingForm>();
        }

        private void lnkSearchBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowForm<BookSearchForm>();
        }
    }
}
