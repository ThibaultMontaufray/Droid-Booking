namespace Droid_Booking
{
    partial class ViewWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewWelcome));
            this.panelStatUsers = new System.Windows.Forms.Panel();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStatUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatUsers
            // 
            this.panelStatUsers.BackColor = System.Drawing.Color.Transparent;
            this.panelStatUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelStatUsers.BackgroundImage")));
            this.panelStatUsers.Controls.Add(this.label1);
            this.panelStatUsers.Controls.Add(this.labelCapacity);
            this.panelStatUsers.Location = new System.Drawing.Point(64, 65);
            this.panelStatUsers.Name = "panelStatUsers";
            this.panelStatUsers.Size = new System.Drawing.Size(323, 90);
            this.panelStatUsers.TabIndex = 0;
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCapacity.ForeColor = System.Drawing.Color.White;
            this.labelCapacity.Location = new System.Drawing.Point(14, 16);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(123, 19);
            this.labelCapacity.TabIndex = 16;
            this.labelCapacity.Text = "Occupancy : 87 %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Area : 20 / 86 available";
            // 
            // ViewWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Droid_Booking.Properties.Resources.SheetBackgroud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelStatUsers);
            this.Name = "ViewWelcome";
            this.Size = new System.Drawing.Size(987, 512);
            this.panelStatUsers.ResumeLayout(false);
            this.panelStatUsers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCapacity;
    }
}
