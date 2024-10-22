namespace ProfitFurniture_2._0
{
    partial class Authoriz
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            toEnter = new Button();
            Registr = new Button();
            Entry = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("Stencil", 36F);
            label1.ForeColor = Color.SlateGray;
            label1.Location = new Point(20, 31);
            label1.Name = "label1";
            label1.Size = new Size(592, 71);
            label1.TabIndex = 6;
            label1.Text = "Profit Furniture";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.AliceBlue;
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(toEnter);
            groupBox1.Controls.Add(Registr);
            groupBox1.Controls.Add(Entry);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 7.8F);
            groupBox1.Location = new Point(67, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(667, 341);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.iconicAuthoriz_;
            pictureBox1.Location = new Point(95, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(124, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 7.8F, FontStyle.Underline);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(266, 305);
            label2.Name = "label2";
            label2.Size = new Size(119, 18);
            label2.TabIndex = 7;
            label2.Text = "изменить пароль";
            label2.Click += ChangePassword_Click;
            // 
            // toEnter
            // 
            toEnter.BackColor = Color.SlateGray;
            toEnter.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            toEnter.ForeColor = Color.AliceBlue;
            toEnter.Location = new Point(95, 258);
            toEnter.Name = "toEnter";
            toEnter.Size = new Size(458, 44);
            toEnter.TabIndex = 0;
            toEnter.Text = "Войти";
            toEnter.UseVisualStyleBackColor = false;
            toEnter.Click += Enter_Click;
            // 
            // Registr
            // 
            Registr.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            Registr.ForeColor = SystemColors.WindowFrame;
            Registr.Location = new Point(331, 215);
            Registr.Name = "Registr";
            Registr.Size = new Size(222, 37);
            Registr.TabIndex = 1;
            Registr.Text = "Регистрация";
            Registr.UseVisualStyleBackColor = true;
            Registr.Click += Registr_Click;
            // 
            // Entry
            // 
            Entry.BackColor = Color.LightSteelBlue;
            Entry.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            Entry.ForeColor = SystemColors.WindowFrame;
            Entry.Location = new Point(95, 215);
            Entry.Name = "Entry";
            Entry.Size = new Size(222, 37);
            Entry.TabIndex = 5;
            Entry.Text = "Вход";
            Entry.UseVisualStyleBackColor = false;
            Entry.Click += Entry_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Gainsboro;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Courier New", 10.2F);
            textBox2.ForeColor = Color.DimGray;
            textBox2.Location = new Point(225, 160);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(328, 28);
            textBox2.TabIndex = 3;
            textBox2.Text = "Пароль";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.Click += textBox2_Click;
            textBox2.MouseDown += textBox2_MouseDown;
            textBox2.MouseUp += textBox2_MouseUp;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Gainsboro;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Courier New", 10.2F);
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(225, 126);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(328, 28);
            textBox1.TabIndex = 2;
            textBox1.Text = "Логин";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Click += textBox1_Click;
            // 
            // Authoriz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(798, 405);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Authoriz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authoriz";
            Load += Authoriz_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button toEnter;
        private Button Registr;
        private Button Entry;
        public PictureBox pictureBox1;
        private Label label2;
    }
}