using office_system.dao;
using office_system.entity;
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
    public partial class AddUserLayout : Form
    {
        private DaoManager daoManager;

        public AddUserLayout()
        {
            InitializeComponent();
            daoManager = DaoManager.getManager();

            roleC.Items.AddRange(new string[] { "admin", "user"});
            roleC.SelectedIndex = 0;
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

            User.Privilege role;
            switch ((string)roleC.SelectedItem)
            {
                case "admin":role = User.Privilege.admin;break;
                case "user":role = User.Privilege.user;break;
                default:role = User.Privilege.user;break;
            }
          
            if (daoManager.getUserDao().UserExisted(name))
            {
                MessageBox.Show("用戶已存在！！！");
                return;
            }

            User user = new User(name, password, role);
            daoManager.getUserDao().add(user);
            this.DialogResult = DialogResult.OK;
        }
    }
}
