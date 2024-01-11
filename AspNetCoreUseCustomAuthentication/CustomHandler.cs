using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AspNetCoreUseCustomAuthentication
{
    public class CustomHandler: AuthenticationHandler<CustomOptions>
    {
        public CustomHandler(IOptionsMonitor<CustomOptions> options, ILoggerFactory logger, UrlEncoder encoder)
            : base(options, logger, encoder)
        { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            await Console.Out.WriteLineAsync("开始验证");

            base.Logger.LogInformation(JsonConvert.SerializeObject(base.Options));

            // 验证通过后
            var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "bidianqing"),
                new Claim("gender", "男"),
            }, "Custom"));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(principal), "Custom");

            return AuthenticateResult.Success(ticket);
        }
    }
}
