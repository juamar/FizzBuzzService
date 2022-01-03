using FizzBuzzService.Exceptions;
using FizzBuzzService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FizzBuzzController : Controller
    {

        private readonly ILogger<FizzBuzzController> _logger;

        public FizzBuzzController(ILogger<FizzBuzzController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult WriteFizzBuzz(FizzBuzzRequest fizzBuzzRequest)
        {
            FizzBuzzResult result = new FizzBuzzResult(fizzBuzzRequest);

            if (fizzBuzzRequest.LimitNumber < fizzBuzzRequest.StartRamdomNumber)
            {
                LimitLessThanStartingNumberException e = new LimitLessThanStartingNumberException();
                _logger.LogError("{0}: {1}", DateTime.Now, e.Message);
                return StatusCode(501, new ErrorResponse(e.Message));
                
            }

            for (int i = fizzBuzzRequest.StartRamdomNumber; i <= fizzBuzzRequest.LimitNumber; i++)
            {
                bool isFizz = i % 3 == 0;
                bool isBuzz = i % 5 == 0;

                if (!isFizz && !isBuzz)
                {
                    //plainNumber
                    result.FizzBuzzString += i;
                    if (i != fizzBuzzRequest.LimitNumber)
                        result.FizzBuzzString += ", ";

                    continue;
                }

                if (isFizz)
                    result.FizzBuzzString += "fizz";

                if (isBuzz)
                    result.FizzBuzzString += "buzz";
                
                if (i != fizzBuzzRequest.LimitNumber)
                    result.FizzBuzzString += ", ";
            }

            _logger.LogInformation("{0}: {1}", DateTime.Now, result.FizzBuzzString);

            return Ok(result);
        }
    }
}
