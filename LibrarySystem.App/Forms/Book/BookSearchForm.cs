using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var dto = new BookService.BookSearchCriteriaDto
            {
                AuthorName = txtAuthorName.Text.Trim(),
                BookName = txtBookName.Text.Trim(),
                CategoryId = Convert.ToInt32(cbCategory.SelectedValue)
            };
            try
            {
                var result = BookService.Search(dto);
                if (result == null || result.Data == null || result.Data.Count() == 0)
                {
                    dgv.DataSource = null;
                }
                else
                {
                    dgv.Width = this.Width - 40;
                    dgv.DataSource = result.Data;
                    dgv.Columns[5].Visible = false;
                    dgv.Columns[6].Visible = false;
                    dgv.Columns[7].Visible = false;
                }
            }
            catch (Exception ex)
            {
                dgv.DataSource = null;
                HandleException(ex);
            }
        }
        protected override void LoadFormData()
        {
            try
            {
                var result = CategoryService.GetAll();
                if (result.Success && result.Data != null)
                {
                    var categories = result.Data.ToList();
                    categories?.Insert(0, new CategoryService.CategoryViewDto { CID = 0, CategoryName = "All Categories" });
                    cbCategory.DataSource = categories;
                    cbCategory.DisplayMember = "CategoryName";
                    cbCategory.ValueMember = "CID";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}
