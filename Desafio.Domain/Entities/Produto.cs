﻿using System.ComponentModel.DataAnnotations;

namespace Desafio.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
