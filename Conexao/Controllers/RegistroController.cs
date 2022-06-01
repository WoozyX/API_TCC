using Conexao.Data;
using Conexao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Conexao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        
        private Registro r = new Registro();

        /*public IActionResult Get()
        {
            return Ok(r);
        }*/

        //lista de contato para teste

        private static List<Registro> Registros = new List<Registro>
        {
            new Registro(),
            /*new Registro {  Id = 1, Latitude = "-23.4847175", Longitude = "-46.5639609"}*/
        };

        //base de dados

        private readonly DataContext _context;

        public RegistroController(DataContext context)
        {
            _context = context;
        }

        //Método de Consulta pelo ID

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Registro r = await _context.Registro.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(r);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        //Consultar Todos
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetRegistros()
        {
            try
            {
                List<Registro> lista = await _context.Registro.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }


        }

        //postando registro

        [HttpPost]

        public async Task<IActionResult> Add (Registro novoRegistro)
        {
            try
            {
                await _context.Registro.AddAsync(novoRegistro);
                await _context.SaveChangesAsync();

                return Ok(novoRegistro.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetbyOccorrencia/{tpOcorrenciasId}")]

        public async Task<IActionResult> GetOcorrencias(int tpOcorrenciasId)
        {
            try
            {
                
                List<Registro> lista = await _context.Registro.Where(r => r.TiposOcorrenciasId == tpOcorrenciasId).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            


        }

        
        







    }




}