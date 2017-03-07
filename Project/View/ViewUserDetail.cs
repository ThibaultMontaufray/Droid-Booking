//using Droid_People;
//using System.Windows.Forms;

//namespace Droid_Booking
//{
//    public partial class ViewUserDetail : UserControl, IView
//    {
//        #region Attributes
//        private System.ComponentModel.IContainer components = null;

//        private PanelShield panelShield1;
//        private PictureBox pictureBox;
//        private Label labelFamilyName;
//        private Label labelFirstname;
//        private TextBox textBoxComment;
//        private Label labelNationality;
//        private Label labelId;
//        private Label labelMail;
//        private Label labelGender;

//        private Person _currentPerson;
//        #endregion

//        #region Properties
//        #endregion

//        #region Constructor
//        public ViewUserDetail()
//        {
//            InitializeComponent();
//            InitializeComponentSpecialized();
//            Init();
//        }
//        #endregion

//        #region Methods public
//        public void LoadUser(Person user)
//        {
//            if (user != null)
//            {
//                _currentPerson = user;
//                labelNationality.Text = user.Nationality;
//                labelFamilyName.Text = user.FamilyName;
//                labelFirstname.Text = user.FirstName;
//                labelGender.Text = GetText.Text("Gender") + " : " + user.Gender;
//                labelId.Text = GetText.Text("Id") + " : " + user.Id;
//                labelMail.Text = user.Mail;
//                textBoxComment.Text = user.Comment;
//                pictureBox.Image = user.Picture;
//           }
//        }
//        public void ChangeLanguage()
//        {
//            this.labelFamilyName.Text = GetText.Text("FamilyName");
//            this.labelFirstname.Text = GetText.Text("FirstName");
//            this.labelNationality.Text = GetText.Text("Nationality");
//            this.labelId.Text = GetText.Text("Id") + " : ";
//            this.labelMail.Text = GetText.Text("Mail") + " : ";
//            this.labelGender.Text = GetText.Text("Gender") + " : "; 

