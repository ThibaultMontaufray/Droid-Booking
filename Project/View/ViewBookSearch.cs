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
    public partial class ViewBookSearch : UserControl
    {
        #region Attribute
        private Interface_booking _intBoo;
        private List<Area> _filterdArea;
        private Label labelUsers;
        private ComboBox comboBoxUsers;
        private ComboBox comboBox1;
        private Label labelArea;
        private DateTimePicker dateTimePickerStart;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerEnd;
        private CheckBox checkBoxConfirmedBook;
        private CheckBox checkBoxNonConfirmedBook;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownMinPrice;
        private NumericUpDown numericUpDownMaxPrice;
        private CheckBox checkBoxNonCompletedPaiement;
        private CheckBox checkBoxCopletedPaiements;
        private PanelShield panelShield1;
        private IContainer components = null;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewBookSearch()
        {
            InitializeComponent();
            InitializeComponentSpecialized();
            Init();
        }
        public ViewBookSearch(Interface_booking intBoo)
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
            //comboBoxArea.Items.Clear();
            //comboBoxArea.Items.Add("All");
            //foreach (var item in Enum.GetValues(typeof(Area.TYPE)))
            //{
            //    comboBoxType.Items.Add(item.ToString());
            //}
            //comboBoxType.Sorted = true;
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
            //numericUpDownFloor.Value = 999;
            //textBoxColor.BackColor = Color.FromName("Control");

            RefreshData();

            //_dgvSearch.Visible = _dgvSearch.Rows.Count != 0;
            //_dgvSearch.Height = (_dgvSearch.Rows.Count * 22) + _dgvSearch.ColumnHeadersHeight;
        }
        private void InitializeComponent()
        {
            this.labelUsers = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelArea = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxConfirmedBook = new System.Windows.Forms.CheckBox();
            this.checkBoxNonConfirmedBook = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMinPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.checkBoxNonCompletedPaiement = new System.Windows.Forms.CheckBox();
            this.checkBoxCopletedPaiements = new System.Windows.Forms.CheckBox();
            this.panelShield1 = new Droid_Booking.PanelShield();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsers.ForeColor = System.Drawing.Color.White;
            this.labelUsers.Location = new System.Drawing.Point(4, 7);
            this.labelUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(58, 19);
            this.labelUsers.TabIndex = 0;
            this.labelUsers.Text = "Users : ";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(103, 4);
            this.comboBoxUsers.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(272, 27);
            this.comboBoxUsers.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 33);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 27);
            this.comboBox1.TabIndex = 4;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.ForeColor = System.Drawing.Color.White;
            this.labelArea.Location = new System.Drawing.Point(4, 36);
            this.labelArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(51, 19);
            this.labelArea.TabIndex = 3;
            this.labelArea.Text = "Area : ";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(103, 62);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(272, 27);
            this.dateTimePickerStart.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start date : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "End date : ";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(103, 91);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(272, 27);
            this.dateTimePickerEnd.TabIndex = 8;
            // 
            // checkBoxConfirmedBook
            // 
            this.checkBoxConfirmedBook.AutoSize = true;
            this.checkBoxConfirmedBook.ForeColor = System.Drawing.Color.White;
            this.checkBoxConfirmedBook.Location = new System.Drawing.Point(400, 6);
            this.checkBoxConfirmedBook.Name = "checkBoxConfirmedBook";
            this.checkBoxConfirmedBook.Size = new System.Drawing.Size(211, 23);
            this.checkBoxConfirmedBook.TabIndex = 9;
            this.checkBoxConfirmedBook.Text = "Filter on confirmed bookings";
            this.checkBoxConfirmedBook.UseVisualStyleBackColor = true;
            // 
            // checkBoxNonConfirmedBook
            // 
            this.checkBoxNonConfirmedBook.AutoSize = true;
            this.checkBoxNonConfirmedBook.ForeColor = System.Drawing.Color.White;
            this.checkBoxNonConfirmedBook.Location = new System.Drawing.Point(400, 35);
            this.checkBoxNonConfirmedBook.Name = "checkBoxNonConfirmedBook";
            this.checkBoxNonConfirmedBook.Size = new System.Drawing.Size(239, 23);
            this.checkBoxNonConfirmedBook.TabIndex = 10;
            this.checkBoxNonConfirmedBook.Text = "Filter on non confirmed bookings";
            this.checkBoxNonConfirmedBook.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(691, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Min price : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(690, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Max price : ";
            // 
            // numericUpDownMinPrice
            // 
            this.numericUpDownMinPrice.Location = new System.Drawing.Point(782, 19);
            this.numericUpDownMinPrice.Name = "numericUpDownMinPrice";
            this.numericUpDownMinPrice.Size = new System.Drawing.Size(77, 27);
            this.numericUpDownMinPrice.TabIndex = 13;
            // 
            // numericUpDownMaxPrice
            // 
            this.numericUpDownMaxPrice.Location = new System.Drawing.Point(782, 67);
            this.numericUpDownMaxPrice.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownMaxPrice.Name = "numericUpDownMaxPrice";
            this.numericUpDownMaxPrice.Size = new System.Drawing.Size(77, 27);
            this.numericUpDownMaxPrice.TabIndex = 14;
            this.numericUpDownMaxPrice.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // checkBoxNonCompletedPaiement
            // 
            this.checkBoxNonCompletedPaiement.AutoSize = true;
            this.checkBoxNonCompletedPaiement.ForeColor = System.Drawing.Color.White;
            this.checkBoxNonCompletedPaiement.Location = new System.Drawing.Point(400, 93);
            this.checkBoxNonCompletedPaiement.Name = "checkBoxNonCompletedPaiement";
            this.checkBoxNonCompletedPaiement.Size = new System.Drawing.Size(253, 23);
            this.checkBoxNonCompletedPaiement.TabIndex = 16;
            this.checkBoxNonCompletedPaiement.Text = "Filter on non completed paiements";
            this.checkBoxNonCompletedPaiement.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopletedPaiements
            // 
            this.checkBoxCopletedPaiements.AutoSize = true;
            this.checkBoxCopletedPaiements.ForeColor = System.Drawing.Color.White;
            this.checkBoxCopletedPaiements.Location = new System.Drawing.Point(400, 67);
            this.checkBoxCopletedPaiements.Name = "checkBoxCopletedPaiements";
            this.checkBoxCopletedPaiements.Size = new System.Drawing.Size(225, 23);
            this.checkBoxCopletedPaiements.TabIndex = 15;
            this.checkBoxCopletedPaiements.Text = "Filter on completed paiements";
            this.checkBoxCopletedPaiements.UseVisualStyleBackColor = true;
            // 
            // panelShield1
            // 
            this.panelShield1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
            this.panelShield1.Location = new System.Drawing.Point(10, 10);
            this.panelShield1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panelShield1.Name = "panelShield1";
            this.panelShield1.Size = new System.Drawing.Size(900, 170);
            this.panelShield1.TabIndex = 27;
            // 
            // ViewBookSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelShield1);
            this.Controls.Add(this.checkBoxNonCompletedPaiement);
            this.Controls.Add(this.checkBoxCopletedPaiements);
            this.Controls.Add(this.numericUpDownMaxPrice);
            this.Controls.Add(this.numericUpDownMinPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxNonConfirmedBook);
            this.Controls.Add(this.checkBoxConfirmedBook);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.labelUsers);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewBookSearch";
            this.Size = new System.Drawing.Size(920, 364);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitializeComponentSpecialized()
        {
            panelShield1.panelMiddle.Controls.Add(this.checkBoxNonCompletedPaiement);
            panelShield1.panelMiddle.Controls.Add(this.checkBoxCopletedPaiements);
            panelShield1.panelMiddle.Controls.Add(this.numericUpDownMaxPrice);
            panelShield1.panelMiddle.Controls.Add(this.numericUpDownMinPrice);
            panelShield1.panelMiddle.Controls.Add(this.label4);
            panelShield1.panelMiddle.Controls.Add(this.label3);
            panelShield1.panelMiddle.Controls.Add(this.checkBoxNonConfirmedBook);
            panelShield1.panelMiddle.Controls.Add(this.checkBoxConfirmedBook);
            panelShield1.panelMiddle.Controls.Add(this.dateTimePickerEnd);
            panelShield1.panelMiddle.Controls.Add(this.label2);
            panelShield1.panelMiddle.Controls.Add(this.label1);
            panelShield1.panelMiddle.Controls.Add(this.dateTimePickerStart);
            panelShield1.panelMiddle.Controls.Add(this.comboBox1);
            panelShield1.panelMiddle.Controls.Add(this.labelArea);
            panelShield1.panelMiddle.Controls.Add(this.comboBoxUsers);
            panelShield1.panelMiddle.Controls.Add(this.labelUsers);
        }
        private void SearchArea()
        {
            //_filterdArea = _intBoo.Areas;

            //if (numericUpDownCapacity.Value != -1) { _filterdArea = _filterdArea.Where(a => a.Capacity == (int)numericUpDownCapacity.Value).ToList(); }
            //if (numericUpDownFloor.Value != 999) { _filterdArea = _filterdArea.Where(a => a.Floor == (int)numericUpDownFloor.Value).ToList(); }
            //if (!string.IsNullOrEmpty(textBoxName.Text)) { _filterdArea = _filterdArea.Where(a => a.Name == textBoxName.Text).ToList(); }
            //if (comboBoxType.SelectedItem != null && comboBoxType.SelectedItem.ToString() != "All") { _filterdArea = _filterdArea.Where(a => a.Type == (Area.TYPE)Enum.Parse(typeof(Area.TYPE), comboBoxType.SelectedItem.ToString())).ToList(); }
            //if (textBoxColor.BackColor != Color.FromName("Control")) { _filterdArea = _filterdArea.Where(a => a.Color == textBoxColor.BackColor).ToList(); }

            //LoadFilteredAreas();

            //_dgvSearch.Visible = _dgvSearch.Rows.Count != 0;
            //_dgvSearch.Height = (_dgvSearch.Rows.Count * 22) + _dgvSearch.ColumnHeadersHeight;
        }
        private void LoadFilteredAreas()
        {
            //DataGridViewRow row;
            //_dgvSearch.Rows.Clear();
            //if (_filterdArea != null)
            //{ 
            //    foreach (Area area in _filterdArea)
            //    {
            //        _dgvSearch.Rows.Add();
            //        row = _dgvSearch.Rows[_dgvSearch.Rows.Count - 1];
            //        row.Cells[_dgvSearch.Columns.IndexOf(ColumnName)].Value = area.Name;
            //        row.Cells[_dgvSearch.Columns.IndexOf(ColumnType)].Value = area.Type;
            //        row.Cells[_dgvSearch.Columns.IndexOf(ColumnFloor)].Value = area.Floor;
            //        row.Cells[_dgvSearch.Columns.IndexOf(ColumnCapacity)].Value = area.Capacity;
            //        row.Cells[_dgvSearch.Columns.IndexOf(ColumnComment)].Value = area.Comment;
            //        (row.Cells[_dgvSearch.Columns.IndexOf(ColumnColor)] as DataGridViewButtonCell).Style.BackColor = area.Color;
            //    }
            //}
        }
        #endregion

        #region Event
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
        #endregion
    }
}
