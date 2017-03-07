//using Droid_People;
//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Droid_Booking
//{
//    public partial class ViewUserEdit : UserControl, IView
//    {
//        #region Atrtibute
//        private Interface_booking _intBoo;

//        private System.ComponentModel.IContainer components = null;
//        private System.Windows.Forms.PictureBox pictureBox;
//        private System.Windows.Forms.Label labelName;
//        private System.Windows.Forms.TextBox textBoxFirstname;
//        private System.Windows.Forms.TextBox textBoxFamilyName;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.TextBox textBoxNationality;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox textBoxId;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.TextBox textBoxMail;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.TextBox textBoxComment;
//        private System.Windows.Forms.ComboBox comboBoxGender;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Button buttonApply;
//        private PanelShield panelShield1;
//        private PanelShield panelShield2;
//        private PictureBox pictureBoxPasport;
//        private System.Windows.Forms.Button buttonCancel;
//        #endregion

//        #region Properties
//        #endregion

//        #region Constructor
//        public ViewUserEdit()
//        {
//            InitializeComponent();
//        }
//        public ViewUserEdit(Interface_booking intBoo)
//        {
//            _intBoo = intBoo;

//            InitializeComponent();
//            InitializeComponentSpecialized();
//            Init();
//        }
//        #endregion

//        #region Methods public
//        public void RefreshData()
//        {
//            if (_intBoo != null && _intBoo.CurrentPerson != null)
//            {
//                textBoxComment.Text = _intBoo.CurrentPerson.Comment;
//                textBoxNationality.Text = _intBoo.CurrentPerson.Nationality;
//                textBoxFamilyName.Text = _intBoo.CurrentPerson.FamilyName;
//                textBoxFirstname.Text = _intBoo.CurrentPerson.FirstName;
//                textBoxId.Text = _intBoo.CurrentPerson.Id;
//                textBoxMail.Text = _intBoo.CurrentPerson.Mail;
//                pictureBox.BackgroundImage = _intBoo.CurrentPerson.Picture[0];
//                pictureBoxPasport.BackgroundImage = _intBoo.CurrentPerson.Passport;

//                foreach (var item in comboBoxGender.Items)
//                {
//                    if (item.ToString().Equals(_intBoo.CurrentPerson.Gender.ToString()))
//                    {
//                        comboBoxGender.SelectedItem = item;
//                        break;
//                    }
//                }
//            }
//        }
//        public void ChangeLanguage()
//        {
//            labelName.Text = GetText.Text("FirstName");
//            label1.Text = GetText.Text("FamilyName") + " : ";
//            label2.Text = GetText.Text("Nationality") + " : ";
//            label3.Text = GetText.Text("Id") + " : ";
//            label4.Text = GetText.Text("Gender") + " : ";
//            label5.Text = GetText.Text("Mail") + " : ";
//            label6.Text = GetText.Text("Comment") + " : ";
//            buttonApply.Text = GetText.Text("Save");
//            buttonCancel.Text = GetText.Text("Cancel");
//        }
//        #endregion

//        #region Methods protected
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//        #endregion

