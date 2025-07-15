using LibrarySystem.Domain.Enums;
using LibrarySystem.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            CreateRoleBasedMenu();
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

        protected void CreateRoleBasedMenu()
        {
            menuStrip.BackColor = Color.White;
            menuStrip.Dock = DockStyle.Top;
            menuStrip.GripStyle = ToolStripGripStyle.Hidden;
            menuStrip.Renderer = new ProfessionalMenuRenderer();
            this.MainMenuStrip = menuStrip;

            if (!UserManager.IsUserLoggedIn())
                return;

            switch (UserManager.CurrentUser.UserLevel)
            {
                case UserLevelEnum.Student:
                    CreateStudentMenu();
                    break;
                case UserLevelEnum.Staff:
                    CreateStaffMenu();
                    break;
                case UserLevelEnum.Manager:
                    CreateManagerMenu();
                    break;
            }
        }

        private void CreateStudentMenu()
        {

        }

        private void CreateStaffMenu()
        {

        }

        private void CreateManagerMenu()
        {
            // Books Menu
            var booksMenu = new ToolStripMenuItem("📚 Books");
            booksMenu.DropDownItems.Add("🔍 Search Book", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            booksMenu.DropDownItems.Add("📌 Reserve Book", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // My Activity Menu
            var activityMenu = new ToolStripMenuItem("📖 My Activity");
            activityMenu.DropDownItems.Add("🕘 Borrowed Books History", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            activityMenu.DropDownItems.Add("📌 Reserved Books", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // User Management Menu
            var userMenu = new ToolStripMenuItem("👥 User Management");
            userMenu.DropDownItems.Add("➕ Add User", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            userMenu.DropDownItems.Add("📝 Update User Info", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            userMenu.DropDownItems.Add("🔑 Reset Password", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // Book Management Menu (same as staff)
            var bookMenu = new ToolStripMenuItem("📚 Book Management");
            bookMenu.DropDownItems.Add("➕ Add Book", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            bookMenu.DropDownItems.Add("📝 Update Book", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            bookMenu.DropDownItems.Add("❌ Delete Book", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            bookMenu.DropDownItems.Add(new ToolStripSeparator());
            bookMenu.DropDownItems.Add("📂 Manage Categories", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            bookMenu.DropDownItems.Add("👨‍💼 Manage Authors", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            bookMenu.DropDownItems.Add("🌐 Manage Languages", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // Student Activity Menu
            var studentMenu = new ToolStripMenuItem("👥 Activity");
            studentMenu.DropDownItems.Add("🧾 View Borrowed Books", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            studentMenu.DropDownItems.Add("📌 View Reservations", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // Reports Menu
            var reportsMenu = new ToolStripMenuItem("📊 Reports");
            reportsMenu.DropDownItems.Add("📈 Most Borrowed Books", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            reportsMenu.DropDownItems.Add("⏰ Overdue Books", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            reportsMenu.DropDownItems.Add("📚 Borrowings by Category", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // Profile Menu
            var profileMenu = new ToolStripMenuItem("🙍 Profile");
            profileMenu.DropDownItems.Add("✏️ Update Email/Phone", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());
            profileMenu.DropDownItems.Add("🔑 Change Password", null, (s, e) => FormManager.ShowFormInMdi<DashboardForm>());

            // Windows
            var windowsMenu = new ToolStripMenuItem("👥 Windows");
            windowsMenu.DropDownItems.Add("🪟 Cascade", null, (s, e) => LayoutMdi(MdiLayout.Cascade));
            windowsMenu.DropDownItems.Add("📏 Tile Vertical", null, (s, e) => LayoutMdi(MdiLayout.TileVertical));
            windowsMenu.DropDownItems.Add("📐 Tile Horizontal", null, (s, e) => LayoutMdi(MdiLayout.TileHorizontal));
            windowsMenu.DropDownItems.Add("❌ Close All", null, (s, e) =>
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                }
            });

            var closeAppMenu = new ToolStripMenuItem("❌ Close", null, (s, e) => this.Close());
            menuStrip.Items.AddRange(new ToolStripItem[] { booksMenu, activityMenu, userMenu, bookMenu, studentMenu, reportsMenu, profileMenu, windowsMenu, closeAppMenu });
        }
        #endregion
    }
}
