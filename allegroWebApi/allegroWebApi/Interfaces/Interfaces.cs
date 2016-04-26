using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.SqlServer;

namespace allegroWebApi.Interfaces
{
    public interface IDataBaseOperations<T,X>
    {
        void ConnectionOpen();
        void ConnectionClose();
        void SaveDataToDataBase(T x);
        IEnumerable<X> GetDataFromDataBase();
    }
}
