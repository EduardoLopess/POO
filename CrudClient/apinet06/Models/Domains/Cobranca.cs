using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apinet06.Models.Domains
{
    public class Cobranca
    {
        public Cobranca(){}

        public Cobranca(int id, double valorCobranca, bool status, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento)
        {
            Id = id;
            this.valorCobranca = valorCobranca;
            this.status = status;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
        }

        public int Id{get; set;}

        public double valorCobranca {get; set;}

        public bool status {get; set;}
        
        public DateTime DataEmissao {get; set;}

        public DateTime DataVencimento {get;set;} 

        public DateTime DataPagamento{get; set;}
    }
}