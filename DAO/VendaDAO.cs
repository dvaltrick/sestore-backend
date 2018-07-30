using softstoreapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using softstoreapi.Database;
using Microsoft.EntityFrameworkCore;

namespace softstoreapi.DAO
{
    public class VendaDAO:IDAO<Venda>
    {
        public Venda Add(Venda toAdd)
        {
            try
            {
                using (var db = new DBContext())
                {
                    foreach(var item in toAdd.Itens){
                        var prod = db.Produtos.Find(item.Produto.ProdutoId);
                        item.Produto = prod;
                    }

                    db.Vendas.Add(toAdd);
                    db.SaveChanges();

                    return toAdd;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
            
        }

        public void Delete(int toDeleteId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var venda = db.Vendas.Find(toDeleteId);
                    if (venda == null)
                    {
                        throw new Exception("Produto não encontrado");
                    }
                    else {
                        db.Vendas.Remove(venda);
                        db.SaveChanges();
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public IEnumerable<Venda> Get()
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.Vendas
                             .Include(v => v.Itens)
                             .ThenInclude(iv => iv.Produto)
                             .ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public Venda Get(int toGetId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.Vendas.Find(toGetId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public Venda Update(Venda toUpdate)
        {
            try
            {
                using (var db = new DBContext())
                {
                    foreach(var item in toUpdate.Itens){
                        var prod = db.Produtos.Find(item.Produto.ProdutoId);
                        item.Produto = prod;
                    }

                    db.Vendas.Update(toUpdate);
                    db.SaveChanges();

                    return toUpdate;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }
        
    }
}