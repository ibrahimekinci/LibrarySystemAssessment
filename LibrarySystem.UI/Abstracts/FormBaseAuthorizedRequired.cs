using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using LibrarySystem.UI.Forms;
using System.Collections.Generic;

namespace LibrarySystem.UI.Abstracts
{
    public partial class FormBaseAuthorizedRequired : FormBase
    {
        private List<UserLevelEnum> authorizedUserLevels = new List<UserLevelEnum>
        {
            UserLevelEnum.Manager
        };
        protected virtual List<UserLevelEnum> AuthorizedUserLevels => authorizedUserLevels;
        public FormBaseAuthorizedRequired()
        {

        }
        public FormBaseAuthorizedRequired(UserViewDto user)
        {
            SetCurentUser(user);

            if (CurrentUser == null ||
                CurrentUser.UID < 1 ||
                AuthorizedUserLevels == null ||
                AuthorizedUserLevels.Count == 0)
            {
                ShowForm<LoginForm>();
                Hide();
            }

            if (
                 AuthorizedUserLevels == null ||
                 AuthorizedUserLevels.Count == 0)
            {
                ShowForm<UnauthorizedWarningForm>();
                Hide();
            }
        }
    }
}
