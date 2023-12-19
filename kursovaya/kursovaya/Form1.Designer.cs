namespace kursovaya
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EventsListBox = new GroupBox();
            EventList = new ListBox();
            HistoryBox = new GroupBox();
            HistoryPanel = new Panel();
            OrderBox = new GroupBox();
            __OrderFinalPrice = new Label();
            _OrderFinalPrice = new Label();
            OrderBuyButton = new Button();
            OrderFinalPrice = new Label();
            OrderFIO = new TextBox();
            OrderPhone = new MaskedTextBox();
            _OrderPhone = new Label();
            _OrderFIO = new Label();
            _OrderCount = new Label();
            OrderCount = new NumericUpDown();
            _OrderPrice = new Label();
            OrderPrice = new TextBox();
            _OrderLocation = new Label();
            OrderLocation = new TextBox();
            _OrderData = new Label();
            OrderData = new TextBox();
            _OrderName = new Label();
            OrderName = new TextBox();
            OrderDenyButton = new Button();
            CreatePeopleButton = new Button();
            HouseBox1 = new PictureBox();
            LabelSumma = new Label();
            EventsListBox.SuspendLayout();
            HistoryBox.SuspendLayout();
            OrderBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HouseBox1).BeginInit();
            SuspendLayout();
            // 
            // EventsListBox
            // 
            EventsListBox.BackColor = Color.FromArgb(164, 43, 43);
            EventsListBox.Controls.Add(EventList);
            EventsListBox.Enabled = false;
            EventsListBox.Font = new Font("Century Gothic", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            EventsListBox.ForeColor = SystemColors.ControlLightLight;
            EventsListBox.Location = new Point(12, 12);
            EventsListBox.Name = "EventsListBox";
            EventsListBox.Size = new Size(1214, 221);
            EventsListBox.TabIndex = 0;
            EventsListBox.TabStop = false;
            EventsListBox.Text = "Доступные мероприятия";
            // 
            // EventList
            // 
            EventList.BackColor = Color.FromArgb(164, 43, 43);
            EventList.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            EventList.ForeColor = SystemColors.Window;
            EventList.FormattingEnabled = true;
            EventList.HorizontalScrollbar = true;
            EventList.ItemHeight = 28;
            EventList.Location = new Point(6, 40);
            EventList.Name = "EventList";
            EventList.Size = new Size(1202, 172);
            EventList.TabIndex = 0;
            EventList.SelectedIndexChanged += EventList_SelectedIndexChanged;
            // 
            // HistoryBox
            // 
            HistoryBox.BackColor = Color.FromArgb(164, 43, 43);
            HistoryBox.Controls.Add(HistoryPanel);
            HistoryBox.Font = new Font("Century Gothic", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            HistoryBox.ForeColor = SystemColors.ControlLightLight;
            HistoryBox.Location = new Point(1232, 12);
            HistoryBox.Name = "HistoryBox";
            HistoryBox.Size = new Size(730, 1255);
            HistoryBox.TabIndex = 1;
            HistoryBox.TabStop = false;
            HistoryBox.Text = "История заказов";
            // 
            // HistoryPanel
            // 
            HistoryPanel.AutoScroll = true;
            HistoryPanel.Location = new Point(20, 40);
            HistoryPanel.Name = "HistoryPanel";
            HistoryPanel.Size = new Size(693, 1199);
            HistoryPanel.TabIndex = 0;
            // 
            // OrderBox
            // 
            OrderBox.BackColor = Color.FromArgb(164, 43, 43);
            OrderBox.Controls.Add(__OrderFinalPrice);
            OrderBox.Controls.Add(_OrderFinalPrice);
            OrderBox.Controls.Add(OrderBuyButton);
            OrderBox.Controls.Add(OrderFinalPrice);
            OrderBox.Controls.Add(OrderFIO);
            OrderBox.Controls.Add(OrderPhone);
            OrderBox.Controls.Add(_OrderPhone);
            OrderBox.Controls.Add(_OrderFIO);
            OrderBox.Controls.Add(_OrderCount);
            OrderBox.Controls.Add(OrderCount);
            OrderBox.Controls.Add(_OrderPrice);
            OrderBox.Controls.Add(OrderPrice);
            OrderBox.Controls.Add(_OrderLocation);
            OrderBox.Controls.Add(OrderLocation);
            OrderBox.Controls.Add(_OrderData);
            OrderBox.Controls.Add(OrderData);
            OrderBox.Controls.Add(_OrderName);
            OrderBox.Controls.Add(OrderName);
            OrderBox.Enabled = false;
            OrderBox.Font = new Font("Century Gothic", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            OrderBox.ForeColor = SystemColors.ControlLightLight;
            OrderBox.Location = new Point(559, 239);
            OrderBox.Name = "OrderBox";
            OrderBox.Size = new Size(667, 895);
            OrderBox.TabIndex = 2;
            OrderBox.TabStop = false;
            OrderBox.Text = "Оформление заказа";
            // 
            // __OrderFinalPrice
            // 
            __OrderFinalPrice.AutoSize = true;
            __OrderFinalPrice.Font = new Font("Century Gothic", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            __OrderFinalPrice.Location = new Point(499, 535);
            __OrderFinalPrice.MaximumSize = new Size(150, 50);
            __OrderFinalPrice.MinimumSize = new Size(150, 50);
            __OrderFinalPrice.Name = "__OrderFinalPrice";
            __OrderFinalPrice.Size = new Size(150, 50);
            __OrderFinalPrice.TabIndex = 21;
            __OrderFinalPrice.Text = "руб.";
            // 
            // _OrderFinalPrice
            // 
            _OrderFinalPrice.AutoSize = true;
            _OrderFinalPrice.Font = new Font("Century Gothic", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            _OrderFinalPrice.Location = new Point(15, 535);
            _OrderFinalPrice.Name = "_OrderFinalPrice";
            _OrderFinalPrice.Size = new Size(305, 44);
            _OrderFinalPrice.TabIndex = 20;
            _OrderFinalPrice.Text = "Итоговая цена:";
            // 
            // OrderBuyButton
            // 
            OrderBuyButton.BackColor = Color.FromArgb(164, 43, 43);
            OrderBuyButton.ForeColor = SystemColors.ButtonHighlight;
            OrderBuyButton.Location = new Point(350, 772);
            OrderBuyButton.Name = "OrderBuyButton";
            OrderBuyButton.Size = new Size(299, 105);
            OrderBuyButton.TabIndex = 18;
            OrderBuyButton.Text = "Оплатить";
            OrderBuyButton.UseVisualStyleBackColor = false;
            OrderBuyButton.Click += OrderBuyButton_Click;
            // 
            // OrderFinalPrice
            // 
            OrderFinalPrice.AutoSize = true;
            OrderFinalPrice.Font = new Font("Century Gothic", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            OrderFinalPrice.Location = new Point(316, 535);
            OrderFinalPrice.MaximumSize = new Size(200, 50);
            OrderFinalPrice.MinimumSize = new Size(200, 50);
            OrderFinalPrice.Name = "OrderFinalPrice";
            OrderFinalPrice.Size = new Size(200, 50);
            OrderFinalPrice.TabIndex = 17;
            // 
            // OrderFIO
            // 
            OrderFIO.Location = new Point(249, 400);
            OrderFIO.Name = "OrderFIO";
            OrderFIO.Size = new Size(400, 41);
            OrderFIO.TabIndex = 16;
            // 
            // OrderPhone
            // 
            OrderPhone.Location = new Point(249, 456);
            OrderPhone.Mask = "+7 (999) 000-0000";
            OrderPhone.Name = "OrderPhone";
            OrderPhone.Size = new Size(400, 41);
            OrderPhone.TabIndex = 15;
            // 
            // _OrderPhone
            // 
            _OrderPhone.AutoSize = true;
            _OrderPhone.Location = new Point(21, 459);
            _OrderPhone.Name = "_OrderPhone";
            _OrderPhone.Size = new Size(208, 32);
            _OrderPhone.TabIndex = 13;
            _OrderPhone.Text = "Ваш Телефон:";
            // 
            // _OrderFIO
            // 
            _OrderFIO.AutoSize = true;
            _OrderFIO.Location = new Point(21, 400);
            _OrderFIO.Name = "_OrderFIO";
            _OrderFIO.Size = new Size(159, 32);
            _OrderFIO.TabIndex = 11;
            _OrderFIO.Text = "Ваше Имя:";
            // 
            // _OrderCount
            // 
            _OrderCount.AutoSize = true;
            _OrderCount.Location = new Point(21, 341);
            _OrderCount.Name = "_OrderCount";
            _OrderCount.Size = new Size(258, 32);
            _OrderCount.TabIndex = 9;
            _OrderCount.Text = "Количество мест:";
            // 
            // OrderCount
            // 
            OrderCount.Location = new Point(300, 341);
            OrderCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            OrderCount.Name = "OrderCount";
            OrderCount.ReadOnly = true;
            OrderCount.Size = new Size(240, 41);
            OrderCount.TabIndex = 8;
            OrderCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            OrderCount.ValueChanged += OrderCount_ValueChanged;
            // 
            // _OrderPrice
            // 
            _OrderPrice.AutoSize = true;
            _OrderPrice.Location = new Point(21, 280);
            _OrderPrice.Name = "_OrderPrice";
            _OrderPrice.Size = new Size(219, 32);
            _OrderPrice.TabIndex = 7;
            _OrderPrice.Text = "Цена за билет:";
            // 
            // OrderPrice
            // 
            OrderPrice.Location = new Point(249, 280);
            OrderPrice.Name = "OrderPrice";
            OrderPrice.ReadOnly = true;
            OrderPrice.Size = new Size(400, 41);
            OrderPrice.TabIndex = 6;
            // 
            // _OrderLocation
            // 
            _OrderLocation.AutoSize = true;
            _OrderLocation.Location = new Point(21, 221);
            _OrderLocation.Name = "_OrderLocation";
            _OrderLocation.Size = new Size(111, 32);
            _OrderLocation.TabIndex = 5;
            _OrderLocation.Text = "Место:";
            // 
            // OrderLocation
            // 
            OrderLocation.Location = new Point(249, 221);
            OrderLocation.Name = "OrderLocation";
            OrderLocation.ReadOnly = true;
            OrderLocation.Size = new Size(400, 41);
            OrderLocation.TabIndex = 4;
            // 
            // _OrderData
            // 
            _OrderData.AutoSize = true;
            _OrderData.Location = new Point(21, 162);
            _OrderData.Name = "_OrderData";
            _OrderData.Size = new Size(93, 32);
            _OrderData.TabIndex = 3;
            _OrderData.Text = "Дата:";
            // 
            // OrderData
            // 
            OrderData.Location = new Point(249, 162);
            OrderData.Name = "OrderData";
            OrderData.ReadOnly = true;
            OrderData.Size = new Size(400, 41);
            OrderData.TabIndex = 2;
            // 
            // _OrderName
            // 
            _OrderName.AutoSize = true;
            _OrderName.Location = new Point(21, 62);
            _OrderName.Name = "_OrderName";
            _OrderName.Size = new Size(209, 32);
            _OrderName.TabIndex = 1;
            _OrderName.Text = "Мероприятие:";
            // 
            // OrderName
            // 
            OrderName.Location = new Point(249, 62);
            OrderName.Multiline = true;
            OrderName.Name = "OrderName";
            OrderName.ReadOnly = true;
            OrderName.Size = new Size(400, 82);
            OrderName.TabIndex = 0;
            // 
            // OrderDenyButton
            // 
            OrderDenyButton.BackColor = Color.FromArgb(0, 189, 111);
            OrderDenyButton.Font = new Font("Century Gothic", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            OrderDenyButton.ForeColor = SystemColors.ControlLightLight;
            OrderDenyButton.Location = new Point(909, 1140);
            OrderDenyButton.Name = "OrderDenyButton";
            OrderDenyButton.Size = new Size(299, 105);
            OrderDenyButton.TabIndex = 19;
            OrderDenyButton.Text = "Выход";
            OrderDenyButton.UseVisualStyleBackColor = false;
            OrderDenyButton.Click += OrderDenyButton_Click;
            // 
            // CreatePeopleButton
            // 
            CreatePeopleButton.BackColor = Color.FromArgb(0, 180, 100);
            CreatePeopleButton.Font = new Font("Century Gothic", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            CreatePeopleButton.ForeColor = SystemColors.ControlLightLight;
            CreatePeopleButton.Location = new Point(12, 1191);
            CreatePeopleButton.Name = "CreatePeopleButton";
            CreatePeopleButton.Size = new Size(205, 76);
            CreatePeopleButton.TabIndex = 3;
            CreatePeopleButton.Text = "Создать покупателя";
            CreatePeopleButton.UseVisualStyleBackColor = false;
            CreatePeopleButton.Click += CreatePeopleButton_Click;
            // 
            // HouseBox1
            // 
            HouseBox1.BackgroundImage = Properties.Resources.House;
            HouseBox1.Location = new Point(12, 239);
            HouseBox1.Name = "HouseBox1";
            HouseBox1.Size = new Size(541, 1028);
            HouseBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            HouseBox1.TabIndex = 20;
            HouseBox1.TabStop = false;
            // 
            // LabelSumma
            // 
            LabelSumma.AutoSize = true;
            LabelSumma.Location = new Point(565, 1141);
            LabelSumma.Name = "LabelSumma";
            LabelSumma.Size = new Size(78, 32);
            LabelSumma.TabIndex = 21;
            LabelSumma.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 189, 111);
            ClientSize = new Size(1974, 1279);
            Controls.Add(LabelSumma);
            Controls.Add(CreatePeopleButton);
            Controls.Add(OrderBox);
            Controls.Add(OrderDenyButton);
            Controls.Add(HistoryBox);
            Controls.Add(EventsListBox);
            Controls.Add(HouseBox1);
            MaximumSize = new Size(2000, 1350);
            MinimumSize = new Size(2000, 1350);
            Name = "Form1";
            Text = "Form1";
            EventsListBox.ResumeLayout(false);
            HistoryBox.ResumeLayout(false);
            OrderBox.ResumeLayout(false);
            OrderBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OrderCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)HouseBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox EventsListBox;
        private ListBox EventList;
        private GroupBox HistoryBox;
        private Panel HistoryPanel;
        private GroupBox OrderBox;
        private Label _OrderName;
        private TextBox OrderName;
        private Label _OrderLocation;
        private TextBox OrderLocation;
        private Label _OrderData;
        private TextBox OrderData;
        private Label _OrderPrice;
        private TextBox OrderPrice;
        private NumericUpDown OrderCount;
        private Label _OrderCount;
        private Label _OrderPhone;
        private Label _OrderFIO;
        private MaskedTextBox OrderPhone;
        private TextBox OrderFIO;
        private Label OrderFinalPrice;
        private Button OrderDenyButton;
        private Button OrderBuyButton;
        private Label __OrderFinalPrice;
        private Label _OrderFinalPrice;
        private Button CreatePeopleButton;
        private PictureBox HouseBox1;
        private Label LabelSumma;
    }
}