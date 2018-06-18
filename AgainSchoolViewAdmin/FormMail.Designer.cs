namespace AgainSchoolViewAdmin
{
    partial class FormMail
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
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonSendEmail = new System.Windows.Forms.Button();
            this.textBoxClientEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(385, 19);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(117, 31);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "Выбрать файл";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonSendEmail
            // 
            this.buttonSendEmail.Location = new System.Drawing.Point(385, 56);
            this.buttonSendEmail.Name = "buttonSendEmail";
            this.buttonSendEmail.Size = new System.Drawing.Size(117, 31);
            this.buttonSendEmail.TabIndex = 1;
            this.buttonSendEmail.Text = "Отправить письмо";
            this.buttonSendEmail.UseVisualStyleBackColor = true;
            this.buttonSendEmail.Click += new System.EventHandler(this.buttonSendEmail_Click);
            // 
            // textBoxClientEmail
            // 
            this.textBoxClientEmail.Location = new System.Drawing.Point(89, 62);
            this.textBoxClientEmail.Name = "textBoxClientEmail";
            this.textBoxClientEmail.Size = new System.Drawing.Size(260, 20);
            this.textBoxClientEmail.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "E-mail клиента";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(89, 19);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(260, 21);
            this.comboBoxClient.TabIndex = 4;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxClient_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Клиент";
            // 
            // FormMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 119);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxClientEmail);
            this.Controls.Add(this.buttonSendEmail);
            this.Controls.Add(this.buttonAddFile);
            this.Name = "FormMail";
            this.Text = "Отправка счетов клиенту";
            this.Load += new System.EventHandler(this.FormMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonSendEmail;
        private System.Windows.Forms.TextBox textBoxClientEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label label2;
    }
}