using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        // Тут я не чистил, вдруг чето не надо
        private List<Changetype> changetypes = new List<Changetype>();
        private Changer changer = new Changer(1000, 1000, 8000, 7000, 1000, 300);
        private List<Person> peoples = new List<Person>();
        List<Order> orders = new List<Order>();
        private PictureBox personPicture;
        private System.Windows.Forms.Label personLabel;
        protected int historyX = 0;
        protected int historyY = 0;
        protected int xPerson, yPerson;
        protected int xLabel;
        private int ID = HelpObjects.generateRandomID();

        // Конструктор формы
        public Form1()
        {
            InitializeComponent();
            ChangeList.SelectedIndexChanged += new System.EventHandler(this.ChangeList_SelectedIndexChanged);
            changetypes = HelpObjects.Generate_ChangesCources();
            placeChangeTypes();
            UpdateChangerLabel();

            // Контроль доступа
            GoAwayButton.Enabled = false;
            ChangeList.Enabled = false;
            ObmenBox.Enabled = false;
        }

        // Заполнение списка обменов валют
        private void placeChangeTypes()
        {
            ChangeList.Items.Clear();

            foreach (Changetype e in changetypes)
            {
                ChangeList.Items.Add(e.getInfo());
            }
        }
        
        // Обновление валюты обменника
        void UpdateChangerLabel()
        {
            ChangerValueLabel.Text = changer.getInfo();
        }

        // Очистка заказа
        void ObmenBoxClear()
        {
            ObmenFromToLabel.Text = "Обмен валюты\nЧто обменять:\nНа что обменять:";
            ObmenFromLabel.Text = "Введите сумму ()";
            ObmenFromTextBox.Text = null;
            ObmenCourseText.Text = "-";
            ObmenToLabel.Text = "Вы получите ()";
            ObmenToTextBox.Text = null;
            ObmenFIOTextBox.Text = null;
            OrderFinalPrice.Text = "К оплате:";
        }

        // работа с выбором мероприятия
        private void ChangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeList.SelectedItem != null)
            {
                // Включаю заказ чтобы можно было вписать туда
                ObmenBox.Enabled = true;

                // Автоматическое заполнение некоторых данных
                int selectedOrderID = (int)ChangeList.SelectedItem.ToString()[0] - 48;
                ObmenFromToLabel.Text = selectedOrderID.ToString();
                foreach (Changetype changetype in changetypes)
                {
                    if (changetype.ID == selectedOrderID)
                    {
                        ObmenFromToLabel.Text = $"Обмен валюты\n" +
                                                $"Что обменять: {changetype.ChangeFrom}\n" +
                                                $"На что обменять: {changetype.ChangeTo}";
                        ObmenFromLabel.Text = $"Введите сумму ( {changetype.ChangeFrom} ):";
                        ObmenToLabel.Text = $"Вы получите ( {changetype.ChangeTo} ):";
                        ObmenCourseText.Text = changetype.ExchangeRate.ToString();
                        ObmenToTextBox.Text = "-";
                        ObmenData.Text = $"Дата: {DateTime.Now.ToString("g")}";
                        break;

                    }
                }
            }
            /*
            if (ChangeList.SelectedItem != null)
            {
                string selectedItem = ChangeList.SelectedItem.ToString();
                string[] selectedValues = selectedItem.Split(' ');

                if (selectedValues.Length >= 3)
                {
                    string changeFrom = selectedValues[0].Trim();
                    string changeTo = selectedValues[2].Trim();
                    int exchangeRate;

                    if (int.TryParse(selectedValues[1].Trim(), out exchangeRate))
                    {
                        // Установка значений в ObmenBox
                        obmenBoxChangeFrom.Text = changeFrom;
                        obmenBoxChangeTo.Text = changeTo;
                        obmenBoxExchangeRate.Text = exchangeRate.ToString();
                    }
                    //else
                    //{
                    //    // Обработка ошибки парсинга значения курса обмена
                    //    MessageBox.Show("Неверный формат курса обмена");
                    //}
                }
            }
            */
        }

        // Для изменения числовых данных внутри заказа в реальном времени
        private void ObmenFromTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ObmenToTextBox.Text = (Int32.Parse(ObmenFromTextBox.Text) / Int32.Parse(ObmenCourseText.Text)).ToString();
                OrderFinalPrice.Text = $"К оплате: {ObmenFromTextBox.Text} {ObmenFromLabel.Text.Split(' ')[ObmenFromLabel.Text.Split(' ').Length - 2]}";
            }
            catch 
            { 
                ObmenToTextBox.Text = "-";
                OrderFinalPrice.Text = "К оплате: -";
            }
        }

        // При подтверждении заказа
        private void buttonChangeConfirm_Click(object sender, EventArgs e)
        {
            // Нужные данные беру в переменные чтобы не вызывать функции каждый раз
            string obmenfrom = ObmenFromLabel.Text.Split(' ')[ObmenFromLabel.Text.Split(' ').Length - 2];
            string obmento = ObmenToLabel.Text.Split(' ')[ObmenToLabel.Text.Split(' ').Length - 2];
            int price, course;
            try
            {
                price = Int32.Parse(ObmenFromTextBox.Text);
                course = Int32.Parse(ObmenCourseText.Text);
            }
            catch { price = 0; course = -1; }
            Person person = peoples[0];
            // Флаг для закрашивания
            int flag = 1; // Все гуд
            if(person.Name != ObmenFIOTextBox.Text) { flag = 2; } // Неверные данные
            else if (flag3checker(obmenfrom,price)) { flag = 3; } // Нет денег у ч-ка
            else if (flag4checker(obmento, price/course)) { flag = 4; } // Нет денег у банка

            Order newOrder = new Order(obmenfrom, obmento,course,ObmenData.Text,ID,"N/A"); ID++;

            System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
            lb.Location = new Point(historyX, historyY);
            historyY += 100;

            // 
            if (flag == 1)
            {
                newOrder.Status = "Оплачено";
                lb.BackColor = Color.LightGreen;

                // Поиск нужного обмена
                foreach(Changetype ct in changetypes)
                {
                    if (ct.ChangeFrom == obmenfrom && ct.ChangeTo == obmento)
                    {
                        // Добавление метода к событию
                        ct.changeFromEnd += MessageChangeFromEnd;
                        ct.changeToEnd += MessageChangeToEnd;
                        

                        // Функции, которые реализуют "вычет денег" из person и changer (описаны ниже)
                        // Вынес отдельно, поскольку валют 6, и тут это будет выглядеть очень объёмно.

                        updatePersonMoney(obmenfrom, -price,ct);
                        updatePersonMoney(obmento, price / course,ct);
                        updateChangerMoney(obmenfrom, price,ct);
                        updateChangerMoney(obmento, -price / course,ct);
                        
                        // Удаление метода от события (обязательно, чтобы потом не вызывалось по 10 окошек "Закончилось чтото")
                        ct.changeFromEnd -= MessageChangeFromEnd;
                        ct.changeToEnd -= MessageChangeToEnd;
                    }
                }

            }
            else if (flag == 2)
            {
                newOrder.Status = "Неверные данные";
                lb.BackColor = Color.IndianRed;
            }
            else if(flag == 3)
            {
                newOrder.Status = "Недостаточно средств клиента";
                lb.BackColor = Color.Yellow;
            }
            else // if flag == 4
            {
                newOrder.Status = "Недостаточно средств обменника";
                lb.BackColor = Color.Orange;
            }
            // Окрашивание и изменение шрифта, затем заполнение текстом
            lb.Font = new Font("Century Gothic", 9);
            lb.ForeColor = Color.Black;
            lb.Size = new Size(width: 298, height: 100);
            lb.Text = newOrder.getInfo();
            // Добавление на форму и в список
            //HistoryPanel.Container.Add(lb);  
            HistoryPanel.Controls.Add(lb);
            orders.Add(newOrder);

            ObmenBoxClear();
            ChangeList.SelectedItem = null;
            ObmenBox.Enabled = false;


            /*
            // Проверка валидности заказа
            Person person = peoples[0];
            int flag = 1; // 1 - Всё хорошо
            if (person.Money < int.Parse(OrderFinalPrice.Text)) { flag = 2; } // 2 - недостаточно средств
            if ((person.Name != obmenBoxChangeFrom.Text)) { flag = 3; } // 3 - неверные данные

            // Создаем новый заказ 
            Order ord = new Order(obmenBoxChangeFrom.Text, obmenBoxChangeTo.Text, ID, DateTime.Parse(orderData.Text), ID, "N/A");
            ord.CurrencyFrom = ChangeList.SelectedItem.ToString();
            ID++;
            System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
            lb.Location = new Point(historyX, historyY);
            historyY += 200;
            lb.BackColor = Color.LightGreen;

            if (flag == 1) // Если хватило денег
            {
                ord.Status = "Оплачено";
                person.Money = person.Money - int.Parse(OrderFinalPrice.Text);
                updatePersonMoney(person);

                // Вычитание билетов
                string s = ChangeList.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (Changetype ct in changetypes)
                {
                    if (ct.ChangeFrom == ord.CurrencyFrom && ct.ChangeTo == person.Money.ToString())
                    {
                        int exchangedAmount = int.Parse(OrderFinalPrice.Text) * ct.ExchangeRate;
                        person.Money += exchangedAmount;

                        lb.Text += $"\nОбменено: {exchangedAmount} {ct.ChangeTo}";
                        break;
                    }
                }
                //обновдение баланса пользователч
                updatePersonMoney(person);

                OrderClear();

                // Обмен валюты
                string selectedCurrency = ChangeList.SelectedItem.ToString();
                foreach (Changetype ct in changetypes)
                {
                    if (ct.ChangeFrom == selectedCurrency)
                    {
                        int exchangedAmount = int.Parse(OrderFinalPrice.Text) * ct.ExchangeRate;
                        person.Money += exchangedAmount;
                        lb.Text += $"\nОбменено: {exchangedAmount} {ct.ChangeTo}";
                        break;
                    }
                }
            }
            else if (flag == 2) // Если не хватило денег
            {
                ord.Status = "Недостаточно средств";
                lb.BackColor = Color.LightPink;
            }
            else if (flag == 3) // Если неверные данные
            {
                ord.Status = "Неверные данные";
                lb.BackColor = Color.LightYellow;
            }
            // Окрашивание и изменение шрифта, затем заполнение текстом
            lb.Font = new Font("Century Gothic", 9);
            lb.ForeColor = Color.Black;
            lb.Size = new Size(width: 700, height: 200);
            lb.Text = ord.getInfo();
            // Добавление на форму и в список
            HistoryPanel.Controls.Add(lb);
            orders.Add(ord);
            */
        }

        // Ну тут из названия понятно думаю
        private void updatePersonMoney(string key,int value,Changetype ct)
        {
            Person person = peoples[0];
            if (key == "Рубли")
            {
                person.Rub = person.Rub + value;
                if (person.Rub <= 0) { ct.ChangeFrom = "-"; ct.ChangeFrom = "Рубли"; }

            }
            if (key == "Песо")
            {
                person.Peso = person.Peso + value;
                if (person.Peso <= 0) { ct.ChangeFrom = "-"; ct.ChangeFrom = "Песо"; }
            }
            if (key == "Доллары")
            {
                person.Dollar = person.Dollar + value;
                if (person.Dollar <= 0) { ct.ChangeFrom = "-"; ct.ChangeFrom = "Доллары"; }
            }
            if (key == "Евро")
            {
                person.Euro = person.Euro + value;
                if (person.Euro <= 0) { ct.ChangeFrom = "-"; ct.ChangeFrom = "Евро"; }
            }
            if (key == "Тенге")
            {
                person.Tenge = person.Tenge + value;
                if (person.Tenge <= 0) { ct.ChangeFrom = "-"; ct.ChangeFrom = "Тенге"; }
            }
            if (key == "Фунты")
            {
                person.Pounds = person.Pounds + value;
                if (person.Pounds <= 0) { ct.ChangeFrom = "-"; ct.ChangeFrom = "Фунты"; }
            }
            personLabel.Text = person.getInfo();
        }
        private void updateChangerMoney(string key, int value, Changetype ct)
        {
            if (key == "Рубли")
            {
                changer.Rub = changer.Rub + value;
                if (changer.Rub <= 0) { ct.ChangeTo = "-"; ct.ChangeTo = "Рубли"; }
            }
            if (key == "Песо")
            {
                changer.Peso = changer.Peso + value;
                if (changer.Rub <= 0) { ct.ChangeTo = "-"; ct.ChangeTo = "Песо"; }
            }
            if (key == "Доллары")
            {
                changer.Dollar = changer.Dollar + value;
                if (changer.Rub <= 0) { ct.ChangeTo = "-"; ct.ChangeTo = "Доллары"; }
            }
            if (key == "Евро")
            {
                changer.Euro = changer.Euro + value;
                if (changer.Rub <= 0) { ct.ChangeTo = "-"; ct.ChangeTo = "Евро"; }
            }
            if (key == "Тенге")
            {
                changer.Tenge = changer.Tenge + value;
                if (changer.Rub <= 0) { ct.ChangeTo = "-"; ct.ChangeTo = "Тенге"; }
            }
            if (key == "Фунты")
            {
                changer.Pounds = changer.Pounds + value;
                if (changer.Rub <= 0) { ct.ChangeTo = "-"; ct.ChangeTo = "Фунты"; }
            }
            UpdateChangerLabel();
        }

        private bool flag3checker(string currency,int price)
        {
            Person person = peoples[0];
            //int price = int.Parse(OrderFinalPrice.Text.Split(' ')[OrderFinalPrice.Text.Split(' ').Length-2]);
            if (currency == "Рубли")
            {
                if (person.Rub < price) return true;
            }
            if (currency == "Песо")
            {
                if (person.Peso < price) return true;
            }
            if (currency == "Доллары")
            {
                if (person.Dollar < price) return true;
            }
            if (currency == "Евро")
            {
                if (person.Euro < price) return true;
            }
            if (currency == "Тенге")
            {
                if (person.Tenge < price) return true;
            }
            if (currency == "Фунты")
            {
                if (person.Pounds < price) return true;
            }
            return false;
        }

        private bool flag4checker(string currency,int price) // пишется наподобие flagchecker3
        {
            //int price = int.Parse(OrderFinalPrice.Text.Split(' ')[OrderFinalPrice.Text.Split(' ').Length-2]);
            if (currency == "Рубли")
            {
                if (changer.Rub < price) return true;
            }
            if (currency == "Песо")
            {
                if (changer.Peso < price) return true;
            }
            if (currency == "Доллары")
            {
                if (changer.Dollar < price) return true;
            }
            if (currency == "Евро")
            {
                if (changer.Euro < price) return true;
            }
            if (currency == "Тенге")
            {
                if (changer.Tenge < price) return true;
            }
            if (currency == "Фунты")
            {
                if (changer.Pounds < price) return true;
            }
            return false;
        }

        // Оповещение при обработке события
        private void MessageChangeFromEnd(object sender, EventArgs e)
        {
            MessageBox.Show("Валюта у клиента закончилась!");
        }

        // Оповещение при обработке события
        private void MessageChangeToEnd(object sender, EventArgs e)
        {
            MessageBox.Show("Валюта у обменника закончилась!");
        }

        // кнопка ухода человечка, блокируются некоторые окна (чтобы не было багов)
        private void GoAwayButton_Click(object sender, EventArgs e)
        {
            removePerson(); // "Человечек" уходит
            ObmenBoxClear(); // Очищается заказ
            ObmenBox.Enabled = false;
            ChangeList.Enabled = false;
            ChangeList.SelectedItem = null;
        }

        // Очистка заказа
        //public void OrderClear()
        //{
            /*
            ChangeList.SelectedItem = null;
            obmenBoxChangeFrom.Text = " ";
            obmenBoxChangeTo.Text = " ";
            obmenBoxExchangeRate.Text = " ";
            ObmenBox.Enabled = false;
            */
        //}

        // ---Удаление покупателя--- человек уходит
        public void removePerson()
        {
            // Блокирование кнопки выхода (от перегрузок)
            GoAwayButton.Enabled = false;
            // Проверка (в случае перегрузки)
            if (personPicture == null || personLabel == null)
            {
                GoAwayButton.Enabled = true;
                return;
            }
            personPicture.Image = Image.FromFile(Path.GetFullPath("Resources") + "\\..\\..\\..\\Resources\\person2.png");
            // Анимация ухода "Человечка" в сторону
            Timer moveTimer = new Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                personPicture.Location = new Point(personPicture.Location.X - 2, personPicture.Location.Y);
                personLabel.Location = new Point(personLabel.Location.X - 252, personLabel.Location.Y);
                if (personPicture.Location.X <= -100)
                {
                    // Анимация поворота
                    Timer rotateTimer = new Timer();
                    rotateTimer.Interval = 10;
                    int angle = 0;
                    rotateTimer.Tick += (s2, args2) =>
                    {
                        personPicture.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        personPicture.Refresh();
                        angle += 90;
                        if (angle >= 360)
                        {
                            BankerPicture.Controls.Remove(personPicture);
                            BankerPicture.Controls.Remove(personLabel);
                            personLabel.Dispose();
                            personPicture.Dispose();
                            personLabel = null;
                            personPicture = null;
                            rotateTimer.Stop();
                        }
                    };
                    rotateTimer.Start();
                    moveTimer.Stop();
                    CreatePeopleButton.Enabled = true;
                }
            };
            moveTimer.Start();

        }

        private void CreatePeopleButton_Click(object sender, EventArgs e)
        {
            GoAwayButton.Enabled = false;
            // Добавление человека в список
            // Можно обойтись без списка, но он нужен на случай перегрузок которые я не увидел
            Person newPerson = HelpObjects.CreateRandomPerson();
            peoples.Add(newPerson);
            // Создание изображения человека
            personPicture = new PictureBox();
            personPicture.Image = Image.FromFile(Path.GetFullPath("Resources") + "\\..\\..\\..\\Resources\\person1.png");
            personPicture.Size = new Size(50, 50);
            personPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            // Позиционирование человека и текста
            int xPerson = 150; int yPerson = 563;
            int xLabel = xPerson - 100;
            // Добавление человека на форму
            Controls.Add(personPicture);
            personPicture.Location = new Point(xPerson, yPerson);

            // Добавление текста для человечка
            personLabel = new System.Windows.Forms.Label();
            personLabel.Text = newPerson.getInfo();

            /*
            // Добавление текста для человечка
            personLabel = new System.Windows.Forms.Label();
            personLabel.Text = newPerson.Name + "\n";


            // Добавление информации о деньгах в каждой валюте
            foreach (var currency in HelpObjects.currencys)
            {
                int moneyInCurrency = HelpObjects.ConvertCurrency(newPerson.Money, currency);
                personLabel.Text += currency + ": " + moneyInCurrency.ToString() + "\n";
            }
            */

            personLabel.Size = new Size(250, 100);
            personLabel.Location = new Point(xLabel, yPerson);
            this.Controls.Add(personLabel); 
           // Анимация перемещения
            Timer moveTimer = new Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                personPicture.Location = new Point(xPerson, yPerson + 70);
                personLabel.Location = new Point(xLabel, yPerson + 70);
                yPerson -= 4;
                if (yPerson <= 200)
                {
                    moveTimer.Stop();
                    GoAwayButton.Enabled = true;
                    ChangeList.Enabled = true;
                }
            };
            moveTimer.Start();

            CreatePeopleButton.Enabled = false;
            //ObmenBox.Enabled = true;
        }



        // Обновление данных рядом с "Человечком"
        /*
        private void updatePersonMoney(Person person)
        {
            // Найти визитку пользователя и обновить информацию о балансе
            foreach (Control control in personLabel.Controls)
            {
                if (control is System.Windows.Forms.Label)
                {
                    System.Windows.Forms.Label label = (System.Windows.Forms.Label)control;
                    if (label.Tag.ToString() == person.PersonID.ToString())

                    {
                        label.Text = $"Имя: {person.Name}\nДеньги: {person.Money} {person.Currency}";
                        break;
                    }
                }
            }
        }
        */
    }

    // Класс обмена валюты
    public class Changetype
    {
        private int _ID;
        private string _changeFrom;
        private string _changeTo;
        private int _exchangeRate;

        // События: 
        // Закончилась changeFrom
        // Закончилась changeTo
        // События
        public event EventHandler changeFromEnd;  // Событие для оповещения о том, что валюта на обмен закончилась
        public event EventHandler changeToEnd; // Событие для оповещения о том, что валюта для обмена закончилась

        protected virtual void onchangeFromEnd()
        {
            changeFromEnd?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void onchangeToEnd()
        {
            changeToEnd?.Invoke(this, EventArgs.Empty);
        }

        public Changetype(int id, string changeFrom, string changeTo, int exchangeRate)
        {
            ID = id;
            ChangeFrom = changeFrom;
            ChangeTo = changeTo;
            ExchangeRate = exchangeRate;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string ChangeFrom
        {
            get { return _changeFrom; }
            set 
            { 
                _changeFrom = value;
                if (value == "-"){ onchangeFromEnd(); }
            }
        }
        public string ChangeTo
        {
            get { return _changeTo; }
            set 
            { 
                _changeTo = value;
                if (value == "-") {  onchangeToEnd(); }
            }
        }
        public int ExchangeRate
        {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }

        public virtual string getInfo()
        {
            return $"{ID}) Обмен {ChangeFrom} на {ChangeTo}, Курс: {ExchangeRate}";
        }
    }

    // Класс заказа (обмена)
    public class Order : Changetype
    {
        private string _date;
        private string _status; // статус заказа (flag=1,2,3)
        private int _ID; // ID ЗАКАЗА!! (не билета)
        private string _currencyFrom;
        public string CurrencyFrom
        {
            get { return _currencyFrom; }
            set { _currencyFrom = value; }
        }


        public Order(string changeFrom, string changeTo, int exchangeRate, string date, int id, string status)
            : base(id, changeFrom, changeTo, exchangeRate)
        {
            Date = date;
            ID = id;
            Status = status;
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }


        public override string getInfo()
        {
            return $"Дата: {Date}\nID Заказа: {ID}\nОбмен {ChangeFrom} на {ChangeTo}, Курс: {ExchangeRate}\nСтатус: {Status}";
        }

        //public void ProcessOrder()
        //{
        //    // Логика обработки заказа
        //}
    }

    // Класс валютообменника
    public class Changer // Класс валютообменника для label
    {
        private int _rub;
        private int _peso;
        private int _dollar;
        private int _euro;
        private int _tenge;
        private int _pounds;

        public Changer(int rub, int peso, int dollar, int euro, int tenge, int pounds)
        {
            Rub = rub;
            Peso = peso;
            Dollar = dollar;
            Euro = euro;
            Tenge = tenge;
            Pounds = pounds;
        }

        public int Rub
        {
            get { return _rub; }
            set { _rub = value; }
        }
        public int Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }
        public int Dollar
        {
            get { return _dollar; }
            set { _dollar = value; }
        }
        public int Euro
        {
            get { return _euro; }
            set { _euro = value; }
        }
        public int Tenge
        {
            get { return _tenge; }
            set { _tenge = value; }
        }
        public int Pounds
        {
            get { return _pounds; }
            set { _pounds = value; }
        }

        public virtual string getInfo()
        {
            return $"\nРубли - {Rub}\nПесо - {Peso}\nДоллар - {Dollar}\nЕвро - {Euro}\nТенге - {Tenge}\nФунт - {Pounds} ";
        }
    }

    // Класс человечка
    public class Person : Changer // Класс человека
    {
        // Приватные поля
        private string name;
        //private int _money;
        //private string _currency;
        //public int PersonID { get; set; }


        // Конструктор класса
        public Person(int rub, int peso, int dollar, int euro, int tenge, int pounds, string name/*, int money, string currency*/) 
            : base(rub, peso, dollar, euro, tenge, pounds)
        {
            Name = name; //Money = money;
            //Currency = currency;
        }

        // Геттеры и Сеттеры
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /*
        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        */

        public override string getInfo()
        {
            return $"{Name}{base.getInfo()}";
        }
        
    }

    public class HelpObjects
    {
        //Данные для случайного создания обменов, людей, цен
        private static Random random = new Random();
        private static string[] personnames = {
        "Иванов И.И.",
        "Петров П.П.",
        "Сидоров С.С.",
        "Кузнецов А.В.",
        "Козлов Г.Н.",
        "Лебедев Д.О.",
        "Никитин Е.М.",
        "Орлов Ж.А.",
        "Павлов З.С.",
        "Романов И.Л.",
        "Соловьев К.У.",
        "Тимофеев Л.П.",
        "Успенский М.Г.",
        "Федоров Н.Д.",
        "Харитонов О.Е.",
        "Чернов П.Ф.",
        "Шевцов Р.И.",
        "Щербаков С.К.",
        "Юдин Т.Л.",
        "Яковлев У.Н.",
        "Исаев Ф.А.",
        "Калашников Х.В.",
        "Медведев Ц.Б.",
        "Назаров Ч.Е.",
        "Овчинников Ш.Ю.",
        "Поляков Щ.Я.",
        "Рябов Э.М.",
        "Семенов Ю.П.",
        "Трофимов Я.Г."
        };

        private static int[] moneys = new int[] { 4200, 4400, 4600, 5000, 5500, 7500, 8000, 10000, 12500, 15000, 17000, 18000, 20000, 22500, 23000, 24000, 25000, 28000, 30000, 32300, 35000, 40000 };
        public static string[] currencys = { "Рубль", "Песо", "Доллар", "Евро", "Тенге", "Фунт" };
        private static int[] rates = new int[] { };
        
        /*
         * Я полностью переделал концепцию валюты, если ты это писал сам то сорян
         * Но если это писала нейронка, то такой вариант неудобен. Человек приходит с фиксированным количеством валюты
         * А не с изменяющимся при изменении только одной (надеюсь понял)
         * 
        public static int ConvertCurrency(int money, string currency)
        {
            switch (currency)
            {
                case "Рубль":
                    return money;
                case "Песо":
                    return money * 2; // Пример простого преобразования
                case "Доллар":
                    return money / 2; // Пример простого преобразования
                case "Евро":
                    return money / 3; // Пример простого преобразования
                case "Тенге":
                    return money * 100; // Пример простого преобразования
                case "Фунт":
                    return money / 4; // Пример простого преобразования
                default:
                    return 0; // Возвращаем 0, если валюта неизвестна
            }
        }
        */

        public static Person CreateRandomPerson()
        {
            Person a = new Person(moneys[random.Next(moneys.Length)], moneys[random.Next(moneys.Length)], moneys[random.Next(moneys.Length)], 
                moneys[random.Next(moneys.Length)], moneys[random.Next(moneys.Length)], 
                moneys[random.Next(moneys.Length)], personnames[random.Next(personnames.Length)]);
            /*
            string name = personnames[random.Next(personnames.Length)];
            int money = moneys[random.Next(moneys.Length)];
            string currency = currencys[random.Next(currencys.Length)];
            Person a = new Person(name, money, currency);
            return a;
            */
            return a;
            
        }

        private static string[] Changes = { "Рубли", "Песо", "Доллары", "Евро", "Тенге", "Фунты" };

        //метод для генерации случайных мероприятий 
        public static List<Changetype> Generate_ChangesCources()
        {
            List<Changetype> changetypes = new List<Changetype>();
            //генерация случайного количества мероприятий от 3 до 6
            int number = random.Next(3, 6);

            for (int i = 0; i < number; i++)
            {
                int index = random.Next(6);
                string changefrom = Changes[index];
                int index1 = random.Next(5);
                if (index == index1) index1++;
                string changeto = Changes[index1];
                int exchangerate = random.Next(1, 100); // потом можно переделать под массив Rates
                Changetype type = new Changetype(i + 1, changefrom, changeto, exchangerate);
                changetypes.Add(type);
            }
            return changetypes;

        }
        public static int generateRandomID()
        {
            return random.Next(1, 1000000);
        }
    }
}