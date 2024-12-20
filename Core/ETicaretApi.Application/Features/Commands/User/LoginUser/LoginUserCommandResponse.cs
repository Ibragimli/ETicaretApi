using ETicaretApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse
    {
        public string Message { get; set; }
        public Token Token { get; set; }
        public bool Succes { get; set; }
    }
}
