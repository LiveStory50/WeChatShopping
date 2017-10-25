using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeChatShop.weixin.Models
{
    public class ViveViewModel
    {
        public int NoticeNum { get; set; }
  
        public IEnumerable<Banner> Banners { get; set; }
        /// <summary>
        /// 用了 IEnumerable 获取很多数据
        /// </summary>
        public IEnumerable<Notice> Notices { get; set; }
        /// <summary>
        /// 没用 IEnumerable 根据id获取一行数据
        /// </summary>
        public Notice Notice { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public Product Product { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
        /// <summary>
        /// 父级列表
        /// </summary>
        public IEnumerable<Sort> TopSorts { get; set; }
        /// <summary>
        /// 子级列表
        /// </summary>
        public IEnumerable<Sort> LowSorts { get; set; }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }


    }
}