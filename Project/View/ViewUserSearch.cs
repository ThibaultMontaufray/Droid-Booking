using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Droid_Booking
{
    public delegate void ViewUserEventHandler(object o);
    public partial class ViewUserSearch : UserControl
    {
        #region Attribute
        public event ViewUserEventHandler RequestUserDetail;

        private readonly DataGridViewCellStyle cellStyle1 = new DataGridViewCellStyle() { BackColor = System.Drawing.Color.DarkGray };
        private readonly DataGridViewCellStyle cellStyle2 = new DataGridViewCellStyle() { BackColor = System.Drawing.Color.LightGray };
        private Interface_booking _intBoo;
        private List<User> _filteredUsers;
        
        private System.ComponentModel.IContainer components = null;
        private PanelShield panelUserSearch;
        private ComboBox comboBoxGender;
        private ComboBox comboBoxCountry;
        private Button buttonValidation;
        private TextBox textBoxFamilyName;
        private TextBox textBoxId;
        private Label labelId;
        private Label labelCountry;
        private Label labelGender;
        private TextBox textBoxFirstname;
        private PictureBox pictureBox1;
        private Label labelFamilyname;
        private Label labelFirstname;
        private Label labelNameTitle;
        private DataGridView _dgvSearchUser;
        private FontDialog fontDialog1;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnFamilyName;
        private DataGridViewImageColumn ColumnGender;
        private DataGridViewTextBoxColumn ColumnCountry;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnMail;
        private DataGridViewTextBoxColumn ColumnComment;
        private DataGridViewImageColumn ColumnEdit;
        private DataGridViewImageColumn ColumnDelete;
        private DataGridViewImageColumn ColumnDetail;
        private User _currentUser;
        #endregion

        #region Properties
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
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

            _dgvSearchUser.Visible = _dgvSearchUser.Rows.Count != 0;
            _dgvSearchUser.Height = (_dgvSearchUser.Rows.Count * 22) + _dgvSearchUser.ColumnHeadersHeight;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUserSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this._dgvSearchUser = new System.Windows.Forms.DataGridView();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.buttonValidation = new System.Windows.Forms.Button();
            this.textBoxFamilyName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelFamilyname = new System.Windows.Forms.Label();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.labelNameTitle = new System.Windows.Forms.Label();
            this.panelUserSearch = new Droid_Booking.PanelShield();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGender = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDetail = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvSearchUser
            // 
            this._dgvSearchUser.AllowUserToAddRows = false;
            this._dgvSearchUser.AllowUserToDeleteRows = false;
            this._dgvSearchUser.AllowUserToOrderColumns = true;
            this._dgvSearchUser.AllowUserToResizeRows = false;
            this._dgvSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvSearchUser.BackgroundColor = System.Drawing.Color.Gray;
            this._dgvSearchUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvSearchUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvSearchUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearchUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnFamilyName,
            this.ColumnGender,
            this.ColumnCountry,
            this.ColumnId,
            this.ColumnMail,
            this.ColumnComment,
            this.ColumnDetail,
            this.ColumnEdit,
            this.ColumnDelete});
            this._dgvSearchUser.Location = new System.Drawing.Point(46, 198);
            this._dgvSearchUser.MultiSelect = false;
            this._dgvSearchUser.Name = "_dgvSearchUser";
            this._dgvSearchUser.RowHeadersVisible = false;
            this._dgvSearchUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._dgvSearchUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvSearchUser.Size = new System.Drawing.Size(1397, 277);
            this._dgvSearchUser.TabIndex = 24;
            this._dgvSearchUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvSearchUser_CellClick);
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
            // panelUserSearch
            // 
            this.panelUserSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserSearch.BackColor = System.Drawing.Color.Transparent;
            this.panelUserSearch.Location = new System.Drawing.Point(10, 10);
            this.panelUserSearch.Margin = new System.Windows.Forms.Padding(5);
            this.panelUserSearch.Name = "panelUserSearch";
            this.panelUserSearch.Size = new System.Drawing.Size(1480, 165);
            this.panelUserSearch.TabIndex = 23;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.ColumnGender.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnGender.HeaderText = "Gender";
            this.ColumnGender.Name = "ColumnGender";
            // 
            // ColumnCountry
            // 
            this.ColumnCountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnCountry.HeaderText = "Country";
            this.ColumnCountry.Name = "ColumnCountry";
            this.ColumnCountry.Width = 84;
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
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.ColumnEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnEdit.Width = 5;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            this.ColumnDelete.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDelete.Width = 5;
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
            // ViewUserSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._dgvSearchUser);
            this.Controls.Add(this.panelUserSearch);
            this.Name = "ViewUserSearch";
            this.Size = new System.Drawing.Size(1500, 500);
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearchUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        private void InitializeComponentSpecial()
        {
            this.panelUserSearch.panelMiddle.Controls.Add(pictureBox1);
            this.panelUserSearch.panelMiddle.Controls.Add(labelFirstname);
            this.panelUserSearch.panelMiddle.Controls.Add(labelFamilyname);
            this.panelUserSearch.panelMiddle.Controls.Add(labelGender);
            this.panelUserSearch.panelMiddle.Controls.Add(labelId);
            this.panelUserSearch.panelMiddle.Controls.Add(labelCountry);
            this.panelUserSearch.panelMiddle.Controls.Add(labelNameTitle);
            this.panelUserSearch.panelMiddle.Controls.Add(comboBoxCountry);
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
        private void SearchUser()
        {
            _filteredUsers = _intBoo.Users;

            if (!string.IsNullOrEmpty(textBoxFirstname.Text)) { _filteredUsers = _filteredUsers.Where(a => a.FirstName == textBoxFirstname.Text).ToList(); }
            if (!string.IsNullOrEmpty(textBoxFamilyName.Text)) { _filteredUsers = _filteredUsers.Where(a => a.FamilyName == textBoxFamilyName.Text).ToList(); }
            if (!string.IsNullOrEmpty(textBoxId.Text)) { _filteredUsers = _filteredUsers.Where(a => a.Id == textBoxId.Text).ToList(); }
            if (comboBoxGender.SelectedItem != null && comboBoxGender.SelectedItem.ToString() != "All") { _filteredUsers = _filteredUsers.Where(a => a.Gender == (User.GENDER)Enum.Parse(typeof(User.GENDER), comboBoxGender.SelectedItem.ToString())).ToList(); }
            if (comboBoxCountry.SelectedItem != null && comboBoxCountry.SelectedItem.ToString() != "All") { _filteredUsers = _filteredUsers.Where(a => a.Country == comboBoxCountry.SelectedItem.ToString()).ToList(); }

            LoadFilteredUsers();
            _dgvSearchUser.Visible = _dgvSearchUser.Rows.Count != 0;
            _dgvSearchUser.Height = (_dgvSearchUser.Rows.Count * 22) + _dgvSearchUser.ColumnHeadersHeight;
        }
        private void LoadFilteredUsers()
        {
            bool altenate = true;
            DataGridViewRow row;
            _dgvSearchUser.Rows.Clear();
            foreach (User user in _filteredUsers)
            {
                altenate = !altenate;
                _dgvSearchUser.Rows.Add();
                row = _dgvSearchUser.Rows[_dgvSearchUser.Rows.Count - 1];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style = altenate ? cellStyle1 : cellStyle2;
                    cell.Style.SelectionBackColor = System.Drawing.Color.DimGray;
                }
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
                row.Cells[_dgvSearchUser.Columns.IndexOf(ColumnDetail)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.report_user;
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
            // TODO go to user file
        }
        private void DetailUser(int rowIndex)
        {
            DetectUser(rowIndex);
            RequestUserDetail(_currentUser);
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
