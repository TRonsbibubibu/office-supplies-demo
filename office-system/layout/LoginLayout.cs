using office_system.dao;
using office_system.entity;
using office_system.exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace office_system.layout
{
    public partial class LoginLayout : Form
    {
        private DaoManager daoManager;
        private User user;

        internal User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public LoginLayout()
        {
            InitializeComponent();
            daoManager = DaoManager.getManager();
        }

        private void confirmB_Click(object sender, EventArgs e)
        {
            if (nameT.TextLength == 0 || passwordT.TextLength == 0)
            {
                MessageBox.Show("请填完所有表单");
                return;
            }

            string name = nameT.Text;
            string password = passwordT.Text;

            try
            {
                User check = daoManager.getUserDao().getByName(name);
                if (!check.Password.Equals(password))
                {
                    MessageBox.Show("密码错误");
                    return;
                }
                else
                {
                    User = check;
                    this.DialogResult = DialogResult.OK;
                }
            }catch(UserNotFoundException)
            {
                MessageBox.Show("用户不存在啊！！！！");
            }
        }

        private void LoginLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
