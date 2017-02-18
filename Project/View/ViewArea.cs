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
        private Interface_booking _intBoo;
        private Mode _mode;
        private List<Area> _filterdArea;
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
        public ViewArea(Interface_booking intBoo)
        {
            _intBoo = intBoo;

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
            numericUpDownFloor.Value = 999;
            textBoxColor.BackColor = Color.FromName("Control");

            comboBoxType.Items.Clear();
            comboBoxType.Items.Add("All");
            foreach (var item in Enum.GetValues(typeof(Area.TYPE)))
            {
                comboBoxType.Items.Add(item.ToString());
            }
            comboBoxType.Sorted = true;
        }
        private void DisplayAreaSearchView()
        {
            if (!comboBoxType.Items.Contains("All")) { comboBoxType.Items.Add("All"); }
            _dgvSearch.Visible = true;
            buttonValidation.Text = "Seach";
        }
        private void DisplayAreaAddView()
        {
            if (comboBoxType.Items.Contains("All")) { comboBoxType.Items.Remove("All"); }
            _dgvSearch.Visible = false;
            buttonValidation.Text = "Add";
        }
        private void ApplyButtonClick()
        {
            switch (_mode)
            {
                case Mode.SEARCH:
                    SearchArea();
                    break;
                case Mode.ADD:
                    AddArea();
                    break;
            }
        }
        private void SearchArea()
        {
            _filterdArea = _intBoo.Areas;

            if (numericUpDownCapacity.Value != -1) { _filterdArea = _filterdArea.Where(a => a.Capacity == (int)numericUpDownCapacity.Value).ToList(); }
            if (numericUpDownFloor.Value != 999) { _filterdArea = _filterdArea.Where(a => a.Floor == (int)numericUpDownFloor.Value).ToList(); }
            if (!string.IsNullOrEmpty(textBoxName.Text)) { _filterdArea = _filterdArea.Where(a => a.Name == textBoxName.Text).ToList(); }
            if (comboBoxType.SelectedItem != null && comboBoxType.SelectedItem.ToString() != "All") { _filterdArea = _filterdArea.Where(a => a.Type == (Area.TYPE)Enum.Parse(typeof(Area.TYPE), comboBoxType.SelectedItem.ToString())).ToList(); }
            if (textBoxColor.BackColor != Color.FromName("Control")) { _filterdArea = _filterdArea.Where(a => a.Color == textBoxColor.BackColor).ToList(); }

            LoadFilteredAreas();
        }
        private void AddArea()
        {
            bool allDataCorrect = true;
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                allDataCorrect = false;
                textBoxName.BackColor = Color.LightYellow;
            }
            else
            {
                textBoxName.BackColor = Color.FromName("Control");
            }
            if (comboBoxType.SelectedItem != null)
            {
                allDataCorrect = false;
                comboBoxType.BackColor = Color.LightYellow;
            }
            else
            {
                comboBoxType.BackColor = Color.FromName("Control");
            }

            if (allDataCorrect)
            { 
                Area a = new Area();
                a.Capacity = (int) numericUpDownCapacity.Value;
                a.Floor = (int)numericUpDownFloor.Value;
                a.Name = textBoxName.Text;
                a.Type = (Area.TYPE) Enum.Parse(typeof(Area.TYPE), comboBoxType.SelectedItem.ToString());
                a.Color = textBoxColor.BackColor;

                _intBoo.Areas.Add(a);
            }
        }
        private void LoadFilteredAreas()
        {
            DataGridViewRow row;
            _dgvSearch.Rows.Clear();
            if (_filterdArea != null)
            { 
                foreach (Area area in _filterdArea)
                {
                    _dgvSearch.Rows.Add();
                    row = _dgvSearch.Rows[_dgvSearch.Rows.Count - 1];
                    row.Cells[_dgvSearch.Columns.IndexOf(ColumnName)].Value = area.Name;
                    row.Cells[_dgvSearch.Columns.IndexOf(ColumnType)].Value = area.Type;
                    row.Cells[_dgvSearch.Columns.IndexOf(ColumnFloor)].Value = area.Floor;
                    row.Cells[_dgvSearch.Columns.IndexOf(ColumnCapacity)].Value = area.Capacity;
                    row.Cells[_dgvSearch.Columns.IndexOf(ColumnComment)].Value = area.Comment;
                    (row.Cells[_dgvSearch.Columns.IndexOf(ColumnColor)] as DataGridViewButtonCell).Style.BackColor = area.Color;
                }
            }
        }
        #endregion

        #region Event
        private void buttonColorChoose_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxColor.BackColor = colorDialog1.Color;
                textBoxColor.Text = colorDialog1.Color.Name;
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
        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyButtonClick();
        }
        private void TextBoxColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxColor.Text))
                {
                    textBoxColor.BackColor = Color.FromName("Control");
                }
                else
                { 
                    Color col = Color.FromName(textBoxColor.Text);
                    textBoxColor.BackColor = col;
                }
            }
            catch (Exception)
            {
                textBoxColor.BackColor = Color.FromName("Control");
                textBoxColor.Text = string.Empty;
            }
        }
        #endregion
    }
}
