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
    public class HomeController : Controller
    {
        ViveViewModel viewModel=new ViveViewModel();
        /// <summary>
        /// 给Banner设置属性方便打点调用它所继承的IBaseService接口内的方法
        /// </summary>
        public IBannerService BannerService { get; set; }
        public INoticeService NoticeService { get; set; }
        public IProductService ProductService { get; set; }
        public ActionResult Index()
        {
            viewModel.NoticeNum = NoticeService.GetCount(r => true);//主页显示的公告数量
            viewModel.Notices =NoticeService.GetEntitiesByPage(3,1,false,r=>true,r=>r.ModiTime) ;//公告

            //b => true 获取所有的Banner实体集
           viewModel.Banners= BannerService.GetEntities(b => true);//Banner

            viewModel.Products = ProductService.GetEntitiesByPage(3, 1, true, p => true, p => p.ModiTime);

        
            //作为强类型传到前台页面 然后用Model打点调用该实体集内所获取到的Banner集合
            return View(viewModel);
        }
        /// <summary>
        /// 最新公告
        /// </summary>
        /// <param name="noteresult"></param>
        /// <returns></returns>
        public ActionResult NoticeResult(int noteresult)
        {
           
            // int noteresult  获取最新的几条
            //倒序获取3条公告
            viewModel.Notices = NoticeService.GetEntitiesByPage(3, 1, true, r =>true, r => r.ModiTime);
            return View(viewModel);
        }
        /// <summary>
        /// 公告详情页
        /// </summary>
        /// <param name="notedetail"></param>
        /// <returns></returns>
        public ActionResult NoticeDetail(int notedetail)
        {

            // 根据传进来的id查询相应的其他数据
            viewModel.Notice = NoticeService.GetEntity(r => r.Id == notedetail);
            return View(viewModel);
        }
    }
}