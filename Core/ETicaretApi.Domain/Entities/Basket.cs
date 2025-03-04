﻿using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Domain.Entities.Identity;

namespace ETicaretApi.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
