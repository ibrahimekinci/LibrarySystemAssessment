using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookSearchForm : BaseForm
    {
        public override string FormTitle => "Book Search";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        public BookSearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            var dto = new BookSearchCriteriaDto
            {
                AuthorName = txtAuthorName.Text.Trim(),
                BookName = txtBookName.Text.Trim(),
                CategoryId = Convert.ToInt32(cbCategory.SelectedValue)
            };

            var result = BookService.Search(dto);
            if (result == null || result.Count == 0 && gvBooks.Rows.Count > 0)
            {
                gvBooks.DataSource = null;
            }
            else
            {
                gvBooks.DataSource = BookService.Search(dto);
                gvBooks.Columns[5].Visible = false;
                gvBooks.Columns[6].Visible = false;
                gvBooks.Columns[7].Visible = false;
            }
        }
        protected override void LoadFormData()
        {
            var categories = MasterDataService.GetAllCategories();
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CID";
        }
    }
}
