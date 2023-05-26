using BookingService.Application.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace BookingService.Application.Providers.TokenAuthProvider
{
    public class TokenAuthHandler : AuthenticationHandler<TokenAuthSchemeOptions>
    {
        public TokenAuthHandler(
             IOptionsMonitor<TokenAuthSchemeOptions> options,
             ILoggerFactory logger,
             UrlEncoder encoder,
             ISystemClock clock)
             : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            TokenModel model;

            if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail("Header Not Found."));
            }

            var header = Request.Headers[HeaderNames.Authorization].ToString();
            var tokenMatch = Regex.Match(header, TokenAuthSchemeConstants.NToken);

            if (tokenMatch.Success)
            {
                var token = tokenMatch.Groups["token"].Value;

                try
                {
                    byte[] fromBase64String = Convert.FromBase64String(token);
                    var parsedToken = Encoding.UTF8.GetString(fromBase64String);

                    model = JsonConvert.DeserializeObject<TokenModel>(parsedToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occured while Deserializing: " + ex);
                    return Task.FromResult(AuthenticateResult.Fail("TokenParseException"));
                }

                if (model != null)
                {
                    var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Role, model.Role) };

                    var claimsIdentity = new ClaimsIdentity(claims,
                                nameof(TokenAuthHandler));

                    var ticket = new AuthenticationTicket(
                        new ClaimsPrincipal(claimsIdentity), Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
            }

            return Task.FromResult(AuthenticateResult.Fail("Model is Empty"));
        }
    }
}