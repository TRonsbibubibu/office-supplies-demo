using office_system.dao;
using office_system.entity;
using office_system.layout;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace office_system
{
    public partial class MainForm : Form
    {
        private double sum = 0;
        private User user = null;

        private DaoManager daoManager;
        
        public MainForm()
        {
            InitializeComponent();

            daoManager = DaoManager.getManager();
            login();
            stockRecord_init();
        }

        private void login()
        {
            /**
             * 登录框启动
             * */
            LoginLayout login = new LoginLayout();
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {
                user = login.User;
            }else
            {
                System.Environment.Exit(0);
            }

            if (user == null)
            {
                MessageBox.Show("非法登录");
                System.Environment.Exit(0);
            }
        }

        private void stockRecord_init()
        {
            /**
             * 初始化listView
             **/
            List<Item> items = daoManager.getItemDao().getAll();
            ListViewItem it;
            foreach (Item i in items)
            {
                it = new ListViewItem();
                it.Text = i.Id.ToString();
                it.SubItems.Add(i.Name);
                it.SubItems.Add(i.Price);
                it.SubItems.Add(i.Number);
                it.SubItems.Add(i.Created_at.ToString());
                this.stockRecord.Items.Add(it);

                sum += Convert.ToDouble(i.Price) * int.Parse(i.Number);
            }
        
            label3.Text = sum.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            welcomeL.Text = user.Name + ",你好！";

            if (user.Role == User.Privilege.user)
            {
                用戶ToolStripMenuItem.Visible = false;
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddItemLayout addItemLayout = new AddItemLayout();
            addItemLayout.ShowDialog();
            if(addItemLayout.DialogResult == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem(new string[] {
                addItemLayout.Item.Id.ToString(),addItemLayout.Item.Name, addItemLayout.Item.Price,addItemLayout.Item.Number ,addItemLayout.Item.Created_at.ToString()}, 0
              );
                stockRecord.Items.Add(item);
                MessageBox.Show("添加成功！！！");
            }

            sum += Convert.ToDouble(addItemLayout.Item.Price) * int.Parse(addItemLayout.Item.Number);
            label3.Text = sum.ToString();
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = stockRecord.SelectedItems;
            foreach (ListViewItem item in items)
            {
                stockRecord.Items.Remove(item);
                daoManager.getItemDao().deleteById(Convert.ToInt32(
                            item.Text
                        ));
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            daoManager.dump();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /**
            * 添加用戶启动
            * */
            AddUserLayout addUser = new AddUserLayout();
            addUser.ShowDialog();

            if (addUser.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("添加成功！！！");
            }
        }

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUserLayout deleteUser = new DeleteUserLayout();
            deleteUser.ShowDialog();
        }
    }
}
