namespace backend.Models.Domain.ViewModels
{
    public class AddressViewModel
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Neighborhood  { get; set; } //Bairro
        public string Complement { get; set; } 
        public int ZipCode { get; set; }

    }
}