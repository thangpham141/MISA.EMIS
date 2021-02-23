using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class BaseService<TEntity>:IBaseService<TEntity>
    {
        #region DECLARE
        protected IDbContext<TEntity> _dbContext;
        #endregion
        #region CONTRUCTOR
        public BaseService(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region METHODS
        public virtual ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();
            var tableName = typeof(TEntity).Name;
            serviceResult.Data = _dbContext.GetAll();
            return serviceResult;
        }
        public ServiceResult Post(TEntity entity)
        {
            var serviceResult = new ServiceResult();
            ErrorMessenger errorMessenger = new ErrorMessenger();

            //Validate dữ liệu
            if (!Validate(entity, errorMessenger))
            {
                serviceResult.Data = errorMessenger;
                return serviceResult;
            }

            serviceResult.Data = _dbContext.Insert(entity);
            serviceResult.Success = true;

            return serviceResult;
        }
        public virtual bool Validate(TEntity entity, ErrorMessenger errorMessenger, string entityCode = null)
        {
            return true;
        }
        public ServiceResult Delete(string entityId)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.Delete(entityId);
            return serviceResult;
        }
        public ServiceResult Put(TEntity entity, string entityCode = null)
        {
            var serviceResult = new ServiceResult();
            ErrorMessenger errorMessenger = new ErrorMessenger();

            //Validate dữ liệu
            if (!Validate(entity, errorMessenger, entityCode))
            {
                serviceResult.Data = errorMessenger;
                return serviceResult;
            }

            serviceResult.Data = _dbContext.Put(entity);
            serviceResult.Success = true;

            return serviceResult;
        }
        #endregion
    }
}
