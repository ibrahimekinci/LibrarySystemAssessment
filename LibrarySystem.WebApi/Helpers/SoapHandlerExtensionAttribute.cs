using System;
using System.Web.Services.Protocols;

namespace LibrarySystem.WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SoapHandlerExtensionAttribute : SoapExtensionAttribute
    {
        public override Type ExtensionType => typeof(SoapHandlerExtension);
        public override int Priority { get; set; } = 1;
    }
}