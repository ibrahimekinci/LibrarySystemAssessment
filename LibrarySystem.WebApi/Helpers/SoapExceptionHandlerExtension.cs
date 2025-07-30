using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Services;
using LibrarySystem.WebApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;

namespace LibrarySystem.WebApi.Helpers
{
    // SoapExtension to intercept and handle SOAP message processing, ensuring exceptions are returned as SoapServiceResult<T>.
    public class SoapExceptionHandlerExtension : SoapExtension
    {
        // Stores the current SOAP message being processed.
        private SoapMessage _message;

        // Lazy-initialized logging service for recording exceptions.
        private ILogService _logService;

        // Property to access the logging service, initializing it if null.
        protected ILogService LogService
        {
            get
            {
                if (_logService == null)
                {
                    _logService = new LogService();
                }
                return _logService;
            }
        }
        // Required by SoapExtension; returns null as no initializer is needed for the service type.
        public override object GetInitializer(Type serviceType) => null;

        // Required by SoapExtension; returns null as no initializer is needed for the method.
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) => null;

        // Required by SoapExtension; no initialization logic needed.
        public override void Initialize(object initializer) { }

        // Processes the SOAP message at different stages of serialization/deserialization.
        public override void ProcessMessage(SoapMessage message)
        {
            _message = message;

            // Handle different stages of SOAP message processing.
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    // Check for exceptions before serialization and handle them.
                    if (message.Exception != null)
                    {
                        HandleException(message);
                    }
                    break;
            }
        }

        // Handles exceptions during SOAP message processing.
        // Creates a SoapServiceResult<T> with the correct generic type to match the method's return type.
        private void HandleException(SoapMessage message)
        {
            // Exit if no exception exists.
            if (message.Exception == null)
                return;

            LogService.LogException(message.Exception);
            var userMsg = LogService.GetUserFriendlyMessage(message.Exception);
            var faultCode = SoapException.ServerFaultCode;
            var detail = CreateSoapDetailElement(userMsg);
            var soapEx = new SoapException(userMsg, faultCode, message.Url, detail);
            message.Exception = soapEx;
        }
        private XmlNode CreateSoapDetailElement(string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement detailNode = doc.CreateElement("Detail");
            XmlElement msgElement = doc.CreateElement("Message");
            msgElement.InnerText = message;
            detailNode.AppendChild(msgElement);
            return detailNode;
        }
    }
}