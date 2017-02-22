using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewUserDetail : ViewApplication
    {
        #region Attributes
        private System.ComponentModel.IContainer components = null;

        private PanelShield panelShield1;
        private PictureBox pictureBox;
        private Label labelFamilyName;
        private Label labelFirstname;
        private TextBox textBoxComment;
        private Label labelCountry;
        private Label labelId;
        private Label labelMail;
        private Label labelGender;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewUserDetail()
        {
            InitializeComponent();
            InitializeComponentSpecialized();
        }
        #endregion

        #region Methods public
        public void LoadUser(User user)
        {
            if (user != null)
            {
                labelCountry.Text = user.Country;
                labelFamilyName.Text = user.FamilyName;
                labelFirstname.Text = user.FirstName;
                labelGender.Text = "gender : " + user.Gender;
                labelId.Text = "Id : " + user.Id;
                labelMail.Text = user.Mail;
                textBoxComment.Text = user.Comment;
                pictureBox.Image = user.Picture;
           }
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelFamilyName = new System.Windows.Forms.Label();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.panelShield1 = new Droid_Booking.PanelShield();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox.Location = new System.Drawing.Point(20, 106);
            this.pictureBox.Name = "pictureBox1";
            this.pictureBox.Size = new System.Drawing.Size(150, 200);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // labelFamilyName
            // 
            this.labelFamilyName.Font = new System.Drawing.Font("Calibri", 24F);
            this.labelFamilyName.ForeColor = System.Drawing.Color.White;
            this.labelFamilyName.Location = new System.Drawing.Point(20, 62);
            this.labelFamilyName.Name = "labelFamilyName";
            this.labelFamilyName.Size = new System.Drawing.Size(363, 41);
            this.labelFamilyName.TabIndex = 16;
            this.labelFamilyName.Text = "Family name";
            this.labelFamilyName.AutoSize = false;
            // 
            // labelFirstname
            // 
            this.labelFirstname.Font = new System.Drawing.Font("Calibri", 18F);
            this.labelFirstname.ForeColor = System.Drawing.Color.White;
            this.labelFirstname.Location = new System.Drawing.Point(20, 29);
            this.labelFirstname.Name = "labelFirstname";
            this.labelFirstname.Size = new System.Drawing.Size(363, 31);
            this.labelFirstname.TabIndex = 17;
            this.labelFirstname.Text = "First name";
            this.labelFirstname.AutoSize = false;
            // 
            // textBoxComment
            // 
            this.textBoxComment.BackColor = System.Drawing.Color.DimGray;
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxComment.Font = new System.Drawing.Font("Calibri", 11F);
            this.textBoxComment.ForeColor = System.Drawing.Color.White;
            this.textBoxComment.Location = new System.Drawing.Point(178, 114);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(450, 192);
            this.textBoxComment.TabIndex = 18;
            // 
            // labelCountry
            // 
            this.labelCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCountry.Font = new System.Drawing.Font("Calibri", 11F);
            this.labelCountry.ForeColor = System.Drawing.Color.White;
            this.labelCountry.Location = new System.Drawing.Point(389, 29);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(220, 18);
            this.labelCountry.TabIndex = 19;
            this.labelCountry.Text = "Nationality";
            this.labelCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCountry.AutoSize = false;
            // 
            // labelId
            // 
            this.labelId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelId.Font = new System.Drawing.Font("Calibri", 11F);
            this.labelId.ForeColor = System.Drawing.Color.White;
            this.labelId.Location = new System.Drawing.Point(389, 47);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(220, 18);
            this.labelId.TabIndex = 20;
            this.labelId.Text = "Id : 123456789";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelId.AutoSize = false;
            // 
            // labelMail
            // 
            this.labelMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMail.Font = new System.Drawing.Font("Calibri", 11F);
            this.labelMail.ForeColor = System.Drawing.Color.White;
            this.labelMail.Location = new System.Drawing.Point(389, 65);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(220, 18);
            this.labelMail.TabIndex = 21;
            this.labelMail.Text = "mail@mail.com";
            this.labelMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMail.AutoSize = false;
            // 
            // labelGender
            // 
            this.labelGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGender.Font = new System.Drawing.Font("Calibri", 11F);
            this.labelGender.ForeColor = System.Drawing.Color.White;
            this.labelGender.Location = new System.Drawing.Point(389, 83);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(220, 18);
            this.labelGender.TabIndex = 22;
            this.labelGender.Text = "genre unknow";
            this.labelGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelGender.AutoSize = false;
            // 
            // panelShield1
            // 
            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
            this.panelShield1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShield1.Location = new System.Drawing.Point(0, 0);
            this.panelShield1.Name = "panelShield1";
            this.panelShield1.Size = new System.Drawing.Size(629, 331);
            this.panelShield1.TabIndex = 0;
            // 
            // ViewUserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelShield1);
            this.Name = "ViewUserDetail";
            this.Size = new System.Drawing.Size(660, 331);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void InitializeComponentSpecialized()
        {
            panelShield1.panelMiddle.Controls.Add(this.labelGender);
            panelShield1.panelMiddle.Controls.Add(this.labelMail);
            panelShield1.panelMiddle.Controls.Add(this.labelId);
            panelShield1.panelMiddle.Controls.Add(this.labelCountry);
            panelShield1.panelMiddle.Controls.Add(this.textBoxComment);
            panelShield1.panelMiddle.Controls.Add(this.labelFirstname);
            panelShield1.panelMiddle.Controls.Add(this.labelFamilyName);
            panelShield1.panelMiddle.Controls.Add(this.pictureBox);
        }
        #endregion

        #region Event
        #endregion
    }
}
