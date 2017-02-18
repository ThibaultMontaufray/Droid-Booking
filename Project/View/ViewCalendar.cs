using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewCalendar : UserControl
    {
        #region Attribute
        private Interface_booking _intBoo;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewCalendar()
        {
            InitializeComponent();
        }
        public ViewCalendar(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
