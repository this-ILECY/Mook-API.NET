using MookApi.Models;
using MookApi.ViewModel;

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
        public static int? getMonth(this string? dt)
        {
            DateTime? date = toGeorgian(dt);
            if (date != null)
            {
                return Zyx.Utility.Calendar.GetPersianMonth((DateTime)date);
            }
            else
                return null;
        }
        public static int? getYear(this string? dt)
        {
            DateTime? date = toGeorgian(dt);
            if (date != null)
            {
                return Zyx.Utility.Calendar.GetPersianYear((DateTime)date);
            }
            else
                return null;
        }
        public static bool compareDate(string timeOne, string timeTwo)
        {

            if (getYear(timeOne) <= getYear(timeTwo))
            {
                if (getMonth(timeOne) <= getMonth(timeTwo))
                {
                    if (getDay(timeOne) <= getDay(timeTwo))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }
        public static Delay getIsDelay(RequestHeader rq, RequestViewModel rqv)
        {
            Delay delay = new Delay();
            var TimeNow = JalaliDate.getDate(DateTime.Now.ToLocalTime());

            bool IsDelay;
            if (rq != null & rqv == null)
                IsDelay = JalaliDate.compareDate(rq.requestFinishedDate, TimeNow);
            else if (rq == null & rqv != null)
                IsDelay = JalaliDate.compareDate(rqv.requestFinishedDate, TimeNow);
            else
                IsDelay = false;

            if (IsDelay)
                delay.isDelayed = true;
            else
                delay.isDelayed = false;

            return delay;
        }

    }
}
