namespace MookApi.Common
{
    public static class JalaliDate
    {
        public static string getDate(this DateTime? dt)
        {
            if (dt != null)
            {
                return Zyx.Utility.Calendar.GetPersianDate(dt.GetValueOrDefault(), "/");
            }
            else
            {
                return null;
            }
        }

        public static string getDateTime(this DateTime? dt)
        {
            if (dt != null)
                return Zyx.Utility.Calendar.GetPersianDate(dt.GetValueOrDefault(), "/") + " " + Zyx.Utility.Calendar.GetHourMinute(dt.GetValueOrDefault());
            else
                return null;
            
        }

        public static DateTime? toGeorgian(this string? dt)
        {
            if (dt != null)
            {
                string[] textDt = dt.Split('/');
                if (textDt.Length == 3)
                    return Zyx.Utility.Calendar.GetGregorianDateFromPersian(int.Parse(textDt[0]), int.Parse(textDt[1]), int.Parse(textDt[2]));
                else
                    return null;
            }
            else
                return null;
            
        }
        public static int? getDay(this string? dt)
        {
            DateTime? date = toGeorgian(dt);
            if (date != null)
            {
                return Zyx.Utility.Calendar.GetPersianDayOfMonth((DateTime)date);
            }
            else
                return null;
        }

    }
}
