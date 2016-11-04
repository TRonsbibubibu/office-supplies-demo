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
    class UserDao :Dao<User>
    {
        private string path;
        private List<User> users;

        public UserDao()
        {
            this.path = System.Windows.Forms.Application.StartupPath + "/user.dat";
            read();
        }

        public List<User> getAll()
        {
            return users;
        }

        public User getById(int id)
        {
            foreach (User u in users)
            {
                if (u.Id == id)
                    return u;
            }
            throw new UserNotFoundException();
        }

        public User getByName(string name)
        {
            foreach (User u in users)
            {
                if (u.Name.Equals(name))
                    return u;
            }
            throw new UserNotFoundException();
        }

        public void add(User t)
        {
            int id = 0;
            foreach(User u in users)
            {
                if (id <= u.Id)
                    id = u.Id;
            }
            t.Id = id + 1;
            users.Add(t);
        }

        public void deleteById(int id)
        {
            User u;
            for(int i = users.Count - 1; i >=0; i--)
            {
                u = users[i];
                if (u.Id == id)
                {
                    users.RemoveAt(i);
                    return;
                }
            }
            throw new UserNotFoundException();
        }

        public void updateById(int id, User t)
        {
            User u;
            for (int i = users.Count - 1; i >= 0; i--)
            {
                u = users[i];
                if (u.Id == id)
                {
                    u.Name = t.Name;
                    u.Password = t.Password;
                    u.Role = t.Role;
                    return;
                }
            }
            throw new UserNotFoundException();
        }

        public bool UserExisted(string name)
        {
            foreach (User u in users)
            {
                if (u.Name.Equals(name))
                    return true;
            }
            return false;
        }

        public void dump()
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, users);

            fs.Close();
        }

        private void read()
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                users = bf.Deserialize(fs) as List<User>;
              
                fs.Close();
            }
            else
            {
                users = new List<User>();
                User admin = new User();
                admin.Id = 1;
                admin.Name = "admin";
                admin.Password = "123456";
                admin.Role = User.Privilege.admin;
                users.Add(admin);
            }
        }
    }
}
