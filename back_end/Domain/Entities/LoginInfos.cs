using Domain.Enums;

namespace Domain.Entities
{
    public abstract class LoginInfos
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordHashSalt { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
    }
}