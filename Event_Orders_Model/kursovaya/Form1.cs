global using global::System;
global using global::System.Collections.Generic;
global using global::System.Drawing;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::System.Windows.Forms;
global using global::System.Xml.Linq;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        // Приватные поля (листы для работы, числа для позиционирования)
        private List<Event> events = new List<Event>();
        private List<Order> orders = new List<Order>();
        private List<Person> peoples = new List<Person>();
        private PictureBox personPicture;
        private Label personLabel;
        private int ID;
        protected int historyX = 0;
        protected int historyY = 0;
        protected int xPerson = 285, yPerson = 1050;
        protected int xLabel;
        protected int TotalSumma = 0;

        // Функция инициализации формы
        public Form1()
        {
            InitializeComponent();
            // Заполнелние списка мероприятиями
            events = HelpObjects.GenerateRandomEvents();
            // Создание уникального ID
            ID = HelpObjects.generateRandomID();
            // Заполнение EventList списком
            fillEventsList();
        }

        // Заполнение списко мероприятий
        public void fillEventsList()
        {
            EventList.Items.Clear();

            foreach (Event e in events)
            {
                EventList.Items.Add(e.getInfo());
            }
        }

        // Работа с выбором мероприятия
        private void EventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если мероприятие выбрано
            if (EventList.SelectedItem != null)
            {
                OrderBox.Enabled = true; // Включаем менюшку заполнения заказа

                // Автоматически заполняем менюшку всеми возможными данными
                string s = EventList.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (Event ev in events)
                {
                    if (ev.EventName == s)
                    {
                        OrderName.Text = ev.EventName;
                        OrderData.Text = ev.EventTime.ToString();
                        OrderLocation.Text = ev.Location;
                        OrderPrice.Text = ev.Price.ToString() + " руб.";
                        OrderCount.Maximum = ev.AvailableSeats;
                        OrderFinalPrice.Text = (ev.Price * OrderCount.Value).ToString();
                    }
                }
            }
        }

        // Изменение счётчика количества билетов
        private void OrderCount_ValueChanged(object sender, EventArgs e)
        {
            if (EventList.SelectedItem != null)
            {
                string s = EventList.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (Event ev in events)
                {
                    if (ev.EventName == s)
                    {
                        OrderFinalPrice.Text = (ev.Price * OrderCount.Value).ToString();
                    }
                }
            }
        }

        // Отказ от заказа
        private void OrderDenyButton_Click(object sender, EventArgs e)
        {
            removePerson(); // "Человечек" уходит
            OrderClear(); // Очищается заказ

        }

        // Очистка заказа
        public void OrderClear()
        {
            EventList.SelectedItem = null;
            OrderName.Text = "";
            OrderData.Text = "";
            OrderLocation.Text = "";
            OrderPrice.Text = "";
            OrderCount.Maximum = 1;
            OrderFinalPrice.Text = "";
            OrderFIO.Text = "";
            OrderPhone.Text = "";
            OrderBox.Enabled = false;
        }

        // Подтверждение заказа
        private void OrderBuyButton_Click(object sender, EventArgs e)
        {
            // Проверка валидности заказа
            Person person = peoples[0];
            int flag = 1; // 1 - Всё хорошо
            if (person.Money < int.Parse(OrderFinalPrice.Text)) { flag = 2; } // 2 - недостаточно средств
            if ((person.Name != OrderFIO.Text) || (person.PhoneNumber != OrderPhone.Text)) { flag = 3; } // 3 - неверные данные

            // Создаем новый билет (Новый заказ, см. в классе "Билет)
            Order ord = new Order(OrderName.Text, OrderLocation.Text, OrderData.Text, (int)OrderCount.Value,
                                     int.Parse(OrderFinalPrice.Text), OrderFIO.Text, OrderPhone.Text, ID, "N/A");
            ID++;
            Label lb = new Label();
            lb.Location = new Point(historyX, historyY);
            historyY += 200;
            //lb.MinimumSize = new Size(width:500,height:200);
            //lb.MaximumSize = new Size(width: 500, height: 200);
            if (flag == 1) // Если хватило денег
            {
                ord.Status = "Оплачено";
                lb.BackColor = Color.LightGreen;
                person.Money = person.Money - int.Parse(OrderFinalPrice.Text);
                updatePersonMoney(person);

                // Добавление стоимости в общую сумму продажи кассы
                TotalSumma = TotalSumma + int.Parse(OrderFinalPrice.Text);
                LabelSumma.Text = "Продано на: " + TotalSumma.ToString() + " руб.";

                // Вычитание билетов
                string s = EventList.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (Event ev in events)
                {   // Ищем нужный элемент в списке мероприятий
                    if (ev.EventName == s)
                    {
                        ev.SoldOut += MessageSoldOut; // Добавляем обработчик события
                        ev.LastTicketAvailable += MessageLastTicket;
                        ev.SellTickets((int)OrderCount.Value);
                        // ev.AvailableSeats -= (int)OrderCount.Value;
                        if (ev.AvailableSeats <= 0) // Если места закончились, удаляем мероприятие
                        { events.Remove(ev); }
                        ev.SoldOut -= MessageSoldOut; // Убираем обработчик события
                        ev.LastTicketAvailable -= MessageLastTicket; // чтобы потом не вылезало по 2 окошка
                        break;

                    }
                }
                // "Обновление" списка мероприятий, очистка заказа
                fillEventsList();
                OrderClear();

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
        }

        // Оповещение при обработке события
        private void MessageSoldOut(object sender, EventArgs e)
        {
            MessageBox.Show("Билеты на мероприятие закончились!");
        }

        // Оповещение при обработке события
        private void MessageLastTicket(object sender, EventArgs e)
        {
            MessageBox.Show("Остался последний билет!");
        }

        // ---Удаление покупателя---
        public void removePerson()
        {
            // Блокирование кнопки выхода (от перегрузок)
            OrderDenyButton.Enabled = false;
            // Проверка (в случае перегрузки)
            if (personPicture == null)
            {
                OrderDenyButton.Enabled = true;
                return;
            }

            // Изменяю картинку человечка
            personPicture.Image = Image.FromFile("../../../Resources/left1.png");

            // Анимация ухода "Человечка" в сторону
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                personPicture.Location = new Point(xPerson - 2, yPerson);
                personLabel.Location = new Point(xPerson - 252, yPerson);
                xPerson -= 4;
                if (yPerson < 300) { yPerson += 4; }

                if (xPerson <= -100)
                {
                    Controls.Remove(personPicture);
                    Controls.Remove(personLabel);
                    personLabel = null;
                    personPicture = null;

                    peoples.RemoveAt(0);
                    CreatePeopleButton.Enabled = true;
                    OrderDenyButton.Enabled = true;
                    moveTimer.Stop();
                }
            };
            moveTimer.Start();
            EventsListBox.Enabled = false;
        }

        // ---Создание покупателя---
        private void CreatePeopleButton_Click(object sender, EventArgs e)
        {
            OrderDenyButton.Enabled = false;
            // Добавление человека в список
            // Можно обойтись без списка, но он нужен на случай перегрузок которые я не увидел
            Person newPerson = HelpObjects.CreateRandomPerson();
            peoples.Add(newPerson);

            // Создание изображения человека
            personPicture = new PictureBox();
            personPicture.Image = Image.FromFile("../../../Resources/Up1.png");
            personPicture.Size = new Size(60, 120);
            personPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            // Позиционирование человека и текста
            xPerson = 370; yPerson = 1050;
            xLabel = xPerson - 250;

            personPicture.Location = new Point(xPerson, yPerson);

            // Добавление текста для человечка
            personLabel = new Label();
            personLabel.Text = newPerson.Name + "\n" + newPerson.PhoneNumber + "\n" + newPerson.Money.ToString();
            personLabel.Size = new Size(250, 100);
            personLabel.Location = new Point(xLabel, yPerson);


            // Добавление человека на форму
            //Controls.Add(personPicture);
            HouseBox1.Controls.Add(personPicture);
            HouseBox1.Controls.Add(personLabel);


            // Анимация перемещения
            System.Windows.Forms.Timer moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += (s, args) =>
            {
                personPicture.Location = new Point(xPerson, yPerson - 2);
                personLabel.Location = new Point(xLabel, yPerson - 2);
                yPerson -= 4;
                if (yPerson <= 200)
                {
                    moveTimer.Stop();
                    OrderDenyButton.Enabled = true;
                }
            };
            moveTimer.Start();

            CreatePeopleButton.Enabled = false;
            EventsListBox.Enabled = true;

        }

        // Обновление данных рядом с "Человечком"
        public void updatePersonMoney(Person person)
        {
            if (personLabel != null)
            {
                personLabel.Text = person.Name + "\n" + person.PhoneNumber + "\n" + person.Money.ToString();
            }
        }

    }

    public class Event // Класс мероприятия
    {
        // Приватные поля
        private string _eventName; // Имя 
        private string _location; // Место
        private string _eventTime; // Время
        private int _availableSeats; // Количество доступных мест
        private int _price; // Цена

        // События
        public event EventHandler SoldOut;  // Событие для оповещения о том, что все билеты проданы
        public event EventHandler LastTicketAvailable; // Событие для повещения о последнем билете

        // Конструктор класса
        public Event(string eventName, string location, string eventTime, int availableSeats, int price)
        {
            _eventName = eventName;
            _location = location;
            _eventTime = eventTime;
            _availableSeats = availableSeats;
            _price = price;
        }

        // Геттеры и сеттеры
        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string EventTime
        {
            get { return _eventTime; }
            set { _eventTime = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int AvailableSeats
        {
            get { return _availableSeats; }
            set
            {
                _availableSeats = value;
                // Проверяем, если все билеты проданы или остался 1, вызываем соотв. событие
                if (_availableSeats == 0)
                {
                    OnSoldOut();
                }
                if (_availableSeats == 1)
                {
                    OnLastTicket();
                }
            }
        }

        // Переопределяемый метод вывода информации
        public virtual string getInfo()
        {
            return $"{EventName} - {EventTime}, Место: {Location}, {AvailableSeats} билета(ов)";
        }

        // Метод для продажи билетов
        public void SellTickets(int quantity)
        {
            if (AvailableSeats >= quantity)
            {
                AvailableSeats -= quantity;
            }
            else
            {
                MessageBox.Show("Not enough available seats!");
            }
        }


        // Проверки определения обработчика при вызове событий
        protected virtual void OnLastTicket()
        {
            // Проверка, аналогичная LastTicketAvailable != null;
            LastTicketAvailable?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSoldOut()
        {
            SoldOut?.Invoke(this, EventArgs.Empty);
        }
    }

    // Класс вспомогательных объектов
    public class HelpObjects
    {
        // Данные для случайного создания мероприятий, людей, цен....
        private static Random random = new Random(); // Генератор случайных величин
        private static string[] eventNames = new string[]
            {
        "Шекспировская Трагедия: Гамлет",
        "Художественный Фильм: Великий Гэтсби",
        "Аукцион Современного Искусства",
        "Театральный Мюзикл: Лесные Прошествия",
        "Кинофестиваль: Новые Горизонты",
        "Лекция: Секреты Успеха в Бизнесе",
        "Мода и Стиль: Вечер Модных Тенденций",
        "Танцевальный Вечер: Латиноамериканские Ритмы",
        "Литературное Путешествие: Встреча с Писателем",
        "Фестиваль Гастрономии: Вкусные Секреты",
        "Фильм-Приключение: Поиск Утерянного Ковчега",
        "Спектакль: Тайны Парижского Оперного Дома",
        "Музыкальный Концерт: Вечер Классической Музыки",
        "Кулинарное Шоу: Мастер-класс Повара",
        "Вечер Искусств: Живопись и Скульптура",
        "Театральная Комедия: Веселые Приключения",
        "Магия и Иллюзии: Фокусы Снов",
        "Танцевальный Карнавал: Маскарад",
        "Дискуссионный Круг: Актуальные Вопросы"
            };
        private static string[] eventLocations = new string[]
        {
        "Сияющий зал",
        "АртБит",
        "ЛайтХолл",
        "КультДом",
        "Сцена21",
        "ЭнтерПлейс",
        "ГламХейвен",
        "ТеатроКорпус",
        "МагияМеста",
        "СтейджПоинт",
        "ЭмоАрена",
        "ФанТеатр",
        "АкцентАрт",
        "ПлейПарк",
        "КреативАудит",
        "ДивоДром",
        "ТалантТрейл",
        "СцениЧайз",
        "ЭклектичЭссенс",
        "ИмпульсХолл"
        };
        private static int[] eventPrices = new int[] { 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500 };
        private static int[] moneys = new int[] { 4200, 4400, 4600, 5000, 5500, 7500, 8000, 10000, 12500, 15000, 17000, 18000, 20000 };
        private static string[] phoneNumbers = new string[] {
            "+7 (123) 456-7890",
            "+7 (987) 654-3210",
            "+7 (111) 222-3333",
            "+7 (444) 555-6666",
            "+7 (777) 888-9999",
            "+7 (234) 567-8901",
            "+7 (876) 543-2109",
            "+7 (135) 246-3579",
            "+7 (801) 234-5678",
            "+7 (765) 432-1098",
            "+7 (543) 210-9876",
            "+7 (246) 135-7980",
            "+7 (980) 765-4321",
            "+7 (678) 901-2345",
            "+7 (432) 109-8765",
            "+7 (357) 246-8135",
            "+7 (531) 642-8970",
            "+7 (123) 456-7890",
            "+7 (987) 654-3210",
            "+7 (111) 222-3333",
            "+7 (444) 555-6666",
            "+7 (777) 888-9999",
            "+7 (234) 567-8901",
            "+7 (876) 543-2109",
            "+7 (135) 246-3579",
            "+7 (801) 234-5678",
            "+7 (765) 432-1098",
            "+7 (543) 210-9876",
            "+7 (246) 135-7980"
        };
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



        //Метод для создания случайного человека
        public static Person CreateRandomPerson()
        {
            string name = personnames[random.Next(personnames.Length)];
            string phonenumber = phoneNumbers[random.Next(phoneNumbers.Length)];
            int money = moneys[random.Next(moneys.Length)];
            Person a = new Person(name, phonenumber, money);
            return a;
        }

        // Метод для генерации случайной даты
        private static DateTime GenerateRandomDate()
        {
            // Генерация случайной даты в пределах ближайших 30 дней
            return DateTime.Now.AddDays(random.Next(30)).AddMinutes(59 - DateTime.Now.Minute).AddSeconds(60 - DateTime.Now.Second);
        }

        // Метод для генерации случайного ID
        public static int generateRandomID()
        {
            return random.Next(1, 1000000);
        }

        // Метод для генерации случайных мероприятий
        public static List<Event> GenerateRandomEvents()
        {
            List<Event> events = new List<Event>();

            // Генерация случайного количества мероприятий от 3 до 6
            int numberOfEvents = random.Next(3, 6);

            for (int i = 0; i < numberOfEvents; i++)
            {
                // Генерация случайных данных для мероприятия
                string eventName = eventNames[i % eventNames.Length];
                string eventLocation = eventLocations[random.Next(eventLocations.Length)];
                DateTime eventDate = GenerateRandomDate();
                int availableTickets = random.Next(3, 8); // Ограничение количества билетов на места от 3 до 8
                int eventPrice = eventPrices[random.Next(eventPrices.Length)];

                // Создание объекта мероприятия и добавление его в список
                Event newEvent = new Event(eventName, eventLocation, eventDate.ToString("g"), availableTickets, eventPrice);
                events.Add(newEvent);
            }

            return events;
        }

    }

    public class Order : Event // Класс заказа (наследуемый от мероприятия)
    {
        // Приватные поля
        private string _buyerInitials; // Фамилия И.О.
        private string _phoneNumber; // Номер телефона
        private string _status; // статус заказа (flag=1,2,3)
        private int _ID; // ID ЗАКАЗА!! (не билета)

        // Конструктор класса 
        public Order(string eventName, string location, string eventTime, int ticketCount, int price, string buyer, string phone, int id, string status)
            : base(eventName, location, eventTime, ticketCount, price)
        {
            BuyerInitials = buyer;
            PhoneNumber = phone;
            ID = id;
        }

        // Геттеры и Сеттеры
        public string BuyerInitials
        {
            get { return _buyerInitials; }
            set { _buyerInitials = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
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

        // Переопределение метода getInfo() базового класса
        public override string getInfo()
        {
            return $"Заказ №{ID}, Статус: {Status}\n" +
                   $"{EventName} - {EventTime}\n" +
                   $"Место - {Location}\n" +
                   $"Количество билетов - {AvailableSeats}\n" +
                   $"Контакты: {BuyerInitials}, {PhoneNumber}";
        }
    }

    public class Person // Класс человека
    {
        // Приватные поля
        private string _name;
        private string _phoneNumber;
        private int _money;

        // Конструктор класса
        public Person(string name, string phonenumber, int money)
        {
            Name = name; PhoneNumber = phonenumber; Money = money;
        }

        // Геттеры и Сеттеры
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
    }
}