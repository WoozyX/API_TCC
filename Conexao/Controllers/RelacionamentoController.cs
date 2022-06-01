using Microsoft.AspNetCore.Mvc;
using Conexao.Models;
using Conexao.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Conexao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelacionamentoController : ControllerBase
    {
        private Relacionamento r = new Relacionamento();

        private readonly DataContext _context;

        public RelacionamentoController(DataContext context)
        {
            _context = context;
        }

        //Buscar pelo cliente associado
        [HttpGet("GetByUser/{ClienteId}")]

        public async Task<IActionResult> GetByUser(int ClienteId)
        {
            try
            {
                
                List<Relacionamento> lista = await _context.Relacionamento.Where(c => c.ClienteId == ClienteId).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            


        }


        //Buscar pelo relacionamento
        [HttpGet("tpRelacionamento/{TipoRelacionamentoId}")]

        public async Task<IActionResult> GetRelacionamento(int TipoRelacionamentoId)
        {
            try
            {
                
                List<Relacionamento> lista = await _context.Relacionamento.Where(r => r.TipoRelacionamentoId == TipoRelacionamentoId).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            


        }


        //Registrar Relacionamento
        [HttpPost]

        public async Task<IActionResult> Add (Relacionamento novoRelacionamento)
        {
            try
            {
                await _context.Relacionamento.AddAsync(novoRelacionamento);
                await _context.SaveChangesAsync();

                return Ok(novoRelacionamento.Id);
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
                Relacionamento rRemover = await _context.Relacionamento.FirstOrDefaultAsync(r => r.Id == id);

                _context.Relacionamento.Remove(rRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Atualizar
        [HttpPut]

        public async Task<IActionResult> Update(Relacionamento novoRelacionamento)
        {
            try
            {
                _context.Relacionamento.Update(novoRelacionamento);
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