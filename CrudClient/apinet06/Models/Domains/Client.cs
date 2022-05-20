using System.ComponentModel.DataAnnotations;

namespace apinet06.Models.Domains
{
    public class Client
    {
        public Client(){}

        public Client(int id, string name, string phone, Cobranca cobranca)
        {
            Id = id;
            this.name = name;
            this.phone = phone;
            this.cobranca = cobranca;
        }

        [Key()]
        public int Id {get; set;} 

        public string name {get; set;} = string.Empty;

        public string phone {get; set;} = string.Empty;

        public Cobranca cobranca {get; set;}

        // public ICollection<Cobranca> Cobrancas {get; set;} 
    
    }
}