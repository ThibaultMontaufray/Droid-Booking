using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Droid_People;
using Tools4Libraries;

namespace Droid_Booking
{
    public delegate void ViewBookEditEventHandler();
    public partial class ViewBookEdit : UserControlCustom, IView
    {
        #region Attribute
        public override event UserControlCustomEventHandler HeightChanged;
        public event ViewBookEditEventHandler CreatePersonRequested;

        private Interface_booking _intBoo;

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.CheckBox checkBoxConfirmed;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelPaid;
        private System.Windows.Forms.TextBox textBoxPaid;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.ComboBox comboBoxPlace;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxArea;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label labelPerson;
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
        public ViewBookEdit(Interface_booking intBoo)
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
                    textBoxPrice.Text = _intBoo.CurrentBooking.Price.ToString();
                    textBoxPaid.Text = _intBoo.CurrentBooking.Paid.ToString();
                    checkBoxConfirmed.Checked = _intBoo.CurrentBooking.Confirmed;
                    comboBoxArea.SelectedItem = Area.GetAreaFromId(_intBoo.CurrentBooking.AreaId, _intBoo.Areas);
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
            labelPaid.Text = GetText.Text("AmountPaid") + " : ";
            labelType.Text = GetText.Text("Area") + " : ";
            buttonApply.Text = GetText.Text("Save");
            buttonCancel.Text = GetText.Text("Cancel");
            labelPerson.Text = GetText.Text("User") + " : ";
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBookEdit));
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.checkBoxConfirmed = new System.Windows.Forms.CheckBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelPaid = new System.Windows.Forms.Label();
            this.textBoxPaid = new System.Windows.Forms.TextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxArea = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelPerson = new System.Windows.Forms.Label();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(92, 84);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerCheckIn.TabIndex = 0;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.Color.White;
            this.labelStart.Location = new System.Drawing.Point(3, 90);
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
            this.labelEnd.Location = new System.Drawing.Point(3, 116);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(39, 17);
            this.labelEnd.TabIndex = 6;
            this.labelEnd.Text = "End : ";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(92, 113);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerCheckOut.TabIndex = 5;
            // 
            // checkBoxConfirmed
            // 
            this.checkBoxConfirmed.AutoSize = true;
            this.checkBoxConfirmed.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConfirmed.ForeColor = System.Drawing.Color.White;
            this.checkBoxConfirmed.Location = new System.Drawing.Point(6, 206);
            this.checkBoxConfirmed.Name = "checkBoxConfirmed";
            this.checkBoxConfirmed.Size = new System.Drawing.Size(131, 21);
            this.checkBoxConfirmed.TabIndex = 7;
            this.checkBoxConfirmed.Text = "Confirmation done";
            this.checkBoxConfirmed.UseVisualStyleBackColor = true;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrice.Location = new System.Drawing.Point(193, 142);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrice.TabIndex = 8;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(4, 145);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(129, 17);
            this.labelPrice.TabIndex = 9;
            this.labelPrice.Text = "Price of the booking : ";
            // 
            // labelPaid
            // 
            this.labelPaid.AutoSize = true;
            this.labelPaid.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaid.ForeColor = System.Drawing.Color.White;
            this.labelPaid.Location = new System.Drawing.Point(3, 174);
            this.labelPaid.Name = "labelPaid";
            this.labelPaid.Size = new System.Drawing.Size(90, 17);
            this.labelPaid.TabIndex = 11;
            this.labelPaid.Text = "Amount paid : ";
            // 
            // textBoxPaid
            // 
            this.textBoxPaid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPaid.Location = new System.Drawing.Point(192, 171);
            this.textBoxPaid.Name = "textBoxPaid";
            this.textBoxPaid.Size = new System.Drawing.Size(100, 23);
            this.textBoxPaid.TabIndex = 10;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace.ForeColor = System.Drawing.Color.White;
            this.labelPlace.Location = new System.Drawing.Point(4, 29);
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
            this.comboBoxPlace.Location = new System.Drawing.Point(92, 26);
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
            this.labelType.Location = new System.Drawing.Point(3, 0);
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
            this.comboBoxArea.Location = new System.Drawing.Point(92, -3);
            this.comboBoxArea.Name = "comboBoxArea";
            this.comboBoxArea.Size = new System.Drawing.Size(200, 23);
            this.comboBoxArea.TabIndex = 13;
            this.comboBoxArea.SelectedValueChanged += new System.EventHandler(this.comboBoxArea_SelectedValueChanged);
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.Location = new System.Drawing.Point(197, 235);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(95, 23);
            this.buttonApply.TabIndex = 14;
            this.buttonApply.Text = "Save";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(116, 235);
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
            this.comboBoxPerson.Location = new System.Drawing.Point(92, 55);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(175, 23);
            this.comboBoxPerson.TabIndex = 17;
            // 
            // labelPerson
            // 
            this.labelPerson.AutoSize = true;
            this.labelPerson.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerson.ForeColor = System.Drawing.Color.White;
            this.labelPerson.Location = new System.Drawing.Point(4, 58);
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
            this.buttonAddPerson.Location = new System.Drawing.Point(273, 57);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(16, 16);
            this.buttonAddPerson.TabIndex = 18;
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // ViewBookEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonAddPerson);
            this.Controls.Add(this.comboBoxPlace);
            this.Controls.Add(this.labelPlace);
            this.Controls.Add(this.comboBoxPerson);
            this.Controls.Add(this.labelPerson);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxArea);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelPaid);
            this.Controls.Add(this.textBoxPaid);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.checkBoxConfirmed);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.dateTimePickerCheckOut);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.dateTimePickerCheckIn);
            this.Name = "ViewBookEdit";
            this.Size = new System.Drawing.Size(296, 262);
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
            _intBoo.CurrentBooking.Save(_intBoo._directoryBook);

            if (_intBoo.Bookings.Contains(_intBoo.CurrentBooking))
            {
                _intBoo.Bookings.Remove(_intBoo.CurrentBooking);
            }
            _intBoo.Bookings.Add(_intBoo.CurrentBooking);
        }
        private void UpdateCurrentBook()
        {
            if (_intBoo.CurrentBooking == null) _intBoo.CurrentBooking = new Booking();

            Area filterArea = (Area) comboBoxArea.SelectedItem;
            Person filterPerson = (Person) comboBoxPerson.SelectedItem;

            if (filterArea != null) _intBoo.CurrentBooking.AreaId = filterArea.Id;
            if (filterPerson != null) _intBoo.CurrentBooking.UserId = filterPerson.Id;
            _intBoo.CurrentBooking.CheckIn = dateTimePickerCheckIn.Value;
            _intBoo.CurrentBooking.CheckOut = dateTimePickerCheckOut.Value;
            _intBoo.CurrentBooking.Confirmed = checkBoxConfirmed.Checked;
            _intBoo.CurrentBooking.Paid = string.IsNullOrEmpty(textBoxPaid.Text) ? 0 : decimal.Parse(textBoxPaid.Text);
            _intBoo.CurrentBooking.Price = string.IsNullOrEmpty(textBoxPrice.Text) ? 0 : decimal.Parse(textBoxPrice.Text);
            _intBoo.CurrentBooking.Place = comboBoxPlace.SelectedItem == null ? string.Empty : comboBoxPlace.SelectedItem.ToString();
        }
        private void GetPrice()
        {
            //UpdateCurrentBook();
            _intBoo.GoAction("getprice");
            if (_intBoo.CurrentPrice != null) textBoxPrice.Text = _intBoo.CurrentPrice != null ? _intBoo.CurrentPrice.Amount.ToString() : string.Empty;
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
        #endregion
    }
}
