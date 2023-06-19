using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 
using System; 
using System.Collections.Generic;
using API_Pagamento.Models;
using API_Pagamento.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Pagamento.Controllers;

[ApiController]
[Route("[controller]")]

public class PagamentoController : ControllerBase
{
    private readonly DataContext _context;

    public PagamentoController(DataContext context)
    {   
        _context = context;        
    }

    

    /*[HttpGet("GetAll")] 
    public IActionResult GetPagamentos() 
    { 
        return Ok(_context.PagamentosPix.ToListAsync()); 
    } */

    [HttpPost] 
    public async Task<IActionResult> RealizarPagamento(PagamentoPix pagamento) 
    { 
        pagamento.id_pagamento = Guid.NewGuid().ToString(); 
        pagamento.data_pagamento = DateTime.Now; 
        
        // Lógica para processar o pagamento via Pix 
        await _context.PagamentosPix.AddAsync(pagamento); 
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(ObterComprovante), new { idPagamento = pagamento.id_pagamento }, pagamento); 
    } 

    [HttpGet("{idPagamento}")] 
    public IActionResult ObterComprovante(string idPagamento) 
    { 
        var pagamento = _context.PagamentosPix.FirstOrDefault(p => p.id_pagamento == idPagamento); 
        if (pagamento == null) 
        { 
            return NotFound(); 
        } 
        var comprovante = JsonConvert.SerializeObject(pagamento); 
        return Ok(comprovante); 
    }               

    [HttpGet("GetAll")] 
    public async Task<IActionResult> ObterTodos(string idPagamento) 
    { 
        var pagamento = await _context.PagamentosPix.ToListAsync(); 
        if (pagamento == null) 
        { 
            return NotFound(); 
        }         
        return Ok(pagamento); 
    }            
}