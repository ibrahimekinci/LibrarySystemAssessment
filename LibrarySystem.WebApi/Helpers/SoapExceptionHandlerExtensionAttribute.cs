using System;
using System.Web.Services.Protocols;

namespace LibrarySystem.WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SoapExceptionHandlerExtensionAttribute : SoapExtensionAttribute
    {
        public override Type ExtensionType => typeof(SoapExceptionHandlerExtension);
        public override int Priority { get; set; } = 1;
    }
}