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
            Droid_Geography.WorldMap worldMap3 = new Droid_Geography.WorldMap();
            this.panelStatUsers = new System.Windows.Forms.Panel();
            this.labelOccTitle = new System.Windows.Forms.Label();
            this.labelAreas = new System.Windows.Forms.Label();
            this.labelOccupancy = new System.Windows.Forms.Label();
            this.panelCountries = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.worldMapView = new Droid_Geography.WorldMapView();
            this.labelOccTitle = new System.Windows.Forms.Label();
            this.panelStatUsers.SuspendLayout();
            this.panelCountries.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatUsers
            // 
            this.panelStatUsers.BackColor = System.Drawing.Color.Transparent;
            this.panelStatUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelStatUsers.BackgroundImage")));
            this.panelStatUsers.Controls.Add(this.labelOccTitle);
            this.panelStatUsers.Controls.Add(this.labelAreas);
            this.panelStatUsers.Controls.Add(this.labelOccupancy);
            this.panelStatUsers.Location = new System.Drawing.Point(275, 25);
            this.panelStatUsers.Name = "panelStatUsers";
            this.panelStatUsers.Size = new System.Drawing.Size(450, 60);
            this.panelStatUsers.TabIndex = 0;
            // 
            // labelOccTitle
            // 
            this.labelOccTitle.AutoSize = true;
            this.labelOccTitle.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOccTitle.ForeColor = System.Drawing.Color.White;
            this.labelOccTitle.Location = new System.Drawing.Point(5, 5);
            this.labelOccTitle.Name = "labelOccTitle";
            this.labelOccTitle.Size = new System.Drawing.Size(83, 17);
            this.labelOccTitle.TabIndex = 18;
            this.labelOccTitle.Text = "Occupancy : ";
            // 
            // labelAreas
            // 
            this.labelAreas.AutoSize = true;
            this.labelAreas.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAreas.ForeColor = System.Drawing.Color.White;
            this.labelAreas.Location = new System.Drawing.Point(5, 30);
            this.labelAreas.Name = "labelAreas";
            this.labelAreas.Size = new System.Drawing.Size(139, 17);
            this.labelAreas.TabIndex = 17;
            this.labelAreas.Text = "Area capacity details : ";
            // 
            // labelOccupancy
            // 
            this.labelOccupancy.AutoSize = true;
            this.labelOccupancy.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOccupancy.ForeColor = System.Drawing.Color.White;
            this.labelOccupancy.Location = new System.Drawing.Point(113, 5);
            this.labelOccupancy.Name = "labelOccupancy";
            this.labelOccupancy.Size = new System.Drawing.Size(29, 17);
            this.labelOccupancy.TabIndex = 16;
            this.labelOccupancy.Text = "___";
            // 
            // panelCountries
            // 
            this.panelCountries.BackColor = System.Drawing.Color.Transparent;
            this.panelCountries.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelCountries.BackgroundImage")));
            this.panelCountries.Controls.Add(this.labelName);
            this.panelCountries.Location = new System.Drawing.Point(650, 110);
            this.panelCountries.Name = "panelCountries";
            this.panelCountries.Size = new System.Drawing.Size(300, 40);
            this.panelCountries.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(5, 5);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(129, 17);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Current nationalities";
            // 
            // worldMapView
            // 
            this.worldMapView.BackColor = System.Drawing.Color.DimGray;
            worldMap3.CurrentCountry = null;
            worldMap3.Mode = Droid_Geography.WorldMap.PresentationMode.POPULATION;
            worldMap3.RunAnimation = true;
            worldMap3.WorkingDirectory = "C:\\Users\\amost\\AppData\\Roaming\\Servodroid\\Droid-Geography";
            worldMap3.Zoom = 1;
            this.worldMapView.CurrentWorldMap = worldMap3;
            this.worldMapView.Location = new System.Drawing.Point(25, 110);
            this.worldMapView.Name = "worldMapView";
            this.worldMapView.Size = new System.Drawing.Size(600, 400);
            this.worldMapView.TabIndex = 0;
            this.worldMapView.Zoom = 0;
            // 
            // label1
            // 
            this.labelOccTitle.AutoSize = true;
            this.labelOccTitle.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOccTitle.ForeColor = System.Drawing.Color.White;
            this.labelOccTitle.Location = new System.Drawing.Point(5, 5);
            this.labelOccTitle.Name = "label1";
            this.labelOccTitle.Size = new System.Drawing.Size(83, 17);
            this.labelOccTitle.TabIndex = 18;
            this.labelOccTitle.Text = "Occupancy : ";
            // 
            // ViewWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.worldMapView);
            this.Controls.Add(this.panelCountries);
            this.Controls.Add(this.panelStatUsers);
            this.Name = "ViewWelcome";
            this.Size = new System.Drawing.Size(987, 512);
            this.panelStatUsers.ResumeLayout(false);
            this.panelStatUsers.PerformLayout();
            this.panelCountries.ResumeLayout(false);
            this.panelCountries.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatUsers;
        private System.Windows.Forms.Label labelAreas;
        private System.Windows.Forms.Label labelOccupancy;
        private System.Windows.Forms.Panel panelCountries;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelOccTitle;
        private Droid_Geography.WorldMapView worldMapView;
    }
}
