using Microsoft.Extensions.Options;
using System;

namespace AspNetCoreUseCustomAuthentication
{
    public class CustomPostConfigureOptions : IPostConfigureOptions<CustomOptions>
    {
        public void PostConfigure(string name, CustomOptions options)
        {
            Console.WriteLine("name=" + name);

            // 覆盖Startup里的配置，可以对CustomOptions的属性赋值
            options.CustomProperty = "456";
        }
    }
}
