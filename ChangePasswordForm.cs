using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfitFurniture_2._0
{
    public partial class ChangePasswordForm : Form
    {
        private string filePath;
        public ChangePasswordForm(string path)
        {
            InitializeComponent();
            filePath = path;
        }
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string currentPassword = textBoxCurrentPassword.Text;
            string newPassword = textBoxNewPassword.Text;

            if (newPassword.Length < 5)
            {
                MessageBox.Show("Пароль должен быть не менее 5 символов.");
                return;
            }

            Dictionary<string, string> credentials = ReadCredentialsFromFile(filePath);

            if (credentials.ContainsKey(login) && credentials[login] == ComputeHash(currentPassword))
            {
                credentials[login] = ComputeHash(newPassword);
                WriteCredentialsToFile(filePath, credentials);
                MessageBox.Show("Пароль успешно изменен!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
        private Dictionary<string, string> ReadCredentialsFromFile(string path)
        {
            var credentials = new Dictionary<string, string>();

            if (File.Exists(path))
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        credentials[parts[0]] = parts[1];
                    }
                }
            }

            return credentials;
        }

        private void WriteCredentialsToFile(string path, Dictionary<string, string> credentials)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (var kvp in credentials)
                {
                    sw.WriteLine($"{kvp.Key}:{kvp.Value}");
                }
            }
        }

        private string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void textBoxLogin_Click(object sender, EventArgs e)
        {
            textBoxLogin.Clear();
        }

        private void textBoxCurrentPassword_Click(object sender, EventArgs e)
        {
            textBoxCurrentPassword.Clear();
        }

        private void textBoxNewPassword_Click(object sender, EventArgs e)
        {
            textBoxNewPassword.Clear();
        }
    }
}

