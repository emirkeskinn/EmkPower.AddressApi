using EmkPower.AddressApi.Mock;
using EmkPower.AddressApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmkPower.AddressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly MockService _mockService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
            _mockService= new MockService();
        }

        [HttpGet]
        [Route("cities")]
        public ActionResult<City> GetCityList()
        {
            var cityList = _mockService.GetCities();
            return Ok(cityList);
        }

        [HttpGet]
        [Route("cities/{cityId}/districts")]
        public ActionResult<District> GetDistrictList(int cityId)
        {
            var DistrictList = _mockService.GetDistricts(cityId);
            return Ok(DistrictList);
        }

        [HttpGet]
        [Route("cities/{cityId}/{districtId}/address")]
        public ActionResult<City> GetAddressList(int cityId, int districtId)
        {
            
            var districtList = _mockService.GetAddresses(cityId, districtId);
            return Ok(districtList);
        }
    }
}