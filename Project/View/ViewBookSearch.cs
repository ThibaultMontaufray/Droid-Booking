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
    public delegate void ViewBookEventHandler(object o);
    public partial class ViewBookSearch : UserControlCustom, IView
    {
        #region Attribute
        public event UserControlCustomEventHandler HeightChanged;
        public event ViewUserEventHandler RequestBookDetail;
        public event ViewUserEventHandler RequestBookEdition;

        private InterfaceBooking _intBoo;
        private List<Booking> _filteredList;

        private IContainer components = null;
        private CheckBox checkBoxNonCompletedPaiement;
        private CheckBox checkBoxCompletedPaiements;
        private NumericUpDown numericUpDownMaxPrice;
        private NumericUpDown numericUpDownMinPrice;
        private Label label4;
        private Label label3;
        private CheckBox checkBoxNonConfirmedbooking;
        private CheckBox checkBoxConfirmedbooking;
        private DateTimePicker dateTimePickerEnd;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerStart;
        private ComboBox comboBoxArea;
        private Label labelArea;
        private ComboBox comboBoxUsers;
        private Button buttonFilter;
        private Button buttonClearFilter;
        private DataGridView _dgvSearch;
        private DataGridViewTextBoxColumn ColumnArea;
        private DataGridViewTextBoxColumn ColumnPrice;
        private DataGridViewTextBoxColumn ColumnPaid;
        private DataGridViewCheckBoxColumn ColumnConfirmed;
        private DataGridViewTextBoxColumn ColumnCheckIn;
        private DataGridViewTextBoxColumn ColumnCheckOut;
        private DataGridViewImageColumn ColumnEdit;
        private DataGridViewImageColumn ColumnDelete;
        private DataGridViewImageColumn ColumnDetails;
        private DataGridViewTextBoxColumn ColumnUser;
        private Label labelUsers;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewBookSearch()
        {
            InitializeComponent();
            Init();
        }
        public ViewBookSearch(InterfaceBooking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            LoadPeople();
            LoadArea();
        }
        public override void ChangeLanguage()
        {
            checkBoxNonCompletedPaiement.Text = GetText.Text("FilterOnNonCompletedPaiements");
            checkBoxCompletedPaiements.Text = GetText.Text("FilterOnCompletedPaiements");
            label3.Text = GetText.Text("MinPrice") + " : ";
            label4.Text = GetText.Text("MaxPrice") + " : ";
            checkBoxNonConfirmedbooking.Text = GetText.Text("FilterOnNonConfirmedBookings");
            checkBoxConfirmedbooking.Text = GetText.Text("FilterOnConfirmedBookings");
            label2.Text = GetText.Text("MinDate") + " : ";
            label1.Text = GetText.Text("MaxDate") + " : ";
            labelArea.Text = GetText.Text("Area") + " : ";
            labelUsers.Text = GetText.Text("Users") + " : ";
            buttonClearFilter.Text = GetText.Text("ClearFilter");
            
            ColumnArea.HeaderText = GetText.Text("Area");
            ColumnUser.HeaderText = GetText.Text("User");
            ColumnPrice.HeaderText = GetText.Text("Price");
            ColumnPaid.HeaderText = GetText.Text("Paid");
            ColumnConfirmed.HeaderText = GetText.Text("Confirmed");
            ColumnCheckIn.HeaderText = GetText.Text("CheckIn");
            ColumnCheckOut.HeaderText = GetText.Text("CheckOut");
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
            ClearFilter();

            _dgvSearch.Visible = _dgvSearch.Rows.Count != 0;
            _dgvSearch.Height = (_dgvSearch.Rows.Count * 22) + _dgvSearch.ColumnHeadersHeight;
            ChangeLanguage();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkBoxNonCompletedPaiement = new System.Windows.Forms.CheckBox();
            this.checkBoxCompletedPaiements = new System.Windows.Forms.CheckBox();
            this.numericUpDownMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxNonConfirmedbooking = new System.Windows.Forms.CheckBox();
            this.checkBoxConfirmedbooking = new System.Windows.Forms.CheckBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.comboBoxArea = new System.Windows.Forms.ComboBox();
            this.labelArea = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.labelUsers = new System.Windows.Forms.Label();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this._dgvSearch = new System.Windows.Forms.DataGridView();
            this.ColumnArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConfirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDetails = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxNonCompletedPaiement
            // 
            this.checkBoxNonCompletedPaiement.AutoSize = true;
            this.checkBoxNonCompletedPaiement.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNonCompletedPaiement.ForeColor = System.Drawing.Color.White;
            this.checkBoxNonCompletedPaiement.Location = new System.Drawing.Point(400, 86);
            this.checkBoxNonCompletedPaiement.Name = "checkBoxNonCompletedPaiement";
            this.checkBoxNonCompletedPaiement.Size = new System.Drawing.Size(222, 21);
            this.checkBoxNonCompletedPaiement.TabIndex = 32;
            this.checkBoxNonCompletedPaiement.Text = "Filter on non completed paiements";
            this.checkBoxNonCompletedPaiement.UseVisualStyleBackColor = true;
            // 
            // checkBoxCompletedPaiements
            // 
            this.checkBoxCompletedPaiements.AutoSize = true;
            this.checkBoxCompletedPaiements.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompletedPaiements.ForeColor = System.Drawing.Color.White;
            this.checkBoxCompletedPaiements.Location = new System.Drawing.Point(400, 57);
            this.checkBoxCompletedPaiements.Name = "checkBoxCompletedPaiements";
            this.checkBoxCompletedPaiements.Size = new System.Drawing.Size(198, 21);
            this.checkBoxCompletedPaiements.TabIndex = 31;
            this.checkBoxCompletedPaiements.Text = "Filter on completed paiements";
            this.checkBoxCompletedPaiements.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxPrice
            // 
            this.numericUpDownMaxPrice.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMaxPrice.Location = new System.Drawing.Point(791, 27);
            this.numericUpDownMaxPrice.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownMaxPrice.Name = "numericUpDownMaxPrice";
            this.numericUpDownMaxPrice.Size = new System.Drawing.Size(77, 24);
            this.numericUpDownMaxPrice.TabIndex = 30;
            this.numericUpDownMaxPrice.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // numericUpDownMinPrice
            // 
            this.numericUpDownMinPrice.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMinPrice.Location = new System.Drawing.Point(791, -2);
            this.numericUpDownMinPrice.Name = "numericUpDownMinPrice";
            this.numericUpDownMinPrice.Size = new System.Drawing.Size(77, 24);
            this.numericUpDownMinPrice.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(700, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Max price : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(700, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Min price : ";
            // 
            // checkBoxNonConfirmedbooking
            // 
            this.checkBoxNonConfirmedbooking.AutoSize = true;
            this.checkBoxNonConfirmedbooking.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNonConfirmedbooking.ForeColor = System.Drawing.Color.White;
            this.checkBoxNonConfirmedbooking.Location = new System.Drawing.Point(400, 28);
            this.checkBoxNonConfirmedbooking.Name = "checkBoxNonConfirmedbooking";
            this.checkBoxNonConfirmedbooking.Size = new System.Drawing.Size(209, 21);
            this.checkBoxNonConfirmedbooking.TabIndex = 26;
            this.checkBoxNonConfirmedbooking.Text = "Filter on non confirmed bookings";
            this.checkBoxNonConfirmedbooking.UseVisualStyleBackColor = true;
            // 
            // checkBoxConfirmedbooking
            // 
            this.checkBoxConfirmedbooking.AutoSize = true;
            this.checkBoxConfirmedbooking.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConfirmedbooking.ForeColor = System.Drawing.Color.White;
            this.checkBoxConfirmedbooking.Location = new System.Drawing.Point(400, -1);
            this.checkBoxConfirmedbooking.Name = "checkBoxConfirmedbooking";
            this.checkBoxConfirmedbooking.Size = new System.Drawing.Size(185, 21);
            this.checkBoxConfirmedbooking.TabIndex = 25;
            this.checkBoxConfirmedbooking.Text = "Filter on confirmed bookings";
            this.checkBoxConfirmedbooking.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(103, 84);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(272, 24);
            this.dateTimePickerEnd.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Max date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Min date : ";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(103, 55);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(272, 24);
            this.dateTimePickerStart.TabIndex = 21;
            // 
            // comboBoxArea
            // 
            this.comboBoxArea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArea.FormattingEnabled = true;
            this.comboBoxArea.Location = new System.Drawing.Point(103, 26);
            this.comboBoxArea.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxArea.Name = "comboBoxArea";
            this.comboBoxArea.Size = new System.Drawing.Size(272, 23);
            this.comboBoxArea.TabIndex = 20;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.ForeColor = System.Drawing.Color.White;
            this.labelArea.Location = new System.Drawing.Point(4, 29);
            this.labelArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(45, 17);
            this.labelArea.TabIndex = 19;
            this.labelArea.Text = "Area : ";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(103, -3);
            this.comboBoxUsers.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(272, 23);
            this.comboBoxUsers.TabIndex = 18;
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsers.ForeColor = System.Drawing.Color.White;
            this.labelUsers.Location = new System.Drawing.Point(4, 0);
            this.labelUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(49, 17);
            this.labelUsers.TabIndex = 17;
            this.labelUsers.Text = "Users : ";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.Location = new System.Drawing.Point(793, 82);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 28);
            this.buttonFilter.TabIndex = 33;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearFilter.Location = new System.Drawing.Point(679, 82);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(108, 28);
            this.buttonClearFilter.TabIndex = 34;
            this.buttonClearFilter.Text = "Clear filter";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // _dgvSearch
            // 
            this._dgvSearch.AllowUserToAddRows = false;
            this._dgvSearch.AllowUserToDeleteRows = false;
            this._dgvSearch.AllowUserToResizeColumns = false;
            this._dgvSearch.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnArea,
            this.ColumnUser,
            this.ColumnPrice,
            this.ColumnPaid,
            this.ColumnConfirmed,
            this.ColumnCheckIn,
            this.ColumnCheckOut,
            this.ColumnEdit,
            this.ColumnDelete,
            this.ColumnDetails});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvSearch.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvSearch.Location = new System.Drawing.Point(7, 116);
            this._dgvSearch.MultiSelect = false;
            this._dgvSearch.Name = "_dgvSearch";
            this._dgvSearch.ReadOnly = true;
            this._dgvSearch.RowHeadersVisible = false;
            this._dgvSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvSearch.Size = new System.Drawing.Size(861, 292);
            this._dgvSearch.TabIndex = 1;
            this._dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvSearch_CellClick);
            // 
            // ColumnArea
            // 
            this.ColumnArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnArea.HeaderText = "Area";
            this.ColumnArea.Name = "ColumnArea";
            this.ColumnArea.ReadOnly = true;
            this.ColumnArea.Width = 66;
            // 
            // ColumnUser
            // 
            this.ColumnUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUser.HeaderText = "User";
            this.ColumnUser.Name = "ColumnUser";
            this.ColumnUser.ReadOnly = true;
            // 
            // ColumnPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            // 
            // ColumnPaid
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnPaid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPaid.HeaderText = "Paid";
            this.ColumnPaid.Name = "ColumnPaid";
            this.ColumnPaid.ReadOnly = true;
            // 
            // ColumnConfirmed
            // 
            this.ColumnConfirmed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnConfirmed.HeaderText = "Confirmed";
            this.ColumnConfirmed.Name = "ColumnConfirmed";
            this.ColumnConfirmed.ReadOnly = true;
            this.ColumnConfirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnConfirmed.Width = 103;
            // 
            // ColumnCheckIn
            // 
            this.ColumnCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnCheckIn.HeaderText = "Check In";
            this.ColumnCheckIn.Name = "ColumnCheckIn";
            this.ColumnCheckIn.ReadOnly = true;
            this.ColumnCheckIn.Width = 92;
            // 
            // ColumnCheckOut
            // 
            this.ColumnCheckOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnCheckOut.HeaderText = "Chek Out";
            this.ColumnCheckOut.Name = "ColumnCheckOut";
            this.ColumnCheckOut.ReadOnly = true;
            this.ColumnCheckOut.Width = 95;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
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
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            this.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDelete.Width = 19;
            // 
            // ColumnDetails
            // 
            this.ColumnDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDetails.HeaderText = "";
            this.ColumnDetails.Name = "ColumnDetails";
            this.ColumnDetails.ReadOnly = true;
            this.ColumnDetails.Width = 5;
            // 
            // ViewBookSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkBoxNonCompletedPaiement);
            this.Controls.Add(this.checkBoxCompletedPaiements);
            this.Controls.Add(this.numericUpDownMaxPrice);
            this.Controls.Add(this.numericUpDownMinPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxNonConfirmedbooking);
            this.Controls.Add(this.checkBoxConfirmedbooking);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBoxArea);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.labelUsers);
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this._dgvSearch);
            this.Name = "ViewBookSearch";
            this.Size = new System.Drawing.Size(873, 411);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadPeople()
        {
            comboBoxUsers.Items.Clear();
            comboBoxUsers.Items.Add("All");
            foreach (Person person in _intBoo.Persons)
            {
                comboBoxUsers.Items.Add(person.ToString());
            }
            comboBoxUsers.Sorted = true;
            comboBoxUsers.SelectedItem = "All";
        }
        private void LoadArea()
        {
            comboBoxArea.Items.Clear();
            comboBoxArea.Items.Add("All");
            foreach (Area area in _intBoo.Areas)
            {
                comboBoxArea.Items.Add(area.ToString());
            }
            comboBoxArea.Sorted = true;
            comboBoxArea.SelectedItem = "All";
        }
        private void ClearFilter()
        {
            comboBoxArea.Text = "All";
            comboBoxUsers.Text = "All";
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-6);
            dateTimePickerEnd.Value = DateTime.Now.AddMonths(6);

            checkBoxConfirmedbooking.Checked = true;
            checkBoxCompletedPaiements.Checked = true;
            checkBoxNonCompletedPaiement.Checked = true;
            checkBoxNonConfirmedbooking.Checked = true;

            numericUpDownMaxPrice.Value = numericUpDownMaxPrice.Maximum;
            numericUpDownMinPrice.Value = numericUpDownMinPrice.Minimum;
        }
        private void Filter()
        {
            Area filterArea = comboBoxArea.SelectedItem.ToString() != "All" ? (Area) comboBoxArea.SelectedItem : null;
            Person filterPerson = comboBoxUsers.SelectedItem.ToString() != "All" ? (Person) comboBoxUsers.SelectedItem : null;
            _filteredList = _intBoo.Bookings;

            if (filterArea != null) _filteredList = _filteredList.Where(f => f.AreaId.Equals(filterArea.Id)).ToList();
            if (filterPerson != null) _filteredList = _filteredList.Where(f => f.UserId.Equals(filterPerson.Id)).ToList();
            if (!dateTimePickerEnd.Value.Equals(dateTimePickerEnd.MaxDate)) _filteredList = _filteredList.Where(f => f.CheckOut.Date <= dateTimePickerEnd.Value.Date).ToList();
            if (!dateTimePickerStart.Value.Equals(dateTimePickerStart.MinDate)) _filteredList = _filteredList.Where(f => f.CheckIn.Date >= dateTimePickerStart.Value.Date).ToList();

            if (checkBoxCompletedPaiements.Checked && !checkBoxNonCompletedPaiement.Checked) _filteredList = _filteredList.Where(f => CRE.GetExpenseFromId(f.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Paid >= CRE.GetExpenseFromId(f.Id, _intBoo.CurrentFinancialActivity.ListCRE)?.Amount).ToList();
            if (!checkBoxCompletedPaiements.Checked && checkBoxNonCompletedPaiement.Checked) _filteredList = _filteredList.Where(f => CRE.GetExpenseFromId(f.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Paid < CRE.GetExpenseFromId(f.Id, _intBoo.CurrentFinancialActivity.ListCRE)?.Amount).ToList();
            if (checkBoxConfirmedbooking.Checked && !checkBoxNonConfirmedbooking.Checked) _filteredList = _filteredList.Where(f => f.Confirmed == true).ToList();
            if (!checkBoxConfirmedbooking.Checked && checkBoxNonConfirmedbooking.Checked) _filteredList = _filteredList.Where(f => f.Confirmed == false).ToList();

            if (numericUpDownMaxPrice.Value != numericUpDownMaxPrice.Maximum) _filteredList = _filteredList.Where(f => CRE.GetExpenseFromId(f.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Amount <= (double)numericUpDownMaxPrice.Value).ToList();
            if (numericUpDownMinPrice.Value != numericUpDownMinPrice.Minimum) _filteredList = _filteredList.Where(f => CRE.GetExpenseFromId(f.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Amount >= (double)numericUpDownMinPrice.Value).ToList();

            RefreshDataGridView();
        }
        private void RefreshDataGridView()
        {
            Area area;
            Person person;
            DataGridViewRow row;
            _dgvSearch.Rows.Clear();
            foreach (Booking booking in _filteredList.OrderBy(f => f.CheckIn))
            {
                area = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas);
                person = Person.GetPersonFromId(booking.UserId, _intBoo.Persons);

                _dgvSearch.Rows.Add();
                row = _dgvSearch.Rows[_dgvSearch.Rows.Count - 1];
                row.Tag = booking.Id;
                row.Cells[ColumnArea.Index].Value = area != null ? area.ToString() : string.Empty ;
                row.Cells[ColumnUser.Index].Value = person != null ? person.ToString() : string.Empty;
                row.Cells[ColumnConfirmed.Index].Value = booking.Confirmed;
                row.Cells[ColumnPrice.Index].Value = CRE.GetExpenseFromId(booking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Amount;
                row.Cells[ColumnPaid.Index].Value = CRE.GetExpenseFromId(booking.ExpenseId, _intBoo.CurrentFinancialActivity.ListCRE)?.Paid;
                row.Cells[ColumnCheckIn.Index].Value = booking.CheckIn.ToShortDateString();
                row.Cells[ColumnCheckOut.Index].Value = booking.CheckOut.ToShortDateString();
                row.Cells[ColumnEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.vcard_edit;
                row.Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.vcard_delete;
                row.Cells[ColumnDetails.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.vcard;
            }
            
            _dgvSearch.Visible = _dgvSearch.Rows.Count != 0;
            _dgvSearch.Height = (_dgvSearch.Rows.Count * 22) + _dgvSearch.ColumnHeadersHeight;
        }
        private void DeleteBook(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this booking ?", "Delete book", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (DetectBook(rowIndex))
                {
                    _intBoo.Bookings.Remove(_intBoo.CurrentBooking);
                    Filter();
                }
            }
        }
        private void EditBook(int rowIndex)
        {
            DetectBook(rowIndex);
            if (_intBoo.CurrentBooking != null) _intBoo.CurrentUser = Person.GetPersonFromId(_intBoo.CurrentBooking.UserId, _intBoo.Persons);
            RequestBookEdition(_intBoo.CurrentBooking);
        }
        private void DetailBook(int rowIndex)
        {
            DetectBook(rowIndex);
            if (_intBoo.CurrentBooking != null) _intBoo.CurrentUser = Person.GetPersonFromId(_intBoo.CurrentBooking.UserId, _intBoo.Persons);
            RequestBookDetail(_intBoo.CurrentBooking);
        }
        private bool DetectBook(int rowIndex)
        {
            string bookId = _dgvSearch.Rows[rowIndex].Tag.ToString();
            List<Booking> books = _intBoo.Bookings.Where(b => b.Id.ToString().Equals(bookId)).ToList();

            if (books.Count == 0)
            {
                MessageBox.Show("This booking has not be found", "booking not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (books.Count > 1)
            {
                MessageBox.Show("Too many books found for this user, area and date. Please change users settings.", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                _intBoo.CurrentBooking = books[0];
                return true;
            }
        }
        #endregion

        #region Event
        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }
        private void _dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDelete.Index)
            {
                DeleteBook(e.RowIndex);
            }
            else if (e.ColumnIndex == ColumnEdit.Index)
            {
                EditBook(e.RowIndex);
            }
            else if (e.ColumnIndex == ColumnDetails.Index)
            {
                DetailBook(e.RowIndex);
            }
        }
        #endregion
    }
}
