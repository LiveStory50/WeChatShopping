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
           viewModel.ShoppingCarts = ShopCartService.GetEntities(r => r.CusId == 3);
                if (viewModel.ShoppingCarts.Count()==0)
                {
                    ViewBag.gudge = 1;
                    return View();
                }
                ViewBag.gudge = 0;


                return View(viewModel);
        }
        /// <summary>
        /// 购物车中的加减对所购买商品的数量进行修改数据库中的数据
        /// </summary>
        /// <param name="proCode">商品编号</param>
        /// <param name="qty">购物车中要购买的商品的数量</param>
        /// <returns></returns>
        public ActionResult UpOrDown(string proCode, int qty)
        {
            var pro = ShopCartService.GetEntity(r => r.CusId == 3 && r.ProCode == proCode);
            pro.Qty = qty;
           bool aa= ShopCartService.Modify(pro);
            return RedirectToAction("ShopCartIndex");
        }
    }
}