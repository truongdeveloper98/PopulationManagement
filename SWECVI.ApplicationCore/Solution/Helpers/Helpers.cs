namespace SWECVI.ApplicationCore.Solution
{
    public static class Helpers
    {
        public static DateTime FormatStringToDate(string date, string time = "")
        {
            if(date.Length != 8)
            {
                return DateTime.Now;
            }

            if(!string.IsNullOrEmpty(time) && time.Length != 6)
            {
                return DateTime.Now;
            }

            if(!string.IsNullOrEmpty(time))
            {
               DateTime dateFormat = new DateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(4, 2)), Convert.ToInt32(date.Substring(6, 2)),
                    Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(2, 2)), Convert.ToInt32(time.Substring(4, 2)));

                return dateFormat;
            }

            DateTime dateFormatWithoutTime = new DateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(4, 2)), Convert.ToInt32(date.Substring(6, 2)));

            return dateFormatWithoutTime;
        }
    }
}
