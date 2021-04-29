
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateRepository _valideRepository;
        private int _secretAccesCode = 321;

        public ValidateController(IValidateRepository valideRepository)
        {
            _valideRepository = valideRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{value}")]
        public string Get(int value)
        {
            string response;
            if (value == _secretAccesCode)
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

        [HttpGet("/available-attempts")]
        public int GetAttempts()
        {
            return _valideRepository.AttemptsAvailable();
        }
    }
}
