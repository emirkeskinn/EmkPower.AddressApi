namespace EmkPower.AddressApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Description { get; set; }
    }
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> AddressList { get; set; }
    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<District> DistrictList { get; set; }
    }
    public class Root
    {
        public List<City> Cities { get; set; }
    }
}
