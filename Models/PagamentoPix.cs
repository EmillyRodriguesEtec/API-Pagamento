using System.ComponentModel.DataAnnotations;


namespace API_Pagamento.Models;


public class PagamentoPix
{
    public DateTime data_pagamento { get; set; }
    public decimal valor { get; set; }
    [Key]
    public string chave_pix { get; set; }
    public string id_pagamento { get; set; }
    public string nome_emissor { get; set; }
    public string nome_receptor { get; set; }

}