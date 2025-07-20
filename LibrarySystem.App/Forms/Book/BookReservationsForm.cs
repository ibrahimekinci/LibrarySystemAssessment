using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.App.Helpers;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LibrarySystem.App.Forms.Book
{
    public partial class BookReservationsForm : BaseForm
    {
        private readonly string _formTitle = "Book Reservations";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private Action RefreshDgv;
        public BookReservationsForm(OperationType operationType)
        {
            InitializeComponent();
            if (operationType == OperationType.ViewAllReservations)
            {
                if (!UserManager.IsloggedInAsManager() && !UserManager.IsloggedInAsStaff())
                    RiderectToUnauthorizedPage();
                RefreshDgv = AdminDgvRefresh;
                _formTitle = "All Book Reservations";
            }
            else if (operationType == OperationType.ViewMyReservations)
            {
                RefreshDgv = UserDgvRefresh;
                _formTitle = "My Book Reservations";
            }
            else
            {
                throw new ArgumentException("Invalid operation type for BookLoanForm", nameof(operationType));

            }
        }
        protected override void LoadFormData()
        {
            lnkTitle.Text = FormTitle;
            RefreshDgv();
        }
        private void AdminDgvRefresh()
        {
            dgv.Width = this.Width - 40;
            dgv.Columns.Clear();
            var result = BookReservationService.GetAll();
            if (result == null || result.Rows.Count == 0)
            {
                dgv.DataSource = null;
                lblMessage.Visible = true;
            }
            else
            {
                dgv.DataSource = result;
                lblMessage.Visible = false;
            }
        }
        private void UserDgvRefresh()
        {
            dgv.Width = this.Width - 40;
            dgv.Columns.Clear();
            var result = BookReservationService.GetAllByUserId(UserManager.CurrentUser.UID);
            if (result == null || result.Rows.Count == 0)
            {
                dgv.DataSource = null;
                lblMessage.Visible = true;
            }
            else
            {
                dgv.DataSource = result;
                lblMessage.Visible = false;
            }
        }
    }
}
