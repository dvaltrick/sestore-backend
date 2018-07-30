using Newtonsoft.Json;

namespace softstoreapi.Models
{

    public class TipoProdutoImposto
    {
        [JsonIgnore]
        public TipoProduto TipoProduto {get; set;}

        public int TipoProdutoId {get; set;}

        public Imposto Imposto {get; set;}

        public int ImpostoId {get; set;}

        public TipoProdutoImposto(){}
    }
}