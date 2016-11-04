using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace office_system.dao
{
    interface Dao<T>
    {
        List<T> getAll();

        T getById(int id);

        void add(T t);

        void deleteById(int id);

        void updateById(int id, T t);

        void dump();
    }
}
