using kursach.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{

    public partial class Form1 : Form
    {
        // Для себя:
        // Размеры окна - 564х830
        // Размеры барьера - 63х73
        private Train train; // Объект для поезда
        private Vehicle car; // Объек для машины
        protected int carX; // Координаты машины
        protected int carY;
        // Всплывающие подсказки с данными машины/поезда
        ToolTip toolTipTrain = new ToolTip();
        ToolTip toolTipCar = new ToolTip();
        // Скорости машины/поезда
        private int trainSpeed = 1;
        private int carSpeed = 1;
        
        // Конструктор формы
        public Form1()
        {
            InitializeComponent();
        }

        // Метод нажатия на кнопку создания поезда
        private void ButtonCreateTrain_Click(object sender, EventArgs e)
        {
            ButtonCreateTrain.Enabled = false; // Блокируется кнопка
            train = HelpObjects.createTrain(trainSpeed); // Создается поезд
            TrainMoving(); // Поезд едет
        }
        // Метод нажатия на кнопку создания машины
        private void ButtonCreateCar_Click(object sender, EventArgs e)
        {
            ButtonCreateCar.Enabled = false; // Блокирую кнопку создания машины
            car = HelpObjects.createCar(carSpeed); // Создается машина

            car.Picture.BackColor = Color.Transparent; // Для прозрачного заднего фона
            Controls.Add(car.Picture); 
            car.Picture.BringToFront(); // На передний план чтобы не загораживали другие картинки

            // Создаю подсказку с данными о машине
            toolTipCar = new ToolTip();
            toolTipCar.SetToolTip(car.Picture, car.getInfo());
            toolTipCar.AutomaticDelay = 50;
            toolTipCar.AutoPopDelay = 5000;
            
            // Машина едет (через таймер)
            if(car.Speed < 0) { CarMovingUp(); }
            else if (car.Speed > 0) { CarMovingDown(); }
            
        }

        private void TrainMoving()
        {
            // Добавляю обработчики события на открытие/закрытие шлагбаума и дальнейшее движение машины
            train.BarrierUp += TrainIncoming;
            train.BarrierDown += TrainOutcoming;
            train.IsMoving = true;
            //BarrierSwitcher();

            int trainX = 600;
            int trainY = 534;
            // 544 - Конец экрана
            train.Picture.Location = new Point(trainX, trainY);
            train.Picture.BackColor = Color.Transparent; // Для прозрачного заднего фона
            Controls.Add(train.Picture);
            train.Picture.BringToFront();

            // Создаю подсказку с данными о поезде
            toolTipTrain = new ToolTip();
            toolTipTrain.SetToolTip(train.Picture, train.getInfo());
            toolTipTrain.AutomaticDelay = 50;
            toolTipTrain.AutoPopDelay = 5000;

            // Таймер, с помощью которого меняется Location картинки поезда, как будто поезд едет
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                train.Picture.Location = new Point(trainX - train.Speed, trainY);

                trainX -= train.Speed;

                if (trainX < -250)
                {
                    moveTimer.Stop();
                    Controls.Remove(train.Picture);
                    train.IsMoving = false;
                    train.BarrierUp -= TrainIncoming;
                    train.BarrierDown -= TrainOutcoming;
                    train = null;
                    
                    //BarrierSwitcher();
                    ButtonCreateTrain.Enabled = true;
                }
            };
            moveTimer.Start();
        }

        // Движение машинки до шлагбаума снизу вверх
        private void CarMovingUp()
        {
            carX = 290;
            carY = 860;
            car.Picture.Location = new Point(carX, carY);

            //объяснение как и в строке 89, но для машины
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                car.Picture.Location = new Point(carX, carY + car.Speed);
                carY += car.Speed;

                if (carY < 625)
                {
                    if(train == null || train.IsMoving == false) { CarMovingUp2(); }
                    moveTimer.Stop();
                }
            };
            moveTimer.Start();
        }
        
        // Движение машинки после шлагбаума снизу вверх
        private void CarMovingUp2()
        {
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                car.Picture.Location = new Point(carX, carY + car.Speed);
                carY += car.Speed;

                if (carY < -250)
                {
                    moveTimer.Stop();
                    Controls.Remove(car.Picture);
                    car = null;
                    
                    ButtonCreateCar.Enabled = true;

                }
            };
            moveTimer.Start();
        }
        // // Движение машинки до шлагбаума сверху вниз
        private void CarMovingDown()
        {
            carX = 230;
            carY = -250;
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                car.Picture.Location = new Point(carX, carY + car.Speed);
                carY += car.Speed;

                if (carY >= 470 - car.Picture.Size.Height)
                {
                    if (train == null || train.IsMoving == false) { CarMovingDown2(); }
                    moveTimer.Stop();
                }
            };
            moveTimer.Start();
        }

        // Движение машинки после шлагбаума сверху вниз
        private void CarMovingDown2()
        {
            if (car != null)
            {
                System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
                moveTimer.Interval = 10;
                moveTimer.Tick += (s, args) =>
                {
                    car.Picture.Location = new Point(carX, carY + car.Speed);
                    carY += car.Speed;

                    if (carY > 860)
                    {
                        moveTimer.Stop();
                        Controls.Remove(car.Picture);
                        car = null;

                        ButtonCreateCar.Enabled = true;
                    }
                };
                moveTimer.Start();
            }
        }

        // Метод, работающий при вызове события закрытия шлагбаума
        private void TrainIncoming(object sender, EventArgs e)
        {
            MessageBox.Show("Поезд приближается!\nПереезд закрыт.");
            BarrierLeft.BackgroundImage = Image.FromFile(HelpObjects.BarrierImages[0].ToString());
            BarrierRight.BackgroundImage = Image.FromFile(HelpObjects.BarrierImages[1].ToString());
        }

        // Метод при открытии шлагбаума и продолжение движения машинкок если есть
        private void TrainOutcoming(object sender, EventArgs e)
        {
            MessageBox.Show("Поезд уехал!\nПереезд открыт.");
            BarrierLeft.BackgroundImage = Image.FromFile(HelpObjects.BarrierImages[2].ToString());
            BarrierRight.BackgroundImage = Image.FromFile(HelpObjects.BarrierImages[3].ToString());
            if ((car != null) && (car.Speed < 0)) { CarMovingUp2(); }
            else if ((car != null) && (car.Speed > 0)) { CarMovingDown2(); }
        }

        // Методы для изменения скоростей машины/поезда
        private void CarSpeedNumber_ValueChanged(object sender, EventArgs e)
        {
            carSpeed = (int)CarSpeedNumber.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trainSpeed = (int)trainSpeedNumber.Value;
        }
    }

    public class Vehicle // Класс транспортного средства
    {
        private string _number; // Номер
        private int _speed; // Скорость
        private string _type; // Тип ТС
        private PictureBox _picture; // Картинка

        // Констуктор
        public Vehicle(string number, int speed, string type, PictureBox picture)
        {
            Number = number;
            Speed = speed;
            Type = type;
            Picture = picture;
        }

        // Геттеры и сеттеры
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public PictureBox Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        // Метод получения информации (переопредеяемый)
        public virtual string getInfo()
        {
            string str = "Номер: " + Number + "\nСкорость: " + Math.Abs(Speed*10).ToString() + "\nТип: " + Type;
            return str;
        }
    }

    public class Train : Vehicle // Класс Поезда
    {
        private int _weight; // Вес
        private bool _is_moving; // Двигается или нет

        public EventHandler BarrierUp; // Событие чтобы опустить шлагбаум
        public EventHandler BarrierDown; // Событие чтобы поднять шлагбаум

        // Методы для вызова событий
        protected virtual void OnBarrierUp()
        {
            BarrierUp?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnBarrierDown()
        {
            BarrierDown?.Invoke(this, EventArgs.Empty);
        }

        // Геттеры и сеттеры
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public bool IsMoving
        {
            get { return _is_moving; }
            set 
            { 
                _is_moving = value;
                if (IsMoving == true) { OnBarrierUp(); }
                else if (IsMoving == false) {  OnBarrierDown(); }
            }
        }

        // Конструктор
        public Train(string number, int speed, string type, int weight, PictureBox picture) : base(number, speed, type, picture)
        {
            Weight = weight;
            IsMoving = false;
        }

        // Переобределенный метод получения информации
        public override string getInfo()
        {
            string str =  base.getInfo() + "\nВес: " + Weight.ToString() + "тонн";
            if (IsMoving) { str += "\nДвигается"; }
            else { str += "\nСтоит"; }
            return str;
        }
    }

    public class HelpObjects // Класс вспомогательных объектов
    {
        private static Random rnd = new Random();
        private static string[] carNumbers = { "А123ВС", "М456ОР", "Т789УХ", "К012ЕН", "У345АК", 
                                               "С678ОМ", "Н901ТМ", "Р234ХУ", "В567КА", "Е890НС" };
        private static string[] trainNames = { "Сапсан", "Ласточка", "Стриж", "Русич", "Алтай", 
                                               "Восток", "Сибирь", "Амур", "ЮгЭкспресс", "Звезда" };
        private static string folderpath = Path.GetFullPath("Resources") + "\\..\\..\\..\\Resources\\"; // Путь для картинок
        private static string TrainImagePath = $"{folderpath}train.png"; // Картинка поезда
        private static string[] CarImagesUpPath = // Картинки машин
        {
            $"{folderpath}\\1Car_up.png", // 46x158
            $"{folderpath}\\2Car_up.png", // 38x91
            $"{folderpath}\\3Car_up.png"  // 38x88
        };
        private static string[] CarImagesDownPath =
        {
            $"{folderpath}\\1Car_down.png",
            $"{folderpath}\\2Car_down.png",
            $"{folderpath}\\3Car_down.png"
        };
        private static int[] CarImagesUpXY = { 46, 158, 38, 91, 38, 88 }; // Размеры картинок автомобилей
        public static string[] BarrierImages = // Картинки шлагбаумов
        {
            $"{folderpath}\\barrierleftclosed.png",
            $"{folderpath}\\barrierrightclosed.png",
            $"{folderpath}\\barrierleftopen.png",
            $"{folderpath}\\barrierrightopen.png"
        };
        // Метод для создания поезда
        public static Train createTrain(int trainSpeed)
        {
            PictureBox trainImage = new PictureBox();
            trainImage.Image = Image.FromFile(TrainImagePath);
            trainImage.Size = new Size(209 + 6, 43);
            //trainImage.Name = trainNames[rnd.Next(trainNames.Length)];
            Train train = new Train(trainNames[rnd.Next(trainNames.Length)], trainSpeed, "Поезд", rnd.Next(50,80), trainImage);
            return train;
        }
        // Метод для создания Автомобиля
        public static Vehicle createCar(int carSpeed)
        {
            PictureBox carImage = new PictureBox();
            string imagepath;
            int index;
            if (rnd.Next(10) > 5) // Вероятность создания машины "по движению" и "против движения" (для разных полос типа)
            {
                carSpeed *= -1;
                // Создается машинка которая едет сверху-вниз
                index = rnd.Next(CarImagesUpPath.Length);
                imagepath = CarImagesUpPath[index];
            }
            else
            {
                // Создается машинка снизу-вверх
                index = rnd.Next(CarImagesDownPath.Length);
                imagepath = CarImagesDownPath[index];
            }
            carImage.Size = new Size(CarImagesUpXY[index * 2], CarImagesUpXY[index * 2 + 1]);
            carImage.Image = Image.FromFile(imagepath);
            Vehicle Car = new Vehicle(carNumbers[rnd.Next(carNumbers.Length)], carSpeed, "Автомобиль", carImage);
            return Car;
        }
    }
}
