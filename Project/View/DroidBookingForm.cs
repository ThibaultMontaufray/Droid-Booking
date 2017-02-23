using System;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class DroidBookingForm : Form
    {
        #region Attribute
        private Interface_booking _intBoo;

        private Ribbon _ribbon;
        private RibbonButton _btn_open;
        private RibbonButton _btn_exit;
        #endregion

        #region Properties
        public Interface_booking IntBooking
        {
            get { return _intBoo; }
            set { _intBoo = value; }
        }
        #endregion

        #region Constructor
        public DroidBookingForm()
        {
            Tools4Libraries.Log.ApplicationAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\Droid-Booking";

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void ChangeLanguage()
        {
            _ribbon.OrbText = GetText.Text("File");
            _btn_open.Text = GetText.Text("Open");
            _btn_exit.Text   = GetText.Text("Exit");
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _intBoo = new Interface_booking();
            _intBoo.LanguageModified += _intBoo_LanguageModified;
            this.Controls.Add(_intBoo.Sheet);

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
            _ribbon.Tabs.Add(_intBoo.Tsm);

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
        private void _intBoo_LanguageModified()
        {
            ChangeLanguage();
        }
        private void B_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B_open_Click(object sender, EventArgs e)
        {
            _intBoo.Open(null);
        }
        #endregion
    }
}
