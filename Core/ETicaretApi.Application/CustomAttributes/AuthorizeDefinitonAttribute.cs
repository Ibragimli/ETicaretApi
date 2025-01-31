using ETicaretApi.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.CustomAttributes
{
    public class AuthorizeDefinitonAttribute : Attribute
    {
        public string Menu { get; set; }
        public string Definatio { get; set; }
        public ActionType ActionType { get; set; }
    }
}
