using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeChatShop.IRepository
{
   public interface IBaseRepository<TEntity> where TEntity:class ,new ()//where TEntity:class ,new ()这是一个泛型约束，使传进去的TEntity只能是一个无参的类
   {
        /// <summary>
        /// 插入数据对应Add
        /// </summary>
       void Insert(TEntity tEntity);
        /// <summary>
        /// 删除数据对应Delete
        /// </summary>
        /// <param name="tEntity"></param>
       void Delete(TEntity tEntity);
        /// <summary>
        /// 更新数据对应Modify
        /// </summary>
        /// <param name="tEntity"></param>
        void Update(TEntity tEntity);

       int QueryCount(Func<TEntity, bool> whereLambda);
       /// <summary>
       /// 获取实体对应
       /// </summary>
       /// <param name="whereLambda">获取实体所需要的Lambda表达式</param>
       /// <returns></returns>
        TEntity QueryEntity(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 获取所有的实体集
        /// </summary>
        /// <param name="whereLambda">获取所有的实体集所需要的Lambda表达式</param>
        /// <returns>要查询的所有的实体集</returns>
       IEnumerable<TEntity> QueryEntites(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 获取分页
        /// </summary>
        /// <typeparam name="TType">排序时需要传入的数据类型</typeparam>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isAsc">是否正序获取</param>
        /// <param name="whereLambda">获取分好页的数据所需要的Lambda表达式</param>
        /// <param name="orderByLambda">获取排序后的分页所需要的Lambda表达式</param>
        /// <returns>查询后的完整数据</returns>
       IEnumerable<TEntity> QueryEntitesByPage<TType>(int pageSize, int pageIndex, bool isAsc,Expression<Func<TEntity ,bool>> whereLambda,
           Expression<Func<TEntity, TType>> orderByLambda);
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
       bool SaveChanges();
   }
}
