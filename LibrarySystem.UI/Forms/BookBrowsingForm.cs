using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.UI.Abstracts;

namespace LibrarySystem.UI.Forms
{
    public partial class BookBrowsingForm : FormBaseAuthorizedRequired
    {
        IBookService service = new BookService();
        public override string FormTitle => "Book Browsing";
        public BookBrowsingForm() : base(CurrentUser)
        {
            InitializeComponent();
        }
        public BookBrowsingForm(UserViewDto user) : base(user)
        {
            InitializeComponent();
        }
        protected override void LoadFormData()
        {
            gvBooks.DataSource = service.GetAll();
            gvBooks.Columns[5].Visible = false;
            gvBooks.Columns[6].Visible = false;
            gvBooks.Columns[7].Visible = false;
        }

        private void gvBooks_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }
    }
}
