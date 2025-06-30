using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.UI.Abstracts;
using System;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class BookSearchForm : FormBaseAuthorizedRequired
    {
        public override string FormTitle => "Book Search";
        IBookService bookService = new BookService();
        IMasterDataService masterDataService = new MasterDataService();
        public BookSearchForm() : base(CurrentUser)
        {
            InitializeComponent();
        }
        public BookSearchForm(UserViewDto user) : base(user)
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

            var ds = masterDataService.GetAllCategories();
            cbCategory.DataSource = ds.Items;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CID";
        }
    }
}
