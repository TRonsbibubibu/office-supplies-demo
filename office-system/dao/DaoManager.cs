using office_system.entity;
using office_system.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace office_system.dao
{
    class DaoManager
    {
        private UserDao userDao;
        private ItemDao itemDao;

        private static DaoManager daoManager;
        private DaoManager()
        {
            
        }

        public static DaoManager getManager()
        {
            if (daoManager == null)
                daoManager = new DaoManager();
            return daoManager;
        }

        public UserDao getUserDao()
        {
            if (userDao == null)
                userDao = new UserDao();
            return userDao;
        }

        public ItemDao getItemDao()
        {
            if (itemDao == null)
                itemDao = new ItemDao();
            return itemDao;
        }

        public void dump()
        {
            userDao.dump();
            itemDao.dump();
        }
    }
}
