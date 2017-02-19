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
    public partial class ViewBookEdit : UserControl
    {
        #region Attribute
        private Interface_booking _intBoo;

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBoxConfirmed;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelPaid;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxArea;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonAddUser;
        private PanelShield panelShield1;
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
            InitializeComponentSpecialized();
            Init();
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {
            if (_intBoo != null)
            {
                comboBoxArea.Items.Clear();
                foreach (var item in _intBoo.Areas)
                {
                    comboBoxArea.Items.Add(item.Type.ToString() + " - " + item.Name);
                }
                comboBoxUser.Items.Clear();
                foreach (var item in _intBoo.Users)
                {
                    comboBoxUser.Items.Add(item.FirstName + " " + item.FamilyName);
                }
            }
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBookEdit));
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBoxConfirmed = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelPaid = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxArea = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.panelShield1 = new Droid_Booking.PanelShield();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(72, 59);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.ForeColor = System.Drawing.Color.White;
            this.labelStart.Location = new System.Drawing.Point(3, 62);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(51, 19);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "Start : ";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnd.ForeColor = System.Drawing.Color.White;
            this.labelEnd.Location = new System.Drawing.Point(3, 91);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(45, 19);
            this.labelEnd.TabIndex = 6;
            this.labelEnd.Text = "End : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // checkBoxConfirmed
            // 
            this.checkBoxConfirmed.AutoSize = true;
            this.checkBoxConfirmed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConfirmed.ForeColor = System.Drawing.Color.White;
            this.checkBoxConfirmed.Location = new System.Drawing.Point(7, 180);
            this.checkBoxConfirmed.Name = "checkBoxConfirmed";
            this.checkBoxConfirmed.Size = new System.Drawing.Size(147, 23);
            this.checkBoxConfirmed.TabIndex = 7;
            this.checkBoxConfirmed.Text = "Confirmation done";
            this.checkBoxConfirmed.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(172, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 8;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(3, 117);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(130, 19);
            this.labelPrice.TabIndex = 9;
            this.labelPrice.Text = "Price of the book : ";
            // 
            // labelPaid
            // 
            this.labelPaid.AutoSize = true;
            this.labelPaid.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaid.ForeColor = System.Drawing.Color.White;
            this.labelPaid.Location = new System.Drawing.Point(3, 146);
            this.labelPaid.Name = "labelPaid";
            this.labelPaid.Size = new System.Drawing.Size(103, 19);
            this.labelPaid.TabIndex = 11;
            this.labelPaid.Text = "Amount paid : ";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(172, 146);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 10;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.White;
            this.labelType.Location = new System.Drawing.Point(3, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(51, 19);
            this.labelType.TabIndex = 12;
            this.labelType.Text = "Area : ";
            // 
            // comboBoxArea
            // 
            this.comboBoxArea.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArea.FormattingEnabled = true;
            this.comboBoxArea.Location = new System.Drawing.Point(72, -3);
            this.comboBoxArea.Name = "comboBoxArea";
            this.comboBoxArea.Size = new System.Drawing.Size(200, 27);
            this.comboBoxArea.TabIndex = 13;
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.Location = new System.Drawing.Point(197, 213);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 14;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(116, 213);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(72, 28);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(175, 27);
            this.comboBoxUser.TabIndex = 17;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(3, 31);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(51, 19);
            this.labelUser.TabIndex = 16;
            this.labelUser.Text = "User : ";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddUser.BackgroundImage")));
            this.buttonAddUser.FlatAppearance.BorderSize = 0;
            this.buttonAddUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddUser.Location = new System.Drawing.Point(256, 34);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(16, 16);
            this.buttonAddUser.TabIndex = 18;
            this.buttonAddUser.UseVisualStyleBackColor = true;
            // 
            // panelShield1
            // 
            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
            this.panelShield1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShield1.Location = new System.Drawing.Point(0, 0);
            this.panelShield1.Name = "panelShield1";
            this.panelShield1.Size = new System.Drawing.Size(330, 300);
            this.panelShield1.TabIndex = 19;
            // 
            // ViewBookEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;;
            this.Controls.Add(this.panelShield1);
            this.Name = "ViewBookEdit";
            this.Size = new System.Drawing.Size(330, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitializeComponentSpecialized()
        {
            panelShield1.panelMiddle.Controls.Add(this.buttonAddUser);
            panelShield1.panelMiddle.Controls.Add(this.comboBoxUser);
            panelShield1.panelMiddle.Controls.Add(this.labelUser);
            panelShield1.panelMiddle.Controls.Add(this.buttonCancel);
            panelShield1.panelMiddle.Controls.Add(this.buttonApply);
            panelShield1.panelMiddle.Controls.Add(this.comboBoxArea);
            panelShield1.panelMiddle.Controls.Add(this.labelType);
            panelShield1.panelMiddle.Controls.Add(this.labelPaid);
            panelShield1.panelMiddle.Controls.Add(this.textBox2);
            panelShield1.panelMiddle.Controls.Add(this.labelPrice);
            panelShield1.panelMiddle.Controls.Add(this.textBox1);
            panelShield1.panelMiddle.Controls.Add(this.checkBoxConfirmed);
            panelShield1.panelMiddle.Controls.Add(this.labelEnd);
            panelShield1.panelMiddle.Controls.Add(this.dateTimePicker1);
            panelShield1.panelMiddle.Controls.Add(this.labelStart);
            panelShield1.panelMiddle.Controls.Add(this.dateTimePickerStart);
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
        }
        #endregion

        #region Event
        private void buttonAddUser_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
