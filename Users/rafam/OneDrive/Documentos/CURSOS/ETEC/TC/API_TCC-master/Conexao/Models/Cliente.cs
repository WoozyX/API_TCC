using Conexao.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic; 

namespace Conexao.Models
{
    
    public class Cliente
    {
        public int Id{ get; set; } 
        public string? Imei_Cliente { get; set; }
        public string? Email_Cliente { get; set; } 
        public byte[]? PasswordHash { get; set; } 
        public byte[]? PasswordSalt { get; set; } 
        public string? Username { get; set; } 
        public string? Sexo_Cliente { get; set; }
        public string? Telefone_Cliente { get; set; }
        public string? Nascimento_Cliente { get; set; }
        public ClasseEnum? Plano_Cliente { get; set; }

        [NotMapped]
        public string? PasswordString { get; set; }
    }
}