//        #region Methods private
//        private void Init()
//        {
//            comboBoxGender.Items.Clear();
//            foreach (Person.GENDER gender in Enum.GetValues(typeof(Person.GENDER)))
//            {
//                comboBoxGender.Items.Add(gender.ToString());
//            }
//            RefreshData();
//            ChangeLanguage();
//        }
//        private void InitializeComponentSpecialized()
//        {
//            panelShield1.panelMiddle.Controls.Add(this.buttonCancel);
//            panelShield1.panelMiddle.Controls.Add(this.buttonApply);
//            panelShield1.panelMiddle.Controls.Add(this.label6);
//            panelShield1.panelMiddle.Controls.Add(this.comboBoxGender);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxComment);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxMail);
//            panelShield1.panelMiddle.Controls.Add(this.label5);
//            panelShield1.panelMiddle.Controls.Add(this.label4);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxId);
//            panelShield1.panelMiddle.Controls.Add(this.label3);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxNationality);
//            panelShield1.panelMiddle.Controls.Add(this.label2);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxFamilyName);
//            panelShield1.panelMiddle.Controls.Add(this.label1);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxFirstname);
//            panelShield1.panelMiddle.Controls.Add(this.labelName);
//            panelShield1.panelMiddle.Controls.Add(this.pictureBox);
//        }
//        private void InitializeComponent()
//        {
//            this.labelName = new System.Windows.Forms.Label();
//            this.textBoxFirstname = new System.Windows.Forms.TextBox();
//            this.textBoxFamilyName = new System.Windows.Forms.TextBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.textBoxNationality = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.textBoxId = new System.Windows.Forms.TextBox();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.textBoxMail = new System.Windows.Forms.TextBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.textBoxComment = new System.Windows.Forms.TextBox();
//            this.comboBoxGender = new System.Windows.Forms.ComboBox();
//            this.label6 = new System.Windows.Forms.Label();
//            this.buttonApply = new System.Windows.Forms.Button();
//            this.buttonCancel = new System.Windows.Forms.Button();
//            this.pictureBoxPasport = new System.Windows.Forms.PictureBox();
//            this.pictureBox = new System.Windows.Forms.PictureBox();
//            this.panelShield2 = new Droid_Booking.PanelShield();
//            this.panelShield1 = new Droid_Booking.PanelShield();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasport)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // labelName
//            // 
//            this.labelName.AutoSize = true;
//            this.labelName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelName.ForeColor = System.Drawing.Color.White;
//            this.labelName.Location = new System.Drawing.Point(159, 6);
//            this.labelName.Name = "labelName";
//            this.labelName.Size = new System.Drawing.Size(89, 19);
//            this.labelName.TabIndex = 4;
//            this.labelName.Text = "First name : ";
//            // 
//            // textBoxFirstname
//            // 
//            this.textBoxFirstname.BackColor = System.Drawing.Color.Gainsboro;
//            this.textBoxFirstname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBoxFirstname.Location = new System.Drawing.Point(276, 3);
//            this.textBoxFirstname.Name = "textBoxFirstname";
//            this.textBoxFirstname.Size = new System.Drawing.Size(290, 27);
//            this.textBoxFirstname.TabIndex = 13;
//            // 
//            // textBoxFamilyName
//            // 
//            this.textBoxFamilyName.BackColor = System.Drawing.Color.Gainsboro;
//            this.textBoxFamilyName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBoxFamilyName.Location = new System.Drawing.Point(276, 31);
//            this.textBoxFamilyName.Name = "textBoxFamilyName";
//            this.textBoxFamilyName.Size = new System.Drawing.Size(290, 27);
//            this.textBoxFamilyName.TabIndex = 15;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.ForeColor = System.Drawing.Color.White;
//            this.label1.Location = new System.Drawing.Point(159, 34);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(103, 19);
//            this.label1.TabIndex = 14;
//            this.label1.Text = "Family name : ";
//            // 
//            // textBoxNationality
//            // 
//            this.textBoxNationality.BackColor = System.Drawing.Color.Gainsboro;
//            this.textBoxNationality.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBoxNationality.Location = new System.Drawing.Point(276, 59);
//            this.textBoxNationality.Name = "textBoxNationality";
//            this.textBoxNationality.Size = new System.Drawing.Size(290, 27);
//            this.textBoxNationality.TabIndex = 17;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.ForeColor = System.Drawing.Color.White;
//            this.label2.Location = new System.Drawing.Point(159, 62);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(71, 19);
//            this.label2.TabIndex = 16;
//            this.label2.Text = "Nationality : ";
//            // 
//            // textBoxId
//            // 
//            this.textBoxId.BackColor = System.Drawing.Color.Gainsboro;
//            this.textBoxId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBoxId.Location = new System.Drawing.Point(276, 87);
//            this.textBoxId.Name = "textBoxId";
//            this.textBoxId.Size = new System.Drawing.Size(290, 27);
//            this.textBoxId.TabIndex = 19;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.ForeColor = System.Drawing.Color.White;
//            this.label3.Location = new System.Drawing.Point(159, 90);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(33, 19);
//            this.label3.TabIndex = 18;
//            this.label3.Text = "Id : ";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.ForeColor = System.Drawing.Color.White;
//            this.label4.Location = new System.Drawing.Point(159, 118);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(68, 19);
//            this.label4.TabIndex = 20;
//            this.label4.Text = "Gender : ";
//            // 
//            // textBoxMail
//            // 
//            this.textBoxMail.BackColor = System.Drawing.Color.Gainsboro;
//            this.textBoxMail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBoxMail.Location = new System.Drawing.Point(276, 143);
//            this.textBoxMail.Name = "textBoxMail";
//            this.textBoxMail.Size = new System.Drawing.Size(290, 27);
//            this.textBoxMail.TabIndex = 23;
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.ForeColor = System.Drawing.Color.White;
//            this.label5.Location = new System.Drawing.Point(159, 146);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(50, 19);
//            this.label5.TabIndex = 22;
//            this.label5.Text = "Mail : ";
//            // 
//            // textBoxComment
//            // 
//            this.textBoxComment.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.textBoxComment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBoxComment.Location = new System.Drawing.Point(3, 209);
//            this.textBoxComment.Multiline = true;
//            this.textBoxComment.Name = "textBoxComment";
//            this.textBoxComment.Size = new System.Drawing.Size(563, 100);
//            this.textBoxComment.TabIndex = 24;
//            // 
//            // comboBoxGender
//            // 
//            this.comboBoxGender.BackColor = System.Drawing.Color.Gainsboro;
//            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.comboBoxGender.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.comboBoxGender.FormattingEnabled = true;
//            this.comboBoxGender.Location = new System.Drawing.Point(276, 115);
//            this.comboBoxGender.Name = "comboBoxGender";
//            this.comboBoxGender.Size = new System.Drawing.Size(290, 27);
//            this.comboBoxGender.TabIndex = 25;
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label6.ForeColor = System.Drawing.Color.White;
//            this.label6.Location = new System.Drawing.Point(159, 174);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(79, 19);
//            this.label6.TabIndex = 26;
//            this.label6.Text = "Comment :";
//            // 
//            // buttonApply
//            // 
//            this.buttonApply.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.buttonApply.Location = new System.Drawing.Point(482, 315);
//            this.buttonApply.Name = "buttonApply";
//            this.buttonApply.Size = new System.Drawing.Size(84, 29);
//            this.buttonApply.TabIndex = 27;
//            this.buttonApply.Text = "Save";
//            this.buttonApply.UseVisualStyleBackColor = true;
//            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
//            // 
//            // buttonCancel
//            // 
//            this.buttonCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.buttonCancel.Location = new System.Drawing.Point(392, 315);
//            this.buttonCancel.Name = "buttonCancel";
//            this.buttonCancel.Size = new System.Drawing.Size(84, 29);
//            this.buttonCancel.TabIndex = 28;
//            this.buttonCancel.Text = "Cancel";
//            this.buttonCancel.UseVisualStyleBackColor = true;
//            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
//            // 
//            // pictureBoxPasesport
//            // 
//            this.pictureBoxPasport.BackColor = System.Drawing.Color.DimGray;
//            this.pictureBoxPasport.BackgroundImage = global::Droid_Booking.Properties.Resources.passeport;
//            this.pictureBoxPasport.Location = new System.Drawing.Point(651, 20);
//            this.pictureBoxPasport.Name = "pictureBoxPasesport";
//            this.pictureBoxPasport.Size = new System.Drawing.Size(320, 430);
//            this.pictureBoxPasport.TabIndex = 31;
//            this.pictureBoxPasport.TabStop = false;
//            this.pictureBoxPasport.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
//            this.pictureBoxPasport.MouseLeave += new System.EventHandler(this.pictureBoxPasesport_MouseLeave);
//            this.pictureBoxPasport.MouseHover += new System.EventHandler(this.pictureBoxPasesport_MouseHover);
//            // 
//            // pictureBox
//            // 
//            this.pictureBox.BackColor = System.Drawing.Color.DimGray;
//            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
//            this.pictureBox.Location = new System.Drawing.Point(3, 3);
//            this.pictureBox.Name = "pictureBox";
//            this.pictureBox.Size = new System.Drawing.Size(150, 200);
//            this.pictureBox.TabIndex = 0;
//            this.pictureBox.TabStop = false;
//            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
//            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
//            this.pictureBox.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
//            // 
//            // panelShield2
//            // 
//            this.panelShield2.BackColor = System.Drawing.Color.Transparent;
//            this.panelShield2.Location = new System.Drawing.Point(631, 0);
//            this.panelShield2.Name = "panelShield2";
//            this.panelShield2.Size = new System.Drawing.Size(360, 470);
//            this.panelShield2.TabIndex = 30;
//            // 
//            // panelShield1
//            // 
//            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
//            this.panelShield1.Location = new System.Drawing.Point(0, 20);
//            this.panelShield1.Name = "panelShield1";
//            this.panelShield1.Size = new System.Drawing.Size(625, 400);
//            this.panelShield1.TabIndex = 29;
//            // 
//            // ViewUserEdit
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.Transparent;
//            this.Controls.Add(this.pictureBoxPasport);
//            this.Controls.Add(this.panelShield2);
//            this.Controls.Add(this.panelShield1);
//            this.Name = "ViewUserEdit";
//            this.Size = new System.Drawing.Size(993, 546);
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasport)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
//            this.ResumeLayout(false);

        //}
