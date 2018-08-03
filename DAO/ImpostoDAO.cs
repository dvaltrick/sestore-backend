using softstoreapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using softstoreapi.Database;

namespace softstoreapi.DAO
{
    public class ImpostoDAO : IDAO<Imposto>
    {
        public virtual Imposto Add(Imposto toAdd)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Impostos.Add(toAdd);
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
                    var imposto = db.Impostos.Find(toDeleteId);
                    if (imposto == null)
                    {
                        throw new Exception("Imposto não encontrado");
                    }
                    else {
                        db.Impostos.Remove(imposto);
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

        public IEnumerable<Imposto> Get()
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.Impostos.ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public Imposto Get(int toGetId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    return db.Impostos.Find(toGetId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Não foi possível realizar a operação.");
            }
        }

        public Imposto Update(Imposto toUpdate)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Impostos.Update(toUpdate);
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
