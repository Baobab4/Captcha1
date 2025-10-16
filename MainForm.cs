using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modl;
using YourProjectName;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private int failedAttempts = 0;
        private const int MaxAttempts = 3;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            using (var db = new ModelEF())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    MessageBox.Show($"Добро пожаловать, {user.First_Name}! Ваша роль: {user.Role_Name}",
                        "Успешная авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    failedAttempts = 0; // Сброс счетчика неудачных попыток
                }
                else
                {
                    failedAttempts++;

                    if (failedAttempts >= MaxAttempts)
                    {
                        // Показываем CAPTCHA после нескольких неудачных попыток
                        using (var captchaForm = new CaptchForm())
                        {
                            if (captchaForm.ShowDialog() == DialogResult.OK)
                            {
                                failedAttempts = 0; // Сброс при успешной CAPTCHA
                                MessageBox.Show("CAPTCHA пройдена успешно. Попробуйте войти снова.");
                            }
                            else
                            {
                                MessageBox.Show("Неверная CAPTCHA. Попробуйте позже.");
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Неверный логин или пароль. Попыток осталось: {MaxAttempts - failedAttempts}",
                            "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void ShowCaptchaForm()
        {
            using (var captchaForm = new CaptchForm())
            {
                var result = captchaForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    failedAttempts = 0;
                    MessageBox.Show("CAPTCHA пройдена успешно! Попробуйте войти снова.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("CAPTCHA не пройдена или форма закрыта. Приложение будет закрыто.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}