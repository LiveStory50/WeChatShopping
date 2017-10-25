using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChatShop.IService;
using WeChatShop.weixin.Models;
using WeShop.EFModel;

namespace WeChatShop.weixin.Controllers
{
    public class ShopCartController : Controller
    {
        ViveViewModel viewModel=new ViveViewModel();
        public IShopCartService ShopCartService { get; set; }
        /// <summary>
        /// 购物车主页
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopCartIndex()
        {
            try
            {
                
                viewModel.ShoppingCarts = ShopCartService.GetEntities(r => r.CusId == 3);
                ViewBag.gudge = 0;
                return View(viewModel);
            }
            catch 
            {
                ViewBag.gudge = 1;
                return View();
            }
             
        }
    }
}