using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YourProjectName
{
    public partial class CaptchForm : Form
    {
        private string currentCaptcha;
        private Random random = new Random();
        private Font captchaFont = new Font("Mistral", 48, FontStyle.Bold | FontStyle.Strikeout);
        private Color captchaColor = Color.Black;
        private Color backgroundColor = Color.LightGray;

        public CaptchForm()
        {
            InitializeComponent();
        }

        private void CaptchForm_Load(object sender, EventArgs e)
        {
            // Настраиваем внешний вид Label
            lblCaptcha.Text = "";
            lblCaptcha.AutoSize = false;
            lblCaptcha.Size = new Size(400, 80); // Увеличиваем размер для большого шрифта
            lblCaptcha.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptcha.BackColor = backgroundColor;
            lblCaptcha.BorderStyle = BorderStyle.FixedSingle;

            GenerateCaptcha();
            timerCaptcha.Interval = 10000; // 10 секунд
            timerCaptcha.Start();
        }

        private void GenerateCaptcha()
        {
            // Генерация случайной строки для CAPTCHA
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }

            currentCaptcha = sb.ToString();

            // Устанавливаем текст с фиксированным оформлением
            lblCaptcha.Text = currentCaptcha;
            lblCaptcha.Font = captchaFont;
            lblCaptcha.ForeColor = captchaColor;
            lblCaptcha.BackColor = backgroundColor;
            lblCaptcha.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void txtCaptchaInput_TextChanged(object sender, EventArgs e)
        {
            if (txtCaptchaInput.Text.Length == currentCaptcha.Length)
            {
                if (txtCaptchaInput.Text.Equals(currentCaptcha, StringComparison.OrdinalIgnoreCase))
                {
                    timerCaptcha.Stop();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверная CAPTCHA! Попробуйте снова.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCaptchaInput.Text = "";
                    txtCaptchaInput.Focus();
                    GenerateCaptcha();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
            txtCaptchaInput.Text = "";
            txtCaptchaInput.Focus();
        }

        private void timerCaptcha_Tick(object sender, EventArgs e)
        {
            GenerateCaptcha();
            txtCaptchaInput.Text = "";
            MessageBox.Show("Время истекло! CAPTCHA обновлена.", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timerCaptcha.Stop();

            // Освобождаем ресурсы шрифта
            captchaFont.Dispose();
        }
    }
}