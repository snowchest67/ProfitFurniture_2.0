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

namespace ProfitFurniture_2._0
{
    public partial class ClientForm : Form
    {
        private const string FilePath = "D:\\Profitability\\Customers\\customerStorage.txt";
        public List<string> SelectedClients { get; private set; } = new List<string>();

        public ClientForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            var checkedListBox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true // Позволяет выбирать несколько вариантов
            };
            checkedListBox.Items.AddRange(LoadClientsFromFile(FilePath));
            Controls.Add(checkedListBox);

            var inputTextBox = new TextBox { Dock = DockStyle.Top };
            Controls.Add(inputTextBox);

            var addButton = new Button
            {
                Text = "Добавить",
                Dock = DockStyle.Top,
                AutoSize = true,
                MinimumSize = new Size(100, 0) // Установите минимальную ширину
            };
            addButton.Click += (sender, e) =>
            {
                var newClient = inputTextBox.Text;
                if (!string.IsNullOrEmpty(newClient) && !ClientExists(newClient))
                {
                    SaveClientToFile(newClient);
                    checkedListBox.Items.Add(newClient);
                    inputTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите уникальное значение.");
                }
            };
            Controls.Add(addButton);

            var okButton = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                AutoSize = true,
                MinimumSize = new Size(100, 0) // Установите минимальную ширину
            };
            okButton.Click += (sender, e) =>
            {
                try
                {
                    SelectedClients = checkedListBox.CheckedItems.Cast<string>().ToList();
                    if (SelectedClients.Any())
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите хотя бы одного клиента.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            };
            Controls.Add(okButton);
        }

        private string[] LoadClientsFromFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllLines(filePath);
            }
            return new string[0];
        }

        private bool ClientExists(string client)
        {
            var clients = LoadClientsFromFile(FilePath);
            return clients.Contains(client);
        }

        private void SaveClientToFile(string client)
        {
            using (var writer = new System.IO.StreamWriter(FilePath, true))
            {
                writer.WriteLine(client);
            }
        }
    }
}
