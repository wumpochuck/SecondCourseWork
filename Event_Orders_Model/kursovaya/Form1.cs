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
        // ��������� ���� (����� ��� ������, ����� ��� ����������������)
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

        // ������� ������������� �����
        public Form1()
        {
            InitializeComponent();
            // ����������� ������ �������������
            events = HelpObjects.GenerateRandomEvents();
            // �������� ����������� ID
            ID = HelpObjects.generateRandomID();
            // ���������� EventList �������
            fillEventsList();
        }

        // ���������� ������ �����������
        public void fillEventsList()
        {
            EventList.Items.Clear();

            foreach (Event e in events)
            {
                EventList.Items.Add(e.getInfo());
            }
        }

        // ������ � ������� �����������
        private void EventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ���� ����������� �������
            if (EventList.SelectedItem != null)
            {
                OrderBox.Enabled = true; // �������� ������� ���������� ������

                // ������������� ��������� ������� ����� ���������� �������
                string s = EventList.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (Event ev in events)
                {
                    if (ev.EventName == s)
                    {
                        OrderName.Text = ev.EventName;
                        OrderData.Text = ev.EventTime.ToString();
                        OrderLocation.Text = ev.Location;
                        OrderPrice.Text = ev.Price.ToString() + " ���.";
                        OrderCount.Maximum = ev.AvailableSeats;
                        OrderFinalPrice.Text = (ev.Price * OrderCount.Value).ToString();
                    }
                }
            }
        }

        // ��������� �������� ���������� �������
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

        // ����� �� ������
        private void OrderDenyButton_Click(object sender, EventArgs e)
        {
            removePerson(); // "���������" ������
            OrderClear(); // ��������� �����

        }

        // ������� ������
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

        // ������������� ������
        private void OrderBuyButton_Click(object sender, EventArgs e)
        {
            // �������� ���������� ������
            Person person = peoples[0];
            int flag = 1; // 1 - �� ������
            if (person.Money < int.Parse(OrderFinalPrice.Text)) { flag = 2; } // 2 - ������������ �������
            if ((person.Name != OrderFIO.Text) || (person.PhoneNumber != OrderPhone.Text)) { flag = 3; } // 3 - �������� ������

            // ������� ����� ����� (����� �����, ��. � ������ "�����)
            Order ord = new Order(OrderName.Text, OrderLocation.Text, OrderData.Text, (int)OrderCount.Value,
                                     int.Parse(OrderFinalPrice.Text), OrderFIO.Text, OrderPhone.Text, ID, "N/A");
            ID++;
            Label lb = new Label();
            lb.Location = new Point(historyX, historyY);
            historyY += 200;
            //lb.MinimumSize = new Size(width:500,height:200);
            //lb.MaximumSize = new Size(width: 500, height: 200);
            if (flag == 1) // ���� ������� �����
            {
                ord.Status = "��������";
                lb.BackColor = Color.LightGreen;
                person.Money = person.Money - int.Parse(OrderFinalPrice.Text);
                updatePersonMoney(person);

                // ���������� ��������� � ����� ����� ������� �����
                TotalSumma = TotalSumma + int.Parse(OrderFinalPrice.Text);
                LabelSumma.Text = "������� ��: " + TotalSumma.ToString() + " ���.";

                // ��������� �������
                string s = EventList.SelectedItem.ToString().Split('-')[0].Trim();
                foreach (Event ev in events)
                {   // ���� ������ ������� � ������ �����������
                    if (ev.EventName == s)
                    {
                        ev.SoldOut += MessageSoldOut; // ��������� ���������� �������
                        ev.LastTicketAvailable += MessageLastTicket;
                        ev.SellTickets((int)OrderCount.Value);
                        // ev.AvailableSeats -= (int)OrderCount.Value;
                        if (ev.AvailableSeats <= 0) // ���� ����� �����������, ������� �����������
                        { events.Remove(ev); }
                        ev.SoldOut -= MessageSoldOut; // ������� ���������� �������
                        ev.LastTicketAvailable -= MessageLastTicket; // ����� ����� �� �������� �� 2 ������
                        break;

                    }
                }
                // "����������" ������ �����������, ������� ������
                fillEventsList();
                OrderClear();

            }
            else if (flag == 2) // ���� �� ������� �����
            {
                ord.Status = "������������ �������";
                lb.BackColor = Color.LightPink;
            }
            else if (flag == 3) // ���� �������� ������
            {
                ord.Status = "�������� ������";
                lb.BackColor = Color.LightYellow;
            }
            // ����������� � ��������� ������, ����� ���������� �������
            lb.Font = new Font("Century Gothic", 9);
            lb.ForeColor = Color.Black;
            lb.Size = new Size(width: 700, height: 200);
            lb.Text = ord.getInfo();
            // ���������� �� ����� � � ������
            HistoryPanel.Controls.Add(lb);
            orders.Add(ord);
        }

        // ���������� ��� ��������� �������
        private void MessageSoldOut(object sender, EventArgs e)
        {
            MessageBox.Show("������ �� ����������� �����������!");
        }

        // ���������� ��� ��������� �������
        private void MessageLastTicket(object sender, EventArgs e)
        {
            MessageBox.Show("������� ��������� �����!");
        }

        // ---�������� ����������---
        public void removePerson()
        {
            // ������������ ������ ������ (�� ����������)
            OrderDenyButton.Enabled = false;
            // �������� (� ������ ����������)
            if (personPicture == null)
            {
                OrderDenyButton.Enabled = true;
                return;
            }

            // ������� �������� ���������
            personPicture.Image = Image.FromFile("../../../Resources/left1.png");

            // �������� ����� "���������" � �������
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

        // ---�������� ����������---
        private void CreatePeopleButton_Click(object sender, EventArgs e)
        {
            OrderDenyButton.Enabled = false;
            // ���������� �������� � ������
            // ����� �������� ��� ������, �� �� ����� �� ������ ���������� ������� � �� ������
            Person newPerson = HelpObjects.CreateRandomPerson();
            peoples.Add(newPerson);

            // �������� ����������� ��������
            personPicture = new PictureBox();
            personPicture.Image = Image.FromFile("../../../Resources/Up1.png");
            personPicture.Size = new Size(60, 120);
            personPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            // ���������������� �������� � ������
            xPerson = 370; yPerson = 1050;
            xLabel = xPerson - 250;

            personPicture.Location = new Point(xPerson, yPerson);

            // ���������� ������ ��� ���������
            personLabel = new Label();
            personLabel.Text = newPerson.Name + "\n" + newPerson.PhoneNumber + "\n" + newPerson.Money.ToString();
            personLabel.Size = new Size(250, 100);
            personLabel.Location = new Point(xLabel, yPerson);


            // ���������� �������� �� �����
            //Controls.Add(personPicture);
            HouseBox1.Controls.Add(personPicture);
            HouseBox1.Controls.Add(personLabel);


            // �������� �����������
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

        // ���������� ������ ����� � "����������"
        public void updatePersonMoney(Person person)
        {
            if (personLabel != null)
            {
                personLabel.Text = person.Name + "\n" + person.PhoneNumber + "\n" + person.Money.ToString();
            }
        }

    }

    public class Event // ����� �����������
    {
        // ��������� ����
        private string _eventName; // ��� 
        private string _location; // �����
        private string _eventTime; // �����
        private int _availableSeats; // ���������� ��������� ����
        private int _price; // ����

        // �������
        public event EventHandler SoldOut;  // ������� ��� ���������� � ���, ��� ��� ������ �������
        public event EventHandler LastTicketAvailable; // ������� ��� ��������� � ��������� ������

        // ����������� ������
        public Event(string eventName, string location, string eventTime, int availableSeats, int price)
        {
            _eventName = eventName;
            _location = location;
            _eventTime = eventTime;
            _availableSeats = availableSeats;
            _price = price;
        }

        // ������� � �������
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
                // ���������, ���� ��� ������ ������� ��� ������� 1, �������� �����. �������
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

        // ���������������� ����� ������ ����������
        public virtual string getInfo()
        {
            return $"{EventName} - {EventTime}, �����: {Location}, {AvailableSeats} ������(��)";
        }

        // ����� ��� ������� �������
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


        // �������� ����������� ����������� ��� ������ �������
        protected virtual void OnLastTicket()
        {
            // ��������, ����������� LastTicketAvailable != null;
            LastTicketAvailable?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSoldOut()
        {
            SoldOut?.Invoke(this, EventArgs.Empty);
        }
    }

    // ����� ��������������� ��������
    public class HelpObjects
    {
        // ������ ��� ���������� �������� �����������, �����, ���....
        private static Random random = new Random(); // ��������� ��������� �������
        private static string[] eventNames = new string[]
            {
        "������������� ��������: ������",
        "�������������� �����: ������� ������",
        "������� ������������ ���������",
        "����������� ������: ������ ����������",
        "�������������: ����� ���������",
        "������: ������� ������ � �������",
        "���� � �����: ����� ������ ���������",
        "������������ �����: ������������������ �����",
        "������������ �����������: ������� � ���������",
        "��������� �����������: ������� �������",
        "�����-�����������: ����� ���������� �������",
        "���������: ����� ���������� �������� ����",
        "����������� �������: ����� ������������ ������",
        "���������� ���: ������-����� ������",
        "����� ��������: �������� � ����������",
        "����������� �������: ������� �����������",
        "����� � �������: ������ ����",
        "������������ ��������: ��������",
        "������������� ����: ���������� �������"
            };
        private static string[] eventLocations = new string[]
        {
        "������� ���",
        "������",
        "��������",
        "��������",
        "�����21",
        "����������",
        "����������",
        "������������",
        "����������",
        "�����������",
        "��������",
        "��������",
        "���������",
        "��������",
        "������������",
        "��������",
        "�����������",
        "���������",
        "��������������",
        "�����������"
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
            "������ �.�.",
            "������ �.�.",
            "������� �.�.",
            "�������� �.�.",
            "������ �.�.",
            "������� �.�.",
            "������� �.�.",
            "����� �.�.",
            "������ �.�.",
            "������� �.�.",
            "�������� �.�.",
            "�������� �.�.",
            "��������� �.�.",
            "������� �.�.",
            "��������� �.�.",
            "������ �.�.",
            "������ �.�.",
            "�������� �.�.",
            "���� �.�.",
            "������� �.�.",
            "����� �.�.",
            "���������� �.�.",
            "�������� �.�.",
            "������� �.�.",
            "���������� �.�.",
            "������� �.�.",
            "����� �.�.",
            "������� �.�.",
            "�������� �.�."
        };



        //����� ��� �������� ���������� ��������
        public static Person CreateRandomPerson()
        {
            string name = personnames[random.Next(personnames.Length)];
            string phonenumber = phoneNumbers[random.Next(phoneNumbers.Length)];
            int money = moneys[random.Next(moneys.Length)];
            Person a = new Person(name, phonenumber, money);
            return a;
        }

        // ����� ��� ��������� ��������� ����
        private static DateTime GenerateRandomDate()
        {
            // ��������� ��������� ���� � �������� ��������� 30 ����
            return DateTime.Now.AddDays(random.Next(30)).AddMinutes(59 - DateTime.Now.Minute).AddSeconds(60 - DateTime.Now.Second);
        }

        // ����� ��� ��������� ���������� ID
        public static int generateRandomID()
        {
            return random.Next(1, 1000000);
        }

        // ����� ��� ��������� ��������� �����������
        public static List<Event> GenerateRandomEvents()
        {
            List<Event> events = new List<Event>();

            // ��������� ���������� ���������� ����������� �� 3 �� 6
            int numberOfEvents = random.Next(3, 6);

            for (int i = 0; i < numberOfEvents; i++)
            {
                // ��������� ��������� ������ ��� �����������
                string eventName = eventNames[i % eventNames.Length];
                string eventLocation = eventLocations[random.Next(eventLocations.Length)];
                DateTime eventDate = GenerateRandomDate();
                int availableTickets = random.Next(3, 8); // ����������� ���������� ������� �� ����� �� 3 �� 8
                int eventPrice = eventPrices[random.Next(eventPrices.Length)];

                // �������� ������� ����������� � ���������� ��� � ������
                Event newEvent = new Event(eventName, eventLocation, eventDate.ToString("g"), availableTickets, eventPrice);
                events.Add(newEvent);
            }

            return events;
        }

    }

    public class Order : Event // ����� ������ (����������� �� �����������)
    {
        // ��������� ����
        private string _buyerInitials; // ������� �.�.
        private string _phoneNumber; // ����� ��������
        private string _status; // ������ ������ (flag=1,2,3)
        private int _ID; // ID ������!! (�� ������)

        // ����������� ������ 
        public Order(string eventName, string location, string eventTime, int ticketCount, int price, string buyer, string phone, int id, string status)
            : base(eventName, location, eventTime, ticketCount, price)
        {
            BuyerInitials = buyer;
            PhoneNumber = phone;
            ID = id;
        }

        // ������� � �������
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

        // ��������������� ������ getInfo() �������� ������
        public override string getInfo()
        {
            return $"����� �{ID}, ������: {Status}\n" +
                   $"{EventName} - {EventTime}\n" +
                   $"����� - {Location}\n" +
                   $"���������� ������� - {AvailableSeats}\n" +
                   $"��������: {BuyerInitials}, {PhoneNumber}";
        }
    }

    public class Person // ����� ��������
    {
        // ��������� ����
        private string _name;
        private string _phoneNumber;
        private int _money;

        // ����������� ������
        public Person(string name, string phonenumber, int money)
        {
            Name = name; PhoneNumber = phonenumber; Money = money;
        }

        // ������� � �������
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