// Log code : 06 - 00

using Droid_People;
using System;
using System.Collections.Generic;
using System.IO;
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
        public readonly int TOP_OFFSET = 175;
        public string _directoryCloud;
        public string _directoryUser;
        public string _directoryArea;
        public string _directoryBook;

        public event InterfaceEventHandler SheetDisplayRequested;
        public event InterfaceBookingEventHandler LanguageModified;

        private Panel _sheet;
        private ToolStripMenuBooking _tsm;
        private ViewCalendar _viewCalendar;
        //private ViewUserSearch _viewUserSearch;
        private ViewAreaSearch _viewAreaSearch;
        private ViewAreaEdit _viewAreaEdit;
        private ViewWelcome _viewWelcome;
        private ViewBookEdit _viewBookEdit;
        private ViewBookSearch _viewBookSearch;
        private ViewSettings _viewSetting;
        private ViewCheckIn _viewCheckIn;
        private ViewCheckOut _viewCheckOut;
        private ViewPrice _viewPrice;

        private List<Person> _peoples;
        private List<Area> _areas;
        private List<Booking> _books;
        private List<Price> _prices;
        
        private Person _currentPerson;
        private Area _currentArea;
        private Booking _currentbooking;
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
            get { return _peoples; }
            set { _peoples = value; }
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
        #endregion

        #region Constructor
        public Interface_booking(string workingDirectory)
        {
            _workingDirectory = workingDirectory;
            _directoryCloud = _workingDirectory + @"";
            _directoryUser = _workingDirectory + @"User\";
            _directoryArea = _workingDirectory + @"Area\";
            _directoryBook = _workingDirectory + @"Book\";

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
            
            _viewAreaSearch = new ViewAreaSearch(this);
            _viewAreaSearch.Name = "CurrentView";

            _viewAreaEdit = new ViewAreaEdit(this);
            _viewAreaEdit.Name = "CurrentView";

            _viewBookSearch = new ViewBookSearch(this);
            _viewBookSearch.RequestBookDetail += _viewBookSearch_RequestBookDetail;
            _viewBookSearch.RequestBookEdition += _viewBookSearch_RequestBookEdition;
            _viewBookSearch.Name = "CurrentView";

            _viewBookEdit = new ViewBookEdit(this);
            _viewBookEdit.Name = "CurrentView";

            _viewSetting = new ViewSettings(this);
            _viewSetting.Name = "CurrentView";

            _viewCheckIn = new ViewCheckIn(this);
            _viewCheckIn.Name = "CurrentView";

            _viewCheckOut = new ViewCheckOut(this);
            _viewCheckOut.Name = "CurrentView";

            _viewPrice = new ViewPrice(this);
            _viewPrice.Name = "CurrentView";

            _viewWelcome = new ViewWelcome(this);
            _viewWelcome.Name = "CurrentView";

            LaunchViewWelcome();
        }
        private void InitData()
        {
            _peoples = new List<Person>();
            _areas = new List<Area>();
            _books = new List<Booking>();
            _prices = new List<Price>();

            LoadPrices();
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

        #region Launcher
        private void LaunchSavePrice()
        {
            SavePrices();
        }
        private void LaunchSettings()
        {
            _sheet.Controls.Clear();

            _viewSetting.Top = TOP_OFFSET;
            _viewSetting.RefreshData();
            _viewSetting.Left = (_sheet.Width / 2) - (_viewSetting.Width / 2);
            _viewSetting.ChangeLanguage();
            _sheet.Controls.Add(_viewSetting);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
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
            _sheet.Controls.Clear();

            _viewBookEdit.Top = TOP_OFFSET;
            _viewBookEdit.RefreshData();
            _viewBookEdit.Left = (_sheet.Width / 2) - (_viewBookEdit.Width / 2);
            _viewBookEdit.ChangeLanguage();
            _sheet.Controls.Add(_viewBookEdit);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewBookSearch()
        {
            _sheet.Controls.Clear();

            _viewBookSearch.Top = TOP_OFFSET;
            _viewBookSearch.RefreshData();
            _viewBookSearch.Left = (_sheet.Width / 2) - (_viewBookSearch.Width / 2);
            _viewBookSearch.ChangeLanguage();
            _sheet.Controls.Add(_viewBookSearch);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
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
            _sheet.Controls.Clear();
            _viewAreaSearch.RefreshData();
            _viewAreaSearch.ChangeLanguage();
            _sheet.Controls.Add(_viewAreaSearch);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewAreaEdit()
        {
            _sheet.Controls.Clear();

            _viewAreaEdit.Top = TOP_OFFSET;
            _viewAreaEdit.RefreshData();
            _viewAreaEdit.Left = (_sheet.Width / 2) - (_viewAreaEdit.Width / 2);
            _viewAreaEdit.ChangeLanguage();
            _sheet.Controls.Add(_viewAreaEdit);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewAreaAdd()
        {
            _sheet.Controls.Clear();

            _viewAreaEdit.Top = TOP_OFFSET;
            _currentArea = new Area();
            _viewAreaEdit.RefreshData();
            _viewAreaEdit.Left = (_sheet.Width / 2) - (_viewAreaEdit.Width / 2);
            _viewAreaEdit.ChangeLanguage();
            _sheet.Controls.Add(_viewAreaEdit);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
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
            _sheet.Controls.Clear();

            _viewPrice.Top = TOP_OFFSET;
            _viewPrice.RefreshData();
            _viewPrice.Left = (_sheet.Width / 2) - (_viewPrice.Width / 2);
            _viewPrice.ChangeLanguage();
            _sheet.Controls.Add(_viewPrice);
            if (SheetDisplayRequested != null) SheetDisplayRequested();

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
        #endregion
    }
}
