using LibrarySystem.App.Forms.Abstracts;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.App.Forms.Report
{
    public partial class ReportDataForm : BaseForm
    {
        private readonly string _formTitle = "Report";
        public override string FormTitle => _formTitle;
        private static readonly IReadOnlyList<UserLevelEnum> allowedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager
        };
        protected override IReadOnlyList<UserLevelEnum> AllowedUserLevels => allowedUserLevels;
        private readonly List<OperationType> _reportTypes = new List<OperationType>() {
            OperationType.GetReportBorrowedBooksByCategory,
            OperationType.GetReportMostBorrowedBooks,
            OperationType.GetReportOverdueBooks };
        public ReportDataForm(OperationType operationType)
        {
            if (!_reportTypes.Contains(operationType))
                throw new ArgumentException("Invalid operation type for ReportDataForm", nameof(operationType));

            InitializeComponent();

            if (!AuthorizetionCheck())
                return;


            if (operationType == OperationType.GetReportBorrowedBooksByCategory)
            {

                _formTitle = lnkTitle.Text = "Borrowed Books By Category Report";
                btn.Click += btnBorrowedBooksByCategory_Click;
                btnBorrowedBooksByCategory_Click(btn, EventArgs.Empty);
            }
            else if (operationType == OperationType.GetReportMostBorrowedBooks)
            {
                _formTitle = lnkTitle.Text = "Most Borrowed Books Report";
                btn.Click += btnMostBorrowedBooks_Click;
                btnMostBorrowedBooks_Click(btn, EventArgs.Empty);
            }
            else if (operationType == OperationType.GetReportOverdueBooks)
            {
                _formTitle = lnkTitle.Text = "Overdue Books Report";
                btn.Click += btnOverdueBooks_Click;
                btnOverdueBooks_Click(btn, EventArgs.Empty);
            }
        }
        private void btnBorrowedBooksByCategory_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetBorrowedBooksByCategory();
            RefreshDgv(result);
        }
        private void btnMostBorrowedBooks_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetMostBorrowedBooks();
            RefreshDgv(result);
        }
        private void btnOverdueBooks_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetOverdueBooks();
            RefreshDgv(result);
        }
        private void RefreshDgv(DataTable result)
        {
            dgv.Width = this.Width - 40;
            dgv.Columns.Clear();
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
