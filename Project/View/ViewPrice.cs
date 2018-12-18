using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.Booking
{
    public class ViewPrice : UserControlCustom, IView
    {
        #region Attribute
        public new event UserControlCustomEventHandler HeightChanged;

        private Label labelType;
        private ComboBox comboBoxType;
        private ComboBox comboBoxName;
        private ComboBox comboBoxPlace;
        private Button buttonAdd;
        private DataGridView dataGridViewPrices;
        private NumericUpDown numericUpDownAmount;
        private GroupBox groupBoxAdd;
        private Label labelName;
        private Label labelPlace;
        private Label labelDateStart;
        private Label labelDateEnd;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Label labelAmount;
        private Label label1;
        private NumericUpDown numericUpDownPriority;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn ColumnType;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnPlace;
        private DataGridViewTextBoxColumn ColumnAmount;
        private DataGridViewTextBoxColumn ColumnStart;
        private DataGridViewTextBoxColumn ColumnEnd;
        private DataGridViewImageColumn ColumnUp;
        private DataGridViewImageColumn ColumnDown;
        private DataGridViewImageColumn ColumnDelete;
        private DataGridViewTextBoxColumn ColumnPrioritu;
        private InterfaceBooking _intBoo;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewPrice()
        {
            InitializeComponent();
            Init();
        }
        public ViewPrice(InterfaceBooking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {

        }
        public override void RefreshData()
        {
            if (_intBoo != null)
            {
                DataGridViewRow row;

                dataGridViewPrices.Rows.Clear();
                foreach (Price price in _intBoo.Prices.OrderByDescending(p => p.Priority))
                {
                    dataGridViewPrices.Rows.Add();
                    row = dataGridViewPrices.Rows[dataGridViewPrices.Rows.Count - 1];
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnPrioritu)].Value = price.Priority;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnType)].Value = price.Type;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnName)].Value = price.Name;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnPlace)].Value = price.Place;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnAmount)].Value = price.Amount;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnStart)].Value = price.DateStart.ToShortDateString();
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnEnd)].Value = price.DateEnd.ToShortDateString();
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnUp)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.arrow_up;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnDown)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.arrow_down;
                    row.Cells[dataGridViewPrices.Columns.IndexOf(ColumnDelete)].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                    row.Tag = price;
                }
            }

            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now.AddYears(50);

            LoadType();
            LoadName();
            LoadPlace();
            UpdateSize();

            _intBoo.GlobalAction(this, new ToolBarEventArgs("saveprice"));
        }
        #endregion

        #region Methods private
        private void Init()
        {
            RefreshData();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPrice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewPrices = new System.Windows.Forms.DataGridView();
            this.ColumnPrioritu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUp = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDown = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPriority = new System.Windows.Forms.NumericUpDown();
            this.labelAmount = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.labelPlace = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.groupBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(15, 23);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 17);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(95, 20);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(154, 23);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // comboBoxName
            // 
            this.comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(357, 20);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(154, 23);
            this.comboBoxName.TabIndex = 2;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(607, 20);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(133, 23);
            this.comboBoxPlace.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(665, 55);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 60);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridViewPrices
            // 
            this.dataGridViewPrices.AllowUserToAddRows = false;
            this.dataGridViewPrices.AllowUserToDeleteRows = false;
            this.dataGridViewPrices.AllowUserToResizeColumns = false;
            this.dataGridViewPrices.AllowUserToResizeRows = false;
            this.dataGridViewPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrioritu,
            this.ColumnType,
            this.ColumnName,
            this.ColumnPlace,
            this.ColumnAmount,
            this.ColumnStart,
            this.ColumnEnd,
            this.ColumnUp,
            this.ColumnDown,
            this.ColumnDelete});
            this.dataGridViewPrices.Location = new System.Drawing.Point(3, 135);
            this.dataGridViewPrices.Name = "dataGridViewPrices";
            this.dataGridViewPrices.ReadOnly = true;
            this.dataGridViewPrices.RowHeadersVisible = false;
            this.dataGridViewPrices.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrices.Size = new System.Drawing.Size(747, 220);
            this.dataGridViewPrices.TabIndex = 5;
            this.dataGridViewPrices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrices_CellClick);
            // 
            // ColumnPrioritu
            // 
            this.ColumnPrioritu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnPrioritu.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColumnPrioritu.HeaderText = "Priority";
            this.ColumnPrioritu.Name = "ColumnPrioritu";
            this.ColumnPrioritu.ReadOnly = true;
            this.ColumnPrioritu.Width = 74;
            // 
            // ColumnType
            // 
            this.ColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnType.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnPlace
            // 
            this.ColumnPlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnPlace.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColumnPlace.HeaderText = "Place";
            this.ColumnPlace.Name = "ColumnPlace";
            this.ColumnPlace.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnAmount.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColumnAmount.HeaderText = "Price";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 61;
            // 
            // ColumnStart
            // 
            this.ColumnStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnStart.DefaultCellStyle = dataGridViewCellStyle20;
            this.ColumnStart.HeaderText = "Start";
            this.ColumnStart.Name = "ColumnStart";
            this.ColumnStart.ReadOnly = true;
            this.ColumnStart.Width = 61;
            // 
            // ColumnEnd
            // 
            this.ColumnEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnEnd.DefaultCellStyle = dataGridViewCellStyle21;
            this.ColumnEnd.HeaderText = "End";
            this.ColumnEnd.Name = "ColumnEnd";
            this.ColumnEnd.ReadOnly = true;
            this.ColumnEnd.Width = 54;
            // 
            // ColumnUp
            // 
            this.ColumnUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle22.NullValue")));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnUp.DefaultCellStyle = dataGridViewCellStyle22;
            this.ColumnUp.HeaderText = "";
            this.ColumnUp.Name = "ColumnUp";
            this.ColumnUp.ReadOnly = true;
            this.ColumnUp.Width = 5;
            // 
            // ColumnDown
            // 
            this.ColumnDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle23.NullValue")));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnDown.DefaultCellStyle = dataGridViewCellStyle23;
            this.ColumnDown.HeaderText = "";
            this.ColumnDown.Name = "ColumnDown";
            this.ColumnDown.ReadOnly = true;
            this.ColumnDown.Width = 5;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle24.NullValue")));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnDelete.DefaultCellStyle = dataGridViewCellStyle24;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            this.ColumnDelete.Width = 5;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(583, 57);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(76, 24);
            this.numericUpDownAmount.TabIndex = 6;
            this.numericUpDownAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.label1);
            this.groupBoxAdd.Controls.Add(this.numericUpDownPriority);
            this.groupBoxAdd.Controls.Add(this.labelAmount);
            this.groupBoxAdd.Controls.Add(this.numericUpDownAmount);
            this.groupBoxAdd.Controls.Add(this.buttonAdd);
            this.groupBoxAdd.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxAdd.Controls.Add(this.dateTimePickerStart);
            this.groupBoxAdd.Controls.Add(this.labelDateEnd);
            this.groupBoxAdd.Controls.Add(this.labelDateStart);
            this.groupBoxAdd.Controls.Add(this.labelPlace);
            this.groupBoxAdd.Controls.Add(this.labelName);
            this.groupBoxAdd.Controls.Add(this.comboBoxType);
            this.groupBoxAdd.Controls.Add(this.labelType);
            this.groupBoxAdd.Controls.Add(this.comboBoxPlace);
            this.groupBoxAdd.Controls.Add(this.comboBoxName);
            this.groupBoxAdd.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(747, 126);
            this.groupBoxAdd.TabIndex = 7;
            this.groupBoxAdd.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Priority (0 the worst)";
            // 
            // numericUpDownPriority
            // 
            this.numericUpDownPriority.Location = new System.Drawing.Point(583, 88);
            this.numericUpDownPriority.Name = "numericUpDownPriority";
            this.numericUpDownPriority.Size = new System.Drawing.Size(76, 24);
            this.numericUpDownPriority.TabIndex = 9;
            this.numericUpDownPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(405, 59);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(53, 17);
            this.labelAmount.TabIndex = 8;
            this.labelAmount.Text = "Amount";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(95, 86);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(291, 24);
            this.dateTimePickerEnd.TabIndex = 7;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(95, 53);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(291, 24);
            this.dateTimePickerStart.TabIndex = 6;
            // 
            // labelDateEnd
            // 
            this.labelDateEnd.AutoSize = true;
            this.labelDateEnd.Location = new System.Drawing.Point(15, 92);
            this.labelDateEnd.Name = "labelDateEnd";
            this.labelDateEnd.Size = new System.Drawing.Size(56, 17);
            this.labelDateEnd.TabIndex = 5;
            this.labelDateEnd.Text = "Finish on";
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Location = new System.Drawing.Point(15, 59);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(53, 17);
            this.labelDateStart.TabIndex = 4;
            this.labelDateStart.Text = "Start on";
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(542, 23);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(38, 17);
            this.labelPlace.TabIndex = 3;
            this.labelPlace.Text = "Place";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(277, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(42, 17);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn4.HeaderText = "Place";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn5.HeaderText = "Price";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Start";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "End";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // ViewPrice
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxAdd);
            this.Controls.Add(this.dataGridViewPrices);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ViewPrice";
            this.Size = new System.Drawing.Size(756, 364);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriority)).EndInit();
            this.ResumeLayout(false);

        }
        private void LoadType()
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.Add("All");
            foreach (var item in Enum.GetValues(typeof(Area.TYPE)))
            {
                comboBoxType.Items.Add(item.ToString());
            }
            comboBoxType.Sorted = true;
            comboBoxType.SelectedItem = "All";
        }
        private void LoadName()
        {
            List<Area> areas = new List<Area>();
            if (!comboBoxType.SelectedItem.ToString().Equals("All"))
            {
                areas = _intBoo.Areas.Where(a => a.Type.Equals((Area.TYPE)Enum.Parse(typeof(Area.TYPE), comboBoxType.SelectedItem.ToString()))).ToList();
            }

            comboBoxName.Items.Clear();
            comboBoxName.Items.Add("All");
            foreach (Area area in areas)
            {
                comboBoxName.Items.Add(area.Name);
            }
            comboBoxName.Sorted = true;
            comboBoxName.SelectedItem = "All";
        }
        private void LoadPlace()
        {
            List<Area> areas = new List<Area>();
            if (!comboBoxType.SelectedItem.ToString().Equals("All"))
            {
                areas = _intBoo.Areas.Where(a => a.Type.Equals((Area.TYPE)Enum.Parse(typeof(Area.TYPE), comboBoxType.SelectedItem.ToString()))).ToList();
            }
            if (!comboBoxName.SelectedItem.ToString().Equals("All"))
            {
                areas = areas.Where(a => a.Name.Equals(comboBoxName.SelectedItem.ToString())).ToList();
                comboBoxPlace.Items.Clear();
                comboBoxPlace.Items.Add("All");
                foreach (Area area in areas)
                {
                    foreach (var place in area.Place)
                    {
                        comboBoxPlace.Items.Add(place.Key);
                    }
                }
            }

            comboBoxPlace.Sorted = true;
            comboBoxPlace.SelectedItem = "All";
        }
        private void PriceDelete(int index)
        {
            _intBoo.Prices.Remove((Price)dataGridViewPrices.Rows[index].Tag);
            RefreshData();
        }
        private void PriceUp(int index)
        {
            ((Price)dataGridViewPrices.Rows[index].Tag).Priority = ((Price)dataGridViewPrices.Rows[index].Tag).Priority + 1;
            RefreshData();
        }
        private void PriceDown(int index)
        {
            ((Price)dataGridViewPrices.Rows[index].Tag).Priority = ((Price)dataGridViewPrices.Rows[index].Tag).Priority - 1;
            RefreshData();
        }
        private void PriceAdd()
        {
            Price p = new Price();
            p.Amount = numericUpDownAmount.Value;
            p.Priority = (int)numericUpDownPriority.Value;
            p.DateStart = dateTimePickerStart.Value;
            p.DateEnd = dateTimePickerEnd.Value;
            p.Type = comboBoxType.SelectedItem.ToString();
            p.Name = comboBoxName.SelectedItem.ToString();
            p.Place = comboBoxPlace.SelectedItem.ToString();

            _intBoo.Prices.Add(p);
            RefreshData();
        }
        private void UpdateSize()
        {
            dataGridViewPrices.Height = dataGridViewPrices.Rows.Count > 0 ? (dataGridViewPrices.Rows.Count * 22) + 25 : 0;
            if (HeightChanged != null) { HeightChanged(dataGridViewPrices.Height + groupBoxAdd.Height + 20); }
        }
        #endregion

        #region Event
        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            PriceAdd();
        }
        private void dataGridViewPrices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDelete.Index)
            {
                PriceDelete(e.RowIndex);
            }
            else if (e.ColumnIndex == ColumnUp.Index)
            {
                PriceUp(e.RowIndex);
            }
            else if (e.ColumnIndex == ColumnDown.Index)
            {
                PriceDown(e.RowIndex);
            }
        }
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadName();
        }
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPlace();
        }
        #endregion
    }
}
