using System;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public class Interface_booking : GPInterface
    {
        #region Attribtue
        private Panel _sheet;
        private ToolStripMenuBooking _tsm;
        #endregion

        #region Properties
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
                case "buttonclic":
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
        }
        #endregion
    }
}
