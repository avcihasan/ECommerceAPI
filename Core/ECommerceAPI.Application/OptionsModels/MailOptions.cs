using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.OptionsModels
{
    public class MailOptions
    {
        public const string Mail = "Mail";
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }
}
