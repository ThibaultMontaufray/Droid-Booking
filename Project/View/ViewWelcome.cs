using Droid_People;
using Droid_Geography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_Booking
{
    public partial class ViewWelcome : UserControlCustom, IView
    {
        #region Attribute
        private Interface_booking _intBoo;
        private Dictionary<string, int> _nationalities;
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
        public void ChangeLanguage()
        {
            //labelOccTitle.Text = GetText.Text("Occupancy") + " : ";
            //labelAreas.Text = GetText.Text("AreaCapacityDetails") + " : ";
            labelName.Text = GetText.Text("currentNationalities");
        }
        public void RefreshData()
        {
            LoadNationalities();
            LoadGlobalStat();
            AdjustWindows();

            ChangeLanguage();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _nationalities = new Dictionary<string, int>();
            _areas = new Dictionary<string, int>();
            _areasCapacity = new Dictionary<string, int>();
            worldMapView.CurrentWorldMap.Mode = WorldMap.PresentationMode.CUSTOM;
        }
        private void LoadNationalities()
        {
            if (_intBoo != null)
            {
                _nationalities.Clear();
                foreach (Person person in _intBoo.Persons)
                {
                    if (!_nationalities.ContainsKey(person.Nationality)) { _nationalities.Add(person.Nationality, _intBoo.Persons.Where(u => person.Nationality.Equals(u.Nationality)).Count()); }
                }

                worldMapView.CurrentWorldMap.ClearCustomValues();
                chartCountries.Series["Series1"].Points.Clear();
                foreach (var nat in _nationalities.OrderBy(n => n.Value))
                {
                    chartCountries.Series["Series1"].Points.AddXY(nat.Key, nat.Value);
                    if (!string.IsNullOrEmpty(nat.Key))
                    {
                        var country = worldMapView.CurrentWorldMap.Countries.Where(c => c.Name.Equals(nat.Key)).First();
                        country.CustomValue = nat.Value;
                    }
                }
            }
            worldMapView.UpdateMap();
        }
        private void LoadGlobalStat()
        {
            if (_intBoo != null)
            {
                int indexPoint = 0;
                List<Booking> currentBooks = _intBoo.Bookings.Where(b => b.CheckIn < DateTime.Now && b.CheckOut > DateTime.Now).ToList();
                int totalCapacity = 0;
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
                foreach (Booking booking in currentBooks)
                {
                    _areas[Area.GetAreaFromId(booking.AreaId, _intBoo.Areas).Type.ToString()] += 1;
                }

                chartTypeRepartition.Series["Types"].Points.Clear();
                chartMainOccupancy.Series["Occupancy"].Points.Clear();
                chartMainOccupancy.Series["Occupancy"].Points.AddXY("Reserved", currentBooks.Count);
                chartMainOccupancy.Series["Occupancy"].Points.AddXY("Available", totalCapacity - currentBooks.Count);
                chartMainOccupancy.Series["Occupancy"].Points[0].Color = System.Drawing.Color.Maroon;
                chartMainOccupancy.Series["Occupancy"].Points[1].Color = System.Drawing.Color.DarkOrange;

                chartTypeDetail.Series["Occupancy"].Points.Clear();
                chartTypeDetail.Series["Available"].Points.Clear();
                foreach (var area in _areasCapacity.OrderByDescending(n => n.Value))
                {
                    chartTypeDetail.Series["Occupancy"].Points.AddXY(area.Key.ToLower(), _areas[area.Key]);
                    chartTypeDetail.Series["Available"].Points.AddXY(area.Key, area.Value - _areas[area.Key]);
                    chartTypeRepartition.Series["Types"].Points.AddXY(area.Key, area.Value);
                    //chartTypeDetail.Series["Occupancy"].Points[indexPoint].LegendText = "#VALX";//area.Key.ToLower();
                    //chartTypeDetail.Series["Available"].Points[indexPoint].LegendText = "#VALX";//area.Key.ToLower();
                    indexPoint++;
                }
            }
        }
        private void AdjustWindows()
        {
            this.Invalidate();
            this.SuspendLayout();
            worldMapView.Top = panelStatUsers.Height + 50;
            panelCountries.Top = panelStatUsers.Height + 50;
            this.Height = (panelCountries.Height > worldMapView.Height ? panelCountries.Height : worldMapView.Height) + panelStatUsers.Height + 100;
            this.ResumeLayout();
            this.Invalidate();
        }
        #endregion

        #region Event
        #endregion
    }
}
