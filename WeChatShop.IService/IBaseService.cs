using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeChatShop.IService
{
   public interface IBaseService<TEntity> where TEntity: class,new()// where TEntity: class,new()是一个泛型约束，意为约束该接口里面的TEntity传进来的只能是带有一个无参数的类
    {
        //由于要把Banner取出来必须要查询，方便调用要写一个查询的接口
        /// <summary>
        /// 添加
        /// </summary>
        bool Add(TEntity tEntity);
        /// <summary>
        /// 删除
        /// </summary>
        bool Remove(TEntity tEntity);
        /// <summary>
        /// 修改
        /// </summary>
        bool Modify(TEntity tEntity);
        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        int GetCount(Func<TEntity,bool> whereLambda);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="whereLambda">获取实体所需要的Lambda表达式</param>
        /// <returns></returns>
        TEntity GetEntity(Func<TEntity,bool> whereLambda);

        /// <summary>
        /// 获取一个实体的集合(用where查询一个集合)
        /// </summary>
        /// <param name="whereLambda">获取该实体集合所需要的Lambda表达式(用where查询一个集合)</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities(Func<TEntity,bool> whereLambda);
        /// <summary>
        /// 获取分页
        /// </summary>
        /// <typeparam name="TeType">排序时候需要的类型(Lambda表达式返回的是一个类型)</typeparam>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="whereLambda">获取分页数据所需要的Lambda表达式</param>
        /// <param name="orderByLambda">排序所需要的Lambda表达式</param>
        /// <returns>返回的是所要查询的实体集结果</returns>
        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda);
    }
}
