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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCalendar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.panelDateDetails = new System.Windows.Forms.Panel();
            this._buttonMonth = new System.Windows.Forms.Button();
            this._buttonWeek = new System.Windows.Forms.Button();
            this._buttonDay = new System.Windows.Forms.Button();
            this._dataGridViewPreview = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelDateDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.monthCalendar);
            this.panel1.Controls.Add(this.panelDateDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 537);
            this.panel1.TabIndex = 1;
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(1, 3);
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar.Location = new System.Drawing.Point(0, 38);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 3;
            // 
            // panelDateDetails
            // 
            this.panelDateDetails.Controls.Add(this._buttonMonth);
            this.panelDateDetails.Controls.Add(this._buttonWeek);
            this.panelDateDetails.Controls.Add(this._buttonDay);
            this.panelDateDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDateDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDateDetails.Name = "panelDateDetails";
            this.panelDateDetails.Size = new System.Drawing.Size(249, 38);
            this.panelDateDetails.TabIndex = 1;
            // 
            // _buttonMonth
            // 
            this._buttonMonth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_buttonMonth.BackgroundImage")));
            this._buttonMonth.FlatAppearance.BorderSize = 0;
            this._buttonMonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this._buttonMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this._buttonMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonMonth.Location = new System.Drawing.Point(79, 3);
            this._buttonMonth.Name = "_buttonMonth";
            this._buttonMonth.Size = new System.Drawing.Size(32, 32);
            this._buttonMonth.TabIndex = 4;
            this._buttonMonth.UseVisualStyleBackColor = true;
            // 
            // _buttonWeek
            // 
            this._buttonWeek.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_buttonWeek.BackgroundImage")));
            this._buttonWeek.FlatAppearance.BorderSize = 0;
            this._buttonWeek.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this._buttonWeek.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this._buttonWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonWeek.Location = new System.Drawing.Point(41, 3);
            this._buttonWeek.Name = "_buttonWeek";
            this._buttonWeek.Size = new System.Drawing.Size(32, 32);
            this._buttonWeek.TabIndex = 3;
            this._buttonWeek.UseVisualStyleBackColor = true;
            // 
            // _buttonDay
            // 
            this._buttonDay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_buttonDay.BackgroundImage")));
            this._buttonDay.FlatAppearance.BorderSize = 0;
            this._buttonDay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this._buttonDay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this._buttonDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonDay.Location = new System.Drawing.Point(3, 3);
            this._buttonDay.Name = "_buttonDay";
            this._buttonDay.Size = new System.Drawing.Size(32, 32);
            this._buttonDay.TabIndex = 2;
            this._buttonDay.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewPreview
            // 
            this._dataGridViewPreview.BackgroundColor = System.Drawing.Color.DimGray;
            this._dataGridViewPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewPreview.Location = new System.Drawing.Point(249, 0);
            this._dataGridViewPreview.Name = "_dataGridViewPreview";
            this._dataGridViewPreview.Size = new System.Drawing.Size(870, 537);
            this._dataGridViewPreview.TabIndex = 4;
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
            this.panelDateDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDateDetails;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button _buttonMonth;
        private System.Windows.Forms.Button _buttonWeek;
        private System.Windows.Forms.Button _buttonDay;
        private System.Windows.Forms.DataGridView _dataGridViewPreview;
    }
}
