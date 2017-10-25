using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeChatShop.IRepository;
using WeChatShop.IService;

namespace WeChatShop.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public bool Add(TEntity tEntity)
        {
            _baseRepository.Insert(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Remove(TEntity tEntity)
        {
            _baseRepository.Delete(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Modify(TEntity tEntity)
        {
            _baseRepository.Update(tEntity);
            return _baseRepository.SaveChanges();
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
          return  _baseRepository.QueryEntity(whereLambda);
        }
        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntites(whereLambda);
        }

        public IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,Expression< Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda)
        {
            return _baseRepository.QueryEntitesByPage(pageSize, pageIndex, isAsc, whereLambda, orderByLambda);
        }

        public int GetCount(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryCount(whereLambda);
        }
    }
}
