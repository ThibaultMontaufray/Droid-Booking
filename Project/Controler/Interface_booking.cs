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
        private ViewUser _viewUser;
        private ViewArea _viewArea;
        private ViewWelcome _viewWelcome;

        private List<User> _users;
        private List<Area> _areas;
        #endregion

        #region Properties
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
                case "viewuserdetail":
                    LaunchViewUserDetails();
                    break;
                case "viewusersearch":
                    LaunchViewUserSearch();
                    break;
                case "viewuseradd":
                    LaunchViewUserAdd();
                    break;
                case "areaadd":
                    LaunchViewAreaDetail();
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

            BuildToolBar();
            InitData();

            _viewCalendar = new ViewCalendar(this);
            _viewCalendar.Dock = DockStyle.Fill;

            _viewUser = new ViewUser(this);
            _viewUser.Dock = DockStyle.Fill;

            _viewArea = new ViewArea(this);
            _viewArea.Dock = DockStyle.Fill;

            _viewWelcome = new ViewWelcome(this);
            _viewWelcome.Dock = DockStyle.Fill;
            _sheet.Controls.Add(_viewWelcome);
        }
        private void InitData()
        {
            _users = new List<User>();
            _areas = new List<Area>();

            LoadDataDemo();
        }
        private void LoadDataDemo()
        {
            _users.Add(new User() { Country = "New Zealand", FamilyName = "MIKOS", FirstName = "Adelaide", Gender = User.GENDER.FEMAL, Id = "0123456789" });
            _users.Add(new User() { Country = "France", FamilyName = "MONTAUFRAY", FirstName = "Thibault", Gender = User.GENDER.MALE, Id = "0123456789" });
            _users.Add(new User() { Country = "New Zealand", FamilyName = "HARRIS", FirstName = "Jeremy", Gender = User.GENDER.MALE, Id = "" });
            _users.Add(new User() { Country = "France", FamilyName = "DUPONT", FirstName = "Pierre", Gender = User.GENDER.OTHER, Id = "0123456789" });
            _users.Add(new User() { Country = "United States", FamilyName = "SMITH", FirstName = "John", Gender = User.GENDER.MALE, Id = "0123456789" });
            _users.Add(new User() { Country = "Russia", FamilyName = "AJIKELIAMOV", FirstName = "Vladimir", Id = "9876543210" });

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
            _viewUser.ModeView = ViewUser.Mode.DETAIL;
            _sheet.Controls.Add(_viewUser);
        }
        private void LaunchViewUserSearch()
        {
            _sheet.Controls.Clear();
            _viewUser.ModeView = ViewUser.Mode.SEARCH;
            _sheet.Controls.Add(_viewUser);
        }
        private void LaunchViewUserAdd()
        {
            _sheet.Controls.Clear();
            _viewUser.ModeView = ViewUser.Mode.ADD;
            _sheet.Controls.Add(_viewUser);
        }
        private void LaunchViewAreaSearch()
        {
            _sheet.Controls.Clear();
            _viewArea.ModeView = ViewArea.Mode.SEARCH;
            _sheet.Controls.Add(_viewArea);
        }
        private void LaunchViewAreaDetail()
        {
            _sheet.Controls.Clear();
            _viewArea.ModeView = ViewArea.Mode.ADD;
            _sheet.Controls.Add(_viewArea);
        }
        #endregion

        #endregion
    }
}
