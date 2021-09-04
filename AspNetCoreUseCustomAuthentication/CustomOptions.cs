using Microsoft.AspNetCore.Authentication;

namespace AspNetCoreUseCustomAuthentication
{
    public class CustomOptions : AuthenticationSchemeOptions
    {
        public string CustomProperty { get; set; }
    }
}
