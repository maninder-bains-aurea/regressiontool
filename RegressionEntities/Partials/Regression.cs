namespace RegressionEntities
{
    public partial class Regression
    {
        public string RegressionStatus
        {
            get { return RegressionStatu == null ? "--" : RegressionStatu.Description; }
        }

        public string StartDateString
        {
            get { return StartDate == null ? string.Empty : StartDate.Value.ToString("dd-MMM-yyyy"); }
        }

        public string EndDateString
        {
            get { return EndDate == null ? string.Empty : EndDate.Value.ToString("dd-MMM-yyyy"); }
        }
    }
}