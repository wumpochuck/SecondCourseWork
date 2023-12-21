namespace kursach
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
            this.BarrierLeft = new System.Windows.Forms.PictureBox();
            this.BarrierRight = new System.Windows.Forms.PictureBox();
            this.ButtonCreateTrain = new System.Windows.Forms.Button();
            this.ButtonCreateCar = new System.Windows.Forms.Button();
            this.CarSpeedNumber = new System.Windows.Forms.NumericUpDown();
            this.CarSpeedLabel = new System.Windows.Forms.Label();
            this.trainSpeedLabel = new System.Windows.Forms.Label();
            this.trainSpeedNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarSpeedNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainSpeedNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // BarrierLeft
            // 
            this.BarrierLeft.BackColor = System.Drawing.Color.Transparent;
            this.BarrierLeft.BackgroundImage = global::kursach.Properties.Resources.barrierleftopen;
            this.BarrierLeft.Location = new System.Drawing.Point(194, 460);
            this.BarrierLeft.MaximumSize = new System.Drawing.Size(63, 73);
            this.BarrierLeft.MinimumSize = new System.Drawing.Size(63, 73);
            this.BarrierLeft.Name = "BarrierLeft";
            this.BarrierLeft.Size = new System.Drawing.Size(63, 73);
            this.BarrierLeft.TabIndex = 0;
            this.BarrierLeft.TabStop = false;
            // 
            // BarrierRight
            // 
            this.BarrierRight.BackColor = System.Drawing.Color.Transparent;
            this.BarrierRight.BackgroundImage = global::kursach.Properties.Resources.barrierrightopen;
            this.BarrierRight.Location = new System.Drawing.Point(304, 541);
            this.BarrierRight.MaximumSize = new System.Drawing.Size(63, 73);
            this.BarrierRight.MinimumSize = new System.Drawing.Size(63, 73);
            this.BarrierRight.Name = "BarrierRight";
            this.BarrierRight.Size = new System.Drawing.Size(63, 73);
            this.BarrierRight.TabIndex = 1;
            this.BarrierRight.TabStop = false;
            // 
            // ButtonCreateTrain
            // 
            this.ButtonCreateTrain.BackColor = System.Drawing.Color.Chocolate;
            this.ButtonCreateTrain.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCreateTrain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCreateTrain.Location = new System.Drawing.Point(12, 301);
            this.ButtonCreateTrain.Name = "ButtonCreateTrain";
            this.ButtonCreateTrain.Size = new System.Drawing.Size(133, 31);
            this.ButtonCreateTrain.TabIndex = 2;
            this.ButtonCreateTrain.Text = "Создать Поезд";
            this.ButtonCreateTrain.UseVisualStyleBackColor = false;
            this.ButtonCreateTrain.Click += new System.EventHandler(this.ButtonCreateTrain_Click);
            // 
            // ButtonCreateCar
            // 
            this.ButtonCreateCar.BackColor = System.Drawing.Color.Chocolate;
            this.ButtonCreateCar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCreateCar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonCreateCar.Location = new System.Drawing.Point(12, 250);
            this.ButtonCreateCar.Name = "ButtonCreateCar";
            this.ButtonCreateCar.Size = new System.Drawing.Size(133, 31);
            this.ButtonCreateCar.TabIndex = 3;
            this.ButtonCreateCar.Text = "Создать Машину";
            this.ButtonCreateCar.UseVisualStyleBackColor = false;
            this.ButtonCreateCar.Click += new System.EventHandler(this.ButtonCreateCar_Click);
            // 
            // CarSpeedNumber
            // 
            this.CarSpeedNumber.BackColor = System.Drawing.Color.Chocolate;
            this.CarSpeedNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarSpeedNumber.ForeColor = System.Drawing.Color.White;
            this.CarSpeedNumber.Location = new System.Drawing.Point(493, 255);
            this.CarSpeedNumber.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CarSpeedNumber.MaximumSize = new System.Drawing.Size(31, 0);
            this.CarSpeedNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CarSpeedNumber.MinimumSize = new System.Drawing.Size(31, 0);
            this.CarSpeedNumber.Name = "CarSpeedNumber";
            this.CarSpeedNumber.Size = new System.Drawing.Size(31, 23);
            this.CarSpeedNumber.TabIndex = 4;
            this.CarSpeedNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CarSpeedNumber.ValueChanged += new System.EventHandler(this.CarSpeedNumber_ValueChanged);
            // 
            // CarSpeedLabel
            // 
            this.CarSpeedLabel.AutoSize = true;
            this.CarSpeedLabel.BackColor = System.Drawing.Color.Chocolate;
            this.CarSpeedLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarSpeedLabel.ForeColor = System.Drawing.Color.White;
            this.CarSpeedLabel.Location = new System.Drawing.Point(353, 250);
            this.CarSpeedLabel.MaximumSize = new System.Drawing.Size(134, 31);
            this.CarSpeedLabel.MinimumSize = new System.Drawing.Size(133, 31);
            this.CarSpeedLabel.Name = "CarSpeedLabel";
            this.CarSpeedLabel.Size = new System.Drawing.Size(133, 31);
            this.CarSpeedLabel.TabIndex = 5;
            this.CarSpeedLabel.Text = "Скорость Машины";
            this.CarSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainSpeedLabel
            // 
            this.trainSpeedLabel.AutoSize = true;
            this.trainSpeedLabel.BackColor = System.Drawing.Color.Chocolate;
            this.trainSpeedLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trainSpeedLabel.ForeColor = System.Drawing.Color.White;
            this.trainSpeedLabel.Location = new System.Drawing.Point(353, 301);
            this.trainSpeedLabel.MaximumSize = new System.Drawing.Size(134, 31);
            this.trainSpeedLabel.MinimumSize = new System.Drawing.Size(133, 31);
            this.trainSpeedLabel.Name = "trainSpeedLabel";
            this.trainSpeedLabel.Size = new System.Drawing.Size(133, 31);
            this.trainSpeedLabel.TabIndex = 7;
            this.trainSpeedLabel.Text = "Скорость Поезда";
            this.trainSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainSpeedNumber
            // 
            this.trainSpeedNumber.BackColor = System.Drawing.Color.Chocolate;
            this.trainSpeedNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trainSpeedNumber.ForeColor = System.Drawing.Color.White;
            this.trainSpeedNumber.Location = new System.Drawing.Point(493, 306);
            this.trainSpeedNumber.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trainSpeedNumber.MaximumSize = new System.Drawing.Size(31, 0);
            this.trainSpeedNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trainSpeedNumber.MinimumSize = new System.Drawing.Size(31, 0);
            this.trainSpeedNumber.Name = "trainSpeedNumber";
            this.trainSpeedNumber.Size = new System.Drawing.Size(31, 23);
            this.trainSpeedNumber.TabIndex = 6;
            this.trainSpeedNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trainSpeedNumber.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kursach.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(548, 791);
            this.Controls.Add(this.trainSpeedLabel);
            this.Controls.Add(this.trainSpeedNumber);
            this.Controls.Add(this.CarSpeedLabel);
            this.Controls.Add(this.CarSpeedNumber);
            this.Controls.Add(this.ButtonCreateCar);
            this.Controls.Add(this.ButtonCreateTrain);
            this.Controls.Add(this.BarrierRight);
            this.Controls.Add(this.BarrierLeft);
            this.MaximumSize = new System.Drawing.Size(564, 830);
            this.MinimumSize = new System.Drawing.Size(564, 830);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BarrierLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarSpeedNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainSpeedNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BarrierLeft;
        private System.Windows.Forms.PictureBox BarrierRight;
        private System.Windows.Forms.Button ButtonCreateTrain;
        private System.Windows.Forms.Button ButtonCreateCar;
        private System.Windows.Forms.NumericUpDown CarSpeedNumber;
        private System.Windows.Forms.Label CarSpeedLabel;
        private System.Windows.Forms.Label trainSpeedLabel;
        private System.Windows.Forms.NumericUpDown trainSpeedNumber;
    }
}

