using System;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public class ToolStripMenuBooking : RibbonTab
    {
        #region Attribute
        public event EventHandlerAction ActionAppened;

        private GUI _gui;
        private RibbonPanel _panelView;
        private RibbonButton _rbWelcome;
        private RibbonButton _rbCalendar;
        private RibbonButton _rbParameters;
        private RibbonButton _rbCheckIn;
        private RibbonButton _rbCheckOut;
        private RibbonButton _rbPrices;

        private RibbonPanel _panelUser;
        private RibbonButton _rbUserAdd;
        private RibbonButton _rbUserSearch;

        private RibbonPanel _panelArea;
        private RibbonButton _rbAreaAdd;
        private RibbonButton _rbAreaSearch;

        private RibbonPanel _panelbooking;
        private RibbonButton _rbBookAdd;
        private RibbonButton _rbBookSearch;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ToolStripMenuBooking()
        {
            Init();
        }
        #endregion

        #region Methods public
        public void ChangeLanguage()
        {
            _rbWelcome.Text = GetText.Text("Menu");
            _rbCalendar.Text = GetText.Text("CalendarView");
            _rbParameters.Text = GetText.Text("Settings");
            _panelView.Text = GetText.Text("View");
            _rbUserAdd.Text = GetText.Text("Useradd");
            _rbUserSearch.Text = GetText.Text("Searchuser");
            _panelUser.Text = GetText.Text("User");
            _rbAreaAdd.Text = GetText.Text("Addarea");
            _rbAreaSearch.Text = GetText.Text("Searcharea");
            _panelArea.Text = GetText.Text("Area");
            _rbBookAdd.Text = GetText.Text("Newbook");
            _rbBookSearch.Text = GetText.Text("Searchbook");
            _panelbooking.Text = GetText.Text("Book");
            _rbCheckIn.Text = GetText.Text("CheckIn");
            _rbCheckOut.Text = GetText.Text("CheckOut");
            _rbPrices.Text = GetText.Text("Prices");
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _gui = new GUI();
            BuildPanelFiles();
            BuildPanelUsers();
            BuildPanelArea();
            BuildPanelBook();
        }
        private void BuildPanelFiles()
        {
            _rbWelcome = new RibbonButton("Menu");
            _rbWelcome.Image = Tools4Libraries.Resources.ResourceIconSet32Default.home_page;
            _rbWelcome.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.home_page;
            _rbWelcome.Click += _rbWelcome_Click;

            _rbCalendar = new RibbonButton("Calendar view");
            _rbCalendar.Image = Tools4Libraries.Resources.ResourceIconSet32Default.calendar;
            _rbCalendar.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.calendar;
            _rbCalendar.Click += _rbCalendar_Click;

            _rbCheckIn = new RibbonButton("Today's check in");
            _rbCheckIn.Image = Tools4Libraries.Resources.ResourceIconSet32Default.door_in;
            _rbCheckIn.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.door_in;
            _rbCheckIn.Click += _rbCheckIn_Click;

            _rbCheckOut = new RibbonButton("Today's check out");
            _rbCheckOut.Image = Tools4Libraries.Resources.ResourceIconSet32Default.door_out;
            _rbCheckOut.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.door_out;
            _rbCheckOut.Click += _rbCheckOut_Click;
            
            _rbPrices = new RibbonButton("Calendar's prices");
            _rbPrices.Image = Tools4Libraries.Resources.ResourceIconSet32Default.table_money;
            _rbPrices.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.table_money;
            _rbPrices.Click += _rbPrices_Click;

            _rbParameters = new RibbonButton("Settings");
            _rbParameters.Image = Tools4Libraries.Resources.ResourceIconSet32Default.google_webmaster_tools;
            _rbParameters.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.google_webmaster_tools;
            _rbParameters.Click += _rbParameter_Click;

            _panelView = new RibbonPanel("View");
            _panelView.Items.Add(_rbWelcome);
            _panelView.Items.Add(_rbCalendar);
            _panelView.Items.Add(_rbCheckIn);
            _panelView.Items.Add(_rbCheckOut);
            _panelView.Items.Add(_rbPrices);
            _panelView.Items.Add(_rbParameters);
            this.Panels.Add(_panelView);
        }
        private void BuildPanelUsers()
        {
            _rbUserAdd = new RibbonButton("User add");
            _rbUserAdd.Image = Tools4Libraries.Resources.ResourceIconSet32Default.user_add;
            _rbUserAdd.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.user_add;
            _rbUserAdd.Click += _rbUserAdd_Click;
            
            _rbUserSearch = new RibbonButton("Search user");
            _rbUserSearch.Image = Tools4Libraries.Resources.ResourceIconSet32Default.drive_user;
            _rbUserSearch.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.drive_user;
            _rbUserSearch.Click += _rbUserSearch_Click;

            _panelUser = new RibbonPanel("User");
            _panelUser.Items.Add(_rbUserAdd);
            _panelUser.Items.Add(_rbUserSearch);
            this.Panels.Add(_panelUser);
        }
        private void BuildPanelArea()
        {
            _rbAreaAdd = new RibbonButton("Add area");
            _rbAreaAdd.Image = Tools4Libraries.Resources.ResourceIconSet32Default.layer_add;
            _rbAreaAdd.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.layer_add;
            _rbAreaAdd.Click += _rbAreaDetail_Click;

            _rbAreaSearch = new RibbonButton("Search area");
            _rbAreaSearch.Image = Tools4Libraries.Resources.ResourceIconSet32Default.layers;
            _rbAreaSearch.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.layers;
            _rbAreaSearch.Click += _rbAreaSearch_Click;

            _panelArea = new RibbonPanel("Area");
            _panelArea.Items.Add(_rbAreaAdd);
            _panelArea.Items.Add(_rbAreaSearch);
            this.Panels.Add(_panelArea);
        }
        private void BuildPanelBook()
        {
            _rbBookAdd = new RibbonButton("New book");
            _rbBookAdd.Image = Tools4Libraries.Resources.ResourceIconSet32Default.report_add;
            _rbBookAdd.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.report_add;
            _rbBookAdd.Click += _rbBookAdd_Click;

            _rbBookSearch = new RibbonButton("Search book");
            _rbBookSearch.Image = Tools4Libraries.Resources.ResourceIconSet32Default.report_magnify;
            _rbBookSearch.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.report_magnify;
            _rbBookSearch.Click += _rbBookSearch_Click;

            _panelbooking = new RibbonPanel("Book");
            _panelbooking.Items.Add(_rbBookAdd);
            _panelbooking.Items.Add(_rbBookSearch);
            this.Panels.Add(_panelbooking);
        }
        #endregion

        #region Event
        public void OnAction(EventArgs e)
        {
            if (ActionAppened != null) ActionAppened(this, e);
        }
        private void _rbWelcome_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("viewwelcome");
            OnAction(action);
        }
        private void _rbCalendar_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("viewcalendar");
            OnAction(action);
        }
        private void _rbUserAdd_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("viewuseradd");
            OnAction(action);
        }
        private void _rbUserSearch_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("viewusersearch");
            OnAction(action);
        }
        private void _rbAreaDetail_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("areaadd");
            OnAction(action);
        }
        private void _rbAreaSearch_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("areasearch");
            OnAction(action);
        }
        private void _rbBookAdd_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("bookadd");
            OnAction(action);
        }
        private void _rbBookSearch_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("booksearch");
            OnAction(action);
        }
        private void _rbParameter_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("settings");
            OnAction(action);
        }
        private void _rbCheckIn_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("checkin");
            OnAction(action);
        }
        private void _rbCheckOut_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("checkout");
            OnAction(action);
        }
        private void _rbPrices_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("prices");
            OnAction(action);
        }
        #endregion
    }
}
