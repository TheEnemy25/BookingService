using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Providers.TokenAuthProvider
{
    public class TokenAuthSchemeConstants
    {
        public const string TokenAuthScheme = "Token";
        public const string NToken = $"{TokenAuthScheme} (?<token>.*)";
    }
}
