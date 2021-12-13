using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken // jwt, jason web token in kısaltmasıdır
    {
        public string Token { get; set; } // tokenin kendisi
        public DateTime Expiration { get; set; } // geçerlilik süresi
    }
}
