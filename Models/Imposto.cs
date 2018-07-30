using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace softstoreapi.Models
{
    public class Imposto
    {
        public int ImpostoId { get; set; }

        public string Nome { get; set; }

        public float Percentual { get; set; }

        [JsonIgnore]
        public ICollection<TipoProdutoImposto> TiposProdutosImpostos {get; set;} = new List<TipoProdutoImposto>();


        public Imposto(string nome, float percentual) {
            Nome = nome;
            Percentual = percentual;
        }

        public Imposto(){}
    }
}
