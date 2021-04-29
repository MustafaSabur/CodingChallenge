
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvailableAttemptsController : ControllerBase
    {
        private readonly IValidateRepository _valideRepository;
        public AvailableAttemptsController(IValidateRepository valideRepository)
        {
            _valideRepository = valideRepository;
        }

        [HttpGet]
        public int Get()
        {
            return _valideRepository.AttemptsAvailable();
        }
    }
}
