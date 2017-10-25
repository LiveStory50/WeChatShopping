using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatShop.IRepository;
using WeShop.EFModel;

namespace WeChatShop.Repository
{
   public class ShopCartRepository:BaseRepository<ShoppingCart>,IShopCartRepository
    {
    }
}
