// Log code : 06 - 00

using Droid_People;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Tools4Libraries;

namespace Droid_Booking
{
    public delegate void InterfaceEventHandler();
    public delegate void InterfaceBookingEventHandler();
    public class Interface_booking : GPInterface
    {
        #region Attribtue
        public readonly int TOP_OFFSET = 150;
        public string _directoryCloud;
        public string _directoryUser;
        public string _directoryArea;
        public string _directoryBook;

        public event InterfaceEventHandler SheetDisplayRequested;
        public event InterfaceBookingEventHandler LanguageModified;
        public event InterfaceBookingEventHandler CreatePersonRequested;

        private Panel _sheet;
        private ToolStripMenuBooking _tsm;
        private ViewCalendar _viewCalendar;
        //private ViewUserSearch _viewUserSearch;
        private PanelCustom _viewAreaSearch;
        private PanelCustom _viewAreaEdit;
        private PanelCustom _viewBookEdit;
        private PanelCustom _viewBookSearch;
        private PanelCustom _viewSetting;
        private PanelCustom _viewPrice;
        private ViewCheckIn _viewCheckIn;
        private ViewCheckOut _viewCheckOut;
        private ViewWelcome _viewWelcome;

        private List<Person> _users;
        private List<Area> _areas;
        private List<Booking> _books;
        private List<Price> _prices;
        
        private Person _currentPerson;
        private Area _currentArea;
        private Booking _currentbooking;
        private Price _currentPrice;
        private string _workingDirectory;
        #endregion

        #region Properties
        public Booking CurrentBooking
        {
            get { return _currentbooking; }
            set { _currentbooking = value; }
        }
        public List<Booking> Bookings
        {
            get { return _books; }
            set { _books = value; }
        }
        public Area CurrentArea
        {
            get { return _currentArea; }
            set { _currentArea = value; }
        }
        public Person CurrentUser
        {
            get { return _currentPerson; }
            set { _currentPerson = value; }
        }
        public List<Area> Areas
        {
            get { return _areas; }
            set { _areas = value; }
        }
        public List<Person> Persons
        {
            get { return _users; }
            set { _users = value; }
        }
        public List<Price> Prices
        {
            get { return _prices; }
            set { _prices = value; }
        }
        public Panel Sheet
        {
            get { return _sheet; }
            set { _sheet = value; }
        }
        public ToolStripMenuBooking Tsm
        {
            get { return _tsm; }
            set { _tsm = value as ToolStripMenuBooking; }
        }
        public Price CurrentPrice
        {
            get { return _currentPrice; }
            set { _currentPrice = value; }
        }
        #endregion

        #region Constructor
        public Interface_booking(string workingDirectory)
        {
            _workingDirectory = workingDirectory;

            _directoryCloud = _workingDirectory;
            _directoryUser = Path.Combine(_workingDirectory, "Users");
            _directoryArea = Path.Combine(_workingDirectory, "Areas");
            _directoryBook = Path.Combine(_workingDirectory, "Books");

            Init();
        }
        #endregion

        #region Methods public
        #region Methods Public override
        public override bool Open(object o)
        {
            string filePath = string.Empty;
            if (o == null && !(o is string))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }
            else
            {
                filePath = o as string;
            }

