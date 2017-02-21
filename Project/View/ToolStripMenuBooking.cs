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

        private RibbonPanel _panelUser;
        private RibbonButton _rbUserAdd;
        private RibbonButton _rbUserSearch;

        private RibbonPanel _panelArea;
        private RibbonButton _rbAreaAdd;
        private RibbonButton _rbAreaSearch;

        private RibbonPanel _panelBook;
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

            _rbParameters = new RibbonButton("Settings");
            _rbParameters.Image = Tools4Libraries.Resources.ResourceIconSet32Default.google_webmaster_tools;
            _rbParameters.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.google_webmaster_tools;
            _rbParameters.Click += _rbParameter_Click;

            _panelView = new RibbonPanel("View");
            _panelView.Items.Add(_rbWelcome);
            _panelView.Items.Add(_rbCalendar);
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

            _panelBook = new RibbonPanel("Book");
            _panelBook.Items.Add(_rbBookAdd);
            _panelBook.Items.Add(_rbBookSearch);
            this.Panels.Add(_panelBook);
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
        #endregion
    }
}
