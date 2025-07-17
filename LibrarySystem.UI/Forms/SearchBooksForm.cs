using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.UI.Forms
{
    public partial class SearchBooksForm : FormBase
    {
        public override string FormTitle => "Book Search";
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;

        IBookService bookService = new BookService();
        IMasterDataService masterDataService = new MasterDataService();
        public SearchBooksForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            var dto = new BookSearchCriteriaDto();
            dto.AuthorName = txtAuthorName.Text;
            dto.BookName = txtBookName.Text;
            dto.CategoryId = Convert.ToInt32(cbCategory.SelectedValue);

            gvBooks.DataSource = bookService.Search(dto);
            gvBooks.Columns[5].Visible = false;
            gvBooks.Columns[6].Visible = false;
            gvBooks.Columns[7].Visible = false;
        }

        private void BookSearchForm_Load(object sender, System.EventArgs e)
        {

            var categories = masterDataService.GetAllCategories();
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CID";
        }
    }
}
