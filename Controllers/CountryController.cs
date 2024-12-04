using loc_api_crud.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace loc_api_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private CountryRepository _countryRepository;
        public CountryController(CountryRepository CountryRepo)
        {
            this._countryRepository = CountryRepo;
        }
        [HttpGet]
        public IActionResult GetAllCountry()
        {
            var country = _countryRepository.GetAllCountry();
            return Ok(country);
        }
    }
}
