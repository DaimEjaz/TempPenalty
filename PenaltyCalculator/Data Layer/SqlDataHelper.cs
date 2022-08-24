using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PenaltyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculator.DataLayer
{
    public class SqlDataHelper : ISqlDataHelper
    {
        string conString = "";

        List<Country> countryList = new List<Country>();

        List<Holiday> holidayList = new List<Holiday>();

        public SqlDataHelper()
        {

        }
        public SqlDataHelper(IConfiguration configuration)
        {
            conString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Country> GetAllCountries()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM CountryTable;", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Country country = new Country(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToDouble(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(6)));
                            countryList.Add(country);
                        }
                    }

                }
                con.Close();
                return countryList;

            }
        }

        public List<Holiday> GetHolidays(int countryId)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM HolidaysTbl WHERE countryId=@countryId;", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@countryId";
                    param.Value = countryId;

                    command.Parameters.Add(param);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Holiday holiday = new Holiday(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), (DateTime)reader.GetValue(2), Convert.ToInt32(reader.GetValue(3)));
                            holidayList.Add(holiday);
                        }
                    }

                }
                con.Close();
                return holidayList;

            }
        }

        public List<string> GetWeekendDays(List<string> WeekDays, string weekendString)
        {
            int length = WeekDays.Count;
            List<string> tempCopy = new List<string>(WeekDays);

            for (int count = 0; count < length; count++)
            {
                if (!(weekendString[count] is '1'))
                {
                    tempCopy.Remove(WeekDays[count]);
                }
            }
            WeekDays = tempCopy;

            return WeekDays;
        }



        public Country GetCountry(int countryId)
        {
            Country country = new Country();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM CountryTable WHERE countryId=@countryId;", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@countryId";
                    param.Value = countryId;

                    // 3. add new parameter to command object
                    command.Parameters.Add(param);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            country = new Country(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToDouble(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(6)));
                        }
                    }

                }
                con.Close();

                return country;

            }
        }

    }
}
