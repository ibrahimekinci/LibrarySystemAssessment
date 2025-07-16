using LibrarySystem.Domain.Enums;
using LibrarySystem.UI.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class MainMdiForm : FormBase
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
            this.ShowIcon = true;
        }
        public MainMdiForm()
        {
            InitializeComponent();
            InitializeMenu();
            FormManager.ShowFormInMdi<DashboardForm>(this);
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

            //// 📚 BOOKS – Everyone
            //var booksMenu = new ToolStripMenuItem("📚 Books");
            //booksMenu.DropDownItems.Add("🔍 Search Books", null, (s, e) => FormManager.ShowFormInMdi<SearchBooksForm>());
            //booksMenu.DropDownItems.Add("📌 Reserve a Book", null, (s, e) => FormManager.ShowFormInMdi<ReserveBookForm>());
            //booksMenu.DropDownItems.Add("📤 Borrow a Book", null, (s, e) => FormManager.ShowFormInMdi<BorrowBookForm>());
            //booksMenu.DropDownItems.Add("📥 Return a Book", null, (s, e) => FormManager.ShowFormInMdi<ReturnBookForm>());
            //menuStrip.Items.Add(booksMenu);

            //// 📖 MY ACTIVITY – Everyone
            //var myActivityMenu = new ToolStripMenuItem("📖 My Activity");
            //myActivityMenu.DropDownItems.Add("📚 My Borrowed Books", null, (s, e) => FormManager.ShowFormInMdi<BorrowedHistoryForm>());
            //myActivityMenu.DropDownItems.Add("📌 My Reservations", null, (s, e) => FormManager.ShowFormInMdi<ReservedBooksForm>());
            //menuStrip.Items.Add(myActivityMenu);

            //// 📖 Student ACTIVITY – For Staff and Manager
            //if (currentUserRole == UserLevelEnum.Staff || currentUserRole == UserLevelEnum.Manager)
            //{
            //    var StudentActivityMenu = new ToolStripMenuItem("📖 Student Activity");
            //    StudentActivityMenu.DropDownItems.Add("📚 Student Borrowed Books", null, (s, e) => FormManager.ShowFormInMdi<BorrowedHistoryForm>());
            //    StudentActivityMenu.DropDownItems.Add("📌 Student Reservations", null, (s, e) => FormManager.ShowFormInMdi<ReservedBooksForm>());
            //    menuStrip.Items.Add(StudentActivityMenu);
            //}

            //// 🛠️ ADMIN – For Staff and Manager
            //if (currentUserRole == UserLevelEnum.Staff || currentUserRole == UserLevelEnum.Manager)
            //{
            //    var adminMenu = new ToolStripMenuItem("🛠️ Admin");
            //    adminMenu.DropDownItems.Add("👥 Manage Users", null, (s, e) => FormManager.ShowFormInMdi<ManageUsersForm>());
            //    adminMenu.DropDownItems.Add("📘 Manage Books", null, (s, e) => FormManager.ShowFormInMdi<ManageBooksForm>());
            //    adminMenu.DropDownItems.Add("🏷️ Manage Categories", null, (s, e) => FormManager.ShowFormInMdi<ManageCategoriesForm>());
            //    adminMenu.DropDownItems.Add("👨‍💼 Manage Authors", null, (s, e) => FormManager.ShowFormInMdi<ManageAuthorsForm>());
            //    adminMenu.DropDownItems.Add("🌐 Manage Languages", null, (s, e) => FormManager.ShowFormInMdi<ManageLanguagesForm>());
            //    menuStrip.Items.Add(adminMenu);
            //}

            //// 🛠️ ADMIN – For Staff and Manager
            //if (currentUserRole == UserLevelEnum.Staff || currentUserRole == UserLevelEnum.Manager)
            //{
            //    var manageUsersMenu = new ToolStripMenuItem("👥 Manage Users");
            //    manageUsersMenu.DropDownItems.Add("➕ Add User", null, (s, e) => FormManager.ShowFormInMdi<AddUserForm>());
            //    manageUsersMenu.DropDownItems.Add("📝 Update User", null, (s, e) => FormManager.ShowFormInMdi<UpdateUserForm>());
            //    manageUsersMenu.DropDownItems.Add("❌ Delete User", null, (s, e) => FormManager.ShowFormInMdi<DeleteUserForm>());
            //    manageUsersMenu.DropDownItems.Add("🔑 Reset Password", null, (s, e) => FormManager.ShowFormInMdi<ResetPasswordForm>());
            //    menuStrip.Items.Add(manageUsersMenu);

            //    var manageBooksMenu = new ToolStripMenuItem("📘 Manage Books");
            //    manageBooksMenu.DropDownItems.Add("➕ Add Book", null, (s, e) => FormManager.ShowFormInMdi<AddBookForm>());
            //    manageBooksMenu.DropDownItems.Add("📝 Update Book", null, (s, e) => FormManager.ShowFormInMdi<UpdateBookForm>());
            //    manageBooksMenu.DropDownItems.Add("❌ Delete Book", null, (s, e) => FormManager.ShowFormInMdi<DeleteBookForm>());
            //    menuStrip.Items.Add(manageBooksMenu);

            //    var manageCategoriesMenu = new ToolStripMenuItem("🏷️ Manage Categories");
            //    manageCategoriesMenu.DropDownItems.Add("➕ Add Category", null, (s, e) => FormManager.ShowFormInMdi<AddCategoryForm>());
            //    manageCategoriesMenu.DropDownItems.Add("📝 Update Category", null, (s, e) => FormManager.ShowFormInMdi<UpdateCategoryForm>());
            //    manageCategoriesMenu.DropDownItems.Add("❌ Delete Category", null, (s, e) => FormManager.ShowFormInMdi<DeleteCategoryForm>());
            //    menuStrip.Items.Add(manageCategoriesMenu);

            //    var manageAuthorsMenu = new ToolStripMenuItem("👨‍💼 Manage Authors");
            //    manageAuthorsMenu.DropDownItems.Add("➕ Add Author", null, (s, e) => FormManager.ShowFormInMdi<AddAuthorForm>());
            //    manageAuthorsMenu.DropDownItems.Add("📝 Update Author", null, (s, e) => FormManager.ShowFormInMdi<UpdateAuthorForm>());
            //    manageAuthorsMenu.DropDownItems.Add("❌ Delete Author", null, (s, e) => FormManager.ShowFormInMdi<DeleteAuthorForm>());
            //    menuStrip.Items.Add(manageAuthorsMenu);

            //    var manageLanguagesMenu = new ToolStripMenuItem("🌐 Manage Languages");
            //    manageLanguagesMenu.DropDownItems.Add("➕ Add Language", null, (s, e) => FormManager.ShowFormInMdi<AddLanguageForm>());
            //    manageLanguagesMenu.DropDownItems.Add("📝 Update Language", null, (s, e) => FormManager.ShowFormInMdi<UpdateLanguageForm>());
            //    manageLanguagesMenu.DropDownItems.Add("❌ Delete Language", null, (s, e) => FormManager.ShowFormInMdi<DeleteLanguageForm>());
            //    menuStrip.Items.Add(manageLanguagesMenu);
            //}

            //// 📊 REPORTS – Only for Manager
            //if (currentUserRole == UserLevelEnum.Manager)
            //{
            //    var reportsMenu = new ToolStripMenuItem("📊 Reports");
            //    reportsMenu.DropDownItems.Add("📈 Most Borrowed Books", null, (s, e) => FormManager.ShowFormInMdi<ReportMostBorrowedBooksForm>());
            //    reportsMenu.DropDownItems.Add("⏰ Overdue Books", null, (s, e) => FormManager.ShowFormInMdi<ReportOverdueBooksForm>());
            //    reportsMenu.DropDownItems.Add("📚 Borrowings by Category", null, (s, e) => FormManager.ShowFormInMdi<ReportByCategoryForm>());
            //    menuStrip.Items.Add(reportsMenu);
            //}

            //// ⚙️ PROFILE – Shared by All Users
            //var profileMenu = new ToolStripMenuItem("⚙️ Profile");
            //profileMenu.DropDownItems.Add("✏️ Update My Info", null, (s, e) => FormManager.ShowFormInMdi<UpdateProfileForm>());
            //profileMenu.DropDownItems.Add("🔒 Change Password", null, (s, e) => FormManager.ShowFormInMdi<ChangePasswordForm>());
            //menuStrip.Items.Add(profileMenu);

            // 🪟 WINDOWS – Always
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

            // 🔚 EXIT – Always
            var exitMenu = new ToolStripMenuItem("🔚 Exit", null, (s, e) => this.Close());
            menuStrip.Items.Add(exitMenu);

            // Assign to Form
            this.MainMenuStrip = menuStrip;
        }
        #endregion
    }
}
