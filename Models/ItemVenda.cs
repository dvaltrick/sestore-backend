using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace softstoreapi.Models
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }

        public Produto Produto { get; set; }

        public float Quantidade { get; set; }

        public float TotalItem { get; set; }

        public ItemVenda(Produto produto, float quantidade, float totalItem) {
            Produto = produto;
            Quantidade = quantidade;
            TotalItem = totalItem;
        }

        public ItemVenda(){}
    }
}
