using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace AspNetCoreUseCustomAuthentication
{
    public static class CustomExtensions
    {
        public static AuthenticationBuilder AddCustom(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<CustomOptions> configureOptions)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<CustomOptions>, CustomPostConfigureOptions>());
            return builder.AddScheme<CustomOptions, CustomHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
