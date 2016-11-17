namespace RegressionEntities
{
    public partial class Regression_ASP_TP
    {
        public string RegressionStatus
        {
            get { return RegressionStatu == null ? string.Empty : RegressionStatu.Description; }
        }
    }
}