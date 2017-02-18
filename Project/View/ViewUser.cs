using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewUser : UserControl
    {
        #region Enum
        public enum Mode
        {
            EDIT,
            DETAIL,
            SEARCH
        }
        #endregion

        #region Attribute
        private Interface_booking _intBoo;
        private Mode _mode;
        private List<User> _filteredUsers;
        
        private System.ComponentModel.IContainer components = null;
        private DataGridView _dgvCalendar;
        private DataGridViewTextBoxColumn Month1;
        private DataGridViewTextBoxColumn Month2;
        private DataGridViewTextBoxColumn Month3;
        private DataGridViewTextBoxColumn Month4;
        private DataGridViewTextBoxColumn Month5;
        private Panel panel1;
        private ComboBox comboBoxGender;
        private ComboBox comboBoxCountry;
        private Button buttonValidation;
        private TextBox textBoxFamilyName;
        private TextBox textBoxId;
        private Label labelIdValue;
        private Label labelGenderValue;
        private Label labelId;
        private Label labelFamilynameValue;
        private Label labelCountry;
        private Label labelCountryValue;
        private Label labelGender;
        private TextBox textBoxFirstname;
        private PictureBox pictureBox1;
        private Label labelNameValue;
        private Label labelFamilyname;
        private Label labelFirstname;
        private Label labelNameTitle;
        private DataGridView _dgvSearchUser;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnFamilyName;
        private DataGridViewImageColumn ColumnGender;
        private DataGridViewTextBoxColumn ColumnCountry;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnMail;
        private DataGridViewTextBoxColumn ColumnComment;
        private DataGridViewImageColumn ColumnEdit;
        private DataGridViewImageColumn ColumnDelete;
        private FontDialog fontDialog1;
        private User _currentUser;
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
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        #endregion

        #region Constructor
        public ViewUser()
        {
            InitializeComponent();
            Init();
        }
        public ViewUser(Interface_booking intBoo)
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
                case Mode.DETAIL:
                    DisplayUserDetailView();
                    break;
                case Mode.SEARCH:
                    DisplayUserSearchingView();
                    break;
                case Mode.EDIT:
                    DisplayUserEditView();
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
            LoadGender();
            LoadCountries();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvCalendar = new System.Windows.Forms.DataGridView();
            this.Month1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.buttonValidation = new System.Windows.Forms.Button();
            this.textBoxFamilyName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelIdValue = new System.Windows.Forms.Label();
            this.labelGenderValue = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelFamilynameValue = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelCountryValue = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNameValue = new System.Windows.Forms.Label();
            this.labelFamilyname = new System.Windows.Forms.Label();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.labelNameTitle = new System.Windows.Forms.Label();
            this._dgvSearchUser = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGender = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCalendar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchUser)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvCalendar
            // 
            this._dgvCalendar.AllowUserToAddRows = false;
            this._dgvCalendar.AllowUserToDeleteRows = false;
            this._dgvCalendar.AllowUserToResizeColumns = false;
            this._dgvCalendar.AllowUserToResizeRows = false;
            this._dgvCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvCalendar.BackgroundColor = System.Drawing.Color.DimGray;
            this._dgvCalendar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this._dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Month1,
            this.Month2,
            this.Month3,
            this.Month4,
            this.Month5});
            this._dgvCalendar.Location = new System.Drawing.Point(0, 133);
            this._dgvCalendar.MultiSelect = false;
            this._dgvCalendar.Name = "_dgvCalendar";
            this._dgvCalendar.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvCalendar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.comboBoxGender);
            this.panel1.Controls.Add(this.comboBoxCountry);
            this.panel1.Controls.Add(this.buttonValidation);
            this.panel1.Controls.Add(this.textBoxFamilyName);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.labelIdValue);
            this.panel1.Controls.Add(this.labelGenderValue);
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.labelFamilynameValue);
            this.panel1.Controls.Add(this.labelCountry);
            this.panel1.Controls.Add(this.labelCountryValue);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.textBoxFirstname);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelNameValue);
            this.panel1.Controls.Add(this.labelFamilyname);
            this.panel1.Controls.Add(this.labelFirstname);
            this.panel1.Controls.Add(this.labelNameTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1434, 133);
            this.panel1.TabIndex = 23;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(231, 94);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(300, 27);
            this.comboBoxGender.TabIndex = 26;
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(625, 38);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(300, 27);
            this.comboBoxCountry.TabIndex = 25;
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
            this.buttonValidation.Click += new System.EventHandler(this.buttonValidation_Click);
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
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstname.Location = new System.Drawing.Point(231, 38);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(300, 27);
            this.textBoxFirstname.TabIndex = 11;
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
            // _dgvSearchUser
            // 
            this._dgvSearchUser.AllowUserToAddRows = false;
            this._dgvSearchUser.AllowUserToDeleteRows = false;
            this._dgvSearchUser.AllowUserToOrderColumns = true;
            this._dgvSearchUser.AllowUserToResizeRows = false;
            this._dgvSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvSearchUser.BackgroundColor = System.Drawing.Color.Gray;
            this._dgvSearchUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearchUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnFamilyName,
            this.ColumnGender,
            this.ColumnCountry,
            this.ColumnId,
            this.ColumnMail,
            this.ColumnComment,
            this.ColumnEdit,
            this.ColumnDelete});
            this._dgvSearchUser.Location = new System.Drawing.Point(0, 133);
            this._dgvSearchUser.Name = "_dgvSearchUser";
            this._dgvSearchUser.RowHeadersVisible = false;
            this._dgvSearchUser.Size = new System.Drawing.Size(1434, 374);
            this._dgvSearchUser.TabIndex = 24;
            this._dgvSearchUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvSearchUser_CellClick);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Firstname";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnFamilyName
            // 
            this.ColumnFamilyName.HeaderText = "Family name";
            this.ColumnFamilyName.Name = "ColumnFamilyName";
            // 
            // ColumnGender
            // 
            this.ColumnGender.HeaderText = "Gender";
            this.ColumnGender.Name = "ColumnGender";
            // 
            // ColumnCountry
            // 
            this.ColumnCountry.HeaderText = "Country";
            this.ColumnCountry.Name = "ColumnCountry";
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            // 
            // ColumnMail
            // 
            this.ColumnMail.HeaderText = "Mail";
            this.ColumnMail.Name = "ColumnMail";
            // 
            // ColumnComment
            // 
            this.ColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComment.HeaderText = "Comment";
            this.ColumnComment.Name = "ColumnComment";
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnEdit.HeaderText = "Edit";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnEdit.Width = 31;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDelete.HeaderText = "Delete";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDelete.Width = 44;
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
            ((System.ComponentModel.ISupportInitialize)(this._dgvCalendar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchUser)).EndInit();
            this.ResumeLayout(false);

        }
        private void LoadGender()
        {
            comboBoxGender.Items.Clear();
            comboBoxGender.Items.Add("All");
            foreach (var item in Enum.GetValues(typeof(User.GENDER)))
            {
                comboBoxGender.Items.Add(item.ToString());
            }
            comboBoxGender.Sorted = true;
        }
        private void LoadCountries()
        {
            comboBoxCountry.Items.Clear();
            comboBoxCountry.Items.Add("All");
            foreach (var item in _intBoo.Users)
            {
                if (!comboBoxCountry.Items.Contains(item.Country)) { comboBoxCountry.Items.Add(item.Country); }
            }
            comboBoxCountry.Sorted = true;
        }
        private void DisplayUserSearchingView()
        {
            if (!comboBoxGender.Items.Contains("All")) { comboBoxGender.Items.Add("All"); }
            comboBoxGender.SelectedItem = "All";

            this.Controls.Remove(this._dgvCalendar);
            this.Controls.Add(this._dgvSearchUser);

            textBoxFirstname.Visible = true;
            textBoxFamilyName.Visible = true;
            comboBoxCountry.Visible = true;
            comboBoxGender.Visible = true;
            textBoxId.Visible = true;

            labelCountryValue.Visible = false;
            labelFamilynameValue.Visible = false;
            labelIdValue.Visible = false;
            labelNameValue.Visible = false;
            labelGenderValue.Visible = false;

            buttonValidation.Text = "Search";
            buttonValidation.Visible = true;
        }
        private void DisplayUserDetailView()
        {
            if (comboBoxGender.Items.Contains("All")) { comboBoxGender.Items.Remove("All"); }

            this.Controls.Remove(this._dgvSearchUser);
            this.Controls.Add(this._dgvCalendar);

            textBoxFirstname.Visible = false;
            textBoxFamilyName.Visible = false;
            comboBoxCountry.Visible = false;
            comboBoxGender.Visible = false;
            textBoxId.Visible = false;

            labelCountryValue.Visible = true;
            labelFamilynameValue.Visible = true;
            labelIdValue.Visible = true;
            labelNameValue.Visible = true;
            labelGenderValue.Visible = true;
            
            buttonValidation.Visible = false;
        }
        private void DisplayUserEditView()
        {
            if (comboBoxGender.Items.Contains("All")) { comboBoxGender.Items.Remove("All"); }

            this.Controls.Remove(this._dgvSearchUser);
            this.Controls.Remove(this._dgvCalendar);

            textBoxFirstname.Visible = true;
            textBoxFamilyName.Visible = true;
            comboBoxCountry.Visible = true;
            comboBoxGender.Visible = true;
            textBoxId.Visible = true;

            labelCountryValue.Visible = false;
            labelFamilynameValue.Visible = false;
            labelIdValue.Visible = false;
            labelNameValue.Visible = false;
            labelGenderValue.Visible = false;

            buttonValidation.Text = "Save";
            buttonValidation.Visible = true;

            LoadUser();
        }
        private void ApplyButtonClick()
        {
            switch (_mode)
            {
                case Mode.EDIT:
                    AddUser();
                    break;
                case Mode.DETAIL:
                    DetailUser();
                    break;
                case Mode.SEARCH:
                    SearchUser();
                    break;
            }
        }
        private void SearchUser()
        {
            _filteredUsers = _intBoo.Users;

            if (!string.IsNullOrEmpty(textBoxFirstname.Text)) { _filteredUsers = _filteredUsers.Where(a => a.FirstName == textBoxFirstname.Text).ToList(); }
            if (!string.IsNullOrEmpty(textBoxFamilyName.Text)) { _filteredUsers = _filteredUsers.Where(a => a.FamilyName == textBoxFamilyName.Text).ToList(); }
            if (!string.IsNullOrEmpty(textBoxId.Text)) { _filteredUsers = _filteredUsers.Where(a => a.Id == textBoxId.Text).ToList(); }
            if (comboBoxGender.SelectedItem != null && comboBoxGender.SelectedItem.ToString() != "All") { _filteredUsers = _filteredUsers.Where(a => a.Gender == (User.GENDER)Enum.Parse(typeof(User.GENDER), comboBoxGender.SelectedItem.ToString())).ToList(); }
            if (comboBoxCountry.SelectedItem != null && comboBoxCountry.SelectedItem.ToString() != "All") { _filteredUsers = _filteredUsers.Where(a => a.Country == comboBoxCountry.SelectedItem.ToString()).ToList(); }

            LoadFilteredUsers();
        }
        private void AddUser()
        {

        }
        private void DetailUser()
        {

        }
        private void LoadFilteredUsers()
        {
            DataGridViewRow row;
            _dgvSearchUser.Rows.Clear();
            foreach (User user in _filteredUsers)
            {
                _dgvSearchUser.Rows.Add();
                row = _dgvSearchUser.Rows[_dgvSearchUser.Rows.Count - 1];
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnName)].Value = user.FirstName;
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnFamilyName)].Value = user.FamilyName;
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnId)].Value = user.Id;
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnCountry)].Value = user.Country;
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnComment)].Value = user.Comment;
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnMail)].Value = user.Mail;
                switch (user.Gender)
                {
                    case User.GENDER.MALE:
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.male;
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Tag = "MALE";
                        break;
                    case User.GENDER.FEMAL:
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.female;
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Tag = "FEMAL";
                        break;
                    case User.GENDER.OTHER:
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.rainbow;
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Tag = "OTHER";
                        break;
                    case User.GENDER.UNKNOW:
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.question;
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Tag = "UNKNOW";
                        break;
                    default:
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.question;
                        row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnGender)].Tag = "UNKNOW";
                        break;
                }
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnDelete)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnEdit)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.user_edit;
            }
        }
        private void DeleteUser(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this user ?", "Delete user", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DetectUser(rowIndex))
                {
                    _intBoo.Users.Remove(_currentUser);
                }
            }
        }
        private void EditUser(int rowIndex)
        {
            DetectUser(rowIndex);

            _mode = Mode.EDIT;
            RefreshDisplay();
        }
        private bool DetectUser(int rowIndex)
        {
            List<User> users = _intBoo.Users.Where(u => u.Id.Equals(_dgvSearchUser.Rows[rowIndex].Cells[ColumnId.Index].Value.ToString())).ToList();
            users = users.Where(u => u.Country.Equals(_dgvSearchUser.Rows[rowIndex].Cells[ColumnCountry.Index].Value.ToString())).ToList();

            if (users.Count == 0)
            {
                MessageBox.Show("This user has not be found", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (users.Count > 1)
            {
                MessageBox.Show("Too many users found for this Id and Country. Please change users settings.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                _currentUser = users[0];
                return true;
            }
        }
        private void LoadUser()
        {
            if (_currentUser != null)
            { 
                textBoxFamilyName.Text = _currentUser.FamilyName;
                textBoxFirstname.Text = _currentUser.FirstName;
                comboBoxCountry.Text = _currentUser.Country;
                comboBoxGender.Text = _currentUser.Gender.ToString();
                textBoxId.Text = _currentUser.Id;
            }
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
        private void buttonValidation_Click(object sender, EventArgs e)
        {
            ApplyButtonClick();
        }
        private void _dgvSearchUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDelete.Index)
            {
                DeleteUser(e.RowIndex);
            }
            else if (e.ColumnIndex == ColumnEdit.Index)
            {
                EditUser(e.RowIndex);
            }
        }
        #endregion
    }
}
