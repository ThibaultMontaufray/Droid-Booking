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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCalendar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this._dataGridViewPreview = new System.Windows.Forms.DataGridView();
            this.imageListCalendarCells = new System.Windows.Forms.ImageList(this.components);
            this.panelTypes = new System.Windows.Forms.Panel();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.panelCapacities = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPreview)).BeginInit();
            this.panelTypes.SuspendLayout();
            this.panelCapacities.SuspendLayout();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panelUsers);
            this.panel1.Controls.Add(this.panelCapacities);
            this.panel1.Controls.Add(this.panelTypes);
            this.panel1.Controls.Add(this.monthCalendar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 537);
            this.panel1.TabIndex = 1;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 3;
            // 
            // _dataGridViewPreview
            // 
            this._dataGridViewPreview.AllowUserToAddRows = false;
            this._dataGridViewPreview.AllowUserToDeleteRows = false;
            this._dataGridViewPreview.AllowUserToResizeColumns = false;
            this._dataGridViewPreview.AllowUserToResizeRows = false;
            this._dataGridViewPreview.BackgroundColor = System.Drawing.Color.DimGray;
            this._dataGridViewPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridViewPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this._dataGridViewPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewPreview.DefaultCellStyle = dataGridViewCellStyle6;
            this._dataGridViewPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewPreview.Location = new System.Drawing.Point(249, 0);
            this._dataGridViewPreview.Name = "_dataGridViewPreview";
            this._dataGridViewPreview.ReadOnly = true;
            this._dataGridViewPreview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dataGridViewPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this._dataGridViewPreview.Size = new System.Drawing.Size(870, 537);
            this._dataGridViewPreview.TabIndex = 4;
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
            // panelTypes
            // 
            this.panelTypes.BackColor = System.Drawing.Color.Silver;
            this.panelTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTypes.Controls.Add(this.checkBoxType);
            this.panelTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTypes.Location = new System.Drawing.Point(0, 162);
            this.panelTypes.Name = "panelTypes";
            this.panelTypes.Size = new System.Drawing.Size(249, 42);
            this.panelTypes.TabIndex = 4;
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Checked = true;
            this.checkBoxType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxType.Location = new System.Drawing.Point(13, 12);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(73, 19);
            this.checkBoxType.TabIndex = 5;
            this.checkBoxType.Text = "All types";
            this.checkBoxType.UseVisualStyleBackColor = true;
            // 
            // panelCapacities
            // 
            this.panelCapacities.BackColor = System.Drawing.Color.Silver;
            this.panelCapacities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCapacities.Controls.Add(this.checkBox1);
            this.panelCapacities.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCapacities.Location = new System.Drawing.Point(0, 204);
            this.panelCapacities.Name = "panelCapacities";
            this.panelCapacities.Size = new System.Drawing.Size(249, 42);
            this.panelCapacities.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(13, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "All capacities";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.Silver;
            this.panelUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsers.Controls.Add(this.dataGridViewUsers);
            this.panelUsers.Controls.Add(this.buttonClearFilter);
            this.panelUsers.Controls.Add(this.textBox1);
            this.panelUsers.Controls.Add(this.label1);
            this.panelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsers.Location = new System.Drawing.Point(0, 246);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(249, 291);
            this.panelUsers.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current guests";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 1;
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClearFilter.BackgroundImage")));
            this.buttonClearFilter.FlatAppearance.BorderSize = 0;
            this.buttonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearFilter.Location = new System.Drawing.Point(227, 30);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(16, 16);
            this.buttonClearFilter.TabIndex = 2;
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AllowUserToOrderColumns = true;
            this.dataGridViewUsers.AllowUserToResizeColumns = false;
            this.dataGridViewUsers.AllowUserToResizeRows = false;
            this.dataGridViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStatus,
            this.ColumnCheckIn,
            this.ColumnArea});
            this.dataGridViewUsers.Location = new System.Drawing.Point(0, 55);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.Size = new System.Drawing.Size(247, 234);
            this.dataGridViewUsers.TabIndex = 3;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnStatus.HeaderText = "";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.Width = 5;
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
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // ColumnCheckIn
            // 
            this.ColumnCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCheckIn.HeaderText = "Check In";
            this.ColumnCheckIn.Name = "ColumnCheckIn";
            // 
            // ColumnArea
            // 
            this.ColumnArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnArea.HeaderText = "Area";
            this.ColumnArea.Name = "ColumnArea";
            this.ColumnArea.Width = 54;
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
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPreview)).EndInit();
            this.panelTypes.ResumeLayout(false);
            this.panelTypes.PerformLayout();
            this.panelCapacities.ResumeLayout(false);
            this.panelCapacities.PerformLayout();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.DataGridViewImageColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
