using ETicaretApi.Application.DTOs;

namespace ETicaretApi.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse
    {
        public string Message { get; set; }
        public Token Token { get; set; }
        public bool Succes { get; set; }
    }
}
