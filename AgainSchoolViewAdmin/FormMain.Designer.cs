namespace AgainSchoolViewAdmin
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.турыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.турыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.написатьКлиентуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonBonusFine = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.турыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.письмаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // турыToolStripMenuItem
            // 
            this.турыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.турыToolStripMenuItem1,
            this.клиентыToolStripMenuItem});
            this.турыToolStripMenuItem.Name = "турыToolStripMenuItem";
            this.турыToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.турыToolStripMenuItem.Text = "Справочники";
            // 
            // турыToolStripMenuItem1
            // 
            this.турыToolStripMenuItem1.Name = "турыToolStripMenuItem1";
            this.турыToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.турыToolStripMenuItem1.Text = "Кружки";
            this.турыToolStripMenuItem1.Click += new System.EventHandler(this.турыToolStripMenuItem1_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.клиентыToolStripMenuItem.Text = "Блокировка клиентов";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getOrderToolStripMenuItem,
            this.orderToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // getOrderToolStripMenuItem
            // 
            this.getOrderToolStripMenuItem.Name = "getOrderToolStripMenuItem";
            this.getOrderToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.getOrderToolStripMenuItem.Text = "Отчет по оплатам";
            this.getOrderToolStripMenuItem.Click += new System.EventHandler(this.getOrderToolStripMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.orderToolStripMenuItem.Text = "Записи клиентов";
            this.orderToolStripMenuItem.Click += new System.EventHandler(this.orderToolStripMenuItem_Click);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.написатьКлиентуToolStripMenuItem});
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.письмаToolStripMenuItem.Text = "Письма";
            // 
            // написатьКлиентуToolStripMenuItem
            // 
            this.написатьКлиентуToolStripMenuItem.Name = "написатьКлиентуToolStripMenuItem";
            this.написатьКлиентуToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.написатьКлиентуToolStripMenuItem.Text = "Написать клиенту";
            this.написатьКлиентуToolStripMenuItem.Click += new System.EventHandler(this.написатьКлиентуToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(946, 253);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(973, 129);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(93, 25);
            this.buttonRef.TabIndex = 1;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonBonusFine
            // 
            this.buttonBonusFine.Location = new System.Drawing.Point(973, 37);
            this.buttonBonusFine.Name = "buttonBonusFine";
            this.buttonBonusFine.Size = new System.Drawing.Size(100, 70);
            this.buttonBonusFine.TabIndex = 2;
            this.buttonBonusFine.Text = "Начисление бонуса или штрафа";
            this.buttonBonusFine.UseVisualStyleBackColor = true;
            this.buttonBonusFine.Click += new System.EventHandler(this.buttonBonusFine_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 293);
            this.Controls.Add(this.buttonBonusFine);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Школа";
            this.Load += new System.EventHandler(this.FormMain1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem турыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem турыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem письмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem написатьКлиентуToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonBonusFine;
    }
}