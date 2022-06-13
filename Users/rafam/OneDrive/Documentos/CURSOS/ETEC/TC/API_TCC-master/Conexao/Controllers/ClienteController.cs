using Conexao.Data;
using Conexao.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Conexao.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Conexao.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class ClienteController : ControllerBase
    {

        public Cliente c = new Cliente();

        public IActionResult GetPuxar()
        {
            return Ok(Clientes);
        }

    //Lista Personagens
        private static List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente() { Id = 1},
            new Cliente() { Id = 2, Imei_Cliente = "1234567895", Email_Cliente = "jose2@gmail.com", Username = "Jose", Sexo_Cliente = "Masculino", Telefone_Cliente = "2366-56241", Nascimento_Cliente = "1994-03-12", Plano_Cliente = ClasseEnum.Premium},
            new Cliente() { Id = 3, Imei_Cliente = "5456478546", Email_Cliente = "silvia3@gmail.com", Username = "Silvia", Sexo_Cliente = "Feminino", Telefone_Cliente = "45687-1547", Nascimento_Cliente = "2000-02-14", Plano_Cliente = ClasseEnum.Premium}
        };





    //Configurando para os dadas serem direcionado á base dados
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }


    //Criando Criptografia de senha
        private void CriarPasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    //verificar se o Cliente exixte no banco

        public async Task<bool> ClienteExistente(string username)
        {
            if( await _context.Clientes.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        //Puxar todos

        [HttpGet("GetAll")]
         
        public async Task<IActionResult> Getall()
        {
            try
            {
                List<Cliente> lista = await _context.Clientes.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }


    //Método para registrar Cliente

        [HttpPost("Registrar")]

        public async Task<IActionResult> RegistrarCliente(Cliente user)
        {
            try
            {
                if(await ClienteExistente(user.Username))
                    throw new System.Exception("Nome de Usuário já existe");

                CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash =hash;
                user.PasswordSalt = salt;

                await _context.Clientes.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch(Exception ex)
            {   
                return BadRequest(ex.Message);

            }
        
        
        }
    
    //Autenticar Usuário

        private bool VerificarPasswordHash( string password, byte[] hash, byte[] salt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++ )
                {
                    if(computedHash[i] != hash[i] )
                    {
                        return false;

                    }
                }
                return false;
            }
        }

    //Autenticar Usuário 
        [HttpPost("Autenticar")]

        public async Task<IActionResult> AutenticarCliente(Cliente credenciais)
        {
            try
            {
                Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if(cliente == null)
                {
                    throw new System.Exception("Usuário não encontrado");
                }
                else if (VerificarPasswordHash(credenciais.PasswordString, cliente.PasswordHash, cliente.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    
                    return Ok(cliente.Email_Cliente);
                    
                }
            }
            catch(Exception ex)
            {   
                return BadRequest(ex.Message);

            }
        
        
        }

















    }
}