namespace TestAVnWOmonitor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MonStart = new System.Windows.Forms.Button();
            this.FilterForMonitor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.BrowsePapka = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.LBforQuarantine = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.RestoreFileButt = new System.Windows.Forms.Button();
            this.RestoreCureFileButt = new System.Windows.Forms.Button();
            this.DeleteFileButt = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сканировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(167, 79);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(119, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Статус проверки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Путь к файлу";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(170, 54);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(380, 22);
            this.tbFilePath.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1346, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.browseToolStripMenuItem.Text = "Выбрать файл для проверки";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MonStart
            // 
            this.MonStart.Enabled = false;
            this.MonStart.Location = new System.Drawing.Point(27, 173);
            this.MonStart.Name = "MonStart";
            this.MonStart.Size = new System.Drawing.Size(134, 49);
            this.MonStart.TabIndex = 7;
            this.MonStart.Text = "Запустить монитор";
            this.MonStart.UseVisualStyleBackColor = true;
            this.MonStart.Click += new System.EventHandler(this.MonStart_Click);
            // 
            // FilterForMonitor
            // 
            this.FilterForMonitor.Location = new System.Drawing.Point(170, 200);
            this.FilterForMonitor.Name = "FilterForMonitor";
            this.FilterForMonitor.Size = new System.Drawing.Size(251, 22);
            this.FilterForMonitor.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Выбранная область";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(27, 228);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(700, 194);
            this.logTextBox.TabIndex = 12;
            // 
            // BrowsePapka
            // 
            this.BrowsePapka.Location = new System.Drawing.Point(27, 112);
            this.BrowsePapka.Name = "BrowsePapka";
            this.BrowsePapka.Size = new System.Drawing.Size(134, 54);
            this.BrowsePapka.TabIndex = 13;
            this.BrowsePapka.Text = "Выбрать область";
            this.BrowsePapka.UseVisualStyleBackColor = true;
            this.BrowsePapka.Click += new System.EventHandler(this.BrowsePapka_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Задайте фильтр. *.* Для всех типов файлов";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(167, 132);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(254, 22);
            this.PathBox.TabIndex = 15;
            // 
            // LBforQuarantine
            // 
            this.LBforQuarantine.FormattingEnabled = true;
            this.LBforQuarantine.ItemHeight = 16;
            this.LBforQuarantine.Location = new System.Drawing.Point(733, 34);
            this.LBforQuarantine.Name = "LBforQuarantine";
            this.LBforQuarantine.Size = new System.Drawing.Size(344, 388);
            this.LBforQuarantine.TabIndex = 16;
            this.LBforQuarantine.SelectedIndexChanged += new System.EventHandler(this.LBforQuarantine_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(1143, 70);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(141, 59);
            this.RefreshButton.TabIndex = 17;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // RestoreFileButt
            // 
            this.RestoreFileButt.Location = new System.Drawing.Point(1143, 147);
            this.RestoreFileButt.Name = "RestoreFileButt";
            this.RestoreFileButt.Size = new System.Drawing.Size(141, 60);
            this.RestoreFileButt.TabIndex = 18;
            this.RestoreFileButt.Text = "Восстановить файл";
            this.RestoreFileButt.UseVisualStyleBackColor = true;
            this.RestoreFileButt.Click += new System.EventHandler(this.RestoreFileButt_Click);
            // 
            // RestoreCureFileButt
            // 
            this.RestoreCureFileButt.Location = new System.Drawing.Point(1143, 228);
            this.RestoreCureFileButt.Name = "RestoreCureFileButt";
            this.RestoreCureFileButt.Size = new System.Drawing.Size(141, 59);
            this.RestoreCureFileButt.TabIndex = 19;
            this.RestoreCureFileButt.Text = "Восстановить и вылечить";
            this.RestoreCureFileButt.UseVisualStyleBackColor = true;
            this.RestoreCureFileButt.Click += new System.EventHandler(this.RestoreCureFileButt_Click);
            // 
            // DeleteFileButt
            // 
            this.DeleteFileButt.Location = new System.Drawing.Point(1143, 308);
            this.DeleteFileButt.Name = "DeleteFileButt";
            this.DeleteFileButt.Size = new System.Drawing.Size(141, 57);
            this.DeleteFileButt.TabIndex = 20;
            this.DeleteFileButt.Text = "Удалить файл";
            this.DeleteFileButt.UseVisualStyleBackColor = true;
            this.DeleteFileButt.Click += new System.EventHandler(this.DeleteFileButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 429);
            this.Controls.Add(this.DeleteFileButt);
            this.Controls.Add(this.RestoreCureFileButt);
            this.Controls.Add(this.RestoreFileButt);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.LBforQuarantine);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BrowsePapka);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilterForMonitor);
            this.Controls.Add(this.MonStart);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button MonStart;
        public System.Windows.Forms.TextBox FilterForMonitor;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button BrowsePapka;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.ListBox LBforQuarantine;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button RestoreFileButt;
        private System.Windows.Forms.Button RestoreCureFileButt;
        private System.Windows.Forms.Button DeleteFileButt;
    }
}

