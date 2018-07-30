using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace softstoreapi.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string CodigoBarras {get; set;}

        public TipoProduto Tipo { get; set; }

        public float ValorUnitario { get; set; }

        public Produto(string nome, TipoProduto tipo, float valorUnitario) {
            Nome = nome;
            Tipo = tipo;
            ValorUnitario = valorUnitario;
        }

        public Produto(){}
    }
}
