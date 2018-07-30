using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace softstoreapi.Models
{
    public class TipoProduto
    {
        public int TipoProdutoId { get; set; }

        public string Nome { get; set; }

        [NotMapped]
        public ObservableCollection<Imposto> Impostos { get; set;}

        public ICollection<TipoProdutoImposto> TiposProdutosImpostos {get; set;} = new List<TipoProdutoImposto>();

        public TipoProduto(string nome, ObservableCollection<Imposto> impostos) {
            Nome = nome;
            Impostos = impostos;
        }

        public TipoProduto(){}
    }
}
