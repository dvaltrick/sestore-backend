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
    public class ProdutoDAO
    {
        public Produto Add(Produto toAdd)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var tipoEncontrado = db.TiposProduto.Find(toAdd.Tipo.TipoProdutoId);
                    toAdd.Tipo = tipoEncontrado;
                    db.Produtos.Add(toAdd);
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
                    var produto = db.Produtos.Find(toDeleteId);
                    if (produto == null)
                    {
                        throw new Exception("Produto não encontrado");
                    }
                    else {
                        db.Produtos.Remove(produto);
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

        public IEnumerable<Produto> Get()
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.Produtos.Include(p => p.Tipo)
                                      .ThenInclude(i => i.TiposProdutosImpostos)
                                      .ThenInclude(i => i.Imposto)
                                      .ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public Produto Get(int toGetId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.Produtos.Find(toGetId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public Produto Update(Produto toUpdate)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var tipoEncontrado = db.TiposProduto.Find(toUpdate.Tipo.TipoProdutoId);
                    toUpdate.Tipo = tipoEncontrado;
                    db.Produtos.Update(toUpdate);
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