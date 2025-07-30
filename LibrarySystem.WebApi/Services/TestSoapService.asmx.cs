using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.WebApi.Abstracts;
using System.Linq;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for TestSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TestSoapService : BaseSoapService
    {

        [WebMethod]
        public string SoapServiceHealthCheck()
        {
            return "The soapService is healty and running.";
        }

        [WebMethod]
        public string TestDatabaseHealthCheck()
        {
            var authors = AuthorService.GetAll();
            return "Database is healty and running.";
        }

        [WebMethod]
        public string TestBadRequestException()
        {
            throw new BadRequestException();
        }

        [WebMethod]
        public string TestConflictException()
        {
            throw new ConflictException();
        }

        [WebMethod]
        public string TestCustomException()
        {
            throw new CustomException();
        }

        [WebMethod]
        public string TestExternalServiceException()
        {
            throw new ExternalServiceException();
        }

        [WebMethod]
        public string TestForbiddenException()
        {
            throw new ForbiddenException();
        }

        [WebMethod]
        public string TestInternalServerErrorException()
        {
            throw new InternalServerErrorException();
        }

        [WebMethod]
        public string TestMethodNotAllowedException()
        {
            throw new MethodNotAllowedException();
        }

        [WebMethod]
        public string TestNotFoundException()
        {
            throw new NotFoundException();
        }

        [WebMethod]
        public string TestResourceAlreadyExistsException()
        {
            throw new ResourceAlreadyExistsException();
        }

        [WebMethod]
        public string TestUnauthorizedException()
        {
            throw new UnauthorizedException();
        }

        [WebMethod]
        public string TestUnprocessableEntityException()
        {
            throw new UnprocessableEntityException();
        }

        [WebMethod]
        public string TestValidationException()
        {
            throw new ValidationException();
        }
    }
}
