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

            if (!AuthorizetionCheck())
                return;

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
            if (result == null || result.Count == 0 && dgv.Rows.Count > 0)
            {
                dgv.DataSource = null;
            }
            else
            {
                dgv.Width = this.Width - 40;
                dgv.DataSource = BookService.Search(dto);
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
            }
        }
        protected override void LoadFormData()
        {
            var categories = CategoryService.GetAll();
            categories?.Insert(0, new CategoryViewDto { CID = 0, CategoryName = "All Categories" });
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CID";
        }
    }
}
