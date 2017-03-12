using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public partial class ViewAreaEdit : UserControlCustom, IView
    {
        #region Attribute
        private Interface_booking _intBoo;

        private IContainer components = null;
        private Label labelName;
        private TextBox textBoxName;
        private Label label1;
        private ComboBox comboBoxType;
        private NumericUpDown numericUpDownFloor;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDownCapacity;
        private Label label4;
        private ColorDialog colorDialog1;
        private TextBox textBoxColor;
        private Button buttonColor;
        private TextBox textBoxDescription;
        private Label label5;
        private Button buttonSave;
        private Button buttonCancel;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewAreaEdit()
        {
            InitializeComponent();
        }
        public ViewAreaEdit(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {
            comboBoxType.Items.Clear();
            foreach (Area.TYPE type in Enum.GetValues(typeof(Area.TYPE)))
            {
                comboBoxType.Items.Add(type.ToString());
            }

            if (_intBoo.CurrentArea != null)
            {
                textBoxName.Text = _intBoo.CurrentArea.Name;
                textBoxColor.BackColor = _intBoo.CurrentArea.Color;
                textBoxColor.Text = _intBoo.CurrentArea.Color.Name;
                numericUpDownFloor.Value = _intBoo.CurrentArea.Floor;
                numericUpDownCapacity.Value = _intBoo.CurrentArea.Capacity;

                foreach (var item in comboBoxType.Items)
                {
                    if (item.ToString().Equals(_intBoo.CurrentArea.Type.ToString()))
                    {
                        comboBoxType.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        public void ChangeLanguage()
        {
            labelName.Text = GetText.Text("Name") + " : ";
            label1.Text = GetText.Text("Type") + " : ";
            label2.Text = GetText.Text("Floor") + " : ";
            label3.Text = GetText.Text("Capacity") + " : ";
            label4.Text = GetText.Text("Color") + " : ";
            buttonColor.Text = GetText.Text("Choose");
            label5.Text = GetText.Text("Comment") + " : ";
            buttonSave.Text = GetText.Text("Save");
            buttonCancel.Text = GetText.Text("Cancel");
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
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.numericUpDownFloor = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.buttonColor = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(3, 6);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 17);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name : ";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(115, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(237, 24);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type : ";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(115, 31);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(237, 23);
            this.comboBoxType.TabIndex = 3;
            // 
            // numericUpDownFloor
            // 
            this.numericUpDownFloor.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFloor.Location = new System.Drawing.Point(115, 60);
            this.numericUpDownFloor.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownFloor.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numericUpDownFloor.Name = "numericUpDownFloor";
            this.numericUpDownFloor.Size = new System.Drawing.Size(60, 24);
            this.numericUpDownFloor.TabIndex = 4;
            this.numericUpDownFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Floor : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(195, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Capacity : ";
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCapacity.Location = new System.Drawing.Point(292, 60);
            this.numericUpDownCapacity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(60, 24);
            this.numericUpDownCapacity.TabIndex = 7;
            this.numericUpDownCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Color : ";
            // 
            // textBoxColor
            // 
            this.textBoxColor.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxColor.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxColor.Location = new System.Drawing.Point(115, 89);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(146, 24);
            this.textBoxColor.TabIndex = 9;
            this.textBoxColor.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxColor_Validating);
            // 
            // buttonColor
            // 
            this.buttonColor.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonColor.Location = new System.Drawing.Point(267, 89);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(85, 27);
            this.buttonColor.TabIndex = 10;
            this.buttonColor.Text = "Choose";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(115, 117);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(237, 110);
            this.textBoxDescription.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Comment : ";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(267, 233);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 27);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(176, 233);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 27);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ViewAreaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.textBoxColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownCapacity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownFloor);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "ViewAreaEdit";
            this.Size = new System.Drawing.Size(357, 265);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void Init()
        {
            RefreshData();
            ChangeLanguage();
        }
        #endregion

        #region Event
        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxColor.BackColor = colorDialog1.Color;
                textBoxColor.Text = colorDialog1.Color.Name;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_intBoo.CurrentArea == null) _intBoo.CurrentArea = new Area();

            _intBoo.CurrentArea.Capacity = (int)numericUpDownCapacity.Value;
            _intBoo.CurrentArea.Floor = (int)numericUpDownFloor.Value;
            _intBoo.CurrentArea.Name = textBoxName.Text;
            _intBoo.CurrentArea.Color = textBoxColor.BackColor;
            _intBoo.CurrentArea.Comment = textBoxDescription.Text;
            _intBoo.CurrentArea.Type = (Area.TYPE)Enum.Parse(typeof(Area.TYPE), comboBoxType.SelectedItem.ToString());
            _intBoo.CurrentArea.Save(_intBoo._directoryArea);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
        private void textBoxColor_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxColor.Text))
            {
                Color col = Color.FromName(textBoxColor.Text);
                textBoxColor.BackColor = Color.FromName(textBoxColor.Text);
            }
            else
            {
                textBoxColor.Text = string.Empty;
                textBoxColor.BackColor = Color.FromName("Control");
            }
        }
        #endregion
    }
}
