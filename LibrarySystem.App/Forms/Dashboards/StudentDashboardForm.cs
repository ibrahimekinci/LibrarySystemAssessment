using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Forms.Book;
using LibrarySystem.App.Helpers;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
