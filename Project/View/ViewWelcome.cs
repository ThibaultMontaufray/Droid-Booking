using Droid_People;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tools4Libraries;

namespace Droid_Booking
{
    public partial class ViewWelcome : UserControlCustom, IView
    {
        #region Attribute
        private Interface_booking _intBoo;
        private Dictionary<string, int> _areas;
        private Dictionary<string, int> _areasCapacity;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewWelcome()
        {
            InitializeComponent();
        }
        public ViewWelcome(Interface_booking intBoo)
        {
            _intBoo = intBoo;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {
            //labelOccTitle.Text = GetText.Text("Occupancy") + " : ";
            //labelAreas.Text = GetText.Text("AreaCapacityDetails") + " : ";
        }
        public override void RefreshData()
        {
            LoadGlobalStat();
            AdjustWindows();

            ChangeLanguage();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _areas = new Dictionary<string, int>();
            _areasCapacity = new Dictionary<string, int>();
        }
        private void LoadGlobalStat()
        {
            int top;
            int left;
            if (_intBoo != null)
            {
                int indexPoint = 0;
                List<Booking> currentBooks = _intBoo.Bookings.Where(b => b.CheckIn < DateTime.Now && b.CheckOut > DateTime.Now).ToList();
                int totalCapacity = 0;
                this.Controls.Clear();
                this.Controls.Add(panelStatUsers);
                foreach (Area area in _intBoo.Areas)
                {
                    if (!_areas.ContainsKey(area.Type.ToString()))
                    {
                        _areas.Add(area.Type.ToString(), 0);
                        _areasCapacity.Add(area.Type.ToString(), 0);
                    }
                    totalCapacity += area.Capacity;
                    _areasCapacity[area.Type.ToString()] += area.Capacity;
                }
                Area tmpArea;
                foreach (Booking booking in currentBooks)
                {
                    tmpArea = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas);
                    if (tmpArea != null) { _areas[tmpArea.Type.ToString()] += 1; }
                }

                chartTypeRepartition.Series["Types"].Points.Clear();
                chartMainOccupancy.Series["Occupancy"].Points.Clear();
                chartMainOccupancy.Series["Occupancy"].Points.AddXY("Reserved", currentBooks.Count);
                chartMainOccupancy.Series["Occupancy"].Points.AddXY("Available", totalCapacity - currentBooks.Count);
                chartMainOccupancy.Series["Occupancy"].Points[0].Color = System.Drawing.Color.Maroon;
                chartMainOccupancy.Series["Occupancy"].Points[1].Color = System.Drawing.Color.DarkOrange;

                chartTypeDetail.Series["Occupancy"].Points.Clear();
                chartTypeDetail.Series["Available"].Points.Clear();

                top = panelStatUsers.Height + 50;
                left = 25;
                foreach (var area in _areasCapacity.OrderByDescending(n => n.Value))
                {
                    chartTypeDetail.Series["Occupancy"].Points.AddXY(area.Key.ToLower(), _areas[area.Key]);
                    chartTypeDetail.Series["Available"].Points.AddXY(area.Key, area.Value - _areas[area.Key]);
                    chartTypeRepartition.Series["Types"].Points.AddXY(area.Key, area.Value);

                    BuildNewYearChart(area.Key, top, left, (panelStatUsers.Width / 3) - 10);
                    if (left > (panelStatUsers.Width / 2))
                    {
                        top += 225;
                        left = 25;
                    }
                    else if (left > 25)
                    {
                        left = (panelStatUsers.Width * 2 / 3) + 35;
                    }
                    else
                    {
                        left = (panelStatUsers.Width / 3) + 30;
                    }
                    indexPoint++;
                }
                AdjustWindows();
            }
        }
        private void BuildNewYearChart(string areaType, int top, int left, int width)
        {
            List<Booking> lstBoo;
            Chart typeStatPerYear;
            Legend legend1 = new Legend();
            ChartArea chartArea1 = new ChartArea();
            typeStatPerYear = new Chart();
            typeStatPerYear.BackColor = System.Drawing.Color.DimGray;
            typeStatPerYear.Palette = ChartColorPalette.EarthTones;
            typeStatPerYear.Top = top;
            typeStatPerYear.Height = 200;
            typeStatPerYear.Left = left;
            typeStatPerYear.Width = width;
            typeStatPerYear.Dock = DockStyle.None;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Maroon;
            chartArea1.Name = "ChartArea1";
            chartArea1.InnerPlotPosition.Auto = true;
            typeStatPerYear.ChartAreas.Add(chartArea1);
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Gray;
            typeStatPerYear.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.Gray;
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.LineColor = Color.Gray;
            typeStatPerYear.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Gray;
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.Minimum = new DateTime(DateTime.Now.Year, 1, 1).ToOADate();
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.Maximum = new DateTime(DateTime.Now.Year, 12, 31).ToOADate();
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Months;
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "MMM";
            typeStatPerYear.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            legend1.Position.Auto = true;
            legend1.Title = areaType;
            legend1.Docking = Docking.Top;
            legend1.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleForeColor = System.Drawing.Color.White;
            typeStatPerYear.Legends.Add(legend1);
            typeStatPerYear.Name = "TypeDetail";
            typeStatPerYear.Series.Add(new Series()
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.DarkOrange,
                Name = DateTime.Now.Year.ToString()
            });

            for (int i = 1; i <= 12; i++)
            {
                lstBoo = _intBoo.Bookings.Where(b => Area.GetAreaFromId(b.AreaId, _intBoo.Areas) != null).ToList();
                lstBoo = lstBoo.Where(b => Area.GetAreaFromId(b.AreaId, _intBoo.Areas).Type.ToString().ToLower().Equals(areaType.ToLower())).ToList();
                lstBoo = lstBoo.Where(b => b.CheckIn.Month.ToString().Equals(i.ToString())).ToList();
                lstBoo = lstBoo.Where(b => b.CheckIn.Year.ToString().Equals(DateTime.Now.Year.ToString())).ToList();
                typeStatPerYear.Series[DateTime.Now.Year.ToString()].Points.AddXY(new DateTime(DateTime.Now.Year, i, 1), lstBoo.Count());
            }

            this.Controls.Add(typeStatPerYear);
        }
        private void AdjustWindows()
        {
            this.Invalidate();
            this.SuspendLayout();
            //worldMapView.Top = panelStatUsers.Height + 50;
            //panelCountries.Top = panelStatUsers.Height + 50;
            //this.Height = (panelCountries.Height > worldMapView.Height ? panelCountries.Height : worldMapView.Height) + panelStatUsers.Height + 100;
            this.Height = panelStatUsers.Height + 100;
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name.Equals("TypeDetail"))
                {
                    this.Height += ctrl.Height + 25;
                }
            }
            this.ResumeLayout();
            this.Invalidate();
        }
        #endregion

        #region Event
        #endregion
    }
}
