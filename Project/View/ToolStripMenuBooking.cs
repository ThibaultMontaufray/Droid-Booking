using System;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.Booking
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

        //private RibbonPanel _panelPerson;
        //private RibbonButton _rbUserAdd;
        //private RibbonButton _rbUserSearch;

        private RibbonPanel _panelArea;
        private RibbonButton _rbAreaAdd;
        private RibbonButton _rbAreaSearch;
        private RibbonButton _rb_importArea;
        private RibbonButton _rb_exportArea;
        private RibbonButton _exportAreaCsv;
        private RibbonButton _exportAreaJson;
        private RibbonButton _exportAreaXml;

        private RibbonPanel _panelbooking;
        private RibbonButton _rbBookAdd;
        private RibbonButton _rbBookSearch;
        private RibbonButton _rb_importBooking;
        private RibbonButton _rb_exportBooking;
        private RibbonButton _exportBookingCsv;
        private RibbonButton _exportBookingJson;
        private RibbonButton _exportBookingXml;
        private RibbonButton _exportBookingICAL;
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
            //_rbUserAdd.Text = GetText.Text("Useradd");
            //_rbUserSearch.Text = GetText.Text("Searchuser");
            //_panelPerson.Text = GetText.Text("User");
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
            //BuildPanelUsers();
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
            _rbCheckIn.Image = Tools4Libraries.Resources.ResourceIconSet32Default.document_import;
            _rbCheckIn.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.document_import;
            _rbCheckIn.Click += _rbCheckIn_Click;

            _rbCheckOut = new RibbonButton("Today's check out");
            _rbCheckOut.Image = Tools4Libraries.Resources.ResourceIconSet32Default.document_export;
            _rbCheckOut.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.document_export;
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

            _exportAreaCsv = new RibbonButton();
            _exportAreaCsv.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.export_excel;
            _exportAreaCsv.Text = "CSV";
            _exportAreaCsv.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportAreaCsv.Click += _exportAreaCsv_Click;

            _exportAreaJson = new RibbonButton();
            _exportAreaJson.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.page_white_text;
            _exportAreaJson.Text = "JSON";
            _exportAreaJson.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportAreaJson.Click += _exportAreaJson_Click;

            _exportAreaXml = new RibbonButton();
            _exportAreaXml.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.page_white_code;
            _exportAreaXml.Text = "XML";
            _exportAreaXml.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportAreaXml.Click += _exportAreaXml_Click;
            
            _rb_exportArea = new RibbonButton();
            _rb_exportArea.Text = "Export";
            _rb_exportArea.Image = Tools4Libraries.Resources.ResourceIconSet32Default.document_export;
            _rb_exportArea.MinSizeMode = RibbonElementSizeMode.Large;
            _rb_exportArea.MaxSizeMode = RibbonElementSizeMode.Large;
            _rb_exportArea.Style = RibbonButtonStyle.SplitDropDown;
            _rb_exportArea.DropDownItems.Add(_exportAreaJson);
            _rb_exportArea.DropDownItems.Add(_exportAreaCsv);
            _rb_exportArea.DropDownItems.Add(_exportAreaXml);
            _rb_exportArea.TextAlignment = RibbonItem.RibbonItemTextAlignment.Left;

            _rb_importArea = new RibbonButton("Import");
            _rb_importArea.Image = Tools4Libraries.Resources.ResourceIconSet32Default.document_export;
            _rb_importArea.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.document_export;
            _rb_importArea.Click += _rb_importArea_Click;

            _panelArea = new RibbonPanel("Area");
            _panelArea.Items.Add(_rbAreaAdd);
            _panelArea.Items.Add(_rbAreaSearch);
            _panelArea.Items.Add(_rb_importArea);
            _panelArea.Items.Add(_rb_exportArea);
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

            _exportBookingCsv = new RibbonButton();
            _exportBookingCsv.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.file_extension_csv;
            _exportBookingCsv.Text = "CSV";
            _exportBookingCsv.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportBookingCsv.Click += _exportBookingCsv_Click;
                   
            _exportBookingJson = new RibbonButton();
            _exportBookingJson.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.page_white_text;
            _exportBookingJson.Text = "JSON";
            _exportBookingJson.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportBookingJson.Click += _exportBookingJson_Click;

            _exportBookingXml = new RibbonButton();
            _exportBookingXml.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.page_white_code;
            _exportBookingXml.Text = "XML";
            _exportBookingXml.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportBookingXml.Click += _exportBookingXml_Click;

            _exportBookingICAL = new RibbonButton();
            _exportBookingICAL.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.calendar;
            _exportBookingICAL.Text = "ICal";
            _exportBookingICAL.MinSizeMode = RibbonElementSizeMode.Medium;
            _exportBookingICAL.Click += _exportBookingICal_Click;

            _rb_exportBooking = new RibbonButton();
            _rb_exportBooking.Text = "Export";
            _rb_exportBooking.Image = Tools4Libraries.Resources.ResourceIconSet32Default.document_export;
            _rb_exportBooking.MinSizeMode = RibbonElementSizeMode.Large;
            _rb_exportBooking.MaxSizeMode = RibbonElementSizeMode.Large;
            _rb_exportBooking.Style = RibbonButtonStyle.SplitDropDown;
            _rb_exportBooking.DropDownItems.Add(_exportBookingCsv);
            _rb_exportBooking.DropDownItems.Add(_exportBookingJson);
            _rb_exportBooking.DropDownItems.Add(_exportBookingXml);
            _rb_exportBooking.DropDownItems.Add(_exportBookingICAL);
            _rb_exportBooking.TextAlignment = RibbonItem.RibbonItemTextAlignment.Left;

            _rb_importBooking = new RibbonButton("Import");
            _rb_importBooking.Image = Tools4Libraries.Resources.ResourceIconSet32Default.document_import;
            _rb_importBooking.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.document_import;
            _rb_importBooking.Click += _rb_importBooking_Click;

            _panelbooking = new RibbonPanel("Book");
            _panelbooking.Items.Add(_rbBookAdd);
            _panelbooking.Items.Add(_rbBookSearch);
            _panelbooking.Items.Add(_rb_importBooking);
            _panelbooking.Items.Add(_rb_exportBooking);
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
        //private void _rbUserAdd_Click(object sender, System.EventArgs e)
        //{
        //    ToolBarEventArgs action = new ToolBarEventArgs("viewuseradd");
        //    OnAction(action);
        //}
        //private void _rbUserSearch_Click(object sender, System.EventArgs e)
        //{
        //    ToolBarEventArgs action = new ToolBarEventArgs("viewusersearch");
        //    OnAction(action);
        //}
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
        private void _exportAreaCsv_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportAreaCsv");
            OnAction(action);
        }
        private void _exportAreaXml_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportAreaXml");
            OnAction(action);
        }
        private void _exportAreaJson_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportAreaJson");
            OnAction(action);
        }
        private void _exportBookingCsv_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportBookingCsv");
            OnAction(action);
        }
        private void _exportBookingXml_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportBookingXml");
            OnAction(action);
        }
        private void _exportBookingJson_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportBookingJson");
            OnAction(action);
        }
        private void _exportBookingICal_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("exportBookingICal");
            OnAction(action);
        }
        private void _rb_importBooking_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("importBooking");
            OnAction(action);
        }
        private void _rb_importArea_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("importArea");
            OnAction(action);
        }
        #endregion
    }
}
