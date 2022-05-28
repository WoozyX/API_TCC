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

        public async Task<IActionResult> Get()
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
        

        
    }
        
}
