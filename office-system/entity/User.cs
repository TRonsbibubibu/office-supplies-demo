using System;

namespace office_system.entity
{
    [Serializable]
    class User
    {
        private int id;
        private string name;
        private string password;
        private Privilege role;
        private DateTime created_at;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public Privilege Role
        {
            get
            {
                return role;
            }

            set
            {
                this.role = value;
            }
        }

        public DateTime Create_at
        {
            get
            {
                return created_at;
            }

            set
            {
                created_at = value;
            }
        }

        public enum Privilege { admin, user};


        

       

        public User()
        {
            this.created_at = DateTime.Now;
        }

        public User(string name, string password, Privilege role)
        {
            this.Name = name;
            this.Password = password;
            this.role = role;
            this.created_at = DateTime.Now;
        }
    }
}
