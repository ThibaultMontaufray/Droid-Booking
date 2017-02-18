using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewWelcome : UserControl
    {
        #region Attribute
        private Interface_booking _intBoo;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewWelcome()
        {
            InitializeComponent();
        }
        public ViewWelcome(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
