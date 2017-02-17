using System;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class DroidBookingForm : Form
    {
        #region Attribute
        private Interface_booking _intRes;

        private Ribbon _ribbon;
        private RibbonButton _btn_open;
        private RibbonButton _btn_exit;
        #endregion

        #region Properties
        public Interface_booking IntBooking
        {
            get { return _intRes; }
            set { _intRes = value; }
        }
        #endregion

        #region Constructor
        public DroidBookingForm()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void Init()
        {
            _intRes = new Interface_booking();
            this.Controls.Add(_intRes.Sheet);

            BuildRibbon();
        }
        private void BuildRibbon()
        {
            _ribbon = new Ribbon();
            _ribbon.Height = 150;
            _ribbon.ThemeColor = RibbonTheme.Black;
            _ribbon.OrbDropDown.Width = 150;
            _ribbon.OrbStyle = RibbonOrbStyle.Office_2013;
            _ribbon.OrbText = GetText.Text("File");
            _ribbon.QuickAccessToolbar.MenuButtonVisible = false;
            _ribbon.QuickAccessToolbar.Visible = false;
            _ribbon.QuickAccessToolbar.MinSizeMode = RibbonElementSizeMode.Compact;
            _ribbon.Tabs.Add(_intRes.Tsm);

            _btn_open = new RibbonButton(GetText.Text("Open"));
            _btn_open.Image = Tools4Libraries.Resources.ResourceIconSet32Default.open_folder;
            _btn_open.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.open_folder;
            _btn_open.Click += B_open_Click;
            _ribbon.OrbDropDown.MenuItems.Add(_btn_open);
            
            _btn_exit = new RibbonButton(GetText.Text("Exit"));
            _btn_exit.Image = Tools4Libraries.Resources.ResourceIconSet32Default.door_out;
            _btn_exit.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.door_out;
            _btn_exit.Click += B_exit_Click;
            _ribbon.OrbDropDown.MenuItems.Add(_btn_exit);

            _ribbon.OrbDropDown.Width = 700;
            this.Controls.Add(_ribbon);
        }
        #endregion

        #region Event
        private void B_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B_open_Click(object sender, EventArgs e)
        {
            _intRes.Open(null);
        }
        #endregion
    }
}
