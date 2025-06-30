using LibrarySystem.BLL.DTOs;
using LibrarySystem.UI.Abstracts;
using LibrarySystem.UI.Forms;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.UI.FormTemplates
{
    public class MdiContainerFormBaseAuthorizedRequired : FormBaseAuthorizedRequired
    {
        private MenuStrip mainMenu;
        private readonly UserViewDto currentUser;
        // Optional interface for forms that need user context
        //public interface IUserContext
        //{
        //    void SetUser(UserViewDto user);
        //}
        public MdiContainerFormBaseAuthorizedRequired(UserViewDto user) : base(user)
        {
            SetCurentUser(user);
            InitializeContainer();
            CreateRoleBasedMenu();
        }

        private void InitializeContainer()
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Library Management System";

            // Main menu setup
            mainMenu = new MenuStrip
            {
                BackColor = Color.White,
                Renderer = new ProfessionalMenuRenderer()
            };
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;
        }

        protected void CreateRoleBasedMenu()
        {
            if (currentUser == null || currentUser.UID < 1)
            {
                return;
            }
            switch (currentUser.UserLevel)
            {
                case Domain.Enums.UserLevelEnum.Student:
                    CreateStudentMenu();
                    break;
                case Domain.Enums.UserLevelEnum.Staff:
                    CreateStaffMenu();
                    break;
                case Domain.Enums.UserLevelEnum.Manager:
                    CreateManagerMenu();
                    break;
            }
        }

        #region Student Menu
        private void CreateStudentMenu()
        {
            // Books Menu
            var booksMenu = new ToolStripMenuItem("📚 Books");
            booksMenu.DropDownItems.Add("🔍 Search Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            booksMenu.DropDownItems.Add("📌 Reserve Book", null, (s, e) => OpenForm<MenuOutlineForm>());

            // My Activity Menu
            var activityMenu = new ToolStripMenuItem("📖 My Activity");
            activityMenu.DropDownItems.Add("🕘 Borrowed Books History", null, (s, e) => OpenForm<MenuOutlineForm>());
            activityMenu.DropDownItems.Add("📌 Reserved Books", null, (s, e) => OpenForm<MenuOutlineForm>());

            // Profile Menu
            var profileMenu = new ToolStripMenuItem("🙍 Profile");
            profileMenu.DropDownItems.Add("✏️ Update Email/Phone", null, (s, e) => OpenForm<MenuOutlineForm>());
            profileMenu.DropDownItems.Add("🔑 Change Password", null, (s, e) => OpenForm<MenuOutlineForm>());

            mainMenu.Items.AddRange(new ToolStripItem[] { booksMenu, activityMenu, profileMenu });
        }
        #endregion

        #region Staff Menu
        private void CreateStaffMenu()
        {
            // Book Management Menu
            var bookMenu = new ToolStripMenuItem("📚 Book Management");
            bookMenu.DropDownItems.Add("➕ Add Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("📝 Update Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("❌ Delete Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add(new ToolStripSeparator());
            bookMenu.DropDownItems.Add("📂 Manage Categories", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("👨‍💼 Manage Authors", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("🌐 Manage Languages", null, (s, e) => OpenForm<MenuOutlineForm>());

            // Student Activity Menu
            var studentMenu = new ToolStripMenuItem("👥 Student Activity");
            studentMenu.DropDownItems.Add("🔍 Search Activities", null, (s, e) => OpenForm<MenuOutlineForm>());
            studentMenu.DropDownItems.Add("🧾 View Borrowed Books", null, (s, e) => OpenForm<MenuOutlineForm>());
            studentMenu.DropDownItems.Add("📌 View Reservations", null, (s, e) => OpenForm<MenuOutlineForm>());

            // Profile Menu
            var profileMenu = new ToolStripMenuItem("🙍 Profile");
            profileMenu.DropDownItems.Add("🔑 Change Password", null, (s, e) => OpenForm<MenuOutlineForm>());

            mainMenu.Items.AddRange(new ToolStripItem[] { bookMenu, studentMenu, profileMenu });
        }
        #endregion

        #region Manager Menu
        private void CreateManagerMenu()
        {
            // User Management Menu
            var userMenu = new ToolStripMenuItem("👥 User Management");
            userMenu.DropDownItems.Add("➕ Add User", null, (s, e) => OpenForm<MenuOutlineForm>());
            userMenu.DropDownItems.Add("📝 Update User Info", null, (s, e) => OpenForm<MenuOutlineForm>());
            userMenu.DropDownItems.Add("🔑 Reset Password", null, (s, e) => OpenForm<MenuOutlineForm>());

            // Book Management Menu (same as staff)
            var bookMenu = new ToolStripMenuItem("📚 Book Management");
            bookMenu.DropDownItems.Add("➕ Add Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("📝 Update Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("❌ Delete Book", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add(new ToolStripSeparator());
            bookMenu.DropDownItems.Add("📂 Manage Categories", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("👨‍💼 Manage Authors", null, (s, e) => OpenForm<MenuOutlineForm>());
            bookMenu.DropDownItems.Add("🌐 Manage Languages", null, (s, e) => OpenForm<MenuOutlineForm>());

            // Reports Menu
            var reportsMenu = new ToolStripMenuItem("📊 Reports");
            reportsMenu.DropDownItems.Add("📈 Most Borrowed Books", null, (s, e) => OpenForm<MenuOutlineForm>());
            reportsMenu.DropDownItems.Add("⏰ Overdue Books", null, (s, e) => OpenForm<MenuOutlineForm>());
            reportsMenu.DropDownItems.Add("📚 Borrowings by Category", null, (s, e) => OpenForm<MenuOutlineForm>());

            // Profile Menu
            var profileMenu = new ToolStripMenuItem("🙍 Profile");
            profileMenu.DropDownItems.Add("🔑 Change Password", null, (s, e) => OpenForm<MenuOutlineForm>());

            mainMenu.Items.AddRange(new ToolStripItem[] { userMenu, bookMenu, reportsMenu, profileMenu });
        }
        #endregion

        #region Form Management
        private void OpenForm<T>() where T : Form, new()
        {
            // Check if form already exists
            var existingForm = this.MdiChildren.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                return;
            }

            // Create new instance
            var form = new T
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized,
            };

            // Set user context if form supports it
            //if (form is IUserContext userForm)
            //{
            //    userForm.SetUser(currentUser);
            //}
            //if (form is FormBase formBase)
            //{
            //    formBase.SetCurentUser(currentUser);
            //}

            form.Show();
        }
        #endregion

        #region Menu Renderer
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
        #endregion
    }
}
