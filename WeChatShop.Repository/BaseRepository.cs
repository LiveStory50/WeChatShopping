using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeChatShop.IRepository;
using WeChatShop.weixin.Models;
using WeShop.EFModel;

namespace WeChatShop.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private DbWeShop _dbContext = DbContextFactory.GetAllDbWeShop();//调用封装好的数据库工厂来获取数据库上下文类
        private DbSet<TEntity> _dbSet;

        /// <summary>
        /// 这个构造函数相当于一个类
        /// </summary>
        public BaseRepository()
        {
          //为了防止  _dbContext.Set<IEntity>().Add(tEntity)  这句代码重复打开获取数据库占用资源所以将其封装调用
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Delete(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public void Insert(TEntity tEntity)
        {
             _dbSet.Add(tEntity);
        }
        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            //更改实体的状态为  已修改
            _dbContext.Entry(tEntity).State = EntityState.Modified;
        }

        public int QueryCount(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda).Count();
        }

        /// <summary>
        /// 保存成功 不为空>0 返回为true
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
          return  _dbContext.SaveChanges()>0;
        }

        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntites(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }
       
       
        public IEnumerable<TEntity> QueryEntitesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda)
        {
            //Expression<>  生成查询语句
            var result =_dbSet.Where(whereLambda);
            //三元表达式   isASC ？ 正序:倒序
            result = isAsc ? result.OrderBy(orderByLambda) : result.OrderByDescending(orderByLambda);//附加排序
            //附加分页（offset 偏移值）（页码-1）*页尺寸
            var offset = (pageIndex - 1) * pageSize;
            //Skip:跳过序列中指定的元素，然后返回剩余的元素   Take：从该处起返回指定数量的连续元素      这句话的意思就是去掉前面的数据  查询后面的数据
            result = result.Skip(offset).Take(pageSize);
            return result; 
        }

        public string sp_joinshopcart(ViveViewModel viewModel)
        {
            
            SqlParameter msg = new SqlParameter
            {
                ParameterName = "@msg",
                Direction = ParameterDirection.Output,
                Size = 50,
                SqlDbType = SqlDbType.NVarChar
            };

        SqlParameter[] sqlpar =
        {
                new SqlParameter("@id",viewModel),
                new SqlParameter("@qq",viewModel)

            };
        _dbContext.Database.ExecuteSqlCommand("exec sp_joinshopcart", sqlpar);
            return msg.Value.ToString();
        }



}
}
