using System.ComponentModel;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewSettings : UserControl
    {
        #region Attribute
        private Interface_booking _intBoo;

        private IContainer components = null;
        private PictureBox pictureBoxFlag;
        private ComboBox comboBoxLanguage;
        private Droid_deployer.CloudView cloudView1;
        private PanelShield panelShield1;
        private Label labelLanguage;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewSettings()
        {
            InitializeComponent();
            Init();
        }
        public ViewSettings(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            Init();
            InitializeComponent();
            InitializeComponentSpecialized();
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {
            cloudView1.InterficeSyncany = _intBoo.Cloud;
            comboBoxLanguage.Text = "English";
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
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSettings));
            Droid_deployer.Interface_syncany interface_syncany2 = new Droid_deployer.Interface_syncany();
            this.pictureBoxFlag = new System.Windows.Forms.PictureBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.cloudView1 = new Droid_deployer.CloudView();
            this.panelShield1 = new Droid_Booking.PanelShield();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFlag
            // 
            this.pictureBoxFlag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFlag.BackgroundImage")));
            this.pictureBoxFlag.Location = new System.Drawing.Point(451, -3);
            this.pictureBoxFlag.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxFlag.Name = "pictureBoxFlag";
            this.pictureBoxFlag.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxFlag.TabIndex = 13;
            this.pictureBoxFlag.TabStop = false;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLanguage.ForeColor = System.Drawing.Color.Black;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "French",
            "English"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(177, -3);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(255, 27);
            this.comboBoxLanguage.TabIndex = 12;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLanguage.ForeColor = System.Drawing.Color.White;
            this.labelLanguage.Location = new System.Drawing.Point(7, 0);
            this.labelLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(84, 19);
            this.labelLanguage.TabIndex = 11;
            this.labelLanguage.Text = "Language : ";
            // 
            // cloudView1
            // 
            this.cloudView1.BackColor = System.Drawing.Color.Transparent;
            interface_syncany2.CloudConfigPath = null;
            interface_syncany2.CloudConnectionType = null;
            interface_syncany2.CloudRepositories = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>)(resources.GetObject("interface_syncany2.CloudRepositories")));
            interface_syncany2.DirectoryOriginal = null;
            interface_syncany2.DirectoryToAssociate = null;
            interface_syncany2.Login = null;
            interface_syncany2.Password = null;
            interface_syncany2.WorkingDirectory = null;
            this.cloudView1.InterficeSyncany = interface_syncany2;
            this.cloudView1.Location = new System.Drawing.Point(0, 31);
            this.cloudView1.Name = "cloudView1";
            this.cloudView1.Size = new System.Drawing.Size(719, 336);
            this.cloudView1.TabIndex = 16;
            // 
            // panelShield1
            // 
            this.panelShield1.BackColor = System.Drawing.Color.Transparent;
            this.panelShield1.Location = new System.Drawing.Point(10, 10);
            this.panelShield1.Name = "panelShield1";
            this.panelShield1.Size = new System.Drawing.Size(771, 413);
            this.panelShield1.TabIndex = 17;
            // 
            // ViewSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelShield1);
            this.Name = "ViewSettings";
            this.Size = new System.Drawing.Size(791, 433);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlag)).EndInit();
            this.ResumeLayout(false);

        }
        private void InitializeComponentSpecialized()
        {
            panelShield1.panelMiddle.Controls.Add(this.pictureBoxFlag);
            panelShield1.panelMiddle.Controls.Add(this.comboBoxLanguage);
            panelShield1.panelMiddle.Controls.Add(this.labelLanguage);
            panelShield1.panelMiddle.Controls.Add(this.cloudView1);
        }
        #endregion

        #region Event
        #endregion
    }
}
