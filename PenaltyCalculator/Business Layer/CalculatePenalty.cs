using PenaltyCalculator.DataLayer;
using PenaltyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculator.BusinessLayer
{
    public class CalculatePenalty : ICalculatePenalty
    {
        List<string> weekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        ISqlDataHelper _sqlDataHelper;

        public CalculatePenalty(ISqlDataHelper sqlDataHelper)
        {
            _sqlDataHelper = sqlDataHelper;
        }

        public CalculatePenalty()
        {

        }

        public Penalty CalculateAmount(DateTime checkoutDate, DateTime returnedDate, int countryId)
        {
            Country selectedCountry = _sqlDataHelper.GetCountry(countryId);

            List<string> weekendDays = _sqlDataHelper.GetWeekendDays(weekDays, selectedCountry.weekend);

            List<Holiday> allHolidays = _sqlDataHelper.GetHolidays(countryId);

            double totalPenalty = 0;

            double taxAdditon = 0;

            string penaltyStr = "";

            List<Holiday> includedHolidays = new List<Holiday>();


            //int dayOfWeek = DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? 7: (int)DateTime.Today.DayOfWeek;

            DateTime firstDay = checkoutDate.Date;
            DateTime lastDay = returnedDate.Date;
            if (firstDay > lastDay)
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan totalTime = lastDay - firstDay;

            int businessDays = totalTime.Days + 1;

            //while (checkoutDate.AddDays(1) <= returnedDate)
            //{
            //    for(int i = 0; i < weekendDays.Count; i++)
            //    {
            //        if (checkoutDate.DayOfWeek != weekDays[i])
            //        {

            //        }

            //    }
            //}

            DateTime day = firstDay;

            while (day <= lastDay)
            {
                //Subtracting every weekend day

                for (int i = 0; i < weekendDays.Count; i++)
                {
                    if ((day.DayOfWeek).ToString() == weekendDays[i])
                    {
                        businessDays--;
                    }
                }
                day = day.AddDays(1);
            }

            for (int i = 0; i < allHolidays.Count; i++)
            {
                //Subtracting holidays

                if (firstDay.CompareTo(allHolidays[i].date) <= 0 && lastDay.CompareTo(allHolidays[i].date) >= 0)
                {
                    includedHolidays.Add(allHolidays[i]);
                    businessDays--;
                }
            }

            for (int i = 0; i < includedHolidays.Count; i++)
            {
                string dayOfHoliday = includedHolidays[i].date.DayOfWeek.ToString();

                //Subtracting holidays
                for (int count = 0; count < weekendDays.Count; count++)
                {
                    if (dayOfHoliday == weekendDays[count])
                    {
                        businessDays++;
                    }
                }
                
            }


            //Method for Penalty calculation

            if (businessDays > 10)
            {
                totalPenalty = (businessDays - 10) * selectedCountry.penaltyPerDay;

                taxAdditon = totalPenalty * (selectedCountry.tax / 100);

                totalPenalty = totalPenalty + taxAdditon;

                penaltyStr = selectedCountry.currencySymbol + " " + totalPenalty.ToString();

                Penalty penaltyObj = new Penalty(businessDays, penaltyStr);

                return penaltyObj;
            }
            else
            {
                totalPenalty = 0;
                penaltyStr = "";
                Penalty penaltyObj = new Penalty(0, penaltyStr);
                return penaltyObj;

            }
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = _sqlDataHelper.GetAllCountries();
            return countries;
        }
    }
}
