﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatShop.IRepository;
using WeChatShop.IService;
using WeShop.EFModel;

namespace WeChatShop.Service
{
   public class ShopCartService:BaseService<ShoppingCart>,IShopCartService
    {
        public ShopCartService(IShopCartRepository shopCartRepository) : base(shopCartRepository)
        {
        }
    }
}
