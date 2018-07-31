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
        private ObservableCollection<Imposto> _impostos;

        public int TipoProdutoId { get; set; }

        public string Nome { get; set; }

        public ICollection<TipoProdutoImposto> TiposProdutosImpostos {get; set;} = new List<TipoProdutoImposto>();

        [NotMapped]
        public ObservableCollection<Imposto> Impostos { 
            get{
                if(_impostos == null){
                    var imps = new ObservableCollection<Imposto>();
                    foreach (var imp in TiposProdutosImpostos)
                    {
                        imps.Add(imp.Imposto);
                    }
                    return imps;
                }else{
                    return _impostos;
                }
            } 
            set{
                _impostos = value;
            }
        }

        public TipoProduto(string nome, ObservableCollection<Imposto> impostos) {
            Nome = nome;
            Impostos = impostos;
        }

        public TipoProduto(){}
    }
}
