using System.ComponentModel.DataAnnotations;


namespace API_Pagamento.Models;


public class PagamentoCartao
{
        [Key]
        public Int64 numero_cartao { get; set; }
        public string nome_titular { get; set; }
        public DateTime validade_cartao { get; set; }
        public int codigo_seguranca { get; set; }
        public string cpf_titular { get; set; }
        public decimal valor { get; set; }
}
