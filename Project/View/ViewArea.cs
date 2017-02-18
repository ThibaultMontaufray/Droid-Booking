using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewArea : UserControl
    {
        #region Enum
        public enum Mode
        {
            SEARCH,
            ADD
        }
        #endregion

        #region Attribute
        private Mode _mode;
        #endregion

        #region Properties
        public Mode ModeView
        {
            get { return _mode; }
            set
            {
                _mode = value;
                RefreshDisplay();
            }
        }
        #endregion

        #region Constructor
        public ViewArea()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void RefreshDisplay()
        {
            switch (_mode)
            {
                case Mode.SEARCH:
                    DisplayAreaSearchView();
                    break;
                case Mode.ADD:
                    DisplayAreaAddView();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _mode = Mode.SEARCH;

            comboBoxType.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(Area.TYPE)))
            {
                comboBoxType.Items.Add(item.ToString());
            }
        }
        private void DisplayAreaSearchView()
        {
            _dgvSearch.Visible = true;
            buttonValidation.Text = "Seach";
        }
        private void DisplayAreaAddView()
        {
            _dgvSearch.Visible = false;
            buttonValidation.Text = "Add";
        }
        #endregion

        #region Event
        private void buttonColorChoose_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxColor.BackColor = colorDialog1.Color;
            }
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
