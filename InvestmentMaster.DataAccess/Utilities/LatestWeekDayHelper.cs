using InvestmentMaster.Entities.Concrete;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.DataAccess.Utilities
{
    public class LatestWeekDayHelper
    {
        public static string GetLatestWeekDay()
        {
            DateTime currentDate = DateTime.Now;

            do
            {
                currentDate = currentDate.AddDays(-1);
            } while (IsWeekend(currentDate) || IsPublicHoliday(currentDate));

            return currentDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }


        private static bool IsPublicHoliday(DateTime date)
        {
            string dateString = date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var publicHoliday in GetPublicHolidays())
            {
                if (publicHoliday.Equals(dateString))
                {
                    return true;
                }
            }

            return false;
        }

        private static List<string> GetPublicHolidays()
        {
            int currentYear = DateTime.Now.Year;

            List<PublicHoliday> publicHolidays = new List<PublicHoliday>();
            List<string> publicHolidaysString = new List<string>();

            var client = new RestClient($"https://date.nager.at/api/v3/publicholidays/{currentYear}/TR");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            publicHolidays = JToken.Parse(response.Content).ToObject<List<PublicHoliday>>();

            foreach (var publicHoliday in publicHolidays)
            {
                DateTime publicHolidayDate = DateTime.Parse(publicHoliday.Date);
                string publicHolidayAdd = publicHolidayDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                publicHolidaysString.Add(publicHolidayAdd);
            }

            return publicHolidaysString;
        }
    }
}
