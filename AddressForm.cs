using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfitFurniture_2._0
{
    public partial class AddressForm : Form
    {
        private const string FilePath = "D:\\Profitability\\Addresses\\addressStorage.txt";
        public List<string> SelectedAddresses { get; private set; } = new List<string>();

        public AddressForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            var checkedListBox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true // Позволяет выбирать несколько вариантов
            };
            checkedListBox.Items.AddRange(LoadAddressesFromFile(FilePath));
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
                var newAddress = inputTextBox.Text;
                if (!string.IsNullOrEmpty(newAddress) && !AddressExists(newAddress, FilePath))
                {
                    SaveAddressToFile(newAddress, FilePath);
                    checkedListBox.Items.Add(newAddress);
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
                    SelectedAddresses = checkedListBox.CheckedItems.Cast<string>().ToList();
                    if (SelectedAddresses.Any())
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите хотя бы один адрес.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            };
            Controls.Add(okButton);
        }

        private string[] LoadAddressesFromFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllLines(filePath);
            }
            return new string[0];
        }

        private bool AddressExists(string address, string filePath)
        {
            var addresses = LoadAddressesFromFile(filePath);
            return addresses.Contains(address);
        }

        private void SaveAddressToFile(string address, string filePath)
        {
            using (var writer = new System.IO.StreamWriter(filePath, true))
            {
                writer.WriteLine(address);
            }
        }
    }
}
