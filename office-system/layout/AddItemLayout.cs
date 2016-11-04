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
    public partial class AddItemLayout : Form
    {
        private DaoManager daoManager;
        private Item item;

        public AddItemLayout()
        {
            InitializeComponent();
            daoManager = DaoManager.getManager();
        }

        internal Item Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("请填完所有表单");
            }else if(numericUpDown1.Value == 0)
            {
                MessageBox.Show("数量不能为0");
            }else
            {
                Item = new Item();
                Item.Name = textBox1.Text;
                Item.Number = Convert.ToString(numericUpDown1.Value);
                Item.Price = textBox2.Text;

                daoManager.getItemDao().add(Item);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < (char)48 || e.KeyChar > (char)57) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox2.Text, out oldf);
                    b2 = float.TryParse(textBox2.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }
    }
}
