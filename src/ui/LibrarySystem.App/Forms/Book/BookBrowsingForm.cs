using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

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

            if (!AuthorizetionCheck())
                return;

        }
        protected override void LoadFormData()
        {
            lnkTitle.Text = FormTitle;
            RefreshDgv();
        }
        private void RefreshDgv()
        {
            dgv.Width = this.Width - 40;
            dgv.Columns.Clear();

            try
            {
                var result = BookService.GetAll();
                if (!result.Success || result.Data == null || result.Data.Count() == 0)
                {
                    dgv.DataSource = null;
                    lblMessage.Visible = true;
                }
                else
                {
                    dgv.DataSource = result.Data;
                    lblMessage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}