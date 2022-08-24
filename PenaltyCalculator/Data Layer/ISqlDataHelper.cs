using PenaltyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PenaltyCalculator.DataLayer
{
    public interface ISqlDataHelper
    {
        List<Country> GetAllCountries();

        List<Holiday> GetHolidays(int countryId);

        List<string> GetWeekendDays(List<string> WeekDays, string weekendString);

        Country GetCountry(int countryId);



    }
}
