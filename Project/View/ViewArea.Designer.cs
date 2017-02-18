namespace Droid_Booking
{
    partial class ViewArea
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewArea));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ribbonColorChooser1 = new System.Windows.Forms.RibbonColorChooser();
            this.ribbonColorChooser2 = new System.Windows.Forms.RibbonColorChooser();
            this.buttonColorChoose = new System.Windows.Forms.Button();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.labelFloor = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.numericUpDownFloor = new System.Windows.Forms.NumericUpDown();
            this.labelNameTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonValidation = new System.Windows.Forms.Button();
            this._dgvSearch = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(123, 41);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 19);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name : ";
            // 
            // labelColor
            // 
            this.labelColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.ForeColor = System.Drawing.Color.White;
            this.labelColor.Location = new System.Drawing.Point(560, 41);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(55, 19);
            this.labelColor.TabIndex = 4;
            this.labelColor.Text = "Color : ";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(188, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(357, 27);
            this.textBoxName.TabIndex = 12;
            // 
            // textBoxColor
            // 
            this.textBoxColor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxColor.Location = new System.Drawing.Point(621, 38);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.ReadOnly = true;
            this.textBoxColor.Size = new System.Drawing.Size(213, 27);
            this.textBoxColor.TabIndex = 13;
            // 
            // ribbonColorChooser1
            // 
            this.ribbonColorChooser1.Color = System.Drawing.Color.Transparent;
            this.ribbonColorChooser1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser1.Image")));
            this.ribbonColorChooser1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser1.LargeImage")));
            this.ribbonColorChooser1.Name = "ribbonColorChooser1";
            this.ribbonColorChooser1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser1.SmallImage")));
            // 
            // ribbonColorChooser2
            // 
            this.ribbonColorChooser2.Color = System.Drawing.Color.Transparent;
            this.ribbonColorChooser2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser2.Image")));
            this.ribbonColorChooser2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser2.LargeImage")));
            this.ribbonColorChooser2.Name = "ribbonColorChooser2";
            this.ribbonColorChooser2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonColorChooser2.SmallImage")));
            // 
            // buttonColorChoose
            // 
            this.buttonColorChoose.Font = new System.Drawing.Font("Calibri", 11F);
            this.buttonColorChoose.Location = new System.Drawing.Point(835, 38);
            this.buttonColorChoose.Name = "buttonColorChoose";
            this.buttonColorChoose.Size = new System.Drawing.Size(76, 27);
            this.buttonColorChoose.TabIndex = 14;
            this.buttonColorChoose.Text = "choose";
            this.buttonColorChoose.UseVisualStyleBackColor = true;
            this.buttonColorChoose.Click += new System.EventHandler(this.buttonColorChoose_Click);
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCapacity.ForeColor = System.Drawing.Color.White;
            this.labelCapacity.Location = new System.Drawing.Point(123, 70);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(77, 19);
            this.labelCapacity.TabIndex = 15;
            this.labelCapacity.Text = "Capacity : ";
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCapacity.Location = new System.Drawing.Point(222, 68);
            this.numericUpDownCapacity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(105, 27);
            this.numericUpDownCapacity.TabIndex = 16;
            this.numericUpDownCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelFloor
            // 
            this.labelFloor.AutoSize = true;
            this.labelFloor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFloor.ForeColor = System.Drawing.Color.White;
            this.labelFloor.Location = new System.Drawing.Point(355, 70);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(53, 19);
            this.labelFloor.TabIndex = 17;
            this.labelFloor.Text = "Floor : ";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.White;
            this.labelType.Location = new System.Drawing.Point(560, 70);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(51, 19);
            this.labelType.TabIndex = 19;
            this.labelType.Text = "Type : ";
            // 
            // numericUpDownFloor
            // 
            this.numericUpDownFloor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFloor.Location = new System.Drawing.Point(440, 68);
            this.numericUpDownFloor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFloor.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownFloor.Name = "numericUpDownFloor";
            this.numericUpDownFloor.Size = new System.Drawing.Size(105, 27);
            this.numericUpDownFloor.TabIndex = 21;
            this.numericUpDownFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelNameTitle
            // 
            this.labelNameTitle.AutoSize = true;
            this.labelNameTitle.BackColor = System.Drawing.Color.Maroon;
            this.labelNameTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameTitle.ForeColor = System.Drawing.Color.White;
            this.labelNameTitle.Location = new System.Drawing.Point(125, 7);
            this.labelNameTitle.Name = "labelNameTitle";
            this.labelNameTitle.Size = new System.Drawing.Size(57, 23);
            this.labelNameTitle.TabIndex = 22;
            this.labelNameTitle.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxType);
            this.panel1.Controls.Add(this.buttonValidation);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.labelNameTitle);
            this.panel1.Controls.Add(this.labelColor);
            this.panel1.Controls.Add(this.numericUpDownFloor);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.textBoxColor);
            this.panel1.Controls.Add(this.labelType);
            this.panel1.Controls.Add(this.buttonColorChoose);
            this.panel1.Controls.Add(this.labelFloor);
            this.panel1.Controls.Add(this.labelCapacity);
            this.panel1.Controls.Add(this.numericUpDownCapacity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 128);
            this.panel1.TabIndex = 24;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(621, 66);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(290, 27);
            this.comboBoxType.TabIndex = 24;
            // 
            // buttonValidation
            // 
            this.buttonValidation.Font = new System.Drawing.Font("Calibri", 11F);
            this.buttonValidation.Location = new System.Drawing.Point(836, 94);
            this.buttonValidation.Name = "buttonValidation";
            this.buttonValidation.Size = new System.Drawing.Size(75, 27);
            this.buttonValidation.TabIndex = 23;
            this.buttonValidation.Text = "Search";
            this.buttonValidation.UseVisualStyleBackColor = true;
            this.buttonValidation.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // _dgvSearch
            // 
            this._dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvSearch.Location = new System.Drawing.Point(0, 128);
            this._dgvSearch.Name = "_dgvSearch";
            this._dgvSearch.Size = new System.Drawing.Size(1280, 328);
            this._dgvSearch.TabIndex = 25;
            // 
            // ViewArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this._dgvSearch);
            this.Controls.Add(this.panel1);
            this.Name = "ViewArea";
            this.Size = new System.Drawing.Size(1280, 456);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RibbonColorChooser ribbonColorChooser1;
        private System.Windows.Forms.RibbonColorChooser ribbonColorChooser2;
        private System.Windows.Forms.Button buttonColorChoose;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.NumericUpDown numericUpDownCapacity;
        private System.Windows.Forms.Label labelFloor;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.NumericUpDown numericUpDownFloor;
        private System.Windows.Forms.Label labelNameTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _dgvSearch;
        private System.Windows.Forms.Button buttonValidation;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}
