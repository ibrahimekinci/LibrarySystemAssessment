using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Enums;
using System.Collections.Generic;

namespace LibrarySystem.UI.Forms
{
    public partial class BookBrowsingForm : FormBase
    {
        private IBookService service = new BookService();
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
