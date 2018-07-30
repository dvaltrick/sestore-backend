using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace softstoreapi.DAO
{
    public interface IDAO<T>
    {
        IEnumerable<T> Get();

        T Get(int toGetId);

        T Add(T toAdd);

        T Update(T toUpdate);

        void Delete(int toDeleteId);
    }
}
