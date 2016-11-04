namespace office_system.layout
{
    partial class AddUserLayout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmB = new System.Windows.Forms.Button();
            this.passwordT = new System.Windows.Forms.TextBox();
            this.nameT = new System.Windows.Forms.TextBox();
            this.roleL = new System.Windows.Forms.Label();
            this.roleC = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "用户名：";
            // 
            // confirmB
            // 
            this.confirmB.Location = new System.Drawing.Point(92, 194);
            this.confirmB.Name = "confirmB";
            this.confirmB.Size = new System.Drawing.Size(100, 23);
            this.confirmB.TabIndex = 7;
            this.confirmB.Text = "确定";
            this.confirmB.UseVisualStyleBackColor = true;
            this.confirmB.Click += new System.EventHandler(this.confirmB_Click);
            // 
            // passwordT
            // 
            this.passwordT.Location = new System.Drawing.Point(118, 94);
            this.passwordT.Name = "passwordT";
            this.passwordT.PasswordChar = '*';
            this.passwordT.Size = new System.Drawing.Size(100, 21);
            this.passwordT.TabIndex = 6;
            // 
            // nameT
            // 
            this.nameT.Location = new System.Drawing.Point(118, 53);
            this.nameT.Name = "nameT";
            this.nameT.Size = new System.Drawing.Size(100, 21);
            this.nameT.TabIndex = 5;
            // 
            // roleL
            // 
            this.roleL.AutoSize = true;
            this.roleL.Location = new System.Drawing.Point(71, 136);
            this.roleL.Name = "roleL";
            this.roleL.Size = new System.Drawing.Size(41, 12);
            this.roleL.TabIndex = 10;
            this.roleL.Text = "角色：";
            // 
            // roleC
            // 
            this.roleC.FormattingEnabled = true;
            this.roleC.Location = new System.Drawing.Point(119, 136);
            this.roleC.Name = "roleC";
            this.roleC.Size = new System.Drawing.Size(99, 20);
            this.roleC.TabIndex = 11;
            // 
            // AddUserLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.roleC);
            this.Controls.Add(this.roleL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmB);
            this.Controls.Add(this.passwordT);
            this.Controls.Add(this.nameT);
            this.Name = "AddUserLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddUserLayout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmB;
        private System.Windows.Forms.TextBox passwordT;
        private System.Windows.Forms.TextBox nameT;
        private System.Windows.Forms.Label roleL;
        private System.Windows.Forms.ComboBox roleC;
    }
}