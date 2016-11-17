using RegressionEntities;

namespace RegressionDAL
{
    public partial class UnitOfWork
    {
        private Repository<LoginUser> loginUserRepository;
        public Repository<LoginUser> LoginUserRepository
        {
            get
            {
                if (this.loginUserRepository == null)
                    this.loginUserRepository = new Repository<LoginUser>(context);

                return loginUserRepository;
            }
        }

        private Repository<Regression> regressionRepository;
        public Repository<Regression> RegressionRepository
        {
            get
            {
                if (this.regressionRepository == null)
                    this.regressionRepository = new Repository<Regression>(context);

                return regressionRepository;
            }
        }

        private Repository<RegressionFile> regressionFileRepository;
        public Repository<RegressionFile> RegressionFileRepository
        {
            get
            {
                if (this.regressionFileRepository == null)
                    this.regressionFileRepository = new Repository<RegressionFile>(context);

                return regressionFileRepository;
            }
        }

        private Repository<RegressionStatu> regressionStatusRepository;
        public Repository<RegressionStatu> RegressionStatusRepository
        {
            get
            {
                if (this.regressionStatusRepository == null)
                    this.regressionStatusRepository = new Repository<RegressionStatu>(context);

                return regressionStatusRepository;
            }
        }

        private Repository<Regression_ASP_TP> regression_ASP_TPRepository;
        public Repository<Regression_ASP_TP> Regression_ASP_TPRepository
        {
            get
            {
                if (this.regression_ASP_TPRepository == null)
                    this.regression_ASP_TPRepository = new Repository<Regression_ASP_TP>(context);

                return regression_ASP_TPRepository;
            }
        }
    }
}