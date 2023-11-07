using backend.Models.Domain.DTOs.EnumDTOs;

namespace backend.Models.Domain.DTOs
{
    public class UserDTO : AbstractDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public GenderEnumDTO GenderEnumDTO { get; set; }

        public AddressDTO AddressDTO { get; set; }
    }
}