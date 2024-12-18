using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using ExcelDataReader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;


namespace ProfitFurniture_2._0
{
    public partial class Calculate : Form
    {
        private string filename = string.Empty;

        private DataTableCollection tableCollection = null;
        public Calculate()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.DataError += dataGridView1_DataError;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    Text = filename;
                    OpenExcelFile(filename);
                }
                else
                {
                    throw new Exception("Файл не выбран");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OpenExcelFile(string path)
        {
            try
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                tableCollection = db.Tables;
                toolStripComboBox1.Items.Clear();
                foreach (System.Data.DataTable tabe in tableCollection)
                {
                    toolStripComboBox1.Items.Add(tabe.TableName);
                }
                toolStripComboBox1.SelectedIndex = 0;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataTable table = tableCollection[Convert.ToString(toolStripComboBox1.SelectedItem)];
            dataGridView1.DataSource = table;
        }

        private void создатьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void расчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename == string.Empty) throw new Exception("Файл не был открыт.");
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Style.BackColor == Color.Red)
                            {
                                cell.Style.BackColor = Color.White;
                            }
                        }
                    }
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Проверка значений и их преобразование
                        if (row.Cells[11].Value != null && decimal.TryParse(row.Cells[11].Value.ToString(), out decimal value11))
                        {
                            // Умножение значения на 0,05
                            decimal result = value11 * 0.05m;

                            // Запись результата в 11-й столбец
                            row.Cells[10].Value = result;
                        }
                        else
                        {
                            // Обработка пустых ячеек
                            row.Cells[10].Value = "N/A";
                            row.Cells[10].Style.BackColor = Color.Red;
                        }
                        row.Cells[10].Style.BackColor = Color.LightSalmon;
                    }
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Инициализация значений
                        decimal value11 = 0, value9 = 0, value10 = 0;

                        // Проверка и преобразование значений
                        if (row.Cells[11].Value != null && decimal.TryParse(row.Cells[11].Value.ToString(), out decimal tempValue11))
                        {
                            value11 = tempValue11;
                        }
                        else
                        {
                            row.Cells[11].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 11");
                        }

                        if (row.Cells[9].Value != null && decimal.TryParse(row.Cells[9].Value.ToString(), out decimal tempValue9))
                        {
                            value9 = tempValue9;
                        }
                        else
                        {
                            row.Cells[9].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 9");
                        }

                        if (row.Cells[10].Value != null && decimal.TryParse(row.Cells[10].Value.ToString(), out decimal tempValue10))
                        {
                            value10 = tempValue10;
                        }
                        else
                        {
                            row.Cells[10].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 10");
                        }

                        // Вычисление значения по формуле
                        decimal result = (value11 - value9 - value10) * 0.1m;

                        // Запись результата в 12-й столбец
                        row.Cells[12].Value = result;
                        row.Cells[12].Style.BackColor = Color.LemonChiffon;
                    }
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        decimal sum = 0;

                        // Суммирование значений столбцов 3-11 и 13-14
                        for (int i = 2; i <= 10; i++)
                        {
                            if (row.Cells[i].Value != null && decimal.TryParse(row.Cells[i].Value.ToString(), out decimal value))
                            {
                                sum += value;
                            }
                            else
                            {
                                row.Cells[i].Style.BackColor = Color.Red;
                                throw new Exception($"Некорректное значение в столбце {i}");
                            }
                        }

                        if (row.Cells[12].Value != null && decimal.TryParse(row.Cells[12].Value.ToString(), out decimal value13))
                        {
                            sum += value13;
                        }
                        else
                        {
                            row.Cells[12].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 12");
                        }

                        if (row.Cells[13].Value != null && decimal.TryParse(row.Cells[13].Value.ToString(), out decimal value14))
                        {
                            sum += value14;
                        }
                        else
                        {
                            row.Cells[13].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 13");
                        }

                        // Запись результата в 15-й столбец
                        row.Cells[14].Value = sum;
                        row.Cells[14].Style.BackColor = Color.Turquoise;
                    }
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Инициализация значений
                        decimal value11 = 0, value14 = 0, value15 = 0;

                        // Проверка и преобразование значений
                        if (row.Cells[11].Value != null && decimal.TryParse(row.Cells[11].Value.ToString(), out decimal tempValue11))
                        {
                            value11 = tempValue11;
                        }
                        else
                        {
                            row.Cells[11].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 11");
                        }

                        if (row.Cells[14].Value != null && decimal.TryParse(row.Cells[14].Value.ToString(), out decimal tempValue14))
                        {
                            value14 = tempValue14;
                        }
                        else
                        {
                            row.Cells[14].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 14");
                        }

                        // Вычисление суммы 12-го и 14-го столбцов
                        decimal sum = value11 - value14;
                        row.Cells[15].Value = sum;
                        row.Cells[15].Style.BackColor = Color.PaleGreen;

                        if (row.Cells[15].Value != null && decimal.TryParse(row.Cells[15].Value.ToString(), out decimal tempValue15))
                        {
                            value15 = tempValue15;
                        }
                        else
                        {
                            row.Cells[15].Style.BackColor = Color.Red;
                            throw new Exception("Некорректное значение в столбце 15");
                        }

                        // Вычисление частного 15-го и 14-го столбцов
                        if (value14 != 0)
                        {
                            decimal quotient = value15 / value14 * 100;
                            row.Cells[16].Value = Math.Round(quotient, 0);
                        }
                        else
                        {
                            row.Cells[16].Value = "N/A"; // Обработка деления на ноль
                        }
                        row.Cells[16].Style.BackColor = Color.LightSteelBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void какНовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename == string.Empty) throw new Exception("Файл не был открыт.");
                System.Windows.Forms.ProgressBar progressBar = new System.Windows.Forms.ProgressBar();
                progressBar.Maximum = toolStripComboBox1.Items.Count;
                progressBar.Step = 1;
                progressBar.Style = ProgressBarStyle.Continuous;

                Form progressForm = new Form();
                progressForm.Text = "Progress";
                progressForm.Controls.Add(progressBar);
                progressBar.Dock = DockStyle.Fill;
                progressForm.StartPosition = FormStartPosition.CenterScreen;
                progressForm.Size = new Size(300, 70);
                progressForm.Show();

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += (s, args) =>
                {
                    Excel.Application exApp = new Excel.Application();
                    Excel.Workbook workbook = exApp.Workbooks.Add();
                    Excel.Worksheet defaultSheet = workbook.Worksheets[1];
                    int index = toolStripComboBox1.Items.Count - 1;
                    System.Data.DataTable table;
                    for (int item = toolStripComboBox1.Items.Count - 1; item >= 0; item--)
                    {
                        table = tableCollection[Convert.ToString(toolStripComboBox1.Items[index])];
                        dataGridView1.Invoke(new System.Action(() => dataGridView1.DataSource = table));
                        string sheetName = toolStripComboBox1.Items[item].ToString();
                        Excel.Worksheet wsh = workbook.Sheets.Add();
                        wsh.Name = sheetName;
                        for (int i = 0; i <= dataGridView1.RowCount - 2; i++)
                        {
                            for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                            {
                                Excel.Range headerCell = wsh.Cells[1, j + 1];
                                headerCell.Value = dataGridView1.Columns[j].HeaderText;
                                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                headerCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                headerCell.Font.Bold = true;
                                wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value;
                            }
                        }
                        index--;
                        wsh.Columns.AutoFit();
                        worker.ReportProgress(toolStripComboBox1.Items.Count - item);
                    }
                    table = tableCollection[Convert.ToString(toolStripComboBox1.Items[0])];
                    dataGridView1.Invoke(new System.Action(() => dataGridView1.DataSource = table));
                    defaultSheet.Delete();
                    exApp.Visible = true;
                };

                worker.ProgressChanged += (s, args) =>
                {
                    progressBar.Value = args.ProgressPercentage;
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    progressForm.Close();
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void какСтарыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename == string.Empty) throw new Exception("Файл не был открыт.");
                System.Windows.Forms.ProgressBar progressBar = new System.Windows.Forms.ProgressBar();
                progressBar.Maximum = toolStripComboBox1.Items.Count;
                progressBar.Step = 1;
                progressBar.Style = ProgressBarStyle.Continuous;

                Form progressForm = new Form();
                progressForm.Text = "Progress";
                progressForm.Controls.Add(progressBar);
                progressBar.Dock = DockStyle.Fill;
                progressForm.StartPosition = FormStartPosition.CenterScreen;
                progressForm.Size = new Size(300, 70);
                progressForm.Show();

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += (s, args) =>
                {
                    Excel.Application exApp = new Excel.Application();
                    Excel.Workbook workbook = exApp.Workbooks.Open(filename);
                    int index = toolStripComboBox1.Items.Count - 1;
                    System.Data.DataTable table;

                    for (int item = toolStripComboBox1.Items.Count - 1; item >= 0; item--)
                    {
                        table = tableCollection[Convert.ToString(toolStripComboBox1.Items[index])];
                        dataGridView1.Invoke(new System.Action(() => dataGridView1.DataSource = table));
                        string sheetName = toolStripComboBox1.Items[item].ToString();
                        Excel.Worksheet wsh;
                        try
                        {
                            wsh = workbook.Sheets[sheetName];
                        }
                        catch
                        {
                            wsh = workbook.Sheets.Add();
                            wsh.Name = sheetName;
                        }

                        for (int i = 0; i <= dataGridView1.RowCount - 2; i++)
                        {
                            for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                            {
                                Excel.Range headerCell = wsh.Cells[1, j + 1];
                                headerCell.Value = dataGridView1.Columns[j].HeaderText;
                                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                headerCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                headerCell.Font.Bold = true;
                                wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value;
                            }
                        }
                        index--;
                        worker.ReportProgress(toolStripComboBox1.Items.Count - item);
                        wsh.Columns.AutoFit();
                    }

                    table = tableCollection[Convert.ToString(toolStripComboBox1.Items[0])];
                    dataGridView1.Invoke(new System.Action(() => dataGridView1.DataSource = table));
                    exApp.Visible = true;
                    workbook.Save();
                };

                worker.ProgressChanged += (s, args) =>
                {
                    progressBar.Value = args.ProgressPercentage;
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    progressForm.Close();
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отчётВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename == string.Empty) throw new Exception("Файл не был открыт.");
                decimal totalProfit = 0;
                decimal totalCost = 0;
                decimal totalClientPrice = 0;
                decimal totalProfitability = 0;
                decimal totalFurnitureAssembled = 0;
                decimal profit = 0;
                decimal cost = 0;
                decimal clientPrice = 0;
                decimal profitability = 0;
                decimal furnitureAssembled = 0;
                decimal averageProfitability = 0;
                int countFurnitureAssembled = 0;
                int countProfitability = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        // Проверка и преобразование значений
                        if (row.Cells[15].Value != null && decimal.TryParse(row.Cells[15].Value.ToString(), out profit))
                        {
                            totalProfit += profit;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (row.Cells[14].Value != null && decimal.TryParse(row.Cells[14].Value.ToString(), out cost))
                        {
                            totalCost += cost;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (row.Cells[11].Value != null && decimal.TryParse(row.Cells[11].Value.ToString(), out clientPrice))
                        {
                            totalClientPrice += clientPrice;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (row.Cells[12].Value != null && decimal.TryParse(row.Cells[12].Value.ToString(), out furnitureAssembled))
                        {
                            totalFurnitureAssembled += furnitureAssembled;
                            countFurnitureAssembled++;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (row.Cells[16].Value != null)
                        {
                            if (cost != 0)
                            {
                                profitability = profit / cost * 100;
                                totalProfitability += profitability;
                                countProfitability++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

                averageProfitability = totalProfitability / countProfitability;
                // Создаем документ Word
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();

                // Добавляем текст в документ
                doc.Content.Text = "Отчет о рентабельности мебельного производства за месяц\n\n" +
                                   $"Месяц: {toolStripComboBox1.Text}\n\n" +
                                   "1. Общая прибыль:\n" +
                                   $"   - Общая прибыль за месяц: {totalProfit} руб.\n\n" +
                                   "2. Общая себестоимость:\n" +
                                   $"   - Себестоимость: {totalCost} руб.\n\n" +
                                   "3. Общая цена для клиента:\n" +
                                   $"   - Общая цена для клиента за месяц: {totalClientPrice} руб.\n\n" +
                                   "4. Затраты на сборку мебели:\n" +
                                   $"   - Количество собранной мебели: {countFurnitureAssembled}\n" +
                                   $"   - Общие затраты на сборку мебели за месяц: {totalFurnitureAssembled} руб.\n\n" +
                                   "5. Рентабельность:\n" +
                                   $"   - Рентабельность за месяц: {averageProfitability:F0}%";
                // Сохраняем документ
                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void отчетПоКлиентамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename == string.Empty) throw new Exception("Файл не был открыт.");
                // Создаем и настраиваем ProgressBar
                System.Windows.Forms.ProgressBar progressBar = new System.Windows.Forms.ProgressBar();
                progressBar.Maximum = dataGridView1.Rows.Count;
                progressBar.Step = 1;
                progressBar.Style = ProgressBarStyle.Continuous;

                Form progressForm = new Form();
                progressForm.Text = "Progress";
                progressForm.Controls.Add(progressBar);
                progressBar.Dock = DockStyle.Fill;
                progressForm.StartPosition = FormStartPosition.CenterScreen;
                progressForm.Size = new Size(300, 70);
                progressForm.Show();

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += (s, args) =>
                {
                    var duplicates = new Dictionary<string, List<DataGridViewRow>>();

                    // Проходим по столбцу 20 и собираем дубликаты
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[19].Value != null && !string.IsNullOrEmpty(row.Cells[19].Value.ToString()))
                        {
                            string cellValue = row.Cells[19].Value.ToString();
                            if (!duplicates.ContainsKey(cellValue))
                            {
                                duplicates[cellValue] = new List<DataGridViewRow>();
                            }
                            duplicates[cellValue].Add(row);
                        }
                        else
                        {
                            // Закрашиваем ячейку красным цветом и добавляем текст ошибки, если она пустая
                            row.Cells[19].Style.BackColor = Color.Red;
                            row.Cells[19].Style.ForeColor = Color.White;
                            row.Cells[19].Value = "Ошибка: пустая ячейка";
                        }
                    }

                    // Создаем новую книгу Excel
                    Excel.Application exApp = new Excel.Application();
                    Excel.Workbook workbook = exApp.Workbooks.Add();
                    Excel.Worksheet defaultSheet = workbook.Worksheets[1];

                    foreach (var entry in duplicates)
                    {
                        Excel.Worksheet worksheet = null;
                        try
                        {
                            worksheet = workbook.Sheets.Add();
                            worksheet.Name = entry.Key;

                            // Копируем заголовки столбцов
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                Excel.Range headerCell = worksheet.Cells[1, i + 1];
                                headerCell.Value = dataGridView1.Columns[i].HeaderText;
                                headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                headerCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                headerCell.Font.Bold = true;
                            }

                            // Копируем строки
                            int rowIndex = 2;
                            foreach (var row in entry.Value)
                            {
                                for (int i = 0; i < row.Cells.Count; i++)
                                {
                                    worksheet.Cells[rowIndex, i + 1] = row.Cells[i].Value;
                                }
                                rowIndex++;
                            }
                            worksheet.Columns.AutoFit();
                        }
                        catch (System.Runtime.InteropServices.COMException ex)
                        {
                            MessageBox.Show($"Не удалось создать лист с именем '{entry.Key}': {ex.Message}");
                            worksheet?.Delete();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                            worksheet?.Delete();
                        }

                        worker.ReportProgress(duplicates.Count);
                    }
                    defaultSheet.Delete();
                    exApp.Visible = true;
                };

                worker.ProgressChanged += (s, args) =>
                {
                    progressBar.Value = args.ProgressPercentage;
                };

                worker.RunWorkerCompleted += (s, args) =>
                {
                    progressForm.Close();
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик события для изменения значения в ячейке
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 19)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()) && cell.Value.ToString() != "Ошибка: пустая ячейка")
                {
                    // Возвращаем ячейку к стандартному виду
                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void Calculate_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect(); 
            GC.WaitForPendingFinalizers();
            System.Windows.Forms.Application.Exit();
        }

        private void создатьПустуюКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Запрашиваем путь для сохранения файла
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Files|*.xlsx";
                saveFileDialog1.Title = "Сохранить Excel файл";
                DialogResult res = saveFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;

                    // Запрашиваем название книги, количество листов и их названия
                    int sheetCount = int.Parse(Interaction.InputBox("Введите количество листов:", "Количество листов"));
                    List<string> sheetNames = new List<string>();
                    for (int i = 0; i < sheetCount; i++)
                    {
                        sheetNames.Add(Interaction.InputBox($"Введите название листа {i + 1}:", "Название листа"));
                    }

                    // Создаем Excel приложение
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();

                    try
                    {
                        // Удаляем автоматически созданный лист
                        Excel.Worksheet defaultSheet = workbook.Worksheets[1];

                        // Добавляем листы в обратном порядке
                        for (int i = sheetCount - 1; i >= 0; i--)
                        {
                            Excel.Worksheet worksheet = workbook.Worksheets.Add();
                            worksheet.Name = sheetNames[i];

                            // Создаем заголовки по шаблону
                            string[] headers = { "Дата", "Номер", "ДСП", "Раскрой", "Кромка", "Z", "Двери", "Пф, ф.", "Тр.", "1-Д", "2-М", "Цена", "Сборка", "Бригада", "С/Стоим.", "Прибыль", "Рент.", "Тип мебели", "Адрес", "Клиент" };
                            for (int j = 0; j < headers.Length; j++)
                            {
                                worksheet.Cells[1, j + 1] = headers[j];
                                Excel.Range headerRange = worksheet.Cells[1, j + 1];
                                headerRange.Font.Bold = true;
                                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                        }
                        defaultSheet.Delete();

                        // Сохраняем файл
                        workbook.SaveAs(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Закрываем книгу и приложение
                        workbook.Close(false);
                        excelApp.Quit();

                        // Освобождаем ресурсы
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    }

                    // Вызываем существующее событие
                    OpenExcelFile(filename);
                }
                else
                {
                    throw new Exception("Файл не выбран");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                        int columnIndex = dataGridView1.SelectedCells[0].ColumnIndex;

                        switch (columnIndex)
                        {
                            case 0:
                                // Открыть форму с DateTimePicker и выбрать дату
                                using (var dateForm = new DateForm())
                                {
                                    if (dateForm.ShowDialog() == DialogResult.OK)
                                    {
                                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = dateForm.SelectedDate.ToString("dd.MM.yyyy");
                                    }
                                }
                                break;

                            case 17:
                                // Предложить пользователю выбрать тип мебели из CheckedListBox
                                using (var furnitureForm = new FurnitureForm())
                                {
                                    if (furnitureForm.ShowDialog() == DialogResult.OK)
                                    {
                                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = string.Join(", ", furnitureForm.SelectedFurniture);
                                    }
                                }
                                break;

                            case 18:
                                // Предложить пользователю выбрать адрес из CheckedListBox
                                using (var addressForm = new AddressForm())
                                {
                                    if (addressForm.ShowDialog() == DialogResult.OK)
                                    {
                                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = string.Join(", ", addressForm.SelectedAddresses);
                                    }
                                }
                                break;

                            case 19:
                                // Предложить пользователю выбрать клиента из CheckedListBox
                                using (var clientForm = new ClientForm())
                                {
                                    if (clientForm.ShowDialog() == DialogResult.OK)
                                    {
                                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = string.Join(", ", clientForm.SelectedClients);
                                    }
                                }
                                break;

                            default:
                                MessageBox.Show("Выберите допустимую ячейку.");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите ячейку.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Обработка ошибки
            MessageBox.Show($"Ошибка в строке {e.RowIndex + 1}, столбце {e.ColumnIndex + 1}: {e.Exception.Message}, ячейка должна иметь формат даты **.**.****\nдни 1-31\nмесяц 1-12", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

    }
}





