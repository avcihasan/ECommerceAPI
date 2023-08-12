using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.OptionsModels
{
    public class TokenOptions
    {
        public const string Token = "Token";
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigninKey { get; set; }
    }
}
