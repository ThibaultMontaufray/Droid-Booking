namespace Droid_Booking
{
    partial class ViewCalendar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCalendar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxFilter = new System.Windows.Forms.PictureBox();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._dataGridViewCheckIn = new System.Windows.Forms.DataGridView();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataGridViewCheckOut = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._comboBoxCurrentUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCapacities = new System.Windows.Forms.Panel();
            this.pictureBoxCapacity = new System.Windows.Forms.PictureBox();
            this.checkBoxCapa = new System.Windows.Forms.CheckBox();
            this.panelTypes = new System.Windows.Forms.Panel();
            this.pictureBoxType = new System.Windows.Forms.PictureBox();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this._dataGridViewPreview = new System.Windows.Forms.DataGridView();
            this.imageListCalendarCells = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilter)).BeginInit();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCheckIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCheckOut)).BeginInit();
            this.panelCapacities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapacity)).BeginInit();
            this.panelTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.pictureBoxFilter);
            this.panel1.Controls.Add(this.panelUsers);
            this.panel1.Controls.Add(this.panelCapacities);
            this.panel1.Controls.Add(this.panelTypes);
            this.panel1.Controls.Add(this.buttonClearFilter);
            this.panel1.Controls.Add(this.monthCalendar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 537);
            this.panel1.TabIndex = 1;
            // 
            // pictureBoxFilter
            // 
            this.pictureBoxFilter.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFilter.BackgroundImage")));
            this.pictureBoxFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxFilter.Location = new System.Drawing.Point(9, 171);
            this.pictureBoxFilter.Name = "pictureBoxFilter";
            this.pictureBoxFilter.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxFilter.TabIndex = 5;
            this.pictureBoxFilter.TabStop = false;
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.Silver;
            this.panelUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsers.Controls.Add(this.pictureBox3);
            this.panelUsers.Controls.Add(this.splitContainer1);
            this.panelUsers.Controls.Add(this._comboBoxCurrentUsers);
            this.panelUsers.Controls.Add(this.label1);
            this.panelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsers.Location = new System.Drawing.Point(0, 288);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(249, 249);
            this.panelUsers.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(8, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(-1, 59);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._dataGridViewCheckIn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dataGridViewCheckOut);
            this.splitContainer1.Size = new System.Drawing.Size(249, 189);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 21;
            // 
            // _dataGridViewCheckIn
            // 
            this._dataGridViewCheckIn.AllowUserToAddRows = false;
            this._dataGridViewCheckIn.AllowUserToDeleteRows = false;
            this._dataGridViewCheckIn.AllowUserToOrderColumns = true;
            this._dataGridViewCheckIn.AllowUserToResizeColumns = false;
            this._dataGridViewCheckIn.AllowUserToResizeRows = false;
            this._dataGridViewCheckIn.BackgroundColor = System.Drawing.Color.Gainsboro;
            this._dataGridViewCheckIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewCheckIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStatus,
            this.ColumnCheckIn,
            this.ColumnArea});
            this._dataGridViewCheckIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewCheckIn.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewCheckIn.Name = "_dataGridViewCheckIn";
            this._dataGridViewCheckIn.ReadOnly = true;
            this._dataGridViewCheckIn.RowHeadersVisible = false;
            this._dataGridViewCheckIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewCheckIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewCheckIn.Size = new System.Drawing.Size(249, 93);
            this._dataGridViewCheckIn.TabIndex = 3;
            this._dataGridViewCheckIn.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._dataGridViewCheckIn_CellMouseClick);
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnStatus.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnStatus.HeaderText = "";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnStatus.Visible = false;
            // 
            // ColumnCheckIn
            // 
            this.ColumnCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnCheckIn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnCheckIn.HeaderText = "Check In";
            this.ColumnCheckIn.Name = "ColumnCheckIn";
            this.ColumnCheckIn.ReadOnly = true;
            // 
            // ColumnArea
            // 
            this.ColumnArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnArea.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnArea.HeaderText = "Area";
            this.ColumnArea.Name = "ColumnArea";
            this.ColumnArea.ReadOnly = true;
            this.ColumnArea.Width = 54;
            // 
            // _dataGridViewCheckOut
            // 
            this._dataGridViewCheckOut.AllowUserToAddRows = false;
            this._dataGridViewCheckOut.AllowUserToDeleteRows = false;
            this._dataGridViewCheckOut.AllowUserToOrderColumns = true;
            this._dataGridViewCheckOut.AllowUserToResizeColumns = false;
            this._dataGridViewCheckOut.AllowUserToResizeRows = false;
            this._dataGridViewCheckOut.BackgroundColor = System.Drawing.Color.Gainsboro;
            this._dataGridViewCheckOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewCheckOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this._dataGridViewCheckOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewCheckOut.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewCheckOut.Name = "_dataGridViewCheckOut";
            this._dataGridViewCheckOut.ReadOnly = true;
            this._dataGridViewCheckOut.RowHeadersVisible = false;
            this._dataGridViewCheckOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._dataGridViewCheckOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewCheckOut.Size = new System.Drawing.Size(249, 92);
            this._dataGridViewCheckOut.TabIndex = 20;
            this._dataGridViewCheckOut.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._dataGridViewCheckOut_CellMouseClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "Check Out";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "Area";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 54;
            // 
            // _comboBoxCurrentUsers
            // 
            this._comboBoxCurrentUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxCurrentUsers.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comboBoxCurrentUsers.FormattingEnabled = true;
            this._comboBoxCurrentUsers.Location = new System.Drawing.Point(8, 30);
            this._comboBoxCurrentUsers.Margin = new System.Windows.Forms.Padding(4);
            this._comboBoxCurrentUsers.Name = "_comboBoxCurrentUsers";
            this._comboBoxCurrentUsers.Size = new System.Drawing.Size(234, 22);
            this._comboBoxCurrentUsers.TabIndex = 19;
            this._comboBoxCurrentUsers.SelectedIndexChanged += new System.EventHandler(this._comboBoxCurrentUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current guests";
            // 
            // panelCapacities
            // 
            this.panelCapacities.BackColor = System.Drawing.Color.Silver;
            this.panelCapacities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCapacities.Controls.Add(this.pictureBoxCapacity);
            this.panelCapacities.Controls.Add(this.checkBoxCapa);
            this.panelCapacities.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCapacities.Location = new System.Drawing.Point(0, 246);
            this.panelCapacities.Name = "panelCapacities";
            this.panelCapacities.Size = new System.Drawing.Size(249, 42);
            this.panelCapacities.TabIndex = 5;
            this.panelCapacities.Click += new System.EventHandler(this.capacities_Click);
            this.panelCapacities.MouseEnter += new System.EventHandler(this.panel_MouseLeave);
            this.panelCapacities.MouseHover += new System.EventHandler(this.panel_MouseHover);
            // 
            // pictureBoxCapacity
            // 
            this.pictureBoxCapacity.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxCapacity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCapacity.BackgroundImage")));
            this.pictureBoxCapacity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCapacity.Location = new System.Drawing.Point(8, 7);
            this.pictureBoxCapacity.Name = "pictureBoxCapacity";
            this.pictureBoxCapacity.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxCapacity.TabIndex = 7;
            this.pictureBoxCapacity.TabStop = false;
            // 
            // checkBoxCapa
            // 
            this.checkBoxCapa.AutoSize = true;
            this.checkBoxCapa.Checked = true;
            this.checkBoxCapa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCapa.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCapa.Location = new System.Drawing.Point(50, 12);
            this.checkBoxCapa.Name = "checkBoxCapa";
            this.checkBoxCapa.Size = new System.Drawing.Size(95, 19);
            this.checkBoxCapa.TabIndex = 5;
            this.checkBoxCapa.Text = "All capacities";
            this.checkBoxCapa.UseVisualStyleBackColor = true;
            this.checkBoxCapa.CheckedChanged += new System.EventHandler(this.checkBoxCapa_CheckedChanged);
            // 
            // panelTypes
            // 
            this.panelTypes.BackColor = System.Drawing.Color.Silver;
            this.panelTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTypes.Controls.Add(this.pictureBoxType);
            this.panelTypes.Controls.Add(this.checkBoxType);
            this.panelTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTypes.Location = new System.Drawing.Point(0, 204);
            this.panelTypes.Name = "panelTypes";
            this.panelTypes.Size = new System.Drawing.Size(249, 42);
            this.panelTypes.TabIndex = 4;
            this.panelTypes.Click += new System.EventHandler(this.type_Click);
            this.panelTypes.MouseLeave += new System.EventHandler(this.panel_MouseLeave);
            this.panelTypes.MouseHover += new System.EventHandler(this.panel_MouseHover);
            // 
            // pictureBoxType
            // 
            this.pictureBoxType.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxType.BackgroundImage")));
            this.pictureBoxType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxType.Location = new System.Drawing.Point(8, 7);
            this.pictureBoxType.Name = "pictureBoxType";
            this.pictureBoxType.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxType.TabIndex = 7;
            this.pictureBoxType.TabStop = false;
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Checked = true;
            this.checkBoxType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxType.Location = new System.Drawing.Point(50, 11);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(73, 19);
            this.checkBoxType.TabIndex = 5;
            this.checkBoxType.Text = "All types";
            this.checkBoxType.UseVisualStyleBackColor = true;
            this.checkBoxType.CheckedChanged += new System.EventHandler(this.checkBoxType_CheckedChanged);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.BackColor = System.Drawing.Color.Silver;
            this.buttonClearFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClearFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonClearFilter.FlatAppearance.BorderSize = 0;
            this.buttonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearFilter.ForeColor = System.Drawing.Color.Black;
            this.buttonClearFilter.Location = new System.Drawing.Point(0, 162);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.buttonClearFilter.Size = new System.Drawing.Size(249, 42);
            this.buttonClearFilter.TabIndex = 2;
            this.buttonClearFilter.Text = "Clear filter";
            this.buttonClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearFilter.UseVisualStyleBackColor = false;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 3;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // _dataGridViewPreview
            // 
            this._dataGridViewPreview.AllowUserToAddRows = false;
            this._dataGridViewPreview.AllowUserToDeleteRows = false;
            this._dataGridViewPreview.AllowUserToResizeColumns = false;
            this._dataGridViewPreview.AllowUserToResizeRows = false;
            this._dataGridViewPreview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._dataGridViewPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._dataGridViewPreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridViewPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this._dataGridViewPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewPreview.DefaultCellStyle = dataGridViewCellStyle8;
            this._dataGridViewPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewPreview.GridColor = System.Drawing.Color.Black;
            this._dataGridViewPreview.Location = new System.Drawing.Point(249, 0);
            this._dataGridViewPreview.Name = "_dataGridViewPreview";
            this._dataGridViewPreview.ReadOnly = true;
            this._dataGridViewPreview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dataGridViewPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this._dataGridViewPreview.Size = new System.Drawing.Size(870, 537);
            this._dataGridViewPreview.TabIndex = 4;
            this._dataGridViewPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this._dataGridViewPreview_MouseClick);
            // 
            // imageListCalendarCells
            // 
            this.imageListCalendarCells.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCalendarCells.ImageStream")));
            this.imageListCalendarCells.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCalendarCells.Images.SetKeyName(0, "CenterGray");
            this.imageListCalendarCells.Images.SetKeyName(1, "CenterWhite");
            this.imageListCalendarCells.Images.SetKeyName(2, "CenterGreen");
            this.imageListCalendarCells.Images.SetKeyName(3, "CenterOrange");
            this.imageListCalendarCells.Images.SetKeyName(4, "CenterRed");
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Check In";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Area";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // ViewCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this._dataGridViewPreview);
            this.Controls.Add(this.panel1);
            this.Name = "ViewCalendar";
            this.Size = new System.Drawing.Size(1119, 537);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilter)).EndInit();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCheckIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCheckOut)).EndInit();
            this.panelCapacities.ResumeLayout(false);
            this.panelCapacities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapacity)).EndInit();
            this.panelTypes.ResumeLayout(false);
            this.panelTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DataGridView _dataGridViewPreview;
        private System.Windows.Forms.ImageList imageListCalendarCells;
        private System.Windows.Forms.Panel panelTypes;
        private System.Windows.Forms.CheckBox checkBoxType;
        private System.Windows.Forms.Panel panelCapacities;
        private System.Windows.Forms.CheckBox checkBoxCapa;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.DataGridView _dataGridViewCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox _comboBoxCurrentUsers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArea;
        private System.Windows.Forms.DataGridView _dataGridViewCheckOut;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxFilter;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBoxCapacity;
        private System.Windows.Forms.PictureBox pictureBoxType;
    }
}