//        private void SaveUser()
//        {
//            if (_intBoo.CurrentPerson == null) _intBoo.CurrentPerson = new Person(_intBoo.USER_DIRECTORY);

//            _intBoo.CurrentPerson.Passport = pictureBoxPasport.BackgroundImage;
//            _intBoo.CurrentPerson.Picture = pictureBox.BackgroundImage;
//            _intBoo.CurrentPerson.Mail = textBoxMail.Text;
//            _intBoo.CurrentPerson.Id = textBoxId.Text;
//            _intBoo.CurrentPerson.FirstName = textBoxFirstname.Text;
//            _intBoo.CurrentPerson.FamilyName = textBoxFamilyName.Text;
//            _intBoo.CurrentPerson.Nationality = textBoxNationality.Text;
//            _intBoo.CurrentPerson.Comment = textBoxComment.Text;
//            _intBoo.CurrentPerson.Save(_intBoo.USER_DIRECTORY);
//        }
//        #endregion

//        #region Event
//        private void pictureBox_MouseHover(object sender, EventArgs e)
//        {
//            Cursor = Cursors.Hand;
//        }
//        private void pictureBox_MouseLeave(object sender, EventArgs e)
//        {
//            Cursor = Cursors.Arrow;
//        }
//        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
//        {
//            OpenFileDialog ofd = new OpenFileDialog();
//            ofd.Title = "Choose picture for user profile";
//            if (ofd.ShowDialog() == DialogResult.OK)
//            {
//                pictureBox.BackgroundImage = Image.FromFile(ofd.FileName);
//            }
//        }
//        private void buttonCancel_Click(object sender, EventArgs e)
//        {

//        }
//        private void buttonApply_Click(object sender, EventArgs e)
//        {
//            SaveUser();
//        }
//        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
//        {
//            OpenFileDialog ofd = new OpenFileDialog();
//            if (ofd.ShowDialog() == DialogResult.OK)
//            {
//                pictureBoxPasport.BackgroundImage = Image.FromFile(ofd.FileName);
//                pictureBoxPasport.BackgroundImageLayout = ImageLayout.Zoom;
//            }
//        }
//        private void pictureBoxPasesport_MouseHover(object sender, EventArgs e)
//        {
//            Cursor = Cursors.Hand;
//        }
//        private void pictureBoxPasesport_MouseLeave(object sender, EventArgs e)
//        {
//            Cursor = Cursors.Arrow;
//        }
//        #endregion
//    }
//}
