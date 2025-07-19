using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Forms.Author;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            lnkTitle.Text = FormTitle;
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dgv.Columns.Clear();
            var result = AuthorService.GetAllAuthors();
            if (result == null || result.Count == 0)
            {
                dgv.DataSource = null;
                lblMessage.Visible = true;
            }
            else
            {
                dgv.DataSource = result;
                lblMessage.Visible = false;
            }
        }
    }
}