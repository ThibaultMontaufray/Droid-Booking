using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public partial class ViewSettings : UserControlCustom, IView
    {
        #region Attribute
        public override event UserControlCustomEventHandler HeightChanged;

        private Interface_booking _intBoo;

        private IContainer components = null;
        private PictureBox pictureBoxFlag;
        private ComboBox comboBoxLanguage;
        private Label labelMaxPurgeHistory;
        private NumericUpDown numericUpDownPurge;
        private ComboBox comboBoxPurge;
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

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {
            comboBoxLanguage.Text = Properties.Settings.Default.Language;
            comboBoxPurge.Text = Properties.Settings.Default.PurgeDelay;
            numericUpDownPurge.Value = Properties.Settings.Default.PurgeValue;
        }
        public void ChangeLanguage()
        {
            this.labelLanguage.Text = string.Format("{0} : ", GetText.Text("Language"));
            this.labelMaxPurgeHistory.Text = string.Format("{0} : ", GetText.Text("PurgeHistory"));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSettings));
            this.pictureBoxFlag = new System.Windows.Forms.PictureBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelMaxPurgeHistory = new System.Windows.Forms.Label();
            this.numericUpDownPurge = new System.Windows.Forms.NumericUpDown();
            this.comboBoxPurge = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPurge)).BeginInit();
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
            this.comboBoxLanguage.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLanguage.ForeColor = System.Drawing.Color.Black;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "French",
            "English"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(177, -3);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(255, 23);
            this.comboBoxLanguage.TabIndex = 12;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLanguage.ForeColor = System.Drawing.Color.White;
            this.labelLanguage.Location = new System.Drawing.Point(7, 0);
            this.labelLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(73, 17);
            this.labelLanguage.TabIndex = 11;
            this.labelLanguage.Text = "Language : ";
            // 
            // labelMaxPurgeHistory
            // 
            this.labelMaxPurgeHistory.AutoSize = true;
            this.labelMaxPurgeHistory.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxPurgeHistory.ForeColor = System.Drawing.Color.White;
            this.labelMaxPurgeHistory.Location = new System.Drawing.Point(7, 35);
            this.labelMaxPurgeHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxPurgeHistory.Name = "labelMaxPurgeHistory";
            this.labelMaxPurgeHistory.Size = new System.Drawing.Size(142, 17);
            this.labelMaxPurgeHistory.TabIndex = 18;
            this.labelMaxPurgeHistory.Text = "Delay to purge history : ";
            // 
            // numericUpDownPurge
            // 
            this.numericUpDownPurge.Font = new System.Drawing.Font("Calibri", 10F);
            this.numericUpDownPurge.Location = new System.Drawing.Point(177, 32);
            this.numericUpDownPurge.Name = "numericUpDownPurge";
            this.numericUpDownPurge.Size = new System.Drawing.Size(76, 24);
            this.numericUpDownPurge.TabIndex = 19;
            this.numericUpDownPurge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPurge.ValueChanged += new System.EventHandler(this.numericUpDownPurge_ValueChanged);
            // 
            // comboBoxPurge
            // 
            this.comboBoxPurge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPurge.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPurge.ForeColor = System.Drawing.Color.Black;
            this.comboBoxPurge.FormattingEnabled = true;
            this.comboBoxPurge.Items.AddRange(new object[] {
            "Day",
            "Month"});
            this.comboBoxPurge.Location = new System.Drawing.Point(260, 32);
            this.comboBoxPurge.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPurge.Name = "comboBoxPurge";
            this.comboBoxPurge.Size = new System.Drawing.Size(223, 23);
            this.comboBoxPurge.TabIndex = 20;
            this.comboBoxPurge.SelectedIndexChanged += new System.EventHandler(this.comboBoxPurge_SelectedIndexChanged);
            // 
            // ViewSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBoxFlag);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.comboBoxPurge);
            this.Controls.Add(this.numericUpDownPurge);
            this.Controls.Add(this.labelMaxPurgeHistory);
            this.Name = "ViewSettings";
            this.Size = new System.Drawing.Size(488, 61);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPurge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void ChangeLanguageApplication()
        {
            GetText.CurrentLanguage = (GetText.Language)Enum.Parse(typeof(GetText.Language), comboBoxLanguage.SelectedItem.ToString().ToUpper());
            Properties.Settings.Default.Language = comboBoxLanguage.SelectedItem.ToString().ToUpper();
            Properties.Settings.Default.Save();

            switch (comboBoxLanguage.SelectedItem.ToString())
            {
                case "English":
                    pictureBoxFlag.BackgroundImage = Tools4Libraries.Resources.ResourceIconSet32Default.flag_great_britain;
                    break;
                case "French":
                    pictureBoxFlag.BackgroundImage = Tools4Libraries.Resources.ResourceIconSet32Default.flag_france;
                    break;
                default:
                    pictureBoxFlag.BackgroundImage = Tools4Libraries.Resources.ResourceIconSet32Default.flag_france;
                    break;
            }
            _intBoo.ChangeLanguage();
        }
        #endregion

        #region Event
        private void comboBoxLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeLanguageApplication();
        }
        private void numericUpDownPurge_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PurgeValue = numericUpDownPurge.Value;
            Properties.Settings.Default.Save();
        }
        private void comboBoxPurge_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PurgeDelay = comboBoxPurge.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
