using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Droid.People;
using Tools4Libraries;
using Droid.financial;

namespace Droid.Booking
{
    public delegate void ViewBookEditEventHandler();
    public partial class ViewBookEdit : UserControlCustom, IView
    {
        #region Attribute
        public new event UserControlCustomEventHandler HeightChanged;
        public event ViewBookEditEventHandler CreatePersonRequested;
        public event ViewBookEditEventHandler OpenFinanceProject;

        private InterfaceBooking _intBoo;

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.CheckBox checkBoxConfirmed;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.ComboBox comboBoxPlace;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxArea;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label labelPerson;
        private Button buttonAddPayment;
        private DataGridView _dataGridViewMovement;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnUser;
        private DataGridViewTextBoxColumn ColumnAmount;
        private DataGridViewTextBoxColumn ColumnSupport;
        private DataGridViewImageColumn ColumnEdit;
        private DataGridViewImageColumn ColumnDelete;
        private GroupBox groupBoxPayment;
        private ComboBox comboBoxCash;
        private TextBox textBoxNewPayment;
        private Label labelNewPayment;
        private TextBox textBoxDescription;
        private Label labelDescription;
        private System.Windows.Forms.Button buttonAddPerson;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewBookEdit()
        {
            InitializeComponent();
            Init();
        }
        public ViewBookEdit(InterfaceBooking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            if (_intBoo != null)
            {
                LoadArea();
                LoadPerson();
                if (_intBoo.CurrentBooking != null)
                {
                    comboBoxPlace.SelectedItem = _intBoo.CurrentBooking.Place;
                    dateTimePickerCheckOut.Value = _intBoo.CurrentBooking.CheckOut;
                    dateTimePickerCheckIn.Value = _intBoo.CurrentBooking.CheckIn;
                    textBoxPrice.Text = CRE.GetExpenseFromId(_intBoo.CurrentBooking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Amount.ToString();
                    checkBoxConfirmed.Checked = _intBoo.CurrentBooking.Confirmed;
                    comboBoxArea.SelectedItem = Area.GetAreaFromId(_intBoo.CurrentBooking.AreaId, _intBoo.Areas);
                    LoadPayment();
                    if (_intBoo.CurrentBooking.UserId != null) comboBoxPerson.SelectedItem = Person.GetPersonFromId(_intBoo.CurrentBooking.UserId, _intBoo.Persons);
                }
                else
                {
                    dateTimePickerCheckOut.Value = DateTime.Now.AddDays(1);
                    dateTimePickerCheckIn.Value = DateTime.Now;
                }
            }
            GetPrice();
        }
        public override void ChangeLanguage()
        {
            labelStart.Text = GetText.Text("Start") + " : ";
            labelEnd.Text = GetText.Text("End") + " : ";
            checkBoxConfirmed.Text = GetText.Text("ConfirmationDone");
            labelPrice.Text = GetText.Text("PriceOfTheBook") + " : ";
            labelType.Text = GetText.Text("Area") + " : ";
            buttonApply.Text = GetText.Text("Save");
            buttonCancel.Text = GetText.Text("Cancel");
            labelPerson.Text = GetText.Text("User") + " : ";
            labelNewPayment.Text = GetText.Text("NewPayment") + " : ";
            comboBoxCash.Items.Clear();
            comboBoxCash.Items.Add(GetText.Text("CreditCard"));
            comboBoxCash.Items.Add(GetText.Text("Cash"));
            buttonAddPayment.Text = GetText.Text("AddPayment");
            labelDescription.Text = GetText.Text("Description");
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
            RefreshData();
            ChangeLanguage();
        }
        private void LoadPayment()
        {
            DataGridViewRow row;

            _dataGridViewMovement.Rows.Clear();
            var expense = CRE.GetExpenseFromId(_intBoo.CurrentBooking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE);
            if (expense != null)
            { 
                foreach (Movement mov in expense.Movements)
                {
                    _dataGridViewMovement.Rows.Add();
                    row = _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1];
                    row.Cells[ColumnUser.Index].Value = Person.GetPersonFromId(mov.UserId?.FirstOrDefault(), _intBoo.Persons);
                    row.Cells[ColumnSupport.Index].Value = mov.Gop;
                    row.Cells[ColumnAmount.Index].Value = mov.Amount;
                    row.Cells[ColumnDate.Index].Value = mov.StartDate.ToShortDateString();
                    row.Cells[ColumnEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cog_edit;
                    row.Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                }
            }
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBookEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.checkBoxConfirmed = new System.Windows.Forms.CheckBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelPlace = new System.Windows.Forms.Label();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxArea = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelPerson = new System.Windows.Forms.Label();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.buttonAddPayment = new System.Windows.Forms.Button();
            this._dataGridViewMovement = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.labelNewPayment = new System.Windows.Forms.Label();
            this.comboBoxCash = new System.Windows.Forms.ComboBox();
            this.textBoxNewPayment = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).BeginInit();
            this.groupBoxPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(93, -1);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerCheckIn.TabIndex = 0;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.Color.White;
            this.labelStart.Location = new System.Drawing.Point(4, 5);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(46, 17);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "Start : ";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnd.ForeColor = System.Drawing.Color.White;
            this.labelEnd.Location = new System.Drawing.Point(324, 2);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(39, 17);
            this.labelEnd.TabIndex = 6;
            this.labelEnd.Text = "End : ";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(413, -1);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerCheckOut.TabIndex = 5;
            // 
            // checkBoxConfirmed
            // 
            this.checkBoxConfirmed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxConfirmed.AutoSize = true;
            this.checkBoxConfirmed.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConfirmed.ForeColor = System.Drawing.Color.White;
            this.checkBoxConfirmed.Location = new System.Drawing.Point(7, 283);
            this.checkBoxConfirmed.Name = "checkBoxConfirmed";
            this.checkBoxConfirmed.Size = new System.Drawing.Size(131, 21);
            this.checkBoxConfirmed.TabIndex = 7;
            this.checkBoxConfirmed.Text = "Confirmation done";
            this.checkBoxConfirmed.UseVisualStyleBackColor = true;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrice.Location = new System.Drawing.Point(513, 52);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrice.TabIndex = 8;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(324, 55);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(129, 17);
            this.labelPrice.TabIndex = 9;
            this.labelPrice.Text = "Price of the booking : ";
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace.ForeColor = System.Drawing.Color.White;
            this.labelPlace.Location = new System.Drawing.Point(325, 28);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(48, 17);
            this.labelPlace.TabIndex = 12;
            this.labelPlace.Text = "Place : ";
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlace.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(413, 25);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(200, 23);
            this.comboBoxPlace.TabIndex = 13;
            this.comboBoxPlace.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlace_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.White;
            this.labelType.Location = new System.Drawing.Point(3, 28);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(45, 17);
            this.labelType.TabIndex = 12;
            this.labelType.Text = "Area : ";
            // 
            // comboBoxArea
            // 
            this.comboBoxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArea.FormattingEnabled = true;
            this.comboBoxArea.Location = new System.Drawing.Point(92, 25);
            this.comboBoxArea.Name = "comboBoxArea";
            this.comboBoxArea.Size = new System.Drawing.Size(200, 23);
            this.comboBoxArea.TabIndex = 13;
            this.comboBoxArea.SelectedValueChanged += new System.EventHandler(this.comboBoxArea_SelectedValueChanged);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.Location = new System.Drawing.Point(518, 281);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(95, 23);
            this.buttonApply.TabIndex = 14;
            this.buttonApply.Text = "Save";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(437, 281);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerson.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(92, 52);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(175, 23);
            this.comboBoxPerson.TabIndex = 17;
            // 
            // labelPerson
            // 
            this.labelPerson.AutoSize = true;
            this.labelPerson.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerson.ForeColor = System.Drawing.Color.White;
            this.labelPerson.Location = new System.Drawing.Point(4, 55);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(56, 17);
            this.labelPerson.TabIndex = 16;
            this.labelPerson.Text = "Person : ";
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddPerson.BackgroundImage")));
            this.buttonAddPerson.FlatAppearance.BorderSize = 0;
            this.buttonAddPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAddPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPerson.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPerson.Location = new System.Drawing.Point(273, 54);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(16, 16);
            this.buttonAddPerson.TabIndex = 18;
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // buttonAddPayment
            // 
            this.buttonAddPayment.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAddPayment.FlatAppearance.BorderSize = 0;
            this.buttonAddPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAddPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddPayment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPayment.ForeColor = System.Drawing.Color.Black;
            this.buttonAddPayment.Location = new System.Drawing.Point(431, 19);
            this.buttonAddPayment.Name = "buttonAddPayment";
            this.buttonAddPayment.Size = new System.Drawing.Size(169, 52);
            this.buttonAddPayment.TabIndex = 19;
            this.buttonAddPayment.Text = "Add payment";
            this.buttonAddPayment.UseVisualStyleBackColor = false;
            this.buttonAddPayment.Click += new System.EventHandler(this.buttonFinance_Click);
            // 
            // _dataGridViewMovement
            // 
            this._dataGridViewMovement.AllowUserToAddRows = false;
            this._dataGridViewMovement.AllowUserToDeleteRows = false;
            this._dataGridViewMovement.AllowUserToResizeColumns = false;
            this._dataGridViewMovement.AllowUserToResizeRows = false;
            this._dataGridViewMovement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dataGridViewMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnUser,
            this.ColumnAmount,
            this.ColumnSupport,
            this.ColumnEdit,
            this.ColumnDelete});
            this._dataGridViewMovement.Location = new System.Drawing.Point(6, 77);
            this._dataGridViewMovement.Name = "_dataGridViewMovement";
            this._dataGridViewMovement.ReadOnly = true;
            this._dataGridViewMovement.RowHeadersVisible = false;
            this._dataGridViewMovement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewMovement.Size = new System.Drawing.Size(594, 111);
            this._dataGridViewMovement.TabIndex = 20;
            // 
            // ColumnDate
            // 
            this.ColumnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 55;
            // 
            // ColumnUser
            // 
            this.ColumnUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnUser.HeaderText = "Guest";
            this.ColumnUser.Name = "ColumnUser";
            this.ColumnUser.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 68;
            // 
            // ColumnSupport
            // 
            this.ColumnSupport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnSupport.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSupport.HeaderText = "Support";
            this.ColumnSupport.Name = "ColumnSupport";
            this.ColumnSupport.ReadOnly = true;
            this.ColumnSupport.Width = 69;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnEdit.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            this.ColumnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnEdit.Width = 19;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnDelete.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            this.ColumnDelete.Width = 5;
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxPayment.Controls.Add(this.textBoxDescription);
            this.groupBoxPayment.Controls.Add(this.labelDescription);
            this.groupBoxPayment.Controls.Add(this.labelNewPayment);
            this.groupBoxPayment.Controls.Add(this.comboBoxCash);
            this.groupBoxPayment.Controls.Add(this.textBoxNewPayment);
            this.groupBoxPayment.Controls.Add(this.buttonAddPayment);
            this.groupBoxPayment.Controls.Add(this._dataGridViewMovement);
            this.groupBoxPayment.ForeColor = System.Drawing.Color.White;
            this.groupBoxPayment.Location = new System.Drawing.Point(7, 81);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(606, 194);
            this.groupBoxPayment.TabIndex = 21;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Payment";
            // 
            // labelNewPayment
            // 
            this.labelNewPayment.AutoSize = true;
            this.labelNewPayment.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPayment.ForeColor = System.Drawing.Color.White;
            this.labelNewPayment.Location = new System.Drawing.Point(6, 24);
            this.labelNewPayment.Name = "labelNewPayment";
            this.labelNewPayment.Size = new System.Drawing.Size(133, 17);
            this.labelNewPayment.TabIndex = 23;
            this.labelNewPayment.Text = "Amount new payment";
            // 
            // comboBoxCash
            // 
            this.comboBoxCash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCash.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCash.FormattingEnabled = true;
            this.comboBoxCash.Items.AddRange(new object[] {
            "CREDIT CARD",
            "CASH"});
            this.comboBoxCash.Location = new System.Drawing.Point(266, 19);
            this.comboBoxCash.Name = "comboBoxCash";
            this.comboBoxCash.Size = new System.Drawing.Size(159, 23);
            this.comboBoxCash.TabIndex = 22;
            // 
            // textBoxNewPayment
            // 
            this.textBoxNewPayment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPayment.Location = new System.Drawing.Point(145, 19);
            this.textBoxNewPayment.Name = "textBoxNewPayment";
            this.textBoxNewPayment.Size = new System.Drawing.Size(115, 23);
            this.textBoxNewPayment.TabIndex = 21;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.White;
            this.labelDescription.Location = new System.Drawing.Point(6, 51);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(72, 17);
            this.labelDescription.TabIndex = 24;
            this.labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(145, 48);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(280, 23);
            this.textBoxDescription.TabIndex = 25;
            // 
            // ViewBookEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxPayment);
            this.Controls.Add(this.buttonAddPerson);
            this.Controls.Add(this.comboBoxPlace);
            this.Controls.Add(this.labelPlace);
            this.Controls.Add(this.comboBoxPerson);
            this.Controls.Add(this.labelPerson);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxArea);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.checkBoxConfirmed);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.dateTimePickerCheckOut);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.dateTimePickerCheckIn);
            this.Name = "ViewBookEdit";
            this.Size = new System.Drawing.Size(617, 307);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).EndInit();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadArea()
        {
            comboBoxArea.DataSource = _intBoo.Areas;
        }
        private void LoadPerson()
        {
            comboBoxPerson.DataSource = _intBoo.Persons;
        }
        private void LoadPlace()
        {
            comboBoxPlace.Items.Clear();
            if (comboBoxArea.SelectedItem != null)
            { 
                foreach (var item in ((Area)comboBoxArea.SelectedItem).Place)
                {
                    comboBoxPlace.Items.Add(item.Key);
                }
                comboBoxPlace.Sorted = true;
                if (comboBoxPlace.Items.Count > 0) { comboBoxPlace.SelectedItem = comboBoxPlace.Items[0]; }
            }
        }
        private void SaveBook()
        {
            UpdateCurrentBook();
            _intBoo.CurrentBooking.Save(_intBoo.DirectoryBooking);
            _intBoo.CurrentFinancialActivity.Save(_intBoo.DirectoryFinancialActivity);

            if (_intBoo.Bookings.Contains(_intBoo.CurrentBooking))
            {
                _intBoo.Bookings.Remove(_intBoo.CurrentBooking);
            }
            _intBoo.Bookings.Add(_intBoo.CurrentBooking);
        }
        private void UpdateCurrentBook()
        {
            Movement mov;
            if (_intBoo.CurrentBooking == null)
            {
                _intBoo.CurrentBooking = new Booking();
            }
            if (string.IsNullOrEmpty(_intBoo.CurrentBooking.ExpenseId))
            {
                CRE exp = new CRE();
                _intBoo.CurrentBooking.ExpenseId = exp.Id;
                _intBoo.CurrentFinancialActivity.ListCRE.Add(exp);
            }

            try
            {
                CRE exp = CRE.GetExpenseFromId(_intBoo.CurrentBooking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE);
                Area filterArea = (!string.IsNullOrEmpty(comboBoxArea.Text)) ? (Area)comboBoxArea.SelectedItem : null;
                Person filterPerson = (!string.IsNullOrEmpty(comboBoxPerson.Text)) ? (Person)comboBoxPerson.SelectedItem : null;

                if (filterArea != null) _intBoo.CurrentBooking.AreaId = filterArea.Id;
                if (filterPerson != null) _intBoo.CurrentBooking.UserId = filterPerson.Id;
                _intBoo.CurrentBooking.CheckIn = dateTimePickerCheckIn.Value;
                _intBoo.CurrentBooking.CheckOut = dateTimePickerCheckOut.Value;
                _intBoo.CurrentBooking.Confirmed = checkBoxConfirmed.Checked;
                _intBoo.CurrentBooking.Place = (comboBoxPlace.SelectedItem == null) ? string.Empty : comboBoxPlace.SelectedItem.ToString();

                exp.Amount = (string.IsNullOrEmpty(textBoxPrice.Text)) ? 0 : double.Parse(textBoxPrice.Text);
                exp.StartDate = dateTimePickerCheckIn.Value;
                exp.EndDate = dateTimePickerCheckOut.Value;

                CRE.GetExpenseFromId(_intBoo.CurrentBooking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE).Movements.Clear();
                foreach (DataGridViewRow row in _dataGridViewMovement.Rows)
                {
                    mov = new Movement();
                    mov.StartDate = DateTime.Parse(row.Cells[ColumnDate.Index].Value.ToString());
                    mov.UserId.Add(Person.GetUserByText(row.Cells[ColumnUser.Index].Value, _intBoo.Persons)?.Id);
                    mov.Amount = float.Parse(row.Cells[ColumnAmount.Index].Value.ToString());
                    mov.Gop = (Movement.GOP)Enum.Parse(typeof(Movement.GOP), row.Cells[ColumnSupport.Index].Value.ToString());
                    CRE.GetExpenseFromId(_intBoo.CurrentBooking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE).Movements.Add(mov);
                }
            }
            catch (Exception)
            {

            }
        }
        private void GetPrice()
        {
            //UpdateCurrentBook();
            _intBoo.GoAction("getprice");
            if (_intBoo.CurrentPrice != null) textBoxPrice.Text = _intBoo.CurrentPrice != null ? _intBoo.CurrentPrice.Amount.ToString() : string.Empty;
        }
        private void AddPayment()
        {
            DataGridViewRow row;
            Movement mov = new Movement();

            _intBoo.CurrentUser = (Person)comboBoxPerson.SelectedItem;
            mov.Amount = float.Parse(textBoxNewPayment.Text);
            mov.UserId.Add(_intBoo.CurrentUser.Id);
            mov.StartDate = DateTime.Now;
            mov.Gop = (Movement.GOP)Enum.Parse(typeof(Movement.GOP), comboBoxCash.SelectedItem.ToString());

            if (_intBoo.CurrentBooking.ExpenseId == null)
            {
                CRE exp = new CRE();
                exp.StartDate = _intBoo.CurrentBooking.CheckIn;
                exp.EndDate = _intBoo.CurrentBooking.CheckOut;
                exp.Description = textBoxDescription.Text;
                //exp.Save(_intBoo.CurrentFinancialActivity.PathActivity);
                exp.Movements.Add(mov);
                _intBoo.CurrentBooking.ExpenseId = exp.Id;
                _intBoo.CurrentFinancialActivity.ListCRE.Add(exp);
            }
            else
            {
                CRE.GetExpenseFromId(_intBoo.CurrentBooking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE).Movements.Add(mov);
            }

            _dataGridViewMovement.Rows.Add();
            row = _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1];
            row.Cells[ColumnUser.Index].Value = (Person)comboBoxPerson.SelectedItem;
            row.Cells[ColumnSupport.Index].Value = mov.Gop;
            row.Cells[ColumnAmount.Index].Value = mov.Amount;
            row.Cells[ColumnDate.Index].Value = mov.StartDate.ToShortDateString();
            row.Cells[ColumnEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cog_edit;
            row.Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;

            SaveBook();
        }
        #endregion

        #region Event
        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveBook();
        }
        private void comboBoxArea_SelectedValueChanged(object sender, EventArgs e)
        {
            _intBoo.CurrentArea = (Area)comboBoxArea.SelectedItem;
            LoadPlace();
            GetPrice();
        }
        private void comboBoxPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice();
        }
        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            if (CreatePersonRequested != null) {  CreatePersonRequested(); }
        }
        private void buttonFinance_Click(object sender, EventArgs e)
        {
            AddPayment();
            //if (OpenFinanceProject != null) { OpenFinanceProject(); }
        }
        #endregion
    }
}
