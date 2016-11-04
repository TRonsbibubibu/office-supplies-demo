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
    public partial class DeleteUserLayout : Form
    {
        private DaoManager daoManager;

        public DeleteUserLayout()
        {
            InitializeComponent();
            daoManager = DaoManager.getManager();
            this.fill();
        }

        public void fill()
        {
            List<User> users = daoManager.getUserDao().getAll();
            ListViewItem it;
            foreach(User u in users)
            {
                it = new ListViewItem();
                it.Text = u.Id.ToString();
                it.SubItems.Add(u.Name);
                it.SubItems.Add(u.Role.ToString());
                this.userList.Items.Add(it);
            }

            this.userList.EndUpdate();
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.userList.SelectedItems[0];
            if (item == null)
            {
                MessageBox.Show("请选择删除的用户");
                return;
            }

            this.userList.Items.Remove(item);
            daoManager.getUserDao().deleteById(
                    Convert.ToInt32(
                            item.Text
                        )
                );
        }
    }
}
