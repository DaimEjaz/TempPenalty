using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculator.Models
{
    public class Penalty
    {
        public int businessDays { get; set; }

        public string totalPenalty { get; set; }

        public Penalty()
        {

        }

        public Penalty(int totalBusinessDays, string penaltyAmount)
        {
            businessDays = totalBusinessDays;
            totalPenalty = penaltyAmount;
        }
    }
}