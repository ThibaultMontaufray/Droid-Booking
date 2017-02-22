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
    public partial class ViewAreaSearch : ViewApplication
    {
        #region Attribute
        private Interface_booking _intBoo;
        private List<Area> _filterdArea;
        
        private IContainer components = null;
        private Label labelName;
        private Label labelColor;
        private TextBox textBoxName;
        private TextBox textBoxColor;
        private ColorDialog colorDialog1;
        private RibbonColorChooser ribbonColorChooser1;
        private RibbonColorChooser ribbonColorChooser2;
        private Button buttonColorChoose;
        private Label labelCapacity;
        private NumericUpDown numericUpDownCapacity;
        private Label labelFloor;
        private Label labelType;
        private NumericUpDown numericUpDownFloor;
        private DataGridView _dgvSearch;
        private Button buttonValidation;
        private ComboBox comboBoxType;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewButtonColumn ColumnColor;
        private DataGridViewTextBoxColumn ColumnFloor;
        private DataGridViewTextBoxColumn ColumnCapacity;
        private DataGridViewTextBoxColumn ColumnType;
        private DataGridViewTextBoxColumn ColumnComment;
        private PanelShield panelShield1;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewAreaSearch()
        {
            InitializeComponent();
            InitializeComponentSpecialized();
            Init();
        }
        public ViewAreaSearch(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            InitializeComponentSpecialized();
            Init();
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.Add("All");
            foreach (var item in Enum.GetValues(typeof(Area.TYPE)))
            {
                comboBoxType.Items.Add(item.ToString());
            }
            comboBoxType.Sorted = true;
        }
        #endregion

        #region Methods protected
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods private
        private void Init()
        {
            numericUpDownFloor.Value = 999;
            textBoxColor.BackColor = Color.FromName("Control");

            RefreshData();

            _dgvSearch.Visible = _dgvSearch.Rows.Count != 0;
            _dgvSearch.Height = (_dgvSearch.Rows.Count * 22) + _dgvSearch.ColumnHeadersHeight;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAreaSearch));
            this.labelName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ribbonColorChooser1 = new System.Windows.Forms.RibbonColorChooser();
            this.ribbonColorChooser2 = new System.Windows.Forms.RibbonColorChooser();
            this.buttonColorChoose = new System.Windows.Forms.Button();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.labelFloor = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.numericUpDownFloor = new System.Windows.Forms.NumericUpDown();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonValidation = new System.Windows.Forms.Button();
            this._dgvSearch = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnFloor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelShield1 = new Droid_Booking.PanelShield();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(-4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 19);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name : ";
            // 
            // labelColor
            // 
            this.labelColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.ForeColor = System.Drawing.Color.White;
            this.labelColor.Location = new System.Drawing.Point(433, 0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(55, 19);
            this.labelColor.TabIndex = 4;
            this.labelColor.Text = "Color : ";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(61, -3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(357, 27);
            this.textBoxName.TabIndex = 12;
            // 
            // textBoxColor
            // 
            this.textBoxColor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxColor.Location = new System.Drawing.Point(494, -3);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(213, 27);
            this.textBoxColor.TabIndex = 13;
            // 
            // ribbonColorChooser1
            // 
            this.ribbonColorChooser1.Color = System.Drawing.Color.Transparent;
            this.ribbonColorChooser1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser1.Image")));
            this.ribbonColorChooser1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser1.LargeImage")));
            this.ribbonColorChooser1.Name = "ribbonColorChooser1";
            this.ribbonColorChooser1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser1.SmallImage")));
            // 
            // ribbonColorChooser2
            // 
            this.ribbonColorChooser2.Color = System.Drawing.Color.Transparent;
            this.ribbonColorChooser2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser2.Image")));
            this.ribbonColorChooser2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser2.LargeImage")));
            this.ribbonColorChooser2.Name = "ribbonColorChooser2";
            this.ribbonColorChooser2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser2.SmallImage")));
            // 
            // buttonColorChoose
            // 
            this.buttonColorChoose.Font = new System.Drawing.Font("Calibri", 11F);
            this.buttonColorChoose.Location = new System.Drawing.Point(708, -3);
            this.buttonColorChoose.Name = "buttonColorChoose";
            this.buttonColorChoose.Size = new System.Drawing.Size(76, 27);
            this.buttonColorChoose.TabIndex = 14;
            this.buttonColorChoose.Text = "choose";
            this.buttonColorChoose.UseVisualStyleBackColor = true;
            this.buttonColorChoose.Click += new System.EventHandler(this.buttonColorChoose_Click);
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCapacity.ForeColor = System.Drawing.Color.White;
            this.labelCapacity.Location = new System.Drawing.Point(-4, 29);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(77, 19);
            this.labelCapacity.TabIndex = 15;
            this.labelCapacity.Text = "Capacity : ";
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCapacity.Location = new System.Drawing.Point(95, 27);
            this.numericUpDownCapacity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(105, 27);
            this.numericUpDownCapacity.TabIndex = 16;
            this.numericUpDownCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // labelFloor
            // 
            this.labelFloor.AutoSize = true;
            this.labelFloor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFloor.ForeColor = System.Drawing.Color.White;
            this.labelFloor.Location = new System.Drawing.Point(228, 29);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(53, 19);
            this.labelFloor.TabIndex = 17;
            this.labelFloor.Text = "Floor : ";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.White;
            this.labelType.Location = new System.Drawing.Point(433, 29);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(51, 19);
            this.labelType.TabIndex = 19;
            this.labelType.Text = "Type : ";
            // 
            // numericUpDownFloor
            // 
            this.numericUpDownFloor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFloor.Location = new System.Drawing.Point(313, 27);
            this.numericUpDownFloor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFloor.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownFloor.Name = "numericUpDownFloor";
            this.numericUpDownFloor.Size = new System.Drawing.Size(105, 27);
            this.numericUpDownFloor.TabIndex = 21;
            this.numericUpDownFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxType
            // 
            this.comboBoxType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(494, 25);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(290, 27);
            this.comboBoxType.TabIndex = 24;
            // 
            // buttonValidation
            // 
            this.buttonValidation.Font = new System.Drawing.Font("Calibri", 11F);
            this.buttonValidation.Location = new System.Drawing.Point(709, 53);
            this.buttonValidation.Name = "buttonValidation";
            this.buttonValidation.Size = new System.Drawing.Size(75, 27);
            this.buttonValidation.TabIndex = 23;
            this.buttonValidation.Text = "Search";
            this.buttonValidation.UseVisualStyleBackColor = true;
            this.buttonValidation.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // _dgvSearch
            // 
            this._dgvSearch.AllowUserToAddRows = false;
            this._dgvSearch.AllowUserToDeleteRows = false;
            this._dgvSearch.AllowUserToResizeRows = false;
            this._dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnColor,
            this.ColumnFloor,
            this.ColumnCapacity,
            this.ColumnType,
            this.ColumnComment});
            this._dgvSearch.Location = new System.Drawing.Point(42, 156);
            this._dgvSearch.Name = "_dgvSearch";
            this._dgvSearch.RowHeadersVisible = false;
            this._dgvSearch.Size = new System.Drawing.Size(1198, 128);
            this._dgvSearch.TabIndex = 25;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnColor
            // 
            this.ColumnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnColor.HeaderText = "Color";
            this.ColumnColor.Name = "ColumnColor";
            // 
            // ColumnFloor
            // 
            this.ColumnFloor.HeaderText = "Floor";
            this.ColumnFloor.Name = "ColumnFloor";
            // 
            // ColumnCapacity
            // 
            this.ColumnCapacity.HeaderText = "Capacity";
            this.ColumnCapacity.Name = "ColumnCapacity";
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            // 
            // ColumnComment
            // 
            this.ColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComment.HeaderText = "Comment";
            this.ColumnComment.Name = "ColumnComment";
            // 
            // panelShield1
            // 
            this.panelShield1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
            this.panelShield1.Location = new System.Drawing.Point(10, 10);
            this.panelShield1.Name = "panelShield1";
            this.panelShield1.Size = new System.Drawing.Size(1260, 140);
            this.panelShield1.TabIndex = 26;
            // 
            // ViewArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelShield1);
            this.Controls.Add(this._dgvSearch);
            this.Name = "ViewArea";
            this.Size = new System.Drawing.Size(1280, 456);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).EndInit();
            this.ResumeLayout(false);

        }
        private void InitializeComponentSpecialized()
        {
            panelShield1.panelMiddle.Controls.Add(this.comboBoxType);
            panelShield1.panelMiddle.Controls.Add(this.buttonValidation);
            panelShield1.panelMiddle.Controls.Add(this.labelName);
            panelShield1.panelMiddle.Controls.Add(this.textBoxColor);
            panelShield1.panelMiddle.Controls.Add(this.labelColor);
            panelShield1.panelMiddle.Controls.Add(this.numericUpDownCapacity);
            panelShield1.panelMiddle.Controls.Add(this.numericUpDownFloor);
            panelShield1.panelMiddle.Controls.Add(this.labelCapacity);
            panelShield1.panelMiddle.Controls.Add(this.textBoxName);
            panelShield1.panelMiddle.Controls.Add(this.labelFloor);
            panelShield1.panelMiddle.Controls.Add(this.buttonColorChoose);
            panelShield1.panelMiddle.Controls.Add(this.labelType);
        }
        private void DisplayAreaAddView()
        {
            if (comboBoxType.Items.Contains("All")) { comboBoxType.Items.Remove("All"); }
            _dgvSearch.Visible = false;
            buttonValidation.Text = "Add";
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

            _dgvSearch.Visible = _dgvSearch.Rows.Count != 0;
            _dgvSearch.Height = (_dgvSearch.Rows.Count * 22) + _dgvSearch.ColumnHeadersHeight;
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
            SearchArea();
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
