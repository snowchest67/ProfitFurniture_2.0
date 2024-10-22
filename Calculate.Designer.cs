namespace ProfitFurniture_2._0
{
    partial class Calculate
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
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem1 = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            создатьПустуюКнигуToolStripMenuItem = new ToolStripMenuItem();
            создатьОтчётToolStripMenuItem = new ToolStripMenuItem();
            отчётВWordToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            расчитатьToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            openFileDialog1 = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.SlateGray;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, создатьОтчётToolStripMenuItem, расчитатьToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.BackColor = Color.SlateGray;
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem, создатьПустуюКнигуToolStripMenuItem });
            файлToolStripMenuItem.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            файлToolStripMenuItem.ForeColor = Color.AliceBlue;
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(70, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.BackColor = Color.LightSlateGray;
            открытьToolStripMenuItem.ForeColor = Color.AliceBlue;
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(306, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.BackColor = Color.LightSlateGray;
            сохранитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem1, сохранитьКакToolStripMenuItem });
            сохранитьToolStripMenuItem.ForeColor = Color.AliceBlue;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(306, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьToolStripMenuItem1
            // 
            сохранитьToolStripMenuItem1.BackColor = Color.LightSteelBlue;
            сохранитьToolStripMenuItem1.ForeColor = Color.SlateGray;
            сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            сохранитьToolStripMenuItem1.Size = new Size(230, 26);
            сохранитьToolStripMenuItem1.Text = "Сохранить";
            сохранитьToolStripMenuItem1.Click += какСтарыйToolStripMenuItem_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.BackColor = Color.LightSteelBlue;
            сохранитьКакToolStripMenuItem.ForeColor = Color.SlateGray;
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(230, 26);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            сохранитьКакToolStripMenuItem.Click += какНовыйToolStripMenuItem_Click;
            // 
            // создатьПустуюКнигуToolStripMenuItem
            // 
            создатьПустуюКнигуToolStripMenuItem.BackColor = Color.LightSlateGray;
            создатьПустуюКнигуToolStripMenuItem.ForeColor = Color.AliceBlue;
            создатьПустуюКнигуToolStripMenuItem.Name = "создатьПустуюКнигуToolStripMenuItem";
            создатьПустуюКнигуToolStripMenuItem.Size = new Size(306, 26);
            создатьПустуюКнигуToolStripMenuItem.Text = "Создать пустую книгу";
            создатьПустуюКнигуToolStripMenuItem.Click += создатьПустуюКнигуToolStripMenuItem_Click;
            // 
            // создатьОтчётToolStripMenuItem
            // 
            создатьОтчётToolStripMenuItem.BackColor = Color.SlateGray;
            создатьОтчётToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отчётВWordToolStripMenuItem, toolStripMenuItem1 });
            создатьОтчётToolStripMenuItem.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            создатьОтчётToolStripMenuItem.ForeColor = Color.AliceBlue;
            создатьОтчётToolStripMenuItem.Name = "создатьОтчётToolStripMenuItem";
            создатьОтчётToolStripMenuItem.Size = new Size(158, 24);
            создатьОтчётToolStripMenuItem.Text = "Создать отчёт";
            // 
            // отчётВWordToolStripMenuItem
            // 
            отчётВWordToolStripMenuItem.BackColor = Color.LightSlateGray;
            отчётВWordToolStripMenuItem.ForeColor = Color.AliceBlue;
            отчётВWordToolStripMenuItem.Name = "отчётВWordToolStripMenuItem";
            отчётВWordToolStripMenuItem.Size = new Size(274, 26);
            отчётВWordToolStripMenuItem.Text = "Отчёт в Word";
            отчётВWordToolStripMenuItem.Click += отчётВWordToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.LightSlateGray;
            toolStripMenuItem1.ForeColor = Color.AliceBlue;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(274, 26);
            toolStripMenuItem1.Text = "Отчёт по клиентам";
            toolStripMenuItem1.Click += отчетПоКлиентамToolStripMenuItem_Click;
            // 
            // расчитатьToolStripMenuItem
            // 
            расчитатьToolStripMenuItem.BackColor = Color.SlateGray;
            расчитатьToolStripMenuItem.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            расчитатьToolStripMenuItem.ForeColor = Color.AliceBlue;
            расчитатьToolStripMenuItem.Name = "расчитатьToolStripMenuItem";
            расчитатьToolStripMenuItem.Size = new Size(120, 24);
            расчитатьToolStripMenuItem.Text = "Расчитать";
            расчитатьToolStripMenuItem.Click += расчитатьToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.LightSlateGray;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 28);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bookman Old Style", 10.2F);
            toolStripLabel1.ForeColor = Color.AliceBlue;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(51, 25);
            toolStripLabel1.Text = "Лист";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 28);
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Excel|*.xlsx";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.ControlDark;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 394);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            // 
            // Calculate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Calculate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculate";
            WindowState = FormWindowState.Maximized;
            FormClosed += Calculate_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem1;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem создатьПустуюКнигуToolStripMenuItem;
        private ToolStripMenuItem создатьОтчётToolStripMenuItem;
        private ToolStripMenuItem отчётВWordToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem расчитатьToolStripMenuItem;
        private ToolStrip toolStrip1;
        private OpenFileDialog openFileDialog1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox toolStripComboBox1;
        private DataGridView dataGridView1;
    }
}