using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace PaycoreFirstTry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult CalculateCompoundInterest(double total, double interestrate, double time)
        {
            if(total < 0 || interestrate < 0 || time < 0)
            {
                return BadRequest();
            }
            InterestResponse interestResponse = new InterestResponse();
            interestResponse.TotalBalance = total * Math.Pow((1 + (interestrate / 100)), time);
            interestResponse.InterestAmount = interestResponse.TotalBalance - total;
            return Ok(interestResponse);
        }
    }
}
