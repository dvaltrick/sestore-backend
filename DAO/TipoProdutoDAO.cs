using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using softstoreapi.Database;
using softstoreapi.Models;
using Microsoft.EntityFrameworkCore;

namespace softstoreapi.DAO
{
    public class TipoProdutoDAO:IDAO<TipoProduto>
    {
        public TipoProduto Add(TipoProduto toAdd)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.TiposProduto.Add(toAdd);

                    foreach(var imposto in toAdd.Impostos){
                        var toSaveImposto = imposto; 
                        
                        if(imposto.ImpostoId > 0){
                            toSaveImposto = db.Impostos.Find(imposto.ImpostoId);
                        }

                        db.TipoProdutoImposto.Add(new TipoProdutoImposto{
                            TipoProduto = toAdd,
                            Imposto = toSaveImposto
                        });
                    }

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
                    var tipo = db.TiposProduto.Find(toDeleteId);
                    if (tipo == null)
                    {
                        throw new Exception("Imposto não encontrado");
                    }
                    else {
                        db.TiposProduto.Remove(tipo);
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

        public IEnumerable<TipoProduto> Get()
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.TiposProduto
                             .Include(tp => tp.TiposProdutosImpostos)
                             .ThenInclude(imp => imp.Imposto)
                             .ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public TipoProduto Get(int toGetId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.TiposProduto.Find(toGetId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public TipoProduto Update(TipoProduto toUpdate)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.TiposProduto.Update(toUpdate);
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