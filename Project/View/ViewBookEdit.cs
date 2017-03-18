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
            Area area;
            Person user;
            if (_intBoo != null)
            {
                LoadArea();
                LoadPerson();
                if (_intBoo.CurrentBooking != null)
                {
                    foreach (var item in comboBoxArea.Items)
                    {
                        area = Area.GetAreaFromId(_intBoo.CurrentBooking.AreaId, _intBoo.Areas);
                        user = Person.GetPersonFromId(_intBoo.CurrentBooking.UserId, _intBoo.Persons);
                        if (item.Equals(area.Type + " - " + area.Name))
                        {
                            comboBoxArea.SelectedItem = item;
                            break;
                        }
                        if (item.Equals(user.FirstName.Firstname + " " + user.FamilyName))
                        {
                            comboBoxPerson.SelectedItem = item;
                            break;
                        }
                        dateTimePickerCheckOut.Value = _intBoo.CurrentBooking.CheckOut;
                        dateTimePickerCheckIn.Value = _intBoo.CurrentBooking.CheckIn;
                        textBoxPrice.Text = _intBoo.CurrentBooking.Price.ToString();
                        textBoxPaid.Text = _intBoo.CurrentBooking.Paid.ToString();
                        checkBoxConfirmed.Checked = _intBoo.CurrentBooking.Confirmed;
                    }
                }
                else
                {
                    dateTimePickerCheckOut.Value = DateTime.Now.AddDays(1);
                    dateTimePickerCheckIn.Value = DateTime.Now;
                }
            }
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
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(92, 91);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerCheckIn.TabIndex = 0;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.Color.White;
            this.labelStart.Location = new System.Drawing.Point(3, 92);
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
            this.checkBoxConfirmed.Location = new System.Drawing.Point(7, 213);
            this.checkBoxConfirmed.Name = "checkBoxConfirmed";
            this.checkBoxConfirmed.Size = new System.Drawing.Size(131, 21);
            this.checkBoxConfirmed.TabIndex = 7;
            this.checkBoxConfirmed.Text = "Confirmation done";
            this.checkBoxConfirmed.UseVisualStyleBackColor = true;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrice.Location = new System.Drawing.Point(192, 149);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrice.TabIndex = 8;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(3, 149);
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
            this.labelPaid.Location = new System.Drawing.Point(3, 178);
            this.labelPaid.Name = "labelPaid";
            this.labelPaid.Size = new System.Drawing.Size(90, 17);
            this.labelPaid.TabIndex = 11;
            this.labelPaid.Text = "Amount paid : ";
            // 
            // textBoxPaid
            // 
            this.textBoxPaid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPaid.Location = new System.Drawing.Point(192, 178);
            this.textBoxPaid.Name = "textBoxPaid";
            this.textBoxPaid.Size = new System.Drawing.Size(100, 23);
            this.textBoxPaid.TabIndex = 10;
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
            this.comboBoxArea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArea.FormattingEnabled = true;
            this.comboBoxArea.Location = new System.Drawing.Point(92, -3);
            this.comboBoxArea.Name = "comboBoxPlace";
            this.comboBoxArea.Size = new System.Drawing.Size(200, 23);
            this.comboBoxArea.TabIndex = 13;
            this.comboBoxArea.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxArea.SelectedIndexChanged += new System.EventHandler(this.comboBoxArea_SelectedIndexChanged);
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace.ForeColor = System.Drawing.Color.White;
            this.labelPlace.Location = new System.Drawing.Point(3, 32);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(45, 17);
            this.labelPlace.TabIndex = 12;
            this.labelPlace.Text = "Place : ";
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(92, 29);
            this.comboBoxPlace.Name = "comboBoxArea";
            this.comboBoxPlace.Size = new System.Drawing.Size(200, 23);
            this.comboBoxPlace.TabIndex = 13;
            this.comboBoxPlace.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPlace.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlace_SelectedIndexChanged);
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.Location = new System.Drawing.Point(197, 245);
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
            this.buttonCancel.Location = new System.Drawing.Point(116, 245);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(92, 60);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(175, 23);
            this.comboBoxPerson.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPerson.TabIndex = 17;
            // 
            // labelPerson
            // 
            this.labelPerson.AutoSize = true;
            this.labelPerson.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerson.ForeColor = System.Drawing.Color.White;
            this.labelPerson.Location = new System.Drawing.Point(3, 60);
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
            this.buttonAddPerson.Location = new System.Drawing.Point(276, 66);
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
            this.Size = new System.Drawing.Size(296, 275);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadArea()
        {
            comboBoxArea.Items.Clear();
            foreach (var item in _intBoo.Areas)
            {
                comboBoxArea.Items.Add(item.Type.ToString() + " - " + item.Name);
            }
        }
        private void LoadPerson()
        {
            comboBoxPerson.Items.Clear();
            foreach (var item in _intBoo.Persons)
            {
                comboBoxPerson.Items.Add(item.FirstName.Firstname + " " + item.FamilyName);
            }
        }
        private void LoadPlace()
        {
            comboBoxPlace.Items.Clear();
            foreach (var item in _intBoo.CurrentArea.Place)
            {
                comboBoxPlace.Items.Add(item.Key);
            }
        }
        private void SaveBook()
        {
            if (_intBoo.CurrentBooking == null) _intBoo.CurrentBooking = new Booking();

            Area filterArea = Area.GetArea(comboBoxArea.SelectedItem, _intBoo.Areas);
            Person filterPerson = Person.GetUserByText(comboBoxPerson.SelectedItem, _intBoo.Persons);

            if (filterArea != null) _intBoo.CurrentBooking.AreaId = filterArea.Id;
            if (filterPerson != null) _intBoo.CurrentBooking.UserId = filterPerson.Id;
            _intBoo.CurrentBooking.CheckIn = dateTimePickerCheckIn.Value;
            _intBoo.CurrentBooking.CheckOut = dateTimePickerCheckOut.Value;
            _intBoo.CurrentBooking.Confirmed = checkBoxConfirmed.Checked;
            _intBoo.CurrentBooking.Paid = decimal.Parse(textBoxPaid.Text);
            _intBoo.CurrentBooking.Price = decimal.Parse(textBoxPrice.Text);
            _intBoo.CurrentBooking.Save(_intBoo._directoryBook);
        }
        private void GetPrice()
        {
            if (_intBoo.CurrentPrice != null) textBoxPrice.Text = _intBoo.CurrentPrice.Amount.ToString();
        }
        #endregion

        #region Event
        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveBook();
        }
        private void comboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            _intBoo.CurrentArea = Area.GetArea(comboBoxArea.SelectedItem, _intBoo.Areas);
            _intBoo.GoAction("getprice");
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
