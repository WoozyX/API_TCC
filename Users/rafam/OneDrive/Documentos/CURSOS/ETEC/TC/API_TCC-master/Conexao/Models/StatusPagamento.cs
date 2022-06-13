using Conexao.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic; 

namespace Conexao.Models
{
    public class StatusPagamento
    {
        public int Id { get; set; } = 1;
        public String? dsStatusPagamento { get; set; }
    }
}