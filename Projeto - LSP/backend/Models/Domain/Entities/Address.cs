namespace backend.Models.Domain.Entities
{
    public class Address : Abstract
    {
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}