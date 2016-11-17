using RegressionDAL;
using RegressionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegressionBusiness
{
    public class RegressionManager : IDisposable
    {
        private UnitOfWork unitOfWork = null;

        public RegressionManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool Add(Regression pRegression)
        {
            unitOfWork.RegressionRepository.Create(pRegression);
            unitOfWork.Save();
            return true;
        }

        public IEnumerable<Regression> GetRegressionListByUserID(Int32 pUserID)
        {
            Expression<Func<Regression, bool>> expression = default(Expression<Func<Regression, bool>>);
            expression = u => u.UserId == pUserID;

            string includeEntities = "RegressionStatu";

            return unitOfWork.RegressionRepository.GetFiltered(includeEntities, expression, orderBy: mt => mt.OrderBy(mt2 => mt2.MapName));
        }

        public IEnumerable<Regression> GetRegressionListByUserID(Int32 pUserID, Int32 pageSize, Int32 pCurrentPage, out Int32 pTotalRecords)
        {
            Expression<Func<Regression, bool>> expression = default(Expression<Func<Regression, bool>>);
            expression = u => u.UserId == pUserID;

            string includeEntities = "RegressionStatu";

            return unitOfWork.RegressionRepository.GetFiltered(pageSize, pCurrentPage, includeEntities, out pTotalRecords, expression, orderBy: mt => mt.OrderBy(mt2 => mt2.MapName));
        }

        public IEnumerable<Regression> GetRegressionListByMapName(string pMapName)
        {
            Expression<Func<Regression, bool>> expression = default(Expression<Func<Regression, bool>>);
            expression = u => u.MapName == pMapName;

            string includeEntities = "";

            return unitOfWork.RegressionRepository.GetFiltered(includeEntities, expression, orderBy: mt => mt.OrderBy(mt2 => mt2.MapName));
        }

        public Regression GetRegressionByMapName(string pMapName)
        {
            Expression<Func<Regression, bool>> expression = default(Expression<Func<Regression, bool>>);
            expression = u => u.MapName == pMapName;

            string includeEntities = "";

            return unitOfWork.RegressionRepository.GetSingle(expression, includeEntities);
        }

        public IEnumerable<Regression> GetAll()
        {
            string includeEntities = "";
            return unitOfWork.RegressionRepository.GetAll(includeEntities);
        }

        public void Dispose()
        {
            if (unitOfWork != null)
            {
                unitOfWork.Dispose();
                unitOfWork = null;
            }
        }
    }
}