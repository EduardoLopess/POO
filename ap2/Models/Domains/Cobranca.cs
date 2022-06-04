namespace apinet06.Models.Domains
{
    public class Cobranca
    {
        public Cobranca(){}

        public Cobranca(int id, double valorCobranca, bool status, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento, Client client, int clientID)
        {
            Id = id;
            this.valorCobranca = valorCobranca;
            this.status = status;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            Client = client;
            ClientID = clientID;
        }

        public int Id{get; set;}

        public double valorCobranca {get; set;}

        public bool status {get; set;}
        
        public DateTime DataEmissao {get; set;}

        public DateTime DataVencimento {get;set;} 

        public DateTime DataPagamento{get; set;}

        public Client Client {get; set;}
        public int ClientID {get;set;}
    }
}