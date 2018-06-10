namespace AgainSchoolViewAdmin
{
    partial class FormClientOrder
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
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.buttonGetOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(75, 24);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(216, 21);
            this.comboBoxClient.TabIndex = 0;
            // 
            // buttonGetOrders
            // 
            this.buttonGetOrders.Location = new System.Drawing.Point(31, 64);
            this.buttonGetOrders.Name = "buttonGetOrders";
            this.buttonGetOrders.Size = new System.Drawing.Size(131, 22);
            this.buttonGetOrders.TabIndex = 1;
            this.buttonGetOrders.Text = "Получить записи";
            this.buttonGetOrders.UseVisualStyleBackColor = true;
            this.buttonGetOrders.Click += new System.EventHandler(this.buttonGetOrders_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Клиент";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormClientOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 111);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGetOrders);
            this.Controls.Add(this.comboBoxClient);
            this.Name = "FormClientOrder";
            this.Text = "Получение записей на кружки клиента";
            this.Load += new System.EventHandler(this.FormClientOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Button buttonGetOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}