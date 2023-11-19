namespace backend.Models.Domain.Entities
{
    public class DonationPoint : Abstract
    {
        public int MyProperty { get; set; }

        public DateTime Data { get; set; }

        public Address Address { get; set; }
    }
}