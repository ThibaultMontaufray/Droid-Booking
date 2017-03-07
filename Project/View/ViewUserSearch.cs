using Droid_People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public delegate void ViewUserEventHandler(object o);
    public class ViewUserSearch : UserControl, IView
    {
        #region Attribute
        public event ViewUserEventHandler RequestUserDetail;
        public event ViewUserEventHandler RequestUserEdition;

        private readonly DataGridViewCellStyle cellStyle1 = new DataGridViewCellStyle() { BackColor = System.Drawing.Color.DarkGray };
        private readonly DataGridViewCellStyle cellStyle2 = new DataGridViewCellStyle() { BackColor = System.Drawing.Color.LightGray };
        private Interface_booking _intBoo;
        private List<Person> _filteredUsers;
        
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxGender;
        private ComboBox comboBoxNationality;
        private Button buttonValidation;
        private TextBox textBoxFamilyName;
        private TextBox textBoxId;
        private Label labelId;
        private Label labelNationality;
        private Label labelGender;
        private TextBox textBoxFirstname;
        private PictureBox pictureBox1;
        private Label labelFamilyname;
        private Label labelFirstname;
        private DataGridView _dgvSearchPerson;
        private FontDialog fontDialog1;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnFamilyName;
        private DataGridViewImageColumn ColumnGender;
        private DataGridViewTextBoxColumn ColumnNationality;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnMail;
        private DataGridViewTextBoxColumn ColumnComment;
        private DataGridViewImageColumn ColumnEdit;
        private DataGridViewImageColumn ColumnDelete;
        private DataGridViewImageColumn ColumnDetail;
        private PanelCustom panelUserSearch;
        private Person _currentPerson;
        #endregion

        #region Properties
        public Person CurrentUser
        {
            get { return _currentPerson; }
            set { _currentPerson = value; }
        }
        #endregion

        #region Constructor
        public ViewUserSearch()
        {
            InitializeComponent();
            InitializeComponentSpecial();
            Init();
        }
        public ViewUserSearch(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            InitializeComponentSpecial();
            Init();
        }
        #endregion

        #region Methods public
        public  void ChangeLanguage()
        {
            ColumnName.HeaderText = GetText.Text("Firstname");
            ColumnFamilyName.HeaderText = GetText.Text("Name");
            ColumnGender.HeaderText = GetText.Text("Gender");
            ColumnId.HeaderText = GetText.Text("Id");
            ColumnNationality.HeaderText = GetText.Text("Nationality");
            ColumnMail.HeaderText = GetText.Text("Mail");
            ColumnComment.HeaderText = GetText.Text("Comment");

            labelId.Text = GetText.Text("Id") + " : ";
            labelNationality.Text = GetText.Text("Nationality") + " : ";
            labelGender.Text = GetText.Text("Gender") + " : ";
            labelFamilyname.Text = GetText.Text("FamilyName") + " : ";
            labelFirstname.Text = GetText.Text("FirstName") + " : ";
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
            DataGridViewRow row;
            for (int i = 1; i < 32; i++)
            {
                row = new DataGridViewRow();
                row.HeaderCell.Value = i.ToString();
            }
            LoadGender();
            LoadCountries();

            _dgvSearchPerson.Visible = _dgvSearchPerson.Rows.Count != 0;
            _dgvSearchPerson.Height = (_dgvSearchPerson.Rows.Count * 22) + _dgvSearchPerson.ColumnHeadersHeight;
            ChangeLanguage();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUserSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this._dgvSearchPerson = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGender = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDetail = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.comboBoxNationality = new System.Windows.Forms.ComboBox();
            this.buttonValidation = new System.Windows.Forms.Button();
            this.textBoxFamilyName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelNationality = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelFamilyname = new System.Windows.Forms.Label();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.panelUserSearch = new PanelCustom();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvSearchUser
            // 
            this._dgvSearchPerson.AllowUserToAddRows = false;
            this._dgvSearchPerson.AllowUserToDeleteRows = false;
            this._dgvSearchPerson.AllowUserToOrderColumns = true;
            this._dgvSearchPerson.AllowUserToResizeRows = false;
            this._dgvSearchPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvSearchPerson.BackgroundColor = System.Drawing.Color.Gray;
            this._dgvSearchPerson.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvSearchPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvSearchPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearchPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnFamilyName,
            this.ColumnGender,
            this.ColumnNationality,
            this.ColumnId,
            this.ColumnMail,
            this.ColumnComment,
            this.ColumnDetail,
            this.ColumnEdit,
            this.ColumnDelete});
            this._dgvSearchPerson.Location = new System.Drawing.Point(46, 198);
            this._dgvSearchPerson.MultiSelect = false;
            this._dgvSearchPerson.Name = "_dgvSearchUser";
            this._dgvSearchPerson.RowHeadersVisible = false;
            this._dgvSearchPerson.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._dgvSearchPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvSearchPerson.Size = new System.Drawing.Size(1397, 277);
            this._dgvSearchPerson.TabIndex = 24;
            this._dgvSearchPerson.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvSearchUser_CellClick);
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnName.HeaderText = "Firstname";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 98;
            // 
            // ColumnFamilyName
            // 
            this.ColumnFamilyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnFamilyName.HeaderText = "Name";
            this.ColumnFamilyName.Name = "ColumnFamilyName";
            this.ColumnFamilyName.Width = 72;
            // 
            // ColumnGender
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            this.ColumnGender.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnGender.HeaderText = "Gender";
            this.ColumnGender.Name = "ColumnGender";
            // 
            // ColumnNationality
            // 
            this.ColumnNationality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnNationality.HeaderText = "Nationality";
            this.ColumnNationality.Name = "ColumnNationality";
            this.ColumnNationality.Width = 84;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Width = 46;
            // 
            // ColumnMail
            // 
            this.ColumnMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMail.HeaderText = "Mail";
            this.ColumnMail.Name = "ColumnMail";
            this.ColumnMail.Width = 63;
            // 
            // ColumnComment
            // 
            this.ColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComment.HeaderText = "Comment";
            this.ColumnComment.Name = "ColumnComment";
            // 
            // ColumnDetail
            // 
            this.ColumnDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDetail.HeaderText = "";
            this.ColumnDetail.Name = "ColumnDetail";
            this.ColumnDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDetail.Width = 19;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle7.NullValue")));
            this.ColumnEdit.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnEdit.Width = 5;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle8.NullValue")));
            this.ColumnDelete.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDelete.Width = 5;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(258, 77);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(280, 27);
            this.comboBoxGender.TabIndex = 26;
            // 
            // comboBoxNationality
            // 
            this.comboBoxNationality.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNationality.FormattingEnabled = true;
            this.comboBoxNationality.Location = new System.Drawing.Point(632, 21);
            this.comboBoxNationality.Name = "comboBoxNationality";
            this.comboBoxNationality.Size = new System.Drawing.Size(300, 27);
            this.comboBoxNationality.TabIndex = 25;
            // 
            // buttonValidation
            // 
            this.buttonValidation.Font = new System.Drawing.Font("Calibri", 11F);
            this.buttonValidation.Location = new System.Drawing.Point(857, 82);
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
            this.textBoxFamilyName.Location = new System.Drawing.Point(258, 49);
            this.textBoxFamilyName.Name = "textBoxFamilyName";
            this.textBoxFamilyName.Size = new System.Drawing.Size(280, 27);
            this.textBoxFamilyName.TabIndex = 19;
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxId.Location = new System.Drawing.Point(632, 49);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(300, 27);
            this.textBoxId.TabIndex = 18;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.ForeColor = System.Drawing.Color.White;
            this.labelId.Location = new System.Drawing.Point(555, 52);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(35, 19);
            this.labelId.TabIndex = 15;
            this.labelId.Text = "Id : ";
            // 
            // labelNationality
            // 
            this.labelNationality.AutoSize = true;
            this.labelNationality.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNationality.ForeColor = System.Drawing.Color.White;
            this.labelNationality.Location = new System.Drawing.Point(555, 24);
            this.labelNationality.Name = "labelNationality";
            this.labelNationality.Size = new System.Drawing.Size(71, 19);
            this.labelNationality.TabIndex = 8;
            this.labelNationality.Text = "Nationality : ";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.ForeColor = System.Drawing.Color.White;
            this.labelGender.Location = new System.Drawing.Point(129, 80);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(68, 19);
            this.labelGender.TabIndex = 6;
            this.labelGender.Text = "Gender : ";
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstname.Location = new System.Drawing.Point(258, 21);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(280, 27);
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
            // labelFamilyname
            // 
            this.labelFamilyname.AutoSize = true;
            this.labelFamilyname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFamilyname.ForeColor = System.Drawing.Color.White;
            this.labelFamilyname.Location = new System.Drawing.Point(129, 52);
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
            this.labelFirstname.Location = new System.Drawing.Point(129, 24);
            this.labelFirstname.Name = "labelFirstname";
            this.labelFirstname.Size = new System.Drawing.Size(85, 19);
            this.labelFirstname.TabIndex = 2;
            this.labelFirstname.Text = "Firstname : ";
            // 
            // panelUserSearch
            // 
            this.panelUserSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserSearch.BackColor = System.Drawing.Color.Transparent;
            this.panelUserSearch.Location = new System.Drawing.Point(10, 10);
            this.panelUserSearch.Margin = new System.Windows.Forms.Padding(5);
            this.panelUserSearch.Name = "panelUserSearch";
            this.panelUserSearch.Size = new System.Drawing.Size(1500, 165);
            this.panelUserSearch.TabIndex = 27;
            // 
            // ViewUserSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelUserSearch);
            this.Controls.Add(this._dgvSearchPerson);
            this.Name = "ViewUserSearch";
            this.Size = new System.Drawing.Size(1520, 500);
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitializeComponentSpecial()
        {
            this.panelUserSearch.panelMiddle.Controls.Add(pictureBox1);
            this.panelUserSearch.panelMiddle.Controls.Add(labelFirstname);
            this.panelUserSearch.panelMiddle.Controls.Add(labelFamilyname);
            this.panelUserSearch.panelMiddle.Controls.Add(labelGender);
            this.panelUserSearch.panelMiddle.Controls.Add(labelId);
            this.panelUserSearch.panelMiddle.Controls.Add(labelNationality);
            this.panelUserSearch.panelMiddle.Controls.Add(comboBoxNationality);
            this.panelUserSearch.panelMiddle.Controls.Add(comboBoxGender);
            this.panelUserSearch.panelMiddle.Controls.Add(textBoxFamilyName);
            this.panelUserSearch.panelMiddle.Controls.Add(textBoxFirstname);
            this.panelUserSearch.panelMiddle.Controls.Add(textBoxId);
            this.panelUserSearch.panelMiddle.Controls.Add(buttonValidation);
            this.panelUserSearch.Size = new System.Drawing.Size(1480, 174);
        }
        private void LoadGender()
        {
            comboBoxGender.Items.Clear();
            comboBoxGender.Items.Add("All");
            foreach (var item in Enum.GetValues(typeof(Person.GENDER)))
            {
                comboBoxGender.Items.Add(item.ToString());
            }
            comboBoxGender.Sorted = true;
        }
        private void LoadCountries()
        {
            comboBoxNationality.Items.Clear();
            comboBoxNationality.Items.Add("All");
            foreach (var item in _intBoo.Persons)
            {
                if (!comboBoxNationality.Items.Contains(item.Nationality)) { comboBoxNationality.Items.Add(item.Nationality); }
            }
            comboBoxNationality.Sorted = true;
        }
        private void SearchUser()
        {
            _filteredUsers = _intBoo.Persons;

            if (!string.IsNullOrEmpty(textBoxFirstname.Text)) { _filteredUsers = _filteredUsers.Where(a => a.FirstName.Firstname == textBoxFirstname.Text).ToList(); }
            if (!string.IsNullOrEmpty(textBoxFamilyName.Text)) { _filteredUsers = _filteredUsers.Where(a => a.FamilyName == textBoxFamilyName.Text).ToList(); }
            if (!string.IsNullOrEmpty(textBoxId.Text)) { _filteredUsers = _filteredUsers.Where(a => a.Id == textBoxId.Text).ToList(); }
            if (comboBoxGender.SelectedItem != null && comboBoxGender.SelectedItem.ToString() != "All") { _filteredUsers = _filteredUsers.Where(a => a.Gender == (Person.GENDER)Enum.Parse(typeof(Person.GENDER), comboBoxGender.SelectedItem.ToString())).ToList(); }
            if (comboBoxNationality.SelectedItem != null && comboBoxNationality.SelectedItem.ToString() != "All") { _filteredUsers = _filteredUsers.Where(a => a.Nationality == comboBoxNationality.SelectedItem.ToString()).ToList(); }

            LoadFilteredUsers();
            _dgvSearchPerson.Visible = _dgvSearchPerson.Rows.Count != 0;
            _dgvSearchPerson.Height = (_dgvSearchPerson.Rows.Count * 22) + _dgvSearchPerson.ColumnHeadersHeight;
        }
        private void LoadFilteredUsers()
        {
            bool altenate = true;
            DataGridViewRow row;
            _dgvSearchPerson.Rows.Clear();
            foreach (Person user in _filteredUsers)
            {
                altenate = !altenate;
                _dgvSearchPerson.Rows.Add();
                row = _dgvSearchPerson.Rows[_dgvSearchPerson.Rows.Count - 1];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style = altenate ? cellStyle1 : cellStyle2;
                    cell.Style.SelectionBackColor = System.Drawing.Color.DimGray;
                }
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnName)].Value = user.FirstName;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnFamilyName)].Value = user.FamilyName;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnId)].Value = user.Id;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnNationality)].Value = user.Nationality;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnComment)].Value = user.Comment;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnMail)].Value = user.Mail;
                switch (user.Gender)
                {
                    case Person.GENDER.MALE:
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.male;
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Tag = "MALE";
                        break;
                    case Person.GENDER.FEMAL:
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.female;
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Tag = "FEMAL";
                        break;
                    case Person.GENDER.OTHER:
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.rainbow;
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Tag = "OTHER";
                        break;
                    case Person.GENDER.UNKNOW:
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.question;
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Tag = "UNKNOW";
                        break;
                    default:
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.question;
                        row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnGender)].Tag = "UNKNOW";
                        break;
                }
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnDetail)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.report_user;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnDelete)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                row.Cells[_dgvSearchPerson.Columns.IndexOf(ColumnEdit)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.user_edit;
            }
        }
        private void DeleteUser(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this user ?", "Delete user", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DetectUser(rowIndex))
                {
                    _intBoo.Persons.Remove(_currentPerson);
                }
            }
        }
        private void EditUser(int rowIndex)
        {
            DetectUser(rowIndex);
            RequestUserEdition(_currentPerson);
        }
        private void DetailUser(int rowIndex)
        {
            DetectUser(rowIndex);
            RequestUserDetail(_currentPerson);
        }
        private bool DetectUser(int rowIndex)
        {
            List<Person> users = _intBoo.Persons.Where(u => u.Id.Equals(_dgvSearchPerson.Rows[rowIndex].Cells[ColumnId.Index].Value.ToString())).ToList();
            users = users.Where(u => u.Nationality.Equals(_dgvSearchPerson.Rows[rowIndex].Cells[ColumnNationality.Index].Value.ToString())).ToList();

            if (users.Count == 0)
            {
                MessageBox.Show("This user has not be found", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (users.Count > 1)
            {
                MessageBox.Show("Too many users found for this Id and Nationality. Please change users settings.", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                _currentPerson = users[0];
                return true;
            }
        }
        private void LoadUser()
        {
            if (_currentPerson != null)
            { 
                textBoxFamilyName.Text = _currentPerson.FamilyName;
                textBoxFirstname.Text = _currentPerson.FirstName.Firstname;
                comboBoxNationality.Text = _currentPerson.Nationality;
                comboBoxGender.Text = _currentPerson.Gender.ToString();
                textBoxId.Text = _currentPerson.Id;
            }
        }
        #endregion

        #region Event
        private void buttonValidation_Click(object sender, EventArgs e)
        {
            SearchUser();
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
            else if (e.ColumnIndex == ColumnDetail.Index)
            {
                DetailUser(e.RowIndex);
            }
        }
        #endregion
    }
}
