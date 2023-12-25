namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChangeBox = new System.Windows.Forms.GroupBox();
            this.ChangeList = new System.Windows.Forms.ListBox();
            this.ChangerValueBox = new System.Windows.Forms.GroupBox();
            this.ChangerValueLabel = new System.Windows.Forms.Label();
            this.ObmenBox = new System.Windows.Forms.GroupBox();
            this.ObmenCourseText = new System.Windows.Forms.Label();
            this.ObmenCourseTextLabel = new System.Windows.Forms.Label();
            this.ObmenFromTextBox = new System.Windows.Forms.TextBox();
            this.ObmenFIOTextBox = new System.Windows.Forms.TextBox();
            this.ObmenToTextBox = new System.Windows.Forms.TextBox();
            this.ObmenFIOLabel = new System.Windows.Forms.Label();
            this.ObmenToLabel = new System.Windows.Forms.Label();
            this.ObmenFromLabel = new System.Windows.Forms.Label();
            this.ObmenFromToLabel = new System.Windows.Forms.Label();
            this.ObmenData = new System.Windows.Forms.Label();
            this.OrderFinalPrice = new System.Windows.Forms.Label();
            this.buttonChangeConfirm = new System.Windows.Forms.Button();
            this.HistoryBox = new System.Windows.Forms.GroupBox();
            this.HistoryPanel = new System.Windows.Forms.Panel();
            this.CreatePeopleButton = new System.Windows.Forms.Button();
            this.GoAwayButton = new System.Windows.Forms.Button();
            this.BankerPicture = new System.Windows.Forms.PictureBox();
            this.ChangeBox.SuspendLayout();
            this.ChangerValueBox.SuspendLayout();
            this.ObmenBox.SuspendLayout();
            this.HistoryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeBox
            // 
            this.ChangeBox.Controls.Add(this.ChangeList);
            this.ChangeBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeBox.Location = new System.Drawing.Point(12, 12);
            this.ChangeBox.MaximumSize = new System.Drawing.Size(384, 173);
            this.ChangeBox.MinimumSize = new System.Drawing.Size(384, 173);
            this.ChangeBox.Name = "ChangeBox";
            this.ChangeBox.Size = new System.Drawing.Size(384, 173);
            this.ChangeBox.TabIndex = 0;
            this.ChangeBox.TabStop = false;
            this.ChangeBox.Text = "Выбор Обмена Валюты";
            // 
            // ChangeList
            // 
            this.ChangeList.BackColor = System.Drawing.Color.LightGray;
            this.ChangeList.FormattingEnabled = true;
            this.ChangeList.ItemHeight = 17;
            this.ChangeList.Location = new System.Drawing.Point(6, 22);
            this.ChangeList.MaximumSize = new System.Drawing.Size(372, 140);
            this.ChangeList.MinimumSize = new System.Drawing.Size(372, 140);
            this.ChangeList.Name = "ChangeList";
            this.ChangeList.Size = new System.Drawing.Size(372, 140);
            this.ChangeList.TabIndex = 0;
            this.ChangeList.SelectedIndexChanged += new System.EventHandler(this.ChangeList_SelectedIndexChanged);
            // 
            // ChangerValueBox
            // 
            this.ChangerValueBox.Controls.Add(this.ChangerValueLabel);
            this.ChangerValueBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangerValueBox.Location = new System.Drawing.Point(402, 12);
            this.ChangerValueBox.Name = "ChangerValueBox";
            this.ChangerValueBox.Size = new System.Drawing.Size(310, 173);
            this.ChangerValueBox.TabIndex = 1;
            this.ChangerValueBox.TabStop = false;
            this.ChangerValueBox.Text = "Валюта обменника";
            // 
            // ChangerValueLabel
            // 
            this.ChangerValueLabel.AutoSize = true;
            this.ChangerValueLabel.BackColor = System.Drawing.Color.LightGray;
            this.ChangerValueLabel.Location = new System.Drawing.Point(6, 22);
            this.ChangerValueLabel.MaximumSize = new System.Drawing.Size(298, 125);
            this.ChangerValueLabel.MinimumSize = new System.Drawing.Size(298, 125);
            this.ChangerValueLabel.Name = "ChangerValueLabel";
            this.ChangerValueLabel.Size = new System.Drawing.Size(298, 125);
            this.ChangerValueLabel.TabIndex = 0;
            this.ChangerValueLabel.Text = "Деньги в хранилище обменника: ";
            // 
            // ObmenBox
            // 
            this.ObmenBox.BackColor = System.Drawing.Color.LightGray;
            this.ObmenBox.Controls.Add(this.ObmenCourseText);
            this.ObmenBox.Controls.Add(this.ObmenCourseTextLabel);
            this.ObmenBox.Controls.Add(this.ObmenFromTextBox);
            this.ObmenBox.Controls.Add(this.ObmenFIOTextBox);
            this.ObmenBox.Controls.Add(this.ObmenToTextBox);
            this.ObmenBox.Controls.Add(this.ObmenFIOLabel);
            this.ObmenBox.Controls.Add(this.ObmenToLabel);
            this.ObmenBox.Controls.Add(this.ObmenFromLabel);
            this.ObmenBox.Controls.Add(this.ObmenFromToLabel);
            this.ObmenBox.Controls.Add(this.ObmenData);
            this.ObmenBox.Controls.Add(this.OrderFinalPrice);
            this.ObmenBox.Controls.Add(this.buttonChangeConfirm);
            this.ObmenBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ObmenBox.Location = new System.Drawing.Point(402, 191);
            this.ObmenBox.Name = "ObmenBox";
            this.ObmenBox.Size = new System.Drawing.Size(310, 425);
            this.ObmenBox.TabIndex = 2;
            this.ObmenBox.TabStop = false;
            this.ObmenBox.Text = "Оформление обмена";
            // 
            // ObmenCourseText
            // 
            this.ObmenCourseText.AutoSize = true;
            this.ObmenCourseText.Location = new System.Drawing.Point(52, 145);
            this.ObmenCourseText.Name = "ObmenCourseText";
            this.ObmenCourseText.Size = new System.Drawing.Size(12, 17);
            this.ObmenCourseText.TabIndex = 21;
            this.ObmenCourseText.Text = "-";
            // 
            // ObmenCourseTextLabel
            // 
            this.ObmenCourseTextLabel.AutoSize = true;
            this.ObmenCourseTextLabel.Location = new System.Drawing.Point(10, 145);
            this.ObmenCourseTextLabel.Name = "ObmenCourseTextLabel";
            this.ObmenCourseTextLabel.Size = new System.Drawing.Size(43, 17);
            this.ObmenCourseTextLabel.TabIndex = 20;
            this.ObmenCourseTextLabel.Text = "Курс:";
            // 
            // ObmenFromTextBox
            // 
            this.ObmenFromTextBox.Location = new System.Drawing.Point(186, 108);
            this.ObmenFromTextBox.Name = "ObmenFromTextBox";
            this.ObmenFromTextBox.Size = new System.Drawing.Size(100, 23);
            this.ObmenFromTextBox.TabIndex = 19;
            this.ObmenFromTextBox.TextChanged += new System.EventHandler(this.ObmenFromTextBox_TextChanged);
            // 
            // ObmenFIOTextBox
            // 
            this.ObmenFIOTextBox.Location = new System.Drawing.Point(13, 239);
            this.ObmenFIOTextBox.Name = "ObmenFIOTextBox";
            this.ObmenFIOTextBox.Size = new System.Drawing.Size(263, 23);
            this.ObmenFIOTextBox.TabIndex = 18;
            // 
            // ObmenToTextBox
            // 
            this.ObmenToTextBox.Location = new System.Drawing.Point(176, 182);
            this.ObmenToTextBox.Name = "ObmenToTextBox";
            this.ObmenToTextBox.ReadOnly = true;
            this.ObmenToTextBox.Size = new System.Drawing.Size(100, 23);
            this.ObmenToTextBox.TabIndex = 15;
            // 
            // ObmenFIOLabel
            // 
            this.ObmenFIOLabel.AutoSize = true;
            this.ObmenFIOLabel.Location = new System.Drawing.Point(10, 219);
            this.ObmenFIOLabel.Name = "ObmenFIOLabel";
            this.ObmenFIOLabel.Size = new System.Drawing.Size(102, 17);
            this.ObmenFIOLabel.TabIndex = 13;
            this.ObmenFIOLabel.Text = "Ваши данные:";
            // 
            // ObmenToLabel
            // 
            this.ObmenToLabel.AutoSize = true;
            this.ObmenToLabel.Location = new System.Drawing.Point(10, 182);
            this.ObmenToLabel.Name = "ObmenToLabel";
            this.ObmenToLabel.Size = new System.Drawing.Size(98, 17);
            this.ObmenToLabel.TabIndex = 12;
            this.ObmenToLabel.Text = "Вы получите ()";
            // 
            // ObmenFromLabel
            // 
            this.ObmenFromLabel.AutoSize = true;
            this.ObmenFromLabel.Location = new System.Drawing.Point(10, 108);
            this.ObmenFromLabel.Name = "ObmenFromLabel";
            this.ObmenFromLabel.Size = new System.Drawing.Size(117, 17);
            this.ObmenFromLabel.TabIndex = 11;
            this.ObmenFromLabel.Text = "Введите сумму ()";
            // 
            // ObmenFromToLabel
            // 
            this.ObmenFromToLabel.AutoSize = true;
            this.ObmenFromToLabel.Location = new System.Drawing.Point(10, 31);
            this.ObmenFromToLabel.Name = "ObmenFromToLabel";
            this.ObmenFromToLabel.Size = new System.Drawing.Size(120, 51);
            this.ObmenFromToLabel.TabIndex = 10;
            this.ObmenFromToLabel.Text = "Обмен валюты\r\nЧто обменять:\r\nНа что обменять:";
            // 
            // ObmenData
            // 
            this.ObmenData.AutoSize = true;
            this.ObmenData.Location = new System.Drawing.Point(8, 402);
            this.ObmenData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ObmenData.Name = "ObmenData";
            this.ObmenData.Size = new System.Drawing.Size(49, 17);
            this.ObmenData.TabIndex = 9;
            this.ObmenData.Text = "Дата: ";
            // 
            // OrderFinalPrice
            // 
            this.OrderFinalPrice.AutoSize = true;
            this.OrderFinalPrice.Location = new System.Drawing.Point(7, 302);
            this.OrderFinalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OrderFinalPrice.Name = "OrderFinalPrice";
            this.OrderFinalPrice.Size = new System.Drawing.Size(74, 17);
            this.OrderFinalPrice.TabIndex = 7;
            this.OrderFinalPrice.Text = "К оплате: ";
            // 
            // buttonChangeConfirm
            // 
            this.buttonChangeConfirm.BackColor = System.Drawing.Color.Silver;
            this.buttonChangeConfirm.Location = new System.Drawing.Point(204, 368);
            this.buttonChangeConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChangeConfirm.Name = "buttonChangeConfirm";
            this.buttonChangeConfirm.Size = new System.Drawing.Size(100, 51);
            this.buttonChangeConfirm.TabIndex = 0;
            this.buttonChangeConfirm.Text = "Принять";
            this.buttonChangeConfirm.UseVisualStyleBackColor = false;
            this.buttonChangeConfirm.Click += new System.EventHandler(this.buttonChangeConfirm_Click);
            // 
            // HistoryBox
            // 
            this.HistoryBox.Controls.Add(this.HistoryPanel);
            this.HistoryBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HistoryBox.Location = new System.Drawing.Point(718, 12);
            this.HistoryBox.Name = "HistoryBox";
            this.HistoryBox.Size = new System.Drawing.Size(310, 604);
            this.HistoryBox.TabIndex = 3;
            this.HistoryBox.TabStop = false;
            this.HistoryBox.Text = "История обменов";
            // 
            // HistoryPanel
            // 
            this.HistoryPanel.AutoScroll = true;
            this.HistoryPanel.Location = new System.Drawing.Point(6, 22);
            this.HistoryPanel.Name = "HistoryPanel";
            this.HistoryPanel.Size = new System.Drawing.Size(298, 576);
            this.HistoryPanel.TabIndex = 0;
            // 
            // CreatePeopleButton
            // 
            this.CreatePeopleButton.BackColor = System.Drawing.Color.YellowGreen;
            this.CreatePeopleButton.Location = new System.Drawing.Point(9, 559);
            this.CreatePeopleButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreatePeopleButton.Name = "CreatePeopleButton";
            this.CreatePeopleButton.Size = new System.Drawing.Size(114, 58);
            this.CreatePeopleButton.TabIndex = 6;
            this.CreatePeopleButton.Text = "Создать";
            this.CreatePeopleButton.UseVisualStyleBackColor = false;
            this.CreatePeopleButton.Click += new System.EventHandler(this.CreatePeopleButton_Click);
            // 
            // GoAwayButton
            // 
            this.GoAwayButton.BackColor = System.Drawing.Color.IndianRed;
            this.GoAwayButton.Location = new System.Drawing.Point(275, 564);
            this.GoAwayButton.Margin = new System.Windows.Forms.Padding(2);
            this.GoAwayButton.Name = "GoAwayButton";
            this.GoAwayButton.Size = new System.Drawing.Size(114, 58);
            this.GoAwayButton.TabIndex = 5;
            this.GoAwayButton.Text = "Уйти";
            this.GoAwayButton.UseVisualStyleBackColor = false;
            this.GoAwayButton.Click += new System.EventHandler(this.GoAwayButton_Click);
            // 
            // BankerPicture
            // 
            this.BankerPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BankerPicture.Image = ((System.Drawing.Image)(resources.GetObject("BankerPicture.Image")));
            this.BankerPicture.Location = new System.Drawing.Point(124, 191);
            this.BankerPicture.Margin = new System.Windows.Forms.Padding(2);
            this.BankerPicture.Name = "BankerPicture";
            this.BankerPicture.Size = new System.Drawing.Size(105, 73);
            this.BankerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BankerPicture.TabIndex = 7;
            this.BankerPicture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1034, 621);
            this.Controls.Add(this.ObmenBox);
            this.Controls.Add(this.BankerPicture);
            this.Controls.Add(this.GoAwayButton);
            this.Controls.Add(this.CreatePeopleButton);
            this.Controls.Add(this.HistoryBox);
            this.Controls.Add(this.ChangerValueBox);
            this.Controls.Add(this.ChangeBox);
            this.MaximumSize = new System.Drawing.Size(1050, 660);
            this.MinimumSize = new System.Drawing.Size(1050, 660);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ChangeBox.ResumeLayout(false);
            this.ChangerValueBox.ResumeLayout(false);
            this.ChangerValueBox.PerformLayout();
            this.ObmenBox.ResumeLayout(false);
            this.ObmenBox.PerformLayout();
            this.HistoryBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BankerPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChangeBox;
        private System.Windows.Forms.ListBox ChangeList;
        private System.Windows.Forms.GroupBox ChangerValueBox;
        private System.Windows.Forms.Label ChangerValueLabel;
        private System.Windows.Forms.GroupBox ObmenBox;
        private System.Windows.Forms.GroupBox HistoryBox;
        private System.Windows.Forms.Panel HistoryPanel;
        private System.Windows.Forms.Button buttonChangeConfirm;
        private System.Windows.Forms.Button CreatePeopleButton;
        private System.Windows.Forms.Button GoAwayButton;
        private System.Windows.Forms.PictureBox BankerPicture;
        private System.Windows.Forms.Label OrderFinalPrice;
        private System.Windows.Forms.Label ObmenData;
        private System.Windows.Forms.Label ObmenFIOLabel;
        private System.Windows.Forms.Label ObmenToLabel;
        private System.Windows.Forms.Label ObmenFromLabel;
        private System.Windows.Forms.Label ObmenFromToLabel;
        private System.Windows.Forms.TextBox ObmenToTextBox;
        private System.Windows.Forms.TextBox ObmenFromTextBox;
        private System.Windows.Forms.TextBox ObmenFIOTextBox;
        private System.Windows.Forms.Label ObmenCourseTextLabel;
        private System.Windows.Forms.Label ObmenCourseText;
    }
}

