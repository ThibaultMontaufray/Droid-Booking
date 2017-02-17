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
        private RibbonButton _rbUser;
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
        }
        private void BuildPanelFiles()
        {
            _rbWelcome = new RibbonButton("Menu");
            _rbWelcome.Image = Tools4Libraries.Resources.ResourceIconSet32Default.home_page;
            _rbWelcome.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.home_page;
            _rbWelcome.Click += _rbWelcome_Click;

            _rbCalendar = new RibbonButton("Calendar");
            _rbCalendar.Image = Tools4Libraries.Resources.ResourceIconSet32Default.calendar;
            _rbCalendar.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.calendar;
            _rbCalendar.Click += _rbCalendar_Click;

            _rbUser = new RibbonButton("User");
            _rbUser.Image = Tools4Libraries.Resources.ResourceIconSet32Default.user_orange;
            _rbUser.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.user_orange;
            _rbUser.Click += _rbUser_Click;

            _panelView = new RibbonPanel("View");
            _panelView.Items.Add(_rbWelcome);
            _panelView.Items.Add(_rbCalendar);
            _panelView.Items.Add(_rbUser);
            this.Panels.Add(_panelView);
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
        private void _rbUser_Click(object sender, System.EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("viewuser");
            OnAction(action);
        }
        #endregion
    }
}
