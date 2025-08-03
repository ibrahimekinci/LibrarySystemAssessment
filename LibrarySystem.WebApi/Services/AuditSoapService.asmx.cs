using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.BLL.Services;
using LibrarySystem.WebApi.Helpers;
using LibrarySystem.WebApi.Models;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for AuditSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuditSoapService : BaseService
    {

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<bool> Log(AuditActionType actionType, int userId, string details)
        {
            var response = Response<bool>.Fail();

            try
            {
                AuditLogService.Log(actionType, userId, details);
                response.SetSuccess(true, "Audit log recorded successfully.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    // Set user-friendly message
                    response.SetFailure(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
            return response;
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<bool> LogWithDto(AuditLogDto log)
        {
            try
            {
                string errorMessage = log.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<bool>.Fail(errorMessage);

                AuditLogService.Log(log);
                return Response<bool>.Ok(true, "Audit log recorded successfully.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<bool>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
