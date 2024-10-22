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
    public partial class DateForm : Form
    {
        public DateTime SelectedDate { get; private set; }

        public DateForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            

            var dateTimePicker = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy"
            };
            Controls.Add(dateTimePicker);

            var okButton = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                AutoSize = true,
                MinimumSize = new Size(100, 0) // Установите минимальную ширину
            };
            okButton.Click += (sender, e) =>
            {
                SelectedDate = dateTimePicker.Value;
                DialogResult = DialogResult.OK;
                Close();
            };
            Controls.Add(okButton);
        }
    }
}
