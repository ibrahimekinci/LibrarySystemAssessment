using LibrarySystem.App.Forms.Author;
using LibrarySystem.App.Forms.Book;
using LibrarySystem.App.Forms.BookManage;
using LibrarySystem.App.Forms.Category;
using LibrarySystem.App.Forms.Dashboards;
using LibrarySystem.App.Forms.Language;
using LibrarySystem.App.Forms.Report;
using LibrarySystem.App.Forms.User;
using LibrarySystem.App.Helpers;
using LibrarySystem.Domain.Enums;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Abstracts
{
    public partial class MainMdiForm : BaseForm
    {
        public override string FormTitle => "Library System";
        private static readonly IReadOnlyList<UserLevelEnum> authorizedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => authorizedUserLevels;
        protected override void InitializeUIAdditional()
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = true;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
        }
        public MainMdiForm()
        {
            InitializeComponent();
            InitializeMenu();
            RiderectToDashboard();
        }
        protected override void RiderectToDashboard()
        {
            if (!UserManager.IsUserLoggedIn())
            {
                RiderectToLoginPage();
                return;
            }

            if (UserManager.IsloggedInAsManager())
                FormManager.ShowFormInMdi<BookLoanForm>(this, OperationType.ViewAllBookLoans);
            else if (UserManager.IsloggedInAsStaff())
                FormManager.ShowFormInMdi<BookLoanForm>(this, OperationType.ViewAllBookLoans);
            else if (UserManager.IsloggedInAsStudent())
                FormManager.ShowFormInMdi<StudentDashboardForm>(this);
        }
        #region Menu
        private class ProfessionalMenuRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)),
                                          e.Item.ContentRectangle);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        public void InitializeMenu()
        {
            menuStrip.BackColor = Color.White;
            menuStrip.Dock = DockStyle.Top;
            menuStrip.GripStyle = ToolStripGripStyle.Hidden;
            menuStrip.Renderer = new ProfessionalMenuRenderer();
            this.MainMenuStrip = menuStrip;

            if (!UserManager.IsUserLoggedIn())
                return;

            var currentUserRole = UserManager.CurrentUser.UserLevel;

            //// 📚 BOOKS – Shared by All Users
            var booksMenu = new ToolStripMenuItem("📚 Books");
            booksMenu.DropDownItems.Add("🔍 Search Books", null, (s, e) => FormManager.ShowFormInMdi<BookSearchForm>());
            booksMenu.DropDownItems.Add("📚 Browse Books", null, (s, e) => FormManager.ShowFormInMdi<BookBrowsingForm>());
            booksMenu.DropDownItems.Add("📌 Reserve a Book", null, (s, e) => FormManager.ShowFormInMdi<BookReserveForm>());
            booksMenu.DropDownItems.Add("📤 Borrow a Book", null, (s, e) => FormManager.ShowFormInMdi<BookBarrowForm>());
            booksMenu.DropDownItems.Add("📥 Return a Book", null, (s, e) => FormManager.ShowFormInMdi<BookReturnForm>());
            menuStrip.Items.Add(booksMenu);

            //// 📖 MY ACTIVITY – Shared by All Users
            var myActivityMenu = new ToolStripMenuItem("📖 My Activity");
            myActivityMenu.DropDownItems.Add("📚 My Book loans", null, (s, e) => FormManager.ShowFormInMdi<BookLoanForm>(OperationType.ViewMyBookLoans));
            myActivityMenu.DropDownItems.Add("📌 My Reservations", null, (s, e) => FormManager.ShowFormInMdi<BookReservationsForm>(OperationType.ViewMyReservations));
            menuStrip.Items.Add(myActivityMenu);

            //// 📖 Student ACTIVITY – For Staff and Manager
            if (UserManager.IsloggedInAsStaff() || UserManager.IsloggedInAsManager())
            {
                var StudentActivityMenu = new ToolStripMenuItem("📖 Student Activity");
                StudentActivityMenu.DropDownItems.Add("📚 Student Book Loans", null, (s, e) => FormManager.ShowFormInMdi<BookLoanForm>(OperationType.ViewAllBookLoans));
                StudentActivityMenu.DropDownItems.Add("📌 Student Reservations", null, (s, e) => FormManager.ShowFormInMdi<BookReservationsForm>(OperationType.ViewAllReservations));
                menuStrip.Items.Add(StudentActivityMenu);
            }

            //// 🛠️ ADMIN – For Staff and Manager
            if (UserManager.IsloggedInAsStaff() || UserManager.IsloggedInAsManager())
            {
                var adminMenu = new ToolStripMenuItem("🛠️ Admin");
                adminMenu.DropDownItems.Add("👥 Manage Users", null, (s, e) => FormManager.ShowFormInMdi<UserForm>());
                adminMenu.DropDownItems.Add("📘 Manage Books", null, (s, e) => FormManager.ShowFormInMdi<BookForm>());
                adminMenu.DropDownItems.Add("🏷️ Manage Categories", null, (s, e) => FormManager.ShowFormInMdi<CategoryForm>());
                adminMenu.DropDownItems.Add("👨‍💼 Manage Authors", null, (s, e) => FormManager.ShowFormInMdi<AuthorForm>());
                adminMenu.DropDownItems.Add("🌐 Manage Languages", null, (s, e) => FormManager.ShowFormInMdi<LanguageForm>());
                menuStrip.Items.Add(adminMenu);
            }

            //// 📊 REPORTS  – For Staff and Manager
            if (UserManager.IsloggedInAsStaff() || UserManager.IsloggedInAsManager())
            {
                var reportsMenu = new ToolStripMenuItem("📊 Reports");
                reportsMenu.DropDownItems.Add("📈 Most Borrowed Books", null, (s, e) => FormManager.ShowFormInMdi<ReportDataForm>(OperationType.GetReportMostBorrowedBooks));
                reportsMenu.DropDownItems.Add("⏰ Overdue Books", null, (s, e) => FormManager.ShowFormInMdi<ReportDataForm>(OperationType.GetReportOverdueBooks));
                reportsMenu.DropDownItems.Add("📚 Borrowings by Category", null, (s, e) => FormManager.ShowFormInMdi<ReportDataForm>(OperationType.GetReportBorrowedBooksByCategory));
                menuStrip.Items.Add(reportsMenu);
            }

            //// ⚙️ PROFILE – Shared by All Users
            var profileMenu = new ToolStripMenuItem("⚙️ Profile");
            profileMenu.DropDownItems.Add("✏️ Update My Info", null, (s, e) => FormManager.ShowFormInMdi<UserManageForm>(OperationType.ProfileUpdate));
            menuStrip.Items.Add(profileMenu);

            // 🪟 WINDOWS – Shared by All Users
            var windowsMenu = new ToolStripMenuItem("🪟 Windows");
            windowsMenu.DropDownItems.Add("🪟 Cascade", null, (s, e) => LayoutMdi(MdiLayout.Cascade));
            windowsMenu.DropDownItems.Add("📏 Tile Vertical", null, (s, e) => LayoutMdi(MdiLayout.TileVertical));
            windowsMenu.DropDownItems.Add("📐 Tile Horizontal", null, (s, e) => LayoutMdi(MdiLayout.TileHorizontal));
            windowsMenu.DropDownItems.Add("❌ Close All Windows", null, (s, e) =>
            {
                foreach (Form childForm in this.MdiChildren)
                    childForm.Close();

            });
            menuStrip.Items.Add(windowsMenu);

            // 🔚 EXIT – Shared by All Users
            var exitMenu = new ToolStripMenuItem("🔚 Exit", null, (s, e) => System.Windows.Forms.Application.Exit());
            menuStrip.Items.Add(exitMenu);

            // Assign to Form
            this.MainMenuStrip = menuStrip;
        }
        #endregion
    }
}
