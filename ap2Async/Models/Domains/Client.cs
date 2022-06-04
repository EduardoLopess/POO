namespace apinet06.Models.Domains
{
    public class Client
    {
        public Client(){}

        public Client(int id, string name, string phone, Cobranca cobrancas)
        {
            Id = id;
            this.name = name;
            this.phone = phone;
            Cobrancas = cobrancas;
        }

       
        public int Id {get; set;} 

        public string name {get; set;} 

        public string phone {get; set;} 

        public Cobranca Cobrancas{get; set;}

    }
}