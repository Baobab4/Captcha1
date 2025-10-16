namespace YourProjectName
{
    partial class CaptchForm
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
            this.components = new System.ComponentModel.Container();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtCaptchaInput = new System.Windows.Forms.TextBox();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.timerCaptcha = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(325, 205);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(119, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Обновить капчу";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtCaptchaInput
            // 
            this.txtCaptchaInput.Location = new System.Drawing.Point(252, 331);
            this.txtCaptchaInput.Name = "txtCaptchaInput";
            this.txtCaptchaInput.Size = new System.Drawing.Size(269, 20);
            this.txtCaptchaInput.TabIndex = 1;
            this.txtCaptchaInput.TextChanged += new System.EventHandler(this.txtCaptchaInput_TextChanged);
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.Font = new System.Drawing.Font("Mistral", 48F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaptcha.Location = new System.Drawing.Point(312, 83);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(0, 76);
            this.lblCaptcha.TabIndex = 2;
            this.lblCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCaptcha
            // 
            this.timerCaptcha.Interval = 200000;
            this.timerCaptcha.Tick += new System.EventHandler(this.timerCaptcha_Tick);
            // 
            // CaptchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCaptcha);
            this.Controls.Add(this.txtCaptchaInput);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CaptchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CaptchForm";
            this.Load += new System.EventHandler(this.CaptchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtCaptchaInput;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.Timer timerCaptcha;
    }
}