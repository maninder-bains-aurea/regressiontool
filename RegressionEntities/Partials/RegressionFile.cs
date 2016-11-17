namespace RegressionEntities
{
    public partial class RegressionFile
    {
        public string RegressionStatus
        {
            get { return RegressionStatu == null ? string.Empty : RegressionStatu.Description; }
        }

        public string TransDateString
        {
            get { return TransDate == null ? string.Empty : TransDate.Date.ToString("dd-MMM-yyyy"); }
        }

        public string PreFileName
        {
            get { return string.Format("{0}{1}", LocalLoationPreTranslatedFile, PresTranslatedFilename); }
        }

        public string PostFileName
        {
            get { return string.Format("{0}{1}", LocalLoationPostTranslatedFile, PostTranslatedFilename_); }
        }
    }
}