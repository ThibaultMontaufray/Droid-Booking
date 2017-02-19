using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public class Interface_booking : GPInterface
    {
        #region Attribtue
        private Panel _sheet;
        private ToolStripMenuBooking _tsm;
        private ViewCalendar _viewCalendar;
        private ViewUserSearch _viewUserSearch;
        private ViewUserDetail _viewUserDetail;
        private ViewAreaSearch _viewAreaSearch;
        private ViewAreaEdit _viewAreaEdit;
        private ViewWelcome _viewWelcome;
        private ViewBookEdit _viewBookEdit;
        private ViewUserEdit _viewUserEdit;

        private List<User> _users;
        private List<Area> _areas;
        private List<Book> _books;
        
        private User _currentUser;
        private Area _currentArea;
        private Book _currentBook;
        #endregion

        #region Properties
        public Book CurrentBook
        {
            get { return _currentBook; }
            set { _currentBook = value; }
        }
        public List<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }
        public Area CurrentArea
        {
            get { return _currentArea; }
            set { _currentArea = value; }
        }
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        public List<Area> Areas
        {
            get { return _areas; }
            set { _areas = value; }
        }
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
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
        public Interface_booking()
        {
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
                    LaunchViewNewBook();
                    break;
                case "booksearch":
                    break;
                case "viewusersearch":
                    LaunchViewUserSearch();
                    break;
                case "viewuseradd":
                    LaunchViewUserAdd();
                    break;
                case "viewuseredit":
                    LaunchViewUserEdit();
                    break;
                case "areaadd":
                    LaunchViewAreaEdit();
                    break;
                case "areasearch":
                    LaunchViewAreaSearch();
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

            BuildToolBar();
            InitData();

            _viewCalendar = new ViewCalendar(this);
            _viewCalendar.Dock = DockStyle.Fill;

            _viewUserSearch = new ViewUserSearch(this);
            _viewUserSearch.Dock = DockStyle.Fill;
            _viewUserSearch.RequestUserDetail += _viewUserSearch_RequestUserDetail;
            _viewUserSearch.RequestUserEdition += _viewUserSearch_RequestUserEdition;

            _viewUserEdit = new ViewUserEdit(this);

            _viewUserDetail = new ViewUserDetail();
            
            _viewAreaSearch = new ViewAreaSearch(this);
            _viewAreaSearch.Dock = DockStyle.Fill;

            _viewAreaEdit = new ViewAreaEdit(this);

            _viewBookEdit = new ViewBookEdit(this);

            _viewWelcome = new ViewWelcome(this);
            _viewWelcome.Dock = DockStyle.Fill;
            _sheet.Controls.Add(_viewWelcome);
        }
        private void InitData()
        {
            _users = new List<User>();
            _areas = new List<Area>();
            _books = new List<Book>();

            LoadDataDemo();
        }
        private void LoadDataDemo()
        {
            _users.Add(new User() { Mail = "MIKOS.Adelaide@totoweb.com", Country = "New Zealand", FamilyName = "MIKOS", FirstName = "Adelaide", Gender = User.GENDER.FEMAL, Id = "0127856789" });
            _users.Add(new User() { Mail = "thibault.montaufray@hotmail.fr", Country = "France", FamilyName = "MONTAUFRAY", FirstName = "Thibault", Gender = User.GENDER.MALE, Id = "0125666789", Comment="Best developer ever ! Trust him you'll be never disapointed, seriously, I never saw a man like that so dedicated to his job and be the best thinns always around him." });
            _users.Add(new User() { Mail = "", Country = "New Zealand", FamilyName = "HARRIS", FirstName = "Jeremy", Gender = User.GENDER.MALE, Id = "5823697410" });
            _users.Add(new User() { Mail = "", Country = "France", FamilyName = "DUPONT", FirstName = "Pierre", Gender = User.GENDER.OTHER, Id = "1111456789" });
            _users.Add(new User() { Mail = "", Country = "United States", FamilyName = "SMITH", FirstName = "John", Gender = User.GENDER.MALE, Id = "0121156789" });
            _users.Add(new User() { Mail = "vladAdj@gmail.com", Country = "Russia", FamilyName = "AJIKELIAMOV", FirstName = "Vladimir", Id = "9876543210" });

            _areas.Add(new Area() { Name = "G1", Floor = 0, Color = System.Drawing.Color.Brown, Capacity = 10, Type = Area.TYPE.DORM });
            _areas.Add(new Area() { Name = "G2", Floor = 0, Color = System.Drawing.Color.Brown, Capacity = 10, Type = Area.TYPE.DORM });
            _areas.Add(new Area() { Name = "G3", Floor = 0, Color = System.Drawing.Color.Brown, Capacity = 12, Type = Area.TYPE.DORM });
            _areas.Add(new Area() { Name = "120", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "121", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "122", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "123", Floor = 1, Color = System.Drawing.Color.Orange, Capacity = 8, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "220", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "221", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "222", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 3, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "223", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 8, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "224", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 8, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "225", Floor = 2, Color = System.Drawing.Color.Orange, Capacity = 5, Type = Area.TYPE.ROOM });
            _areas.Add(new Area() { Name = "P0", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            _areas.Add(new Area() { Name = "P1", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            _areas.Add(new Area() { Name = "P2", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            _areas.Add(new Area() { Name = "P3", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });
            _areas.Add(new Area() { Name = "P4", Floor = 0, Color = System.Drawing.Color.Gray, Capacity = 1, Type = Area.TYPE.PARKING });

            _books.Add(new Book() { Area = _areas[4], Confirmed = true, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(7), Paid = 20, Price = 120, User = _users[0] });
            _books.Add(new Book() { Area = _areas[0], Confirmed = true, StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(5), Paid = 20, Price = 120, User = _users[1] });
            _books.Add(new Book() { Area = _areas[4], Confirmed = true, StartDate = DateTime.Now.AddDays(-3), EndDate = DateTime.Now.AddDays(5), Paid = 20, Price = 120, User = _users[2] });
            _books.Add(new Book() { Area = _areas[7], Confirmed = true, StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(6), Paid = 20, Price = 120, User = _users[4] });
            _books.Add(new Book() { Area = _areas[5], Confirmed = true, StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(7), Paid = 20, Price = 120, User = _users[3] });
            _books.Add(new Book() { Area = _areas[5], Confirmed = true, StartDate = DateTime.Now.AddDays(-7), EndDate = DateTime.Now.AddDays(9), Paid = 20, Price = 120, User = _users[5] });
            _books.Add(new Book() { Area = _areas[8], Confirmed = true, StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(8), Paid = 20, Price = 120, User = _users[0] });
            _books.Add(new Book() { Area = _areas[9], Confirmed = true, StartDate = DateTime.Now.AddDays(6), EndDate = DateTime.Now.AddDays(17), Paid = 20, Price = 120, User = _users[1] });
            _books.Add(new Book() { Area = _areas[1], Confirmed = true, StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(17), Paid = 20, Price = 120, User = _users[2] });
            _books.Add(new Book() { Area = _areas[14], Confirmed = true, StartDate = DateTime.Now.AddDays(-9), EndDate = DateTime.Now.AddDays(17), Paid = 20, Price = 120, User = _users[3] });
            _books.Add(new Book() { Area = _areas[4], Confirmed = true, StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(3), Paid = 20, Price = 120, User = _users[2] });
        }

        #region Launcher
        private void LaunchViewWelcome()
        {
            _sheet.Controls.Clear();
            _sheet.Controls.Add(_viewWelcome);
        }
        private void LaunchViewCalendar()
        {
            _sheet.Controls.Clear();
            _sheet.Controls.Add(_viewCalendar);
        }
        private void LaunchViewUserDetails()
        {
            _sheet.Controls.Clear();

            if (_currentUser != null)
            { 
                _viewUserDetail.Top = 76;
                _viewUserDetail.Left =( _sheet.Width / 2) - (_viewUserDetail.Width / 2);
                _viewUserDetail.LoadUser(_currentUser);
                _sheet.Controls.Add(_viewUserDetail);
            }
            else
            {

            }
        }
        private void LaunchViewNewBook()
        {
            _sheet.Controls.Clear();

            _viewBookEdit.Top = 76;
            _viewBookEdit.RefreshData();
            _viewBookEdit.Left = (_sheet.Width / 2) - (_viewBookEdit.Width / 2);
            _sheet.Controls.Add(_viewBookEdit);
        }
        private void LaunchViewUserSearch()
        {
            _sheet.Controls.Clear();
            _sheet.Controls.Add(_viewUserSearch);
        }
        private void LaunchViewUserEdit()
        {
            _sheet.Controls.Clear();

            _viewUserEdit.Top = 76;
            _viewUserEdit.RefreshData();
            _viewUserEdit.Left = (_sheet.Width / 2) - (_viewUserEdit.Width / 2);
            _sheet.Controls.Add(_viewUserEdit);
        }
        private void LaunchViewUserAdd()
        {
            _sheet.Controls.Clear();

            _viewUserEdit.Top = 76;
            _currentUser = new User();
            _viewUserEdit.RefreshData();
            _viewUserEdit.Left = (_sheet.Width / 2) - (_viewUserEdit.Width / 2);
            _sheet.Controls.Add(_viewUserEdit);
        }
        private void LaunchViewAreaSearch()
        {
            _sheet.Controls.Clear();
            _viewAreaSearch.RefreshData();
            _sheet.Controls.Add(_viewAreaSearch);
        }
        private void LaunchViewAreaEdit()
        {
            _sheet.Controls.Clear();

            _viewAreaEdit.Top = 76;
            _viewAreaEdit.RefreshData();
            _viewAreaEdit.Left = (_sheet.Width / 2) - (_viewAreaEdit.Width / 2);
            _sheet.Controls.Add(_viewAreaEdit);
        }
        private void LaunchViewAreaAdd()
        {
            _sheet.Controls.Clear();

            _viewAreaEdit.Top = 76;
            _currentArea = new Area();
            _viewAreaEdit.RefreshData();
            _viewAreaEdit.Left = (_sheet.Width / 2) - (_viewAreaEdit.Width / 2);
            _sheet.Controls.Add(_viewAreaEdit);
        }
        #endregion

        #endregion

        #region Event
        private void _viewUserSearch_RequestUserDetail(object o)
        {
            if (o is User)
            {
                _currentUser = o as User;
                LaunchViewUserDetails();
            }
        }
        private void _viewUserSearch_RequestUserEdition(object o)
        {
            if (o is User)
            {
                _currentUser = o as User;
                LaunchViewUserEdit();
            }
        }
        #endregion
    }
}
