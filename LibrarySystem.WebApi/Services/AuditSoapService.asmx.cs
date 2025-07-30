using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Enums;
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
        public SoapServiceResult<bool> Log(AuditActionType actionType, int userId, string details)
        {
            var response = SoapServiceResult<bool>.Fail();

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
        public SoapServiceResult<bool> LogWithDto(AuditLogDto log)
        {
            try
            {
                string errorMessage = log.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<bool>.Fail(errorMessage);

                AuditLogService.Log(log);
                return SoapServiceResult<bool>.Ok(true, "Audit log recorded successfully.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<bool>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
