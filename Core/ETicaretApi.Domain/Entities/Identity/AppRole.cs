﻿using Microsoft.AspNetCore.Identity;

namespace ETicaretApi.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public string Name { get; set; }
    }
}