//            LoadUser(_currentPerson);
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
//            ChangeLanguage();
//        }
//        private void InitializeComponent()
//        {
//            this.pictureBox = new System.Windows.Forms.PictureBox();
//            this.labelFamilyName = new System.Windows.Forms.Label();
//            this.labelFirstname = new System.Windows.Forms.Label();
//            this.textBoxComment = new System.Windows.Forms.TextBox();
//            this.labelNationality = new System.Windows.Forms.Label();
//            this.labelId = new System.Windows.Forms.Label();
//            this.labelMail = new System.Windows.Forms.Label();
//            this.labelGender = new System.Windows.Forms.Label();
//            this.panelShield1 = new Droid_Booking.PanelShield();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // pictureBox1
//            // 
//            this.pictureBox.Location = new System.Drawing.Point(20, 106);
//            this.pictureBox.Name = "pictureBox1";
//            this.pictureBox.Size = new System.Drawing.Size(150, 200);
//            this.pictureBox.TabIndex = 1;
//            this.pictureBox.TabStop = false;
//            // 
//            // labelFamilyName
//            // 
//            this.labelFamilyName.Font = new System.Drawing.Font("Calibri", 24F);
//            this.labelFamilyName.ForeColor = System.Drawing.Color.White;
//            this.labelFamilyName.Location = new System.Drawing.Point(20, 62);
//            this.labelFamilyName.Name = "labelFamilyName";
//            this.labelFamilyName.Size = new System.Drawing.Size(363, 41);
//            this.labelFamilyName.TabIndex = 16;
//            this.labelFamilyName.Text = "Family name";
//            this.labelFamilyName.AutoSize = false;
//            // 
//            // labelFirstname
//            // 
//            this.labelFirstname.Font = new System.Drawing.Font("Calibri", 18F);
//            this.labelFirstname.ForeColor = System.Drawing.Color.White;
//            this.labelFirstname.Location = new System.Drawing.Point(20, 29);
//            this.labelFirstname.Name = "labelFirstname";
//            this.labelFirstname.Size = new System.Drawing.Size(363, 31);
//            this.labelFirstname.TabIndex = 17;
//            this.labelFirstname.Text = "First name";
//            this.labelFirstname.AutoSize = false;
//            // 
//            // textBoxComment
//            // 
//            this.textBoxComment.BackColor = System.Drawing.Color.DimGray;
//            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.textBoxComment.Font = new System.Drawing.Font("Calibri", 11F);
//            this.textBoxComment.ForeColor = System.Drawing.Color.White;
//            this.textBoxComment.Location = new System.Drawing.Point(178, 114);
//            this.textBoxComment.Multiline = true;
//            this.textBoxComment.Name = "textBoxComment";
//            this.textBoxComment.Size = new System.Drawing.Size(450, 192);
//            this.textBoxComment.TabIndex = 18;
//            // 
//            // labelNationality
//            // 
//            this.labelNationality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.labelNationality.Font = new System.Drawing.Font("Calibri", 11F);
//            this.labelNationality.ForeColor = System.Drawing.Color.White;
//            this.labelNationality.Location = new System.Drawing.Point(389, 29);
//            this.labelNationality.Name = "labelNationality";
//            this.labelNationality.Size = new System.Drawing.Size(220, 18);
//            this.labelNationality.TabIndex = 19;
//            this.labelNationality.Text = "Nationality";
//            this.labelNationality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            this.labelNationality.AutoSize = false;
//            // 
//            // labelId
//            // 
//            this.labelId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.labelId.Font = new System.Drawing.Font("Calibri", 11F);
//            this.labelId.ForeColor = System.Drawing.Color.White;
//            this.labelId.Location = new System.Drawing.Point(389, 47);
//            this.labelId.Name = "labelId";
//            this.labelId.Size = new System.Drawing.Size(220, 18);
//            this.labelId.TabIndex = 20;
//            this.labelId.Text = "Id : ";
//            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            this.labelId.AutoSize = false;
//            // 
//            // labelMail
//            // 
//            this.labelMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.labelMail.Font = new System.Drawing.Font("Calibri", 11F);
//            this.labelMail.ForeColor = System.Drawing.Color.White;
//            this.labelMail.Location = new System.Drawing.Point(389, 65);
//            this.labelMail.Name = "labelMail";
//            this.labelMail.Size = new System.Drawing.Size(220, 18);
//            this.labelMail.TabIndex = 21;
//            this.labelMail.Text = "Mail : ";
//            this.labelMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            this.labelMail.AutoSize = false;
//            // 
//            // labelGender
//            // 
//            this.labelGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.labelGender.Font = new System.Drawing.Font("Calibri", 11F);
//            this.labelGender.ForeColor = System.Drawing.Color.White;
//            this.labelGender.Location = new System.Drawing.Point(389, 83);
//            this.labelGender.Name = "labelGender";
//            this.labelGender.Size = new System.Drawing.Size(220, 18);
//            this.labelGender.TabIndex = 22;
//            this.labelGender.Text = "Gender : ";
//            this.labelGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            this.labelGender.AutoSize = false;
//            // 
//            // panelShield1
//            // 
//            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
//            this.panelShield1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.panelShield1.Location = new System.Drawing.Point(0, 0);
//            this.panelShield1.Name = "panelShield1";
//            this.panelShield1.Size = new System.Drawing.Size(629, 331);
//            this.panelShield1.TabIndex = 0;
//            // 
//            // ViewUserDetail
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.Transparent;
//            this.Controls.Add(this.panelShield1);
//            this.Name = "ViewUserDetail";
//            this.Size = new System.Drawing.Size(660, 331);
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }
//        private void InitializeComponentSpecialized()
//        {
//            panelShield1.panelMiddle.Controls.Add(this.labelGender);
//            panelShield1.panelMiddle.Controls.Add(this.labelMail);
//            panelShield1.panelMiddle.Controls.Add(this.labelId);
//            panelShield1.panelMiddle.Controls.Add(this.labelNationality);
//            panelShield1.panelMiddle.Controls.Add(this.textBoxComment);
//            panelShield1.panelMiddle.Controls.Add(this.labelFirstname);
//            panelShield1.panelMiddle.Controls.Add(this.labelFamilyName);
//            panelShield1.panelMiddle.Controls.Add(this.pictureBox);
//        }
//        #endregion

//        #region Event
//        #endregion
//    }
//}
