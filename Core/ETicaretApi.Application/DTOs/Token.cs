using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.DTOs
{
    public class Token
    {
        public string AccesToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
