namespace tposDesktop
{
    partial class AddUser
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPass = new System.Windows.Forms.Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.lblRepass = new System.Windows.Forms.Label();
            this.tbxRepass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(153, 33);
            this.lblCaption.Text = "Добавить";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Yellow;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnAdd.Location = new System.Drawing.Point(371, 233);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 46);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxName.Location = new System.Drawing.Point(202, 92);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(327, 28);
            this.tbxName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label1.Location = new System.Drawing.Point(8, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Имя пользователя:";
            // 
            // btnPass
            // 
            this.btnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnPass.Location = new System.Drawing.Point(12, 237);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(164, 40);
            this.btnPass.TabIndex = 18;
            this.btnPass.Text = "Сменить пароль";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Visible = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblPass.Location = new System.Drawing.Point(8, 141);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(81, 24);
            this.lblPass.TabIndex = 20;
            this.lblPass.Text = "Пароль:";
            // 
            // tbxPass
            // 
            this.tbxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxPass.Location = new System.Drawing.Point(202, 137);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(327, 28);
            this.tbxPass.TabIndex = 19;
            // 
            // lblRepass
            // 
            this.lblRepass.AutoSize = true;
            this.lblRepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblRepass.Location = new System.Drawing.Point(8, 187);
            this.lblRepass.Name = "lblRepass";
            this.lblRepass.Size = new System.Drawing.Size(150, 24);
            this.lblRepass.TabIndex = 22;
            this.lblRepass.Text = "Повтор пароля:";
            // 
            // tbxRepass
            // 
            this.tbxRepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxRepass.Location = new System.Drawing.Point(202, 183);
            this.tbxRepass.Name = "tbxRepass";
            this.tbxRepass.PasswordChar = '*';
            this.tbxRepass.Size = new System.Drawing.Size(327, 28);
            this.tbxRepass.TabIndex = 21;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 291);
            this.Controls.Add(this.lblRepass);
            this.Controls.Add(this.tbxRepass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.tbxName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnPass, 0);
            this.Controls.SetChildIndex(this.tbxPass, 0);
            this.Controls.SetChildIndex(this.lblPass, 0);
            this.Controls.SetChildIndex(this.tbxRepass, 0);
            this.Controls.SetChildIndex(this.lblRepass, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Label lblRepass;
        private System.Windows.Forms.TextBox tbxRepass;
    }
}