using EmkPower.AddressApi.Models;
using System.Text.Json;

namespace EmkPower.AddressApi.Mock
{
    public class MockService
    {

        private readonly List<City> _cityList;
        public MockService()
        {
            var dbPath = Path.Combine(Environment.CurrentDirectory, "Mock", "mock-db.json");
            var dbString = File.ReadAllText(dbPath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var db = JsonSerializer.Deserialize<Root>(dbString, options);
            _cityList = db.Cities;
        }
        public List<City> GetCities()
        {
            var cities = new List<City>();
            foreach (var city in _cityList)
            {
                cities.Add(new City()
                {
                    Id = city.Id,
                    Name = city.Name
                });
            }
            return cities;
        }
        public City GetDistricts(int cityId)
        {
            var city = new City();
            city.Id = cityId;
            city.Name = _cityList.FirstOrDefault(w => w.Id == cityId).Name;
            city.DistrictList = new List<District>();
            foreach (var district in _cityList.Where(w => w.Id == cityId).FirstOrDefault().DistrictList)
            {
                city.DistrictList.Add(new District() { Id = district.Id, Name = district.Name });
            }
            return city;
        }

        public City GetAddresses(int cityId, int districtId)
        {
            var city = new City() { Id = cityId,DistrictList=new List<District>() };
            var district = new District() { Id = districtId };
            var addresses = new List<Address>();

            foreach (var address in _cityList.FirstOrDefault(w => w.Id == cityId).DistrictList.FirstOrDefault(x => x.Id == districtId).AddressList)
            {
                addresses.Add(new Address()
                {
                    Id = address.Id,
                    Title = address.Title,
                    Lat = address.Lat,
                    Lon = address.Lon,
                    Description = address.Description,
                });
            }
            district.AddressList = addresses;
            city.DistrictList.Add(district);
            return city;
        }
    }
}
