using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenaltyCalculator.BusinessLayer;
using PenaltyCalculator.Models;

namespace PenaltyCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        ICalculatePenalty _penaltyCalculator;
        public PenaltyController(ICalculatePenalty penaltyCalculator)
        {
            _penaltyCalculator = penaltyCalculator;
        }


        [Route("GetAllCountries")]
        [HttpGet]
        public List<Country> GetCountries()
        {
            List<Country> countries = _penaltyCalculator.GetCountries();
            return countries;
        }

        [Route("CalculateAmount")]
        [HttpPost]

        public Penalty CalculateAmount([FromBody] Query obj)
        {
            DateTime first = obj.checkoutDate;
            DateTime second = obj.returnedDate;
            int id = obj.countryId;

            return _penaltyCalculator.CalculateAmount(first, second, id);
        }
    }
}