            //if (!string.IsNullOrEmpty(filePath))
            //{
            //    SaveAudioRecurrent(filePath);
            //    if (_panau == null) BuildPanel();
            //    return AddTitle(filePath);
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
        public override void Print()
        {

        }
        public override void Close()
        {

        }
        public override bool Save()
        {
            return false;
        }
        public override void ZoomIn()
        {

        }
        public override void ZoomOut()
        {

        }
        public override void Copy()
        {

        }
        public override void Cut()
        {

        }
        public override void Paste()
        {

        }
        public override void Resize()
        {
            foreach (Control ctrl in _sheet.Controls)
            {
                if (ctrl.Name.Equals("CurrentView"))
                {
                    ctrl.Left = (_sheet.Width / 2) - (ctrl.Width / 2);
                }
            }
        }
        public override void Refresh()
        {

        }
        public override void GlobalAction(object sender, EventArgs e)
        {
            ToolBarEventArgs tbea = e as ToolBarEventArgs;
            string action = tbea.EventText;
            GoAction(action);
        }
        public System.Windows.Forms.RibbonTab BuildToolBar()
        {
            _tsm = new ToolStripMenuBooking();
            _tsm.ActionAppened += GlobalAction;
            return _tsm;
        }
        #endregion
        public void ChangeLanguage()
        {
            _tsm.ChangeLanguage();
            foreach (var ctrl in _sheet.Controls)
            {
                if (ctrl is IView)
                {
                    (ctrl as IView).ChangeLanguage();
                    break;
                }
            }
            if (LanguageModified != null) LanguageModified();
        }
        public void GoAction(string act)
        {
            switch (act.ToLower())
            {
                case "viewwelcome":
                    LaunchViewWelcome();
                    break;
                case "viewcalendar":
                    LaunchViewCalendar();
                    break;
                case "bookadd":
                    LaunchViewBookEdit();
                    break;
                case "booksearch":
                    LaunchViewBookSearch();
                    break;
                case "saveprice":
                    LaunchSavePrice();
                    break;
                case "getprice":
                    LaunchDeterminePrice();
                    break;
                //case "viewusersearch":
                //    LaunchViewUserSearch();
                //    break;
                //case "viewuseradd":
                //    LaunchViewUserAdd();
                //    break;
                //case "viewuseredit":
                //    LaunchViewUserEdit();
                //    break;
                case "areaadd":
                    LaunchViewAreaAdd();
                    break;
                case "areaedit":
                    LaunchViewAreaEdit();
                    break;
                case "areasearch":
                    LaunchViewAreaSearch();
                    break;
                case "settings":
                    LaunchSettings();
                    break;
                case "checkin":
                    LaunchCheckIn();
                    break;
                case "checkout":
                    LaunchCheckOut();
                    break;
                case "prices":
                    LaunchPrices();
                    break;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _sheet = new Panel();
            _sheet.BackColor = System.Drawing.Color.DimGray;
            _sheet.Dock = DockStyle.Fill;
            _sheet.BackgroundImage = Properties.Resources.ShieldTileBg;
            _sheet.BackgroundImageLayout = ImageLayout.Tile;
            _sheet.Resize += _sheet_Resize;

            BuildToolBar();
            InitData();

            _viewCalendar = new ViewCalendar(this);
            _viewCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            _viewCalendar.Name = "CurrentView";

            //_viewUserSearch = new ViewUserSearch(this);
            //_viewUserSearch.Dock = DockStyle.Fill;
            //_viewUserSearch.RequestUserDetail += _viewUserSearch_RequestUserDetail;
            //_viewUserSearch.RequestUserEdition += _viewUserSearch_RequestUserEdition;
            //_viewUserSearch.Name = "CurrentView";
            
            _viewAreaSearch = new PanelCustom(new ViewAreaSearch(this));
            _viewAreaSearch.Title = "Search area";
            _viewAreaSearch.Name = "CurrentView";

            _viewAreaEdit = new PanelCustom(new ViewAreaEdit(this));
            _viewAreaEdit.Title = "Edit area";
            _viewAreaEdit.Name = "CurrentView";

            ViewBookSearch vbs = new ViewBookSearch(this);
            vbs.RequestBookDetail += _viewBookSearch_RequestBookDetail;
            vbs.RequestBookEdition += _viewBookSearch_RequestBookEdition;
            _viewBookSearch = new PanelCustom(vbs);
            _viewBookSearch.Title = "Search booking";
            _viewBookSearch.Name = "CurrentView";

            ViewBookEdit vbe = new ViewBookEdit(this);
            vbe.CreatePersonRequested += Vbe_CreatePersonRequested;
            _viewBookEdit = new PanelCustom(vbe);
            _viewBookEdit.Title = "Edit booking";
            _viewBookEdit.Name = "CurrentView";

            _viewSetting = new PanelCustom(new ViewSettings(this));
            _viewSetting.Title = "Settings";
            _viewSetting.Name = "CurrentView";

            _viewCheckIn = new ViewCheckIn(this);
            _viewCheckIn.Name = "CurrentView";

            _viewCheckOut = new ViewCheckOut(this);
            _viewCheckOut.Name = "CurrentView";

            _viewPrice = new PanelCustom(new ViewPrice(this));
            _viewPrice.Title = "Prices";
            _viewPrice.Name = "CurrentView";

            _viewWelcome = new ViewWelcome(this);
            _viewWelcome.Name = "CurrentView";

            LaunchViewWelcome();
        }
        private void InitData()
        {
            _users = new List<Person>();
            _areas = new List<Area>();
            _books = new List<Booking>();
            _prices = new List<Price>();

            LoadPrices();
            LoadUsers();
            LoadAreas();
            LoadBooks();
            LoadDataDemo();
        }
        private void LoadDataDemo()
        {
            //_users.Add(new Person(_intBoo.USER_DIRECTORY) { Mail = "MIKOS.Adelaide@totoweb.com", Nationality = "New Zealand", FamilyName = "MIKOS", FirstName = "Adelaide", Gender = Person.GENDER.FEMAL });
            //_users.Add(new Person(_intBoo.USER_DIRECTORY) { Mail = "thibault.montaufray@hotmail.fr", Nationality = "France", FamilyName = "MONTAUFRAY", FirstName = "Thibault", Gender = Person.GENDER.MALE, Comment="Best developer ever ! Trust him you'll be never disapointed, seriously, I never saw a man like that so dedicated to his job and be the best thinns always around him." });
            //_users.Add(new Person(_intBoo.USER_DIRECTORY) { Mail = "", Nationality = "New Zealand", FamilyName = "HARRIS", FirstName = "Jeremy", Gender = Person.GENDER.MALE });
            //_users.Add(new Person(_intBoo.USER_DIRECTORY) { Mail = "", Nationality = "France", FamilyName = "DUPONT", FirstName = "Pierre", Gender = Person.GENDER.OTHER });
            //_users.Add(new Person(_intBoo.USER_DIRECTORY) { Mail = "", Nationality = "United States", FamilyName = "SMITH", FirstName = "John", Gender = Person.GENDER.MALE });
            //_users.Add(new Person(_intBoo.USER_DIRECTORY) { Mail = "vladAdj@gmail.com", Nationality = "Russia", FamilyName = "AJIKELIAMOV", FirstName = "Vladimir" });

            //_peoples.Add(new Person(PERSON_DIRECTORY, "Adelaide", "MIKOS") { Mail = "MIKOS.Adelaide@totoweb.com", Nationality = "New Zealand", Gender = Person.GENDER.FEMAL });
            //_peoples.Add(new Person(PERSON_DIRECTORY, "Thibault", "MONTAUFRAY") { Mail = "thibault.montaufray@hotmail.fr", Nationality = "France", Gender = Person.GENDER.MALE, Comment = "Best developer ever ! Trust him you'll be never disapointed, seriously, I never saw a man like that so dedicated to his job and be the best thinns always around him." });
            //_peoples.Add(new Person(PERSON_DIRECTORY, "Jeremy", "HARRIS") { Mail = "", Nationality = "New Zealand", Gender = Person.GENDER.MALE });
            //_peoples.Add(new Person(PERSON_DIRECTORY, "Pierre", "DUPONT") { Mail = "", Nationality = "France", Gender = Person.GENDER.FEMAL });
            //_peoples.Add(new Person(PERSON_DIRECTORY, "John", "SMITH") { Mail = "", Nationality = "United States", Gender = Person.GENDER.OTHER });
            //_peoples.Add(new Person(PERSON_DIRECTORY, "Vladimir", "AJIKELIAMOV") { Mail = "vladAdj@gmail.com", Nationality = "Russia", Gender = Person.GENDER.UNKNOW });

            //_areas.Add(new Area() { Name = "G1", Floor = 0, Color = System.Drawing.Color.Brown, Capacity = 10, Type = Area.TYPE.DORM });
            //_areas.Add(new Area() { Name = "G2", Floor = 0, Color = System.Drawing.Color.Brown, Capacity = 10, Type = Area.TYPE.DORM });
            //_areas.Add(new Area() { Name = "G3", Floor = 0, Color = System.Drawing.Color.Brown, Capacity = 12, Type = Area.TYPE.DORM });
            //_areas.Add(new Area() { Name = "120", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "121", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "122", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "123", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 8, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "220", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "221", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "222", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "223", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 8, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "224", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 8, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "225", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 5, Type = Area.TYPE.ROOM });
            //_areas.Add(new Area() { Name = "P0", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            //_areas.Add(new Area() { Name = "P1", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            //_areas.Add(new Area() { Name = "P2", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            //_areas.Add(new Area() { Name = "P3", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            //_areas.Add(new Area() { Name = "P4", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });

            //_books.Add(new Booking() { AreaId = _areas[4].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(0), CheckOut = DateTime.Now.AddDays(7), Paid = 20, Price = 120, UserId = _peoples[0].Id });
            //_books.Add(new Booking() { AreaId = _areas[0].Id, Confirmed = false, CheckIn = DateTime.Now.AddDays(0), CheckOut = DateTime.Now.AddDays(5), Paid = 20, Price = 120, UserId = _peoples[1].Id });
            //_books.Add(new Booking() { AreaId = _areas[10].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(-3), CheckOut = DateTime.Now.AddDays(5), Paid = 0, Price = 150, UserId = _peoples[2].Id });
            //_books.Add(new Booking() { AreaId = _areas[7].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(0), CheckOut = DateTime.Now.AddDays(6), Paid = 20, Price = 120, UserId = _peoples[4].Id });
            //_books.Add(new Booking() { AreaId = _areas[5].Id, Confirmed = false, CheckIn = DateTime.Now.AddDays(1), CheckOut = DateTime.Now.AddDays(7), Paid = 20, Price = 120, UserId = _peoples[3].Id });
            //_books.Add(new Booking() { AreaId = _areas[11].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(-7), CheckOut = DateTime.Now.AddDays(0), Paid = 20, Price = 120, UserId = _peoples[5].Id });
            //_books.Add(new Booking() { AreaId = _areas[8].Id, Confirmed = false, CheckIn = DateTime.Now.AddDays(5), CheckOut = DateTime.Now.AddDays(8), Paid = 120, Price = 120, UserId = _peoples[0].Id });
            //_books.Add(new Booking() { AreaId = _areas[9].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(6), CheckOut = DateTime.Now.AddDays(17), Paid = 120, Price = 120, UserId = _peoples[1].Id });
            //_books.Add(new Booking() { AreaId = _areas[1].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(0), CheckOut = DateTime.Now.AddDays(17), Paid = 20, Price = 120, UserId = _peoples[2].Id });
            //_books.Add(new Booking() { AreaId = _areas[14].Id, Confirmed = false, CheckIn = DateTime.Now.AddDays(-9), CheckOut = DateTime.Now.AddDays(0), Paid = 20, Price = 10, UserId = _peoples[3].Id });
            //_books.Add(new Booking() { AreaId = _areas[13].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(2), CheckOut = DateTime.Now.AddDays(3), Paid = 20, Price = 20, UserId = _peoples[2].Id });
            //_books.Add(new Booking() { AreaId = _areas[12].Id, Confirmed = true, CheckIn = DateTime.Now.AddDays(0), CheckOut = DateTime.Now.AddDays(2), Paid = 20, Price = 20, UserId = _peoples[0].Id });
        }
        private void LoadPrices()
        {
            string fileData = string.Empty;

            if (_prices == null) { _prices = new List<Price>(); }
            else { _prices.Clear(); }

            if  (File.Exists(Path.Combine(_directoryCloud, "prices.xml")))
            {
                using (StreamReader sr = new StreamReader(Path.Combine(_directoryCloud, "prices.xml")))
                {
                    fileData = sr.ReadToEnd();
                }
                XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Price>));
                using (var sww = new StringReader(fileData))
                {
                    using (XmlReader reader = XmlReader.Create(sww))
                    {
                        try
                        {
                            _prices = (List<Price>)xsSubmit.Deserialize(reader);
                        }
                        catch (Exception exp)
                        {
                            Log.Write("[ ERR 0600 ] Cannot load price xml file : " + exp.Message);
                        }
                    }
                }
            }
            else
            {
                _prices = new List<Price>();
            }
        }
        private void LoadUsers()
        {
            _users.Clear();
            if (Directory.Exists(_directoryUser))
            { 
                foreach (string dirName in Directory.GetDirectories(_directoryUser))
                {
                    _users.Add(new Person(dirName));
                }
            }
        }
        private void LoadAreas()
        {
            _areas.Clear();
            if (Directory.Exists(_directoryArea))
            {
                foreach (string dirName in Directory.GetDirectories(_directoryArea))
                {
                    _areas.Add(new Area(dirName));
                }
            }
        }
        private void LoadBooks()
        {
            _books.Clear();
            if (Directory.Exists(_directoryBook))
            {
                foreach (string dirName in Directory.GetDirectories(_directoryBook))
                {
                    _books.Add(new Booking(dirName));
                }
            }
        }
        private void SavePrices()
        {
            string serializedObject = string.Empty;

            if (!Directory.Exists(_directoryCloud)) { Directory.CreateDirectory(_directoryCloud); }
            //if (!File.Exists(Path.Combine(CLOUD_DIRECTORY, "prices.xml"))) { File.Create(Path.Combine(CLOUD_DIRECTORY, "prices.xml")); }

            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Price>));
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, _prices);
                    serializedObject = sww.ToString();
                }
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(_directoryCloud, "prices.xml"), false))
            {
                sw.Write(serializedObject);
            }
        }
        private void DisplayControl(PanelCustom pc)
        {
            _sheet.Controls.Clear();

            pc.Top = TOP_OFFSET;
            pc.RefreshData();
            pc.Left = (_sheet.Width / 2) - (pc.Width / 2);
            pc.ChangeLanguage();
            _sheet.Controls.Add(pc);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }

        #region Launcher
        private void LaunchSavePrice()
        {
            SavePrices();
        }
        private void LaunchSettings()
        {
            DisplayControl(_viewSetting);
        }
        private void LaunchViewWelcome()
        {
            _sheet.Controls.Clear();
            
            _viewWelcome.Top = TOP_OFFSET;
            _viewWelcome.RefreshData();
            _viewWelcome.Left = (_sheet.Width / 2) - (_viewWelcome.Width / 2);
            _viewWelcome.ChangeLanguage();
            _sheet.Controls.Add(_viewWelcome);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewCalendar()
        {
            _sheet.Controls.Clear();

            _viewCalendar.Top = TOP_OFFSET - 25;
            _viewCalendar.RefreshData();
            _viewCalendar.Left = 0;
            _viewCalendar.Width = _sheet.Width;
            _viewCalendar.Height = _sheet.Height - TOP_OFFSET + 25;
            _viewCalendar.ChangeLanguage();
            _sheet.Controls.Add(_viewCalendar);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewBookDetail()
        {
            _sheet.Controls.Clear();
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewBookEdit()
        {
            DisplayControl(_viewBookEdit);
        }
        private void LaunchViewBookSearch()
        {
            DisplayControl(_viewBookSearch);
        }
        //private void LaunchViewUserSearch()
        //{
        //    _sheet.Controls.Clear();
        //    _viewUserSearch.ChangeLanguage();
        //    _sheet.Controls.Add(_viewUserSearch);
        //}
        //private void LaunchViewUserEdit()
        //{
        //    _sheet.Controls.Clear();

        //    _viewUserDetail.Top = 76;
        //    _viewUserDetail.CurrentPerson = _currentPerson;
        //    _viewUserDetail.Left = (_sheet.Width / 2) - (_viewUserDetail.Width / 2);
        //    _viewUserDetail.IsEditable = true;
        //    _viewUserDetail.ChangeLanguage(Properties.Settings.Default.Language);
        //    _sheet.Controls.Add(_viewUserDetail);
        //}
        //private void LaunchViewUserAdd()
        //{
        //    _sheet.Controls.Clear();

        //    _viewUserDetail.Top = 76;
        //    _currentPerson = new Person(PERSON_DIRECTORY);
        //    _viewUserDetail.CurrentPerson = _currentPerson;
        //    _viewUserDetail.Left = (_sheet.Width / 2) - (_viewUserDetail.Width / 2);
        //    _viewUserDetail.IsEditable = true;
        //    _viewUserDetail.ChangeLanguage(Properties.Settings.Default.Language);
        //    _sheet.Controls.Add(_viewUserDetail);
        //}
        //private void LaunchViewUserDetails()
        //{
        //    _sheet.Controls.Clear();

        //    if (_currentPerson != null)
        //    {
        //        _viewUserDetail.Top = 76;
        //        _viewUserDetail.CurrentPerson = _currentPerson;
        //        _viewUserDetail.Left = (_sheet.Width / 2) - (_viewUserDetail.Width / 2);
        //        _viewUserDetail.IsEditable = false;
        //        _viewUserDetail.ChangeLanguage(Properties.Settings.Default.Language);
        //        _sheet.Controls.Add(_viewUserDetail);
        //    }
        //    else
        //    {
        //        LaunchViewUserAdd();
        //    }
        //}
        private void LaunchViewAreaSearch()
        {
            DisplayControl(_viewAreaSearch);
        }
        private void LaunchViewAreaEdit()
        {
            DisplayControl(_viewAreaEdit);
        }
        private void LaunchViewAreaAdd()
        {
            _currentArea = new Area();
            DisplayControl(_viewAreaEdit);
        }
        private void LaunchCheckIn()
        {
            _sheet.Controls.Clear();

            _viewCheckIn.Top = TOP_OFFSET;
            _viewCheckIn.RefreshData();
            _viewCheckIn.Left = (_sheet.Width / 2) - (_viewCheckIn.Width / 2);
            _viewCheckIn.ChangeLanguage();
            _sheet.Controls.Add(_viewCheckIn);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchCheckOut()
        {
            _sheet.Controls.Clear();

            _viewCheckOut.Top = TOP_OFFSET;
            _viewCheckOut.RefreshData();
            _viewCheckOut.Left = (_sheet.Width / 2) - (_viewCheckOut.Width / 2);
            _viewCheckOut.ChangeLanguage();
            _sheet.Controls.Add(_viewCheckOut);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchPrices()
        {
            DisplayControl(_viewPrice);
        }
        private void LaunchDeterminePrice()
        {
            _currentPrice = null;
            if (_currentArea != null)
            {
                var lst = _prices.Where(p => p.Type.ToString().Equals(_currentArea.Type.ToString())).ToList();
                if (lst.Count() == 0) return;
                else if (lst.Count() == 1)
                {
                    _currentPrice = lst.First();
                }
                else if (!string.IsNullOrEmpty(_currentArea.Name))
                {
                    var lst2 = lst.Where(p => p.Name.Equals(_currentArea.Name)).ToList();
                    if (lst2.Count() == 0)
                    {
                        _currentPrice = lst.First();
                    }
                    else if (lst2.Count() == 1)
                    {
                        _currentPrice = lst2.First();
                    }
                    else
                    {
                        var lst3 = lst2.Where(p => p.Place.Equals(_currentArea.Place)).ToList();
                        if (lst3.Count() == 0)
                        {
                            _currentPrice = lst2.First();
                        }
                        else if (lst3.Count() == 1)
                        {
                            _currentPrice = lst3.First();
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Event
        private void _sheet_Resize(object sender, EventArgs e)
        {
            Resize();
        }
        //private void _viewUserSearch_RequestUserDetail(object o)
        //{
        //    if (o is Person)
        //    {
        //        _currentPerson = o as Person;
        //        LaunchViewUserDetails();
        //    }
        //}
        //private void _viewUserSearch_RequestUserEdition(object o)
        //{
        //    if (o is Person)
        //    {
        //        _currentPerson = o as Person;
        //        LaunchViewUserEdit();
        //    }
        //}
        private void _viewBookSearch_RequestBookDetail(object o)
        {
            if (o is Booking)
            {
                _currentbooking = o as Booking;
                LaunchViewBookDetail();
            }
        }
        private void _viewBookSearch_RequestBookEdition(object o)
        {
            if (o is Booking)
            {
                _currentbooking = o as Booking;
                LaunchViewBookEdit();
            }
        }
        private void Vbe_CreatePersonRequested()
        {
            if (CreatePersonRequested != null) { CreatePersonRequested(); }
        }
        #endregion
    }
}
