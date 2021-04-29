
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("validate")]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateRepository _valideRepository;
        private int _secretAccesCode = 321;

        public ValidateController(IValidateRepository valideRepository)
        {
            _valideRepository = valideRepository;
        }

        [HttpGet("{value}")]
        public string Get(int value)
        {
            string response;
            if (value == _secretAccesCode )
            {
                _valideRepository.ResetAttempts();
                response = "ACCESS GRANTED";
            }
            else
            {
                _valideRepository.IncrementAttempts();
                response = "ACCESS DENIED";
            }

            return response;
        }

        [HttpGet("/available-attemps")]
        public int Get()
        {
            return _valideRepository.AttemptsAvailable();
        }
    }
}
