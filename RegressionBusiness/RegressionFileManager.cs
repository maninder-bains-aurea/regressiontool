using RegressionDAL;
using RegressionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegressionBusiness
{
    public class RegressionFileManager : IDisposable
    {
        private UnitOfWork unitOfWork = null;

        public RegressionFileManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<RegressionFile> GetRegressionFileDetails(int aspTpID)
        {
            Expression<Func<RegressionFile, bool>> expression = default(Expression<Func<RegressionFile, bool>>);
            expression = u => u.Regression_ASP_TPID == aspTpID;

            string includeEntities = "";

            return unitOfWork.RegressionFileRepository.GetFiltered(includeEntities, expression, orderBy: mt => mt.OrderBy(mt2 => mt2.TransDate));
        }

        public RegressionFile GetRegressionFileInfo(int fileID)
        {
            Expression<Func<RegressionFile, bool>> expression = default(Expression<Func<RegressionFile, bool>>);
            expression = u => u.Id == fileID;

            string includeEntities = "";

            return unitOfWork.RegressionFileRepository.GetSingle(expression, includeEntities);
        }

        public IEnumerable<RegressionFile> GetAll()
        {
            string includeEntities = "";
            return unitOfWork.RegressionFileRepository.GetAll(includeEntities);
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