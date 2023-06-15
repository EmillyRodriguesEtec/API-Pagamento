using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 
using System; 
using System.Collections.Generic;

namespace API_Pagamento.Controllers;

[ApiController]
[Route("[controller]")]

public class PagamentoController : ControllerBase
{

    private static List<PagamentoPix> pagamentos = new List<PagamentoPix>()
    {
        new PagamentoPix() {id_pagamento = "1", valor = 100, chave_pix = "minha chave pix", data_pagamento = DateTime.Now},
        new PagamentoPix() {id_pagamento = "2", valor = 120, chave_pix = "sua chave pix", data_pagamento = DateTime.Now}
    }; 

    [HttpGet] 
    public IActionResult GetPagamentos() 
    { 
        return Ok(pagamentos); 
    } 

    [HttpPost] 
    public IActionResult RealizarPagamento(PagamentoPix pagamento) 
    { 
        pagamento.id_pagamento = Guid.NewGuid().ToString(); 
        pagamento.data_pagamento = DateTime.Now; 
        
        // Lógica para processar o pagamento via Pix 
        pagamentos.Add(pagamento); 
        return CreatedAtAction(nameof(ObterComprovante), new { idPagamento = pagamento.id_pagamento }, pagamento); 
    } 

    [HttpGet("{idPagamento}/comprovante")] 
    public IActionResult ObterComprovante(string idPagamento) 
    { 
        var pagamento = pagamentos.Find(p => p.id_pagamento == idPagamento); 
        if (pagamento == null) 
        { 
            return NotFound(); 
        } 
        var comprovante = JsonConvert.SerializeObject(pagamento); 
        return Ok(comprovante); 
    }               
}