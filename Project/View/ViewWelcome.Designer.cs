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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelStatUsers = new System.Windows.Forms.Panel();
            this.chartTypeDetail = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTypeRepartition = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMainOccupancy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelStatUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypeDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypeRepartition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMainOccupancy)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStatUsers
            // 
            this.panelStatUsers.BackColor = System.Drawing.Color.Gray;
            this.panelStatUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelStatUsers.BackgroundImage")));
            this.panelStatUsers.Controls.Add(this.chartTypeDetail);
            this.panelStatUsers.Controls.Add(this.chartTypeRepartition);
            this.panelStatUsers.Controls.Add(this.chartMainOccupancy);
            this.panelStatUsers.Location = new System.Drawing.Point(25, 25);
            this.panelStatUsers.Name = "panelStatUsers";
            this.panelStatUsers.Size = new System.Drawing.Size(921, 116);
            this.panelStatUsers.TabIndex = 0;
            // 
            // chartTypeDetail
            // 
            this.chartTypeDetail.BackColor = System.Drawing.Color.Transparent;
            this.chartTypeDetail.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            this.chartTypeDetail.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 10;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.TruncatedLabels = true;
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.LabelAutoFitMinFontSize = 10;
            chartArea1.AxisX2.MaximumAutoSize = 100F;
            chartArea1.AxisX2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 10;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.LabelAutoFitMinFontSize = 10;
            chartArea1.AxisY2.MaximumAutoSize = 100F;
            chartArea1.AxisY2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Maroon;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 70F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            this.chartTypeDetail.ChartAreas.Add(chartArea1);
            this.chartTypeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.AutoFitMinFontSize = 12;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.Fuchsia;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 82.05128F;
            legend1.Position.Width = 30F;
            legend1.Position.X = 70F;
            legend1.Position.Y = 10F;
            legend1.Title = "Area occupancy";
            legend1.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.Maroon;
            this.chartTypeDetail.Legends.Add(legend1);
            this.chartTypeDetail.Location = new System.Drawing.Point(241, 0);
            this.chartTypeDetail.Name = "chartTypeDetail";
            this.chartTypeDetail.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.Color = System.Drawing.Color.DarkRed;
            series1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.Gainsboro;
            series1.Legend = "Legend1";
            series1.Name = "Occupancy";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Available";
            this.chartTypeDetail.Series.Add(series1);
            this.chartTypeDetail.Series.Add(series2);
            this.chartTypeDetail.Size = new System.Drawing.Size(439, 116);
            this.chartTypeDetail.TabIndex = 5;
            this.chartTypeDetail.Text = "Expense completed";
            // 
            // chartTypeRepartition
            // 
            this.chartTypeRepartition.BackColor = System.Drawing.Color.Transparent;
            this.chartTypeRepartition.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            this.chartTypeRepartition.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            chartArea2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Maroon;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 94.99999F;
            chartArea2.InnerPlotPosition.Width = 46.3125F;
            chartArea2.InnerPlotPosition.X = 3F;
            chartArea2.InnerPlotPosition.Y = 3F;
            chartArea2.Name = "ChartArea1";
            this.chartTypeRepartition.ChartAreas.Add(chartArea2);
            this.chartTypeRepartition.Dock = System.Windows.Forms.DockStyle.Right;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 82.05128F;
            legend2.Position.Width = 43.33333F;
            legend2.Position.X = 53.66667F;
            legend2.Position.Y = 10F;
            legend2.Title = "Area types";
            legend2.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.TitleForeColor = System.Drawing.Color.White;
            this.chartTypeRepartition.Legends.Add(legend2);
            this.chartTypeRepartition.Location = new System.Drawing.Point(680, 0);
            this.chartTypeRepartition.Name = "chartTypeRepartition";
            this.chartTypeRepartition.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Color = System.Drawing.Color.Transparent;
            series3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.MarkerBorderColor = System.Drawing.Color.Transparent;
            series3.MarkerColor = System.Drawing.Color.Transparent;
            series3.MarkerImageTransparentColor = System.Drawing.Color.Transparent;
            series3.Name = "Types";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartTypeRepartition.Series.Add(series3);
            this.chartTypeRepartition.Size = new System.Drawing.Size(241, 116);
            this.chartTypeRepartition.TabIndex = 4;
            this.chartTypeRepartition.Text = "Expense completed";
            // 
            // chartMainOccupancy
            // 
            this.chartMainOccupancy.BackColor = System.Drawing.Color.Transparent;
            this.chartMainOccupancy.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            this.chartMainOccupancy.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            chartArea3.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Maroon;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 94.99999F;
            chartArea3.InnerPlotPosition.Width = 46.3125F;
            chartArea3.InnerPlotPosition.X = 3F;
            chartArea3.InnerPlotPosition.Y = 3F;
            chartArea3.Name = "ChartArea1";
            this.chartMainOccupancy.ChartAreas.Add(chartArea3);
            this.chartMainOccupancy.Dock = System.Windows.Forms.DockStyle.Left;
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.ForeColor = System.Drawing.Color.White;
            legend3.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend3.Name = "Legend1";
            legend3.Position.Auto = false;
            legend3.Position.Height = 82.05128F;
            legend3.Position.Width = 43.33333F;
            legend3.Position.X = 53.66667F;
            legend3.Position.Y = 10F;
            legend3.Title = "Global occupancy";
            legend3.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.TitleForeColor = System.Drawing.Color.White;
            this.chartMainOccupancy.Legends.Add(legend3);
            this.chartMainOccupancy.Location = new System.Drawing.Point(0, 0);
            this.chartMainOccupancy.Name = "chartMainOccupancy";
            this.chartMainOccupancy.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series4.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Color = System.Drawing.Color.Transparent;
            series4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.MarkerBorderColor = System.Drawing.Color.Transparent;
            series4.MarkerColor = System.Drawing.Color.Transparent;
            series4.MarkerImageTransparentColor = System.Drawing.Color.Transparent;
            series4.Name = "Occupancy";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartMainOccupancy.Series.Add(series4);
            this.chartMainOccupancy.Size = new System.Drawing.Size(241, 116);
            this.chartMainOccupancy.TabIndex = 2;
            this.chartMainOccupancy.Text = "Expense completed";
            // 
            // ViewWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.panelStatUsers);
            this.Name = "ViewWelcome";
            this.Size = new System.Drawing.Size(987, 567);
            this.panelStatUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTypeDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypeRepartition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMainOccupancy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatUsers;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMainOccupancy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTypeDetail;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTypeRepartition;
    }
}
