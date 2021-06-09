
namespace Authorization
{
    partial class AuthForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginLbl = new System.Windows.Forms.Label();
            this.passLbl = new System.Windows.Forms.Label();
            this.loginTxtBox = new System.Windows.Forms.TextBox();
            this.passTxtBox = new System.Windows.Forms.TextBox();
            this.introLbl = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.guestLoginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginLbl.Location = new System.Drawing.Point(44, 78);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(52, 20);
            this.loginLbl.TabIndex = 0;
            this.loginLbl.Text = "Логин";
            this.loginLbl.Click += new System.EventHandler(this.loginLbl_Click);
            // 
            // passLbl
            // 
            this.passLbl.AutoSize = true;
            this.passLbl.Location = new System.Drawing.Point(44, 116);
            this.passLbl.Name = "passLbl";
            this.passLbl.Size = new System.Drawing.Size(62, 20);
            this.passLbl.TabIndex = 1;
            this.passLbl.Text = "Пароль";
            // 
            // loginTxtBox
            // 
            this.loginTxtBox.Location = new System.Drawing.Point(107, 75);
            this.loginTxtBox.Name = "loginTxtBox";
            this.loginTxtBox.Size = new System.Drawing.Size(188, 27);
            this.loginTxtBox.TabIndex = 2;
            // 
            // passTxtBox
            // 
            this.passTxtBox.Location = new System.Drawing.Point(107, 114);
            this.passTxtBox.Name = "passTxtBox";
            this.passTxtBox.Size = new System.Drawing.Size(188, 27);
            this.passTxtBox.TabIndex = 3;
            // 
            // introLbl
            // 
            this.introLbl.AutoSize = true;
            this.introLbl.Location = new System.Drawing.Point(107, 36);
            this.introLbl.Name = "introLbl";
            this.introLbl.Size = new System.Drawing.Size(163, 20);
            this.introLbl.TabIndex = 4;
            this.introLbl.Text = "Введите ваши данные";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(107, 149);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(188, 29);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "Войти";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // guestLoginBtn
            // 
            this.guestLoginBtn.Location = new System.Drawing.Point(107, 184);
            this.guestLoginBtn.Name = "guestLoginBtn";
            this.guestLoginBtn.Size = new System.Drawing.Size(188, 29);
            this.guestLoginBtn.TabIndex = 6;
            this.guestLoginBtn.Text = "Войти как Гость";
            this.guestLoginBtn.UseVisualStyleBackColor = true;
            this.guestLoginBtn.Click += new System.EventHandler(this.guestLoginBtn_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 220);
            this.Controls.Add(this.guestLoginBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.introLbl);
            this.Controls.Add(this.passTxtBox);
            this.Controls.Add(this.loginTxtBox);
            this.Controls.Add(this.passLbl);
            this.Controls.Add(this.loginLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "AuthForm";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.Label passLbl;
        private System.Windows.Forms.TextBox loginTxtBox;
        private System.Windows.Forms.TextBox passTxtBox;
        private System.Windows.Forms.Label introLbl;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button guestLoginBtn;
    }
}

