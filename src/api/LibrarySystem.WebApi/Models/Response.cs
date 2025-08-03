using System.Web;

namespace LibrarySystem.WebApi.Models
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        //public string RefreshToken { get; set; }
        public void SetSuccess(T data, string message = null)
        {
            Success = true;
            Message = string.IsNullOrEmpty(message) ? "Operation completed successfully." : message;
            Data = data;
            //RefreshToken = HttpContext.Current.Items["AuthToken"] as string;
        }

        public void SetFailure(string message = null)
        {
            Success = false;
            Message = string.IsNullOrEmpty(message) ? "Operation failed. Please try again or contact support if the issue persists." : message;
        }
        public static Response<T> Ok(T data, string msg = null)
        {
            var ok = new Response<T>();
            ok.SetSuccess(data, msg);
            return ok;
        }
        public static Response<T> Fail(string msg = null)
        {
            var failure = new Response<T>();
            failure.SetFailure(msg);
            return failure;
        }
    }

}