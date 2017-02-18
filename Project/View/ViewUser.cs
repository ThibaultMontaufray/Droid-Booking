using System;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewUser : UserControl
    {
        #region Enum
        public enum Mode
        {
            ADD,
            DETAIL,
            SEARCH
        }
        #endregion

        #region Attribute
        private Mode _mode;
        
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBox1;
        private Label labelNameTitle;
        private Label labelFirstname;
        private Label labelNameValue;
        private Label labelFamilyname;
        private Label labelFamilynameValue;
        private Label labelGender;
        private Label labelGenderValue;
        private Panel panel1;
        private DataGridView _dgvCalendar;
        private Label labelCountry;
        private Label labelCountryValue;
        private TextBox textBoxName;
        private Label labelId;
        private TextBox textBoxCountry;
        private Label labelIdValue;
        private TextBox textBoxGender;
        private TextBox textBoxFamilyName;
        private TextBox textBoxId;
        private DataGridViewTextBoxColumn Month1;
        private DataGridViewTextBoxColumn Month2;
        private DataGridViewTextBoxColumn Month3;
        private DataGridViewTextBoxColumn Month4;
        private DataGridViewTextBoxColumn Month5;
        private Button buttonValidation;
        private DataGridView _dgvSearchUser;
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
        public ViewUser()
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
                case Mode.DETAIL:
                    DisplayUserDetailView();
                    break;
                case Mode.SEARCH:
                    DisplayUserSearchingView();
                    break;
                case Mode.ADD:
                    DisplayUserAddView();
                    break;
                default:
                    break;
            }
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
            _mode = Mode.SEARCH;
            DataGridViewRow row;
            _dgvCalendar.Rows.Clear();
            for (int i = 1; i < 32; i++)
            {
                row = new DataGridViewRow();
                row.HeaderCell.Value = i.ToString();
                _dgvCalendar.Rows.Add(row);
            }
            this.Controls.Add(this._dgvCalendar);
            RefreshDisplay();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNameTitle = new System.Windows.Forms.Label();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.labelNameValue = new System.Windows.Forms.Label();
            this.labelFamilyname = new System.Windows.Forms.Label();
            this.labelFamilynameValue = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelGenderValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonValidation = new System.Windows.Forms.Button();
            this.textBoxGender = new System.Windows.Forms.TextBox();
            this.textBoxFamilyName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelIdValue = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelCountryValue = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this._dgvCalendar = new System.Windows.Forms.DataGridView();
            this.Month1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dgvSearchUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Droid_Booking.Properties.Resources.shadow_man;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // labelNameTitle
            // 
            this.labelNameTitle.AutoSize = true;
            this.labelNameTitle.BackColor = System.Drawing.Color.Maroon;
            this.labelNameTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameTitle.ForeColor = System.Drawing.Color.White;
            this.labelNameTitle.Location = new System.Drawing.Point(122, 12);
            this.labelNameTitle.Name = "labelNameTitle";
            this.labelNameTitle.Size = new System.Drawing.Size(57, 23);
            this.labelNameTitle.TabIndex = 1;
            this.labelNameTitle.Text = "Name";
            // 
            // labelFirstname
            // 
            this.labelFirstname.AutoSize = true;
            this.labelFirstname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstname.ForeColor = System.Drawing.Color.White;
            this.labelFirstname.Location = new System.Drawing.Point(122, 41);
            this.labelFirstname.Name = "labelFirstname";
            this.labelFirstname.Size = new System.Drawing.Size(85, 19);
            this.labelFirstname.TabIndex = 2;
            this.labelFirstname.Text = "Firstname : ";
            // 
            // labelNameValue
            // 
            this.labelNameValue.AutoSize = true;
            this.labelNameValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameValue.ForeColor = System.Drawing.Color.White;
            this.labelNameValue.Location = new System.Drawing.Point(231, 38);
            this.labelNameValue.Name = "labelNameValue";
            this.labelNameValue.Size = new System.Drawing.Size(65, 19);
            this.labelNameValue.TabIndex = 3;
            this.labelNameValue.Text = "_______";
            // 
            // labelFamilyname
            // 
            this.labelFamilyname.AutoSize = true;
            this.labelFamilyname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFamilyname.ForeColor = System.Drawing.Color.White;
            this.labelFamilyname.Location = new System.Drawing.Point(122, 69);
            this.labelFamilyname.Name = "labelFamilyname";
            this.labelFamilyname.Size = new System.Drawing.Size(103, 19);
            this.labelFamilyname.TabIndex = 4;
            this.labelFamilyname.Text = "Family name : ";
            // 
            // labelFamilynameValue
            // 
            this.labelFamilynameValue.AutoSize = true;
            this.labelFamilynameValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFamilynameValue.ForeColor = System.Drawing.Color.White;
            this.labelFamilynameValue.Location = new System.Drawing.Point(231, 69);
            this.labelFamilynameValue.Name = "labelFamilynameValue";
            this.labelFamilynameValue.Size = new System.Drawing.Size(65, 19);
            this.labelFamilynameValue.TabIndex = 5;
            this.labelFamilynameValue.Text = "_______";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.ForeColor = System.Drawing.Color.White;
            this.labelGender.Location = new System.Drawing.Point(122, 97);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(68, 19);
            this.labelGender.TabIndex = 6;
            this.labelGender.Text = "Gender : ";
            // 
            // labelGenderValue
            // 
            this.labelGenderValue.AutoSize = true;
            this.labelGenderValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenderValue.ForeColor = System.Drawing.Color.White;
            this.labelGenderValue.Location = new System.Drawing.Point(231, 102);
            this.labelGenderValue.Name = "labelGenderValue";
            this.labelGenderValue.Size = new System.Drawing.Size(65, 19);
            this.labelGenderValue.TabIndex = 7;
            this.labelGenderValue.Text = "_______";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.buttonValidation);
            this.panel1.Controls.Add(this.textBoxGender);
            this.panel1.Controls.Add(this.textBoxFamilyName);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.labelIdValue);
            this.panel1.Controls.Add(this.labelGenderValue);
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.labelFamilynameValue);
            this.panel1.Controls.Add(this.textBoxCountry);
            this.panel1.Controls.Add(this.labelCountry);
            this.panel1.Controls.Add(this.labelCountryValue);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelNameValue);
            this.panel1.Controls.Add(this.labelFamilyname);
            this.panel1.Controls.Add(this.labelFirstname);
            this.panel1.Controls.Add(this.labelNameTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1434, 133);
            this.panel1.TabIndex = 9;
            // 
            // buttonValidation
            // 
            this.buttonValidation.Font = new System.Drawing.Font("Calibri", 11F);
            this.buttonValidation.Location = new System.Drawing.Point(850, 99);
            this.buttonValidation.Name = "buttonValidation";
            this.buttonValidation.Size = new System.Drawing.Size(75, 27);
            this.buttonValidation.TabIndex = 21;
            this.buttonValidation.Text = "Search";
            this.buttonValidation.UseVisualStyleBackColor = true;
            this.buttonValidation.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxGender
            // 
            this.textBoxGender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGender.Location = new System.Drawing.Point(231, 94);
            this.textBoxGender.Name = "textBoxGender";
            this.textBoxGender.Size = new System.Drawing.Size(300, 27);
            this.textBoxGender.TabIndex = 20;
            // 
            // textBoxFamilyName
            // 
            this.textBoxFamilyName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFamilyName.Location = new System.Drawing.Point(231, 66);
            this.textBoxFamilyName.Name = "textBoxFamilyName";
            this.textBoxFamilyName.Size = new System.Drawing.Size(300, 27);
            this.textBoxFamilyName.TabIndex = 19;
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxId.Location = new System.Drawing.Point(625, 66);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(300, 27);
            this.textBoxId.TabIndex = 18;
            // 
            // labelIdValue
            // 
            this.labelIdValue.AutoSize = true;
            this.labelIdValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdValue.ForeColor = System.Drawing.Color.White;
            this.labelIdValue.Location = new System.Drawing.Point(625, 69);
            this.labelIdValue.Name = "labelIdValue";
            this.labelIdValue.Size = new System.Drawing.Size(65, 19);
            this.labelIdValue.TabIndex = 11;
            this.labelIdValue.Text = "_______";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.ForeColor = System.Drawing.Color.White;
            this.labelId.Location = new System.Drawing.Point(548, 69);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(35, 19);
            this.labelId.TabIndex = 15;
            this.labelId.Text = "ID : ";
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCountry.Location = new System.Drawing.Point(625, 38);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(300, 27);
            this.textBoxCountry.TabIndex = 14;
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountry.ForeColor = System.Drawing.Color.White;
            this.labelCountry.Location = new System.Drawing.Point(548, 41);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(71, 19);
            this.labelCountry.TabIndex = 8;
            this.labelCountry.Text = "Country : ";
            // 
            // labelCountryValue
            // 
            this.labelCountryValue.AutoSize = true;
            this.labelCountryValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountryValue.ForeColor = System.Drawing.Color.White;
            this.labelCountryValue.Location = new System.Drawing.Point(625, 41);
            this.labelCountryValue.Name = "labelCountryValue";
            this.labelCountryValue.Size = new System.Drawing.Size(65, 19);
            this.labelCountryValue.TabIndex = 9;
            this.labelCountryValue.Text = "_______";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(231, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(300, 27);
            this.textBoxName.TabIndex = 11;
            // 
            // _dgvCalendar
            // 
            this._dgvCalendar.AllowUserToAddRows = false;
            this._dgvCalendar.AllowUserToDeleteRows = false;
            this._dgvCalendar.AllowUserToResizeColumns = false;
            this._dgvCalendar.AllowUserToResizeRows = false;
            this._dgvCalendar.BackgroundColor = System.Drawing.Color.DimGray;
            this._dgvCalendar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this._dgvCalendar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvCalendar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Month1,
            this.Month2,
            this.Month3,
            this.Month4,
            this.Month5});
            this._dgvCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvCalendar.Location = new System.Drawing.Point(0, 133);
            this._dgvCalendar.MultiSelect = false;
            this._dgvCalendar.Name = "_dgvCalendar";
            this._dgvCalendar.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvCalendar.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvCalendar.RowHeadersWidth = 76;
            this._dgvCalendar.Size = new System.Drawing.Size(1434, 374);
            this._dgvCalendar.TabIndex = 10;
            // 
            // Month1
            // 
            this.Month1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Month1.HeaderText = "ColumnMonth1";
            this.Month1.Name = "Month1";
            this.Month1.ReadOnly = true;
            this.Month1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Month2
            // 
            this.Month2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Month2.HeaderText = "ColumnMonth2";
            this.Month2.Name = "Month2";
            this.Month2.ReadOnly = true;
            // 
            // Month3
            // 
            this.Month3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Month3.HeaderText = "ColumnMonth3";
            this.Month3.Name = "Month3";
            this.Month3.ReadOnly = true;
            // 
            // Month4
            // 
            this.Month4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Month4.HeaderText = "ColumnMonth4";
            this.Month4.Name = "Month4";
            this.Month4.ReadOnly = true;
            // 
            // Month5
            // 
            this.Month5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Month5.HeaderText = "ColumnMonth5";
            this.Month5.Name = "Month5";
            this.Month5.ReadOnly = true;
            // 
            // _dgvSearchUser
            // 
            this._dgvSearchUser.BackgroundColor = System.Drawing.Color.DimGray;
            this._dgvSearchUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearchUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvSearchUser.Location = new System.Drawing.Point(0, 133);
            this._dgvSearchUser.Name = "_dgvSearchUser";
            this._dgvSearchUser.Size = new System.Drawing.Size(1434, 374);
            this._dgvSearchUser.TabIndex = 21;
            // 
            // ViewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this._dgvSearchUser);
            this.Controls.Add(this.panel1);
            this.Name = "ViewUser";
            this.Size = new System.Drawing.Size(1434, 507);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchUser)).EndInit();
            this.ResumeLayout(false);

        }
        private void DisplayUserSearchingView()
        {
            this.Controls.Remove(this._dgvCalendar);
            this.Controls.Add(this._dgvSearchUser);

            textBoxName.Visible = true;
            textBoxFamilyName.Visible = true;
            textBoxGender.Visible = true;
            textBoxCountry.Visible = true;
            textBoxId.Visible = true;

            labelCountryValue.Visible = false;
            labelFamilynameValue.Visible = false;
            labelIdValue.Visible = false;
            labelNameValue.Visible = false;
            labelGenderValue.Visible = false;

            buttonValidation.Text = "Search";
        }
        private void DisplayUserDetailView()
        {
            this.Controls.Remove(this._dgvSearchUser);
            this.Controls.Add(this._dgvCalendar);

            textBoxName.Visible = false;
            textBoxFamilyName.Visible = false;
            textBoxGender.Visible = false;
            textBoxCountry.Visible = false;
            textBoxId.Visible = false;

            labelCountryValue.Visible = true;
            labelFamilynameValue.Visible = true;
            labelIdValue.Visible = true;
            labelNameValue.Visible = true;
            labelGenderValue.Visible = true;

            buttonValidation.Text = "Save";
        }
        private void DisplayUserAddView()
        {
            this.Controls.Remove(this._dgvSearchUser);
            this.Controls.Remove(this._dgvCalendar);

            textBoxName.Visible = true;
            textBoxFamilyName.Visible = true;
            textBoxGender.Visible = true;
            textBoxCountry.Visible = true;
            textBoxId.Visible = true;

            labelCountryValue.Visible = false;
            labelFamilynameValue.Visible = false;
            labelIdValue.Visible = false;
            labelNameValue.Visible = false;
            labelGenderValue.Visible = false;

            buttonValidation.Text = "Add";
        }
        #endregion

        #region Event
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (_mode == Mode.DETAIL) { Cursor = Cursors.Hand; }
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (_mode == Mode.DETAIL) { Cursor = Cursors.Arrow; }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
