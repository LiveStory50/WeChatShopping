using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;

namespace WeChatShop.Repository
{
   public class DbContextFactory
    {
        /// <summary>
        /// 获取数据库所有上下文类
        /// </summary>
        /// <returns></returns>
        public static DbWeShop GetAllDbWeShop()
        {
            var _dbContext = CallContext.GetData("dbContext") as DbWeShop;
            if (_dbContext==null)
            {
                _dbContext=new DbWeShop();
                CallContext.SetData("dbContext",_dbContext);
            }
            return _dbContext;
        }
    }
}
