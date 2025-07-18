using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.Domain.Enums;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookBrowsingForm : BaseForm
    {
        public override string FormTitle => "Book Browsing";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public BookBrowsingForm()
        {
            InitializeComponent();
        }
        protected override void LoadFormData()
        {
            var result = BookService.GetAll();
            if (result == null || result.Count == 0)
            {
                gvBooks.DataSource = null;
                lblMessage.Visible = true;
            }
            else
            {
                gvBooks.DataSource = result;
                gvBooks.Columns[5].Visible = false;
                gvBooks.Columns[6].Visible = false;
                gvBooks.Columns[7].Visible = false;
                lblMessage.Visible = false;
            }
        }
    }
}