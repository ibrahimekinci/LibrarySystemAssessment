using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Forms.Book;
using LibrarySystem.App.Helpers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Dashboards
{
    public partial class StudentDashboardForm : BaseForm
    {
        public override string FormTitle => "Home Page";
        private static readonly IReadOnlyList<UserLevelEnum> authorizedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => authorizedUserLevels;

        public StudentDashboardForm()
        {
            InitializeComponent();
            if (!AuthorizetionCheck())
                return;

            lnkWelcome.Text = $"🙍 Hello {SessionManager.Username}, How are you today ?";
            lnkWelcome.Anchor = AnchorStyles.None;
            lnkWelcome.Left = (this.ClientSize.Width - lnkWelcome.Width) / 2;
        }
        private void lnkSearchBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookSearchForm>();
        }

        private void lnkBrowseBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookBrowsingForm>();
        }

        private void lnkReverseBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookReserveForm>();
        }

        private void lnkBorrowBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookBorrowForm>();
        }

        private void lnkReturnBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormInMdi<BookReturnForm>();
        }
    }
}
