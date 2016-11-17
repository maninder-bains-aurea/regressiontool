using RegressionDAL;
using RegressionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegressionBusiness
{
    public class RegressionAspTpManager : IDisposable
    {
        private UnitOfWork unitOfWork = null;

        public RegressionAspTpManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Regression_ASP_TP> GetRegressionAspTpDetails(int regressionID)
        {
            Expression<Func<Regression_ASP_TP, bool>> expression = default(Expression<Func<Regression_ASP_TP, bool>>);
            expression = u => u.RegressionId == regressionID;

            string includeEntities = "";

            return unitOfWork.Regression_ASP_TPRepository.GetFiltered(includeEntities, expression, orderBy: mt => mt.OrderBy(mt2 => mt2.Client));
        }

        public IEnumerable<Regression_ASP_TP> GetAll()
        {
            string includeEntities = "";
            return unitOfWork.Regression_ASP_TPRepository.GetAll(includeEntities);
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