using System.Windows.Forms;

namespace Droid_Booking
{
    public class ViewPrice : UserControl, IView
    {
        #region Attribute
        private Interface_booking _intBoo;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewPrice()
        {
            Init();
        }
        public ViewPrice(Interface_booking intBoo)
        {
            _intBoo = intBoo;
            Init();
        }
        #endregion

        #region Methods public
        public void ChangeLanguage()
        {

        }
        public void RefreshData()
        {

        }
        #endregion

        #region Methods private
        private void Init()
        {

        }
        #endregion

        #region Event
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ViewPrice
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "ViewPrice";
            this.Size = new System.Drawing.Size(900, 400);
            this.ResumeLayout(false);

        }
    }
}
