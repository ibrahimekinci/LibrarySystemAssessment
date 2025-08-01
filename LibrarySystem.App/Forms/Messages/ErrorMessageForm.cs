using LibrarySystem.App.Forms.Abstracts;

namespace LibrarySystem.App.Forms.Messages
{
    public partial class ErrorMessageForm : BaseForm
    {
        public override string FormTitle => "Library System - UnAuthorized Page";
        protected override bool IsLoggedInRequired() => false;
        public ErrorMessageForm()
        {
            InitializeComponent();
        }
    }
}
