using backend.Models.Domain.Enums;

namespace backend.Models.Domain.Entities
{
    public class User : Abstract
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateBirth { get; set; }
        public string CPF { get; set; }
        public Gender Gender { get; set; } // ENUM

        //LOGIN
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        //REFERENCIAS
        public IList<Address> Addresses { get; set; }

    }
}