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
    public partial class Authoriz : Form
    {
        bool flag;
        private string filePath = "D:\\Profitability\\UsersAuth\\credentials.txt";
        public Authoriz()
        {
            InitializeComponent();
        }
        private void Enter_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                // Вход
                string enteredLogin = textBox1.Text;
                string enteredPassword = textBox2.Text;
                Dictionary<string, string> credentials = ReadCredentialsFromFile(filePath);

                if (credentials.ContainsKey(enteredLogin) && credentials[enteredLogin] == ComputeHash(enteredPassword))
                {
                    MessageBox.Show("Вход выполнен успешно!");
                    Calculate newForm = new Calculate();
                    newForm.Show();
                    this.Hide(); // Скрыть текущую форму
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
            else
            {
                // Регистрация
                string newLogin = textBox1.Text;
                string newPassword = textBox2.Text;

                if (newPassword.Length < 5)
                {
                    MessageBox.Show("Пароль должен быть не менее 5 символов.");
                    return;
                }

                Dictionary<string, string> credentials = ReadCredentialsFromFile(filePath);

                if (credentials.ContainsKey(newLogin))
                {
                    MessageBox.Show("Логин уже существует. Пожалуйста, выберите другой логин.");
                }
                else
                {
                    string hashedPassword = ComputeHash(newPassword);
                    WriteCredentialsToFile(filePath, newLogin, hashedPassword);
                    MessageBox.Show("Регистрация выполнена успешно!");
                }
            }
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(filePath);
            changePasswordForm.ShowDialog(this); // Открыть форму как модальную
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

        private void WriteCredentialsToFile(string path, string login, string hashedPassword)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{login}:{hashedPassword}");
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

        private void Entry_Click(object sender, EventArgs e)
        {
            toEnter.Text = "Войти";
            Registr.BackColor = Color.White;
            Entry.BackColor = Color.LightSteelBlue;
            flag = true;
        }

        private void Registr_Click(object sender, EventArgs e)
        {
            toEnter.Text = "Зарегистрироваться";
            Entry.BackColor = Color.White;
            Registr.BackColor = Color.LightSteelBlue;
            flag = false;
        }

        private void Authoriz_Load(object sender, EventArgs e)
        {
            flag = true;
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;
            textBox2.MouseDown += new MouseEventHandler(this.textBox2_MouseDown);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "Логин")
            {
                textBox1.Clear();
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Clear();

            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }
    }
}

