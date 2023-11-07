namespace backend.Models.Domain.DTOs
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }

        public UserDTO UserDTO { get; set; }
    }
}