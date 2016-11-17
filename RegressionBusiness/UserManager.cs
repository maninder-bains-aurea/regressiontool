using RegressionDAL;
using RegressionEntities;
using System;
using System.Linq.Expressions;

namespace RegressionBusiness
{
    public class UserManager : IDisposable
    {
        private UnitOfWork unitOfWork = null;

        public UserManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public LoginUser AuthenticateUser(string pUserName)
        {
            Expression<Func<LoginUser, bool>> expression = default(Expression<Func<LoginUser, bool>>);
            expression = u => u.UserName.Equals(pUserName);

            return unitOfWork.LoginUserRepository.GetSingle(expression, string.Empty);
        }

        public LoginUser GeByID(int pUserID)
        {
            Expression<Func<LoginUser, bool>> expression = default(Expression<Func<LoginUser, bool>>);
            expression = u => u.Id == pUserID;

            return unitOfWork.LoginUserRepository.GetSingle(expression, string.Empty);
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