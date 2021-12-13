using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions // apide settingsin içinde tutacağız
    {
        public string Audience { get; set; } // kullanıcı kitlesi
        public string Issuer { get; set; } // imzalayan
        public int AccessTokenExpiration { get; set; } // tokenin geçerlilik süresi
        public string SecurityKey { get; set; } // token
    }
}
