using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChatShop.weixin.Controllers
{
    public class PersonCenterController : Controller
    {
        // GET: PersonCenter
        public ActionResult CenterIndex()
        {
            return View();
        }
        /// <summary>
        /// 全部订单
        /// </summary>
        /// <returns></returns>
        public ActionResult CenterOrderAll(string states)
        {
            ViewBag.states = states;
            return View();
        }






        /// <summary>
        /// 待付款
        /// </summary>
        /// <returns></returns>
        public ActionResult NoObligationOrder()
        {
            return View();
        }
        /// <summary>
        /// 待发货
        /// </summary>
        /// <returns></returns>
        public ActionResult NoShipmentsOrder()
        {
            return View();
        }
        /// <summary>
        /// 待收货
        /// </summary>
        /// <returns></returns>
        public ActionResult NoTakeOrder()
        {
            return View();
        }
        /// <summary>
        /// 待评价
        /// </summary>
        /// <returns></returns>
        public ActionResult NoAppraiseOrder()
        {
            return View();
        }
        /// <summary>
        /// 退款、售后
        /// </summary>
        /// <returns></returns>
        public ActionResult RefultSale()
        {
            return View();
        }
    }
}