﻿using ETicaretApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstractions.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccesToken(int minute);

    }
}
