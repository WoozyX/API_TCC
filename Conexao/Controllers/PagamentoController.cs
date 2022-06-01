using Microsoft.AspNetCore.Mvc;
using Conexao.Models;
using Conexao.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Conexao.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        
        private Pagamento p = new Pagamento();

        

        private readonly DataContext _context;

        public PagamentoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Add (Pagamento novoPagamento)
        {
            try
            {
                await _context.Pagamento.AddAsync(novoPagamento);
                await _context.SaveChangesAsync();

                return Ok(novoPagamento.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetPagamentos()
        {
            try
            {
                List<Pagamento> lista = await _context.Pagamento.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        //Consultar cliente pelo id do Usuário 
        [HttpGet("{ClienteId}")]

        public async Task<IActionResult> GetByUser(int ClienteId)
        {
            try
            {
                
                List<Pagamento> lista = await _context.Pagamento.Where(c => c.ClienteId == ClienteId).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            


        }

        [HttpGet("statuspagamento/{StatusPagamentoId}")]

        public async Task<IActionResult> GetStPagamento(int StatusPagamentoId)
        {
            try
            {
                
                List<Pagamento> lista = await _context.Pagamento.Where(c => c.StatusPagId == StatusPagamentoId).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            


        }

        [HttpPut]

        public async Task<IActionResult> Update(Pagamento novoPagamento)
        {
            try
            {
                _context.Pagamento.Update(novoPagamento);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Pagamento pRemover = await _context.Pagamento.FirstOrDefaultAsync(p => p.Id == id);

                _context.Pagamento.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        

        
        

        
    }
        
}