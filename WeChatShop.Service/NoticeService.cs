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
    public class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(INoticeRepository noticeRepository) : base(noticeRepository)
        {
        }
    }
}