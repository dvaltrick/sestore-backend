using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace softstoreapi.Models
{
    public class Venda
    {
        public int VendaId { get; set; }

        public ObservableCollection<ItemVenda> Itens { get; set; } = new ObservableCollection<ItemVenda>();

        public float Total { get; set; }

        public Venda(ObservableCollection<ItemVenda> itens, float total) {
            Itens = itens;
            Total = total;
        }

        public Venda(){}
    }
}
