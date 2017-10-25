using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatShop.IRepository;
using WeChatShop.IService;
using WeShop.EFModel;

namespace WeChatShop.Service
{
    public class BannerService : BaseService<Banner>, IBannerService
    {
        public BannerService(IBannerRepository bannerRepository) : base(bannerRepository)//Base是指调用父类的构造函数
        {
        }
    }

}
