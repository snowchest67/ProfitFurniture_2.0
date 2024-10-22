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
    public partial class FurnitureForm : Form
    {
        private const string FilePath = "D:\\Profitability\\Furniture\\furnitureStorage.txt";
        public List<string> SelectedFurniture { get; private set; } = new List<string>();

        public FurnitureForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            var checkedListBox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true // Позволяет выбирать несколько вариантов
            };
            checkedListBox.Items.AddRange(LoadFurnitureFromFile(FilePath));
            Controls.Add(checkedListBox);

            var inputTextBox = new TextBox { Dock = DockStyle.Top };
            Controls.Add(inputTextBox);

            var addButton = new Button { Text = "Добавить", Dock = DockStyle.Top };
            addButton.Click += (sender, e) =>
            {
                var newFurniture = inputTextBox.Text;
                if (!string.IsNullOrEmpty(newFurniture) && !FurnitureExists(newFurniture))
                {
                    SaveFurnitureToFile(newFurniture);
                    checkedListBox.Items.Add(newFurniture);
                    inputTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите уникальное значение.");
                }
            };
            Controls.Add(addButton);

            var okButton = new Button { Text = "OK", Dock = DockStyle.Bottom };
            okButton.Click += (sender, e) =>
            {
                SelectedFurniture = checkedListBox.CheckedItems.Cast<string>().ToList();
                if (SelectedFurniture.Any())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите хотя бы одну мебель.");
                }
            };
            Controls.Add(okButton);
        }

        private string[] LoadFurnitureFromFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllLines(filePath);
            }
            return new string[0];
        }

        private bool FurnitureExists(string furniture)
        {
            var furnitureItems = LoadFurnitureFromFile(FilePath);
            return furnitureItems.Contains(furniture);
        }

        private void SaveFurnitureToFile(string furniture)
        {
            using (var writer = new System.IO.StreamWriter(FilePath, true))
            {
                writer.WriteLine(furniture);
            }
        }
    }
}
