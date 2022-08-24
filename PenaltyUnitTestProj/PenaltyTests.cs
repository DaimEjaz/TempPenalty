using PenaltyCalculator.BusinessLayer;
using PenaltyCalculator.DataLayer;
using PenaltyCalculator.Models;

namespace PenaltyUnitTestProj
{
    public class Tests
    {
        List<string> weekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            Country country = new Country(1, "Pakistan", "Pakistani rupees", "PKR", "0000011", 0, 50);
            List<string> weekendDays = new List<string>(){"Saturday", "Sunday"};
            DateTime holidayTime = new DateTime(2022, 08, 14);
            List<Holiday> holidays = new List<Holiday>() { new Holiday(1, "Independence Day", holidayTime, 1) };
            DateTime checkoutDate = new DateTime(2022, 08, 10);
            DateTime returnedDate = new DateTime(2022, 08, 30);
            int countryId = 1;

            CalculatePenalty calculatePenalty = new CalculatePenalty();
            Penalty penalty = calculatePenalty.CalculateAmount(checkoutDate,returnedDate, countryId);






            //Act
            //Approve
            Assert.AreNotEqual(0, penalty.businessDays );
        }
    }
}