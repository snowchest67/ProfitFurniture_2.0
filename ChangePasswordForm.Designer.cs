namespace ProfitFurniture_2._0
{
    partial class ChangePasswordForm
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
            button1 = new Button();
            textBoxLogin = new TextBox();
            textBoxCurrentPassword = new TextBox();
            textBoxNewPassword = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.SlateGray;
            button1.Font = new Font("Bookman Old Style", 9F, FontStyle.Bold);
            button1.ForeColor = Color.AliceBlue;
            button1.Location = new Point(41, 138);
            button1.Name = "button1";
            button1.Size = new Size(258, 44);
            button1.TabIndex = 3;
            button1.Text = "Подтвердить изменение пароля";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ChangePassword_Click;
            // 
            // textBoxLogin
            // 
            textBoxLogin.BackColor = Color.Gainsboro;
            textBoxLogin.Cursor = Cursors.IBeam;
            textBoxLogin.Font = new Font("Courier New", 10.2F);
            textBoxLogin.ForeColor = Color.DimGray;
            textBoxLogin.Location = new Point(41, 40);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(258, 27);
            textBoxLogin.TabIndex = 0;
            textBoxLogin.Text = "Логин";
            textBoxLogin.Click += textBoxLogin_Click;
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.BackColor = Color.Gainsboro;
            textBoxCurrentPassword.Cursor = Cursors.IBeam;
            textBoxCurrentPassword.Font = new Font("Courier New", 10.2F);
            textBoxCurrentPassword.ForeColor = Color.DimGray;
            textBoxCurrentPassword.Location = new Point(41, 73);
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.Size = new Size(258, 27);
            textBoxCurrentPassword.TabIndex = 1;
            textBoxCurrentPassword.Text = "Пароль";
            textBoxCurrentPassword.Click += textBoxCurrentPassword_Click;
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.BackColor = Color.Gainsboro;
            textBoxNewPassword.Cursor = Cursors.IBeam;
            textBoxNewPassword.Font = new Font("Courier New", 10.2F);
            textBoxNewPassword.ForeColor = Color.DimGray;
            textBoxNewPassword.Location = new Point(41, 106);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.Size = new Size(258, 27);
            textBoxNewPassword.TabIndex = 2;
            textBoxNewPassword.Text = "Новый пароль";
            textBoxNewPassword.Click += textBoxNewPassword_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 211);
            Controls.Add(textBoxNewPassword);
            Controls.Add(textBoxCurrentPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBoxLogin;
        private TextBox textBoxCurrentPassword;
        private TextBox textBoxNewPassword;
    }
}