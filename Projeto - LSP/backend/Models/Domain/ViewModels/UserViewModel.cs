using backend.Models.Domain.ViewModels.EnumViewModel;

namespace backend.Models.Domain.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public DateTime DateBirth { get; set; }
        public GenderViewModel GenderViewModel { get; set; }
        
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public IList<AddressViewModel> AddressViewModel { get; set; }
    }
}