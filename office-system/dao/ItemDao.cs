using office_system.entity;
using office_system.exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace office_system.dao
{
    class ItemDao :Dao<Item>
    {
        private string path;
        private List<Item> items;

        public ItemDao()
        {
            this.path = System.Windows.Forms.Application.StartupPath + "/item.dat";
            read();
        }

        public List<Item> getAll()
        {
            return items;
        }

        public Item getById(int id)
        {
            foreach (Item u in items)
            {
                if (u.Id == id)
                    return u;
            }
            throw new UserNotFoundException();
        }

        public Item getByName(string name)
        {
            foreach (Item u in items)
            {
                if (u.Name.Equals(name))
                    return u;
            }
            throw new UserNotFoundException();
        }

        public void add(Item t)
        {
            int id = 0;
            foreach (Item u in items)
            {
                if (id <= u.Id)
                    id = u.Id;
            }
            t.Id = id + 1;
            items.Add(t);
        }

        public void deleteById(int id)
        {
            Item u;
            for(int i = items.Count - 1; i >=0; i--)
            {
                u = items[i];
                if (u.Id == id)
                {
                    items.RemoveAt(i);
                    return;
                }
            }
            throw new UserNotFoundException();
        }

        public void updateById(int id, Item t)
        {
            Item u;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                u = items[i];
                if (u.Id == id)
                {
                    u.Name = t.Name;
                    u.Price = t.Price;
                    u.Number = t.Number;
                    return;
                }
            }
            throw new UserNotFoundException();
        }

        public void dump()
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, items);

            fs.Close();
        }

        private void read()
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                items = bf.Deserialize(fs) as List<Item>;

                fs.Close();
            }
            else
            {
                items = new List<Item>();
            }
        }
    }
}
