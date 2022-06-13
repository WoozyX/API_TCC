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
    public class ContatoController : ControllerBase
    {
        
        private Contato c = new Contato();

        

        private readonly DataContext _context;

        public ContatoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Add (Contato novoContato)
        {
            try
            {
                await _context.Contato.AddAsync(novoContato);
                await _context.SaveChangesAsync();

                return Ok(novoContato.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetContatos()
        {
            try
            {
                List<Contato> lista = await _context.Contato.ToListAsync();
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
                
                List<Contato> lista = await _context.Contato.Where(c => c.ClienteId == ClienteId).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            


        }

        //Deletar
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Contato cRemover = await _context.Contato.FirstOrDefaultAsync(c => c.Id == id);

                _context.Contato.Remove(cRemover);
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

        public async Task<IActionResult> Update(Contato novoContato)
        {
            try
            {
                _context.Contato.Update(novoContato);
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
