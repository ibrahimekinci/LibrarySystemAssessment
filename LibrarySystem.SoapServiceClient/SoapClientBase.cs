using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace LibrarySystem.SoapServiceClient
{
    public abstract class SoapClientBase<T> : ClientBase<T> where T : class
    {
        protected static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"] ?? "http://localhost:5000/";

        protected static BasicHttpBinding CreateBinding()
        {
            return new BasicHttpBinding
            {
                MaxReceivedMessageSize = 2147483647,
                MaxBufferSize = 2147483647
            };
        }

        protected static MessageHeader CreateTokenHeader(string token)
        {
            return MessageHeader.CreateHeader("Token", "http://tempuri.org/", token);
        }

        protected SoapClientBase(string endpointUrl, string token) : base(CreateBinding(), new EndpointAddress(endpointUrl))
        {
            if (!string.IsNullOrEmpty(token))
            {
                using (var scope = new OperationContextScope(InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageHeaders.Add(CreateTokenHeader(token));
                }
            }
        }
    }
}