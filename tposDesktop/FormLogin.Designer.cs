namespace tposDesktop
{
    partial class FormLogin
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.lblErr = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TouchPos";
            this.notifyIcon1.Visible = true;
            // 
            // tbxLogin
            // 
            this.tbxLogin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbxLogin.Location = new System.Drawing.Point(263, 119);
            this.tbxLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(180, 29);
            this.tbxLogin.TabIndex = 0;
            this.tbxLogin.Text = "Логин";
            this.tbxLogin.Enter += new System.EventHandler(this.tbxEnter);
            this.tbxLogin.Leave += new System.EventHandler(this.tbxLeave);
            // 
            // tbxPass
            // 
            this.tbxPass.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbxPass.Location = new System.Drawing.Point(263, 160);
            this.tbxPass.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(180, 29);
            this.tbxPass.TabIndex = 0;
            this.tbxPass.Text = "Пароль";
            this.tbxPass.Enter += new System.EventHandler(this.tbxEnter);
            this.tbxPass.Leave += new System.EventHandler(this.tbxLeave);
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(260, 244);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(40, 16);
            this.lblErr.TabIndex = 1;
            this.lblErr.Text = "Error:";
            this.lblErr.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(263, 198);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 34);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Вход";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 376);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.tbxLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Button btnLogin;

    }
}

