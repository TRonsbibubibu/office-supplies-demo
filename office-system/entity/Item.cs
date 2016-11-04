using System;

namespace office_system.entity
{
    [Serializable]
    class Item
    {
        private int id;
        private string name;
        private string price;
        private string number;
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

        public string Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public DateTime Created_at
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

        public Item()
        {
            this.created_at = DateTime.Now;
        }
    }
}
