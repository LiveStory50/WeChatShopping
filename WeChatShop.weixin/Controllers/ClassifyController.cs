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
    public class ClassifyController : Controller
    {
        ViveViewModel viewmode = new ViveViewModel();
        public ISortService SortService { get; set; }
        public IProductService ProductService { get; set; }
        public IShopCartService ShopCartService { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViveViewModel viewmode=new ViveViewModel();
            viewmode.TopSorts = SortService.GetEntities(s=>s.UpCode!=null);
          return View(viewmode);
        }
        /// <summary>
        /// 二级分类
        /// </summary>
        /// <param name="upcode"></param>
        /// <returns></returns>
        public ActionResult ChiSort(string upcode)
        {
            ViveViewModel viewmode = new ViveViewModel();
            //Contains 匹配数据库中是否出现的字符  相当于模糊查询
            viewmode.LowSorts = SortService.GetEntities(r => r.Code.Contains(upcode));
            return View(viewmode);
        }
        /// <summary>
        /// 三级分类  综合 畅销 价格
        /// </summary>
        /// <param name="codeSort"></param>
        /// <returns></returns>
        public ActionResult DetailList(string codeSort)
        {
          
            //获取二级分类下的所有商品
            viewmode.Products = SortService.GetEntity(p => p.Code == codeSort).Products;
            //0  代表热销 查询二级分类下的所有商品中商品对应的图片表中的No为0的商品
         

            return View(viewmode);
        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="procode"></param>
        /// <returns></returns>
        public ActionResult Detail(string procode)
        {
            viewmode.Product = ProductService.GetEntity(p => p.Code == procode);
            return View(viewmode);
        }
        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="proCode">商品Id</param>
        /// <param name="qty">要加入购物车的数量</param>
        /// <returns></returns>
        public ActionResult JoinShopCart(string proCode, int qty)
        {
   
            //判断数据库是否存在该条数据
           var pro = ShopCartService.GetEntity(r => r.CusId == 3 && r.ProCode == proCode);
          // 
            bool aa;
            if (pro == null)
            {
                ShoppingCart shoppingCart = new ShoppingCart();
                shoppingCart.CusId = 3; //登陆的用户的id编号
                shoppingCart.ProCode = proCode;
                shoppingCart.Qty = qty;
                aa= ShopCartService.Add(shoppingCart);
            }
            else
            {
                pro.Qty+=qty;
                aa = ShopCartService.Modify(pro);
            }
           

          
            var msg = aa ? 1 : 0;
            return Json(new {msg});
        }


        /// <summary>
        /// 立即购买
        /// </summary>
        /// <param name="proCode">商品Id</param>
        /// <param name="payQty">要加入购物车的数量</param>
        /// <returns></returns>
        public ActionResult PayNowResult(string proCode,int payQty=3)
        {
            viewmode.Product = ProductService.GetEntity(r => r.Code == proCode);
            return View(viewmode);
        }
    }
}