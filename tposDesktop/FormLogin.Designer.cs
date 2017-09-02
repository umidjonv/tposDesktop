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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.key_1 = new System.Windows.Forms.Button();
            this.key_2 = new System.Windows.Forms.Button();
            this.key_3 = new System.Windows.Forms.Button();
            this.key_4 = new System.Windows.Forms.Button();
            this.key_5 = new System.Windows.Forms.Button();
            this.key_6 = new System.Windows.Forms.Button();
            this.key_7 = new System.Windows.Forms.Button();
            this.key_8 = new System.Windows.Forms.Button();
            this.key_9 = new System.Windows.Forms.Button();
            this.key_plus = new System.Windows.Forms.Button();
            this.key_0 = new System.Windows.Forms.Button();
            this.key_dot = new System.Windows.Forms.Button();
            this.btnkassaexit = new System.Windows.Forms.Button();
            this.btnPanel.SuspendLayout();
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
            this.tbxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLogin.ForeColor = System.Drawing.Color.Silver;
            this.tbxLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbxLogin.Location = new System.Drawing.Point(278, 255);
            this.tbxLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(180, 29);
            this.tbxLogin.TabIndex = 1;
            this.tbxLogin.Text = "Логин";
            this.tbxLogin.Enter += new System.EventHandler(this.tbxEnter);
            this.tbxLogin.Leave += new System.EventHandler(this.tbxLeave);
            // 
            // tbxPass
            // 
            this.tbxPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPass.ForeColor = System.Drawing.Color.Silver;
            this.tbxPass.Location = new System.Drawing.Point(278, 293);
            this.tbxPass.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(180, 29);
            this.tbxPass.TabIndex = 2;
            this.tbxPass.Text = "Пароль";
            this.tbxPass.Enter += new System.EventHandler(this.tbxEnter);
            this.tbxPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPass_KeyPress);
            this.tbxPass.Leave += new System.EventHandler(this.tbxLeave);
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.BackColor = System.Drawing.SystemColors.Control;
            this.lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(231, 4);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(46, 16);
            this.lblErr.TabIndex = 1;
            this.lblErr.Text = "Error:";
            this.lblErr.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.Navy;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(278, 331);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 34);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Вход";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(673, 83);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPanel
            // 
            this.btnPanel.BackColor = System.Drawing.Color.Turquoise;
            this.btnPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPanel.Controls.Add(this.tbxPassword);
            this.btnPanel.Controls.Add(this.key_1);
            this.btnPanel.Controls.Add(this.key_2);
            this.btnPanel.Controls.Add(this.key_3);
            this.btnPanel.Controls.Add(this.key_4);
            this.btnPanel.Controls.Add(this.key_5);
            this.btnPanel.Controls.Add(this.key_6);
            this.btnPanel.Controls.Add(this.key_7);
            this.btnPanel.Controls.Add(this.key_8);
            this.btnPanel.Controls.Add(this.key_9);
            this.btnPanel.Controls.Add(this.key_plus);
            this.btnPanel.Controls.Add(this.key_0);
            this.btnPanel.Controls.Add(this.key_dot);
            this.btnPanel.Location = new System.Drawing.Point(248, 23);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(232, 305);
            this.btnPanel.TabIndex = 9;
            this.btnPanel.Visible = false;
            this.btnPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("News701 BT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(3, 3);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(225, 50);
            this.tbxPassword.TabIndex = 12;
            this.tbxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // key_1
            // 
            this.key_1.BackColor = System.Drawing.Color.Khaki;
            this.key_1.FlatAppearance.BorderSize = 0;
            this.key_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_1.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_1.Location = new System.Drawing.Point(3, 59);
            this.key_1.Name = "key_1";
            this.key_1.Size = new System.Drawing.Size(70, 55);
            this.key_1.TabIndex = 0;
            this.key_1.Text = "1";
            this.key_1.UseVisualStyleBackColor = false;
            this.key_1.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_2
            // 
            this.key_2.BackColor = System.Drawing.Color.Khaki;
            this.key_2.FlatAppearance.BorderSize = 0;
            this.key_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_2.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_2.Location = new System.Drawing.Point(79, 59);
            this.key_2.Name = "key_2";
            this.key_2.Size = new System.Drawing.Size(70, 55);
            this.key_2.TabIndex = 1;
            this.key_2.Text = "2";
            this.key_2.UseVisualStyleBackColor = false;
            this.key_2.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_3
            // 
            this.key_3.BackColor = System.Drawing.Color.Khaki;
            this.key_3.FlatAppearance.BorderSize = 0;
            this.key_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_3.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_3.Location = new System.Drawing.Point(155, 59);
            this.key_3.Name = "key_3";
            this.key_3.Size = new System.Drawing.Size(70, 55);
            this.key_3.TabIndex = 2;
            this.key_3.Text = "3";
            this.key_3.UseVisualStyleBackColor = false;
            this.key_3.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_4
            // 
            this.key_4.BackColor = System.Drawing.Color.Khaki;
            this.key_4.FlatAppearance.BorderSize = 0;
            this.key_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_4.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_4.Location = new System.Drawing.Point(3, 120);
            this.key_4.Name = "key_4";
            this.key_4.Size = new System.Drawing.Size(70, 55);
            this.key_4.TabIndex = 3;
            this.key_4.Text = "4";
            this.key_4.UseVisualStyleBackColor = false;
            this.key_4.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_5
            // 
            this.key_5.BackColor = System.Drawing.Color.Khaki;
            this.key_5.FlatAppearance.BorderSize = 0;
            this.key_5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_5.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_5.Location = new System.Drawing.Point(79, 120);
            this.key_5.Name = "key_5";
            this.key_5.Size = new System.Drawing.Size(70, 55);
            this.key_5.TabIndex = 4;
            this.key_5.Text = "5";
            this.key_5.UseVisualStyleBackColor = false;
            this.key_5.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_6
            // 
            this.key_6.BackColor = System.Drawing.Color.Khaki;
            this.key_6.FlatAppearance.BorderSize = 0;
            this.key_6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_6.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_6.Location = new System.Drawing.Point(155, 120);
            this.key_6.Name = "key_6";
            this.key_6.Size = new System.Drawing.Size(70, 55);
            this.key_6.TabIndex = 5;
            this.key_6.Text = "6";
            this.key_6.UseVisualStyleBackColor = false;
            this.key_6.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_7
            // 
            this.key_7.BackColor = System.Drawing.Color.Khaki;
            this.key_7.FlatAppearance.BorderSize = 0;
            this.key_7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_7.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_7.Location = new System.Drawing.Point(3, 181);
            this.key_7.Name = "key_7";
            this.key_7.Size = new System.Drawing.Size(70, 55);
            this.key_7.TabIndex = 6;
            this.key_7.Text = "7";
            this.key_7.UseVisualStyleBackColor = false;
            this.key_7.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_8
            // 
            this.key_8.BackColor = System.Drawing.Color.Khaki;
            this.key_8.FlatAppearance.BorderSize = 0;
            this.key_8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_8.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_8.Location = new System.Drawing.Point(79, 181);
            this.key_8.Name = "key_8";
            this.key_8.Size = new System.Drawing.Size(70, 55);
            this.key_8.TabIndex = 7;
            this.key_8.Text = "8";
            this.key_8.UseVisualStyleBackColor = false;
            this.key_8.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_9
            // 
            this.key_9.BackColor = System.Drawing.Color.Khaki;
            this.key_9.FlatAppearance.BorderSize = 0;
            this.key_9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_9.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_9.Location = new System.Drawing.Point(155, 181);
            this.key_9.Name = "key_9";
            this.key_9.Size = new System.Drawing.Size(70, 55);
            this.key_9.TabIndex = 8;
            this.key_9.Text = "9";
            this.key_9.UseVisualStyleBackColor = false;
            this.key_9.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_plus
            // 
            this.key_plus.BackColor = System.Drawing.Color.Red;
            this.key_plus.BackgroundImage = global::tposDesktop.Properties.Resources.delete1;
            this.key_plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.key_plus.FlatAppearance.BorderSize = 0;
            this.key_plus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.key_plus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.key_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_plus.Location = new System.Drawing.Point(3, 242);
            this.key_plus.Name = "key_plus";
            this.key_plus.Size = new System.Drawing.Size(70, 55);
            this.key_plus.TabIndex = 9;
            this.key_plus.UseVisualStyleBackColor = false;
            this.key_plus.Click += new System.EventHandler(this.key_plus_Click);
            // 
            // key_0
            // 
            this.key_0.BackColor = System.Drawing.Color.Khaki;
            this.key_0.FlatAppearance.BorderSize = 0;
            this.key_0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.key_0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.key_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_0.Font = new System.Drawing.Font("News701 BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.key_0.Location = new System.Drawing.Point(79, 242);
            this.key_0.Name = "key_0";
            this.key_0.Size = new System.Drawing.Size(70, 55);
            this.key_0.TabIndex = 10;
            this.key_0.Text = "0";
            this.key_0.UseVisualStyleBackColor = false;
            this.key_0.Click += new System.EventHandler(this.btnKeypress_Click);
            // 
            // key_dot
            // 
            this.key_dot.BackColor = System.Drawing.Color.Red;
            this.key_dot.BackgroundImage = global::tposDesktop.Properties.Resources.back2;
            this.key_dot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.key_dot.FlatAppearance.BorderSize = 0;
            this.key_dot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.key_dot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.key_dot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key_dot.Location = new System.Drawing.Point(155, 242);
            this.key_dot.Name = "key_dot";
            this.key_dot.Size = new System.Drawing.Size(70, 55);
            this.key_dot.TabIndex = 11;
            this.key_dot.UseVisualStyleBackColor = false;
            this.key_dot.Click += new System.EventHandler(this.key_dot_Click);
            // 
            // btnkassaexit
            // 
            this.btnkassaexit.BackColor = System.Drawing.Color.Black;
            this.btnkassaexit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnkassaexit.FlatAppearance.BorderSize = 0;
            this.btnkassaexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnkassaexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnkassaexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkassaexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnkassaexit.ForeColor = System.Drawing.Color.White;
            this.btnkassaexit.Location = new System.Drawing.Point(483, 23);
            this.btnkassaexit.Name = "btnkassaexit";
            this.btnkassaexit.Size = new System.Drawing.Size(30, 30);
            this.btnkassaexit.TabIndex = 10;
            this.btnkassaexit.Text = "X";
            this.btnkassaexit.UseVisualStyleBackColor = false;
            this.btnkassaexit.Visible = false;
            this.btnkassaexit.Click += new System.EventHandler(this.btnkassaexit_Click);
            // 
            // FormLogin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::tposDesktop.Properties.Resources.login3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(724, 406);
            this.Controls.Add(this.btnkassaexit);
            this.Controls.Add(this.btnPanel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.tbxLogin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.LoadForm);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseUp);
            this.btnPanel.ResumeLayout(false);
            this.btnPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FlowLayoutPanel btnPanel;
        private System.Windows.Forms.Button key_plus;
        private System.Windows.Forms.Button key_0;
        private System.Windows.Forms.Button key_1;
        private System.Windows.Forms.Button key_2;
        private System.Windows.Forms.Button key_3;
        private System.Windows.Forms.Button key_4;
        private System.Windows.Forms.Button key_5;
        private System.Windows.Forms.Button key_6;
        private System.Windows.Forms.Button key_7;
        private System.Windows.Forms.Button key_8;
        private System.Windows.Forms.Button key_9;
        private System.Windows.Forms.Button key_dot;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnkassaexit;

    }
}

