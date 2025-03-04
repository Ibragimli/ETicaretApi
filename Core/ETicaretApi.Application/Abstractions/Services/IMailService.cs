﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IMailService
    {
        Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml);
        Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml);
        Task SendPasswordResetMailAsync(string to,string userId,string resetToToken);
    }
}
