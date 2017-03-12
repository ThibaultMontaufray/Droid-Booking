﻿using Droid_People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewWelcome : UserControl, IView
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
            LoadNationalities();
            LoadGlobalStat();

            label1.Text = GetText.Text("Occupancy") + " : ";
            labelAreas.Text = GetText.Text("AreaCapacityDetails") + " : ";
            labelName.Text = GetText.Text("currentNationalities");
        }
        public void RefreshData()
        {
            LoadNationalities();
            LoadGlobalStat();
            ChangeLanguage();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _nationalities = new Dictionary<string, int>();
            _areas = new Dictionary<string, int>();
            _areasCapacity = new Dictionary<string, int>();

            RefreshData();
        }
        private void LoadNationalities()
        {
            if (_intBoo != null)
            {
                Label labelNat;
                int posY = 30;
                _nationalities.Clear();
                foreach (Person person in _intBoo.Persons)
                {
                    if (!_nationalities.ContainsKey(person.Nationality)) { _nationalities.Add(person.Nationality, _intBoo.Persons.Where(u => person.Nationality.Equals(u.Nationality)).Count()); }
                }
                foreach (var nat in _nationalities.OrderByDescending(n => n.Value))
                {
                    labelNat = new Label();
                    labelNat.Text = string.Format("{0} : {1}", nat.Key, nat.Value);
                    labelNat.Left = 5;
                    labelNat.Top = posY;
                    labelNat.ForeColor = System.Drawing.Color.White;
                    labelNat.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    labelNat.AutoSize = true;
                    panelCountries.Controls.Add(labelNat);
                    posY += labelNat.Height + 5;
                    panelCountries.Height += labelNat.Height + 5; ;
                }
            }
        }
        private void LoadGlobalStat()
        {
            if (_intBoo != null)
            {
                Label labelArea;
                int posY = 65;
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
                if (totalCapacity != 0) { labelOccupancy.Text = string.Format("{0} / {1} ( {2} {3} % )", currentBooks.Count, totalCapacity, GetText.Text("Rate"), currentBooks.Count * 100 / totalCapacity); }
                else labelOccupancy.Text = GetText.Text("Empty");

                foreach (var area in _areasCapacity.OrderByDescending(n => n.Value))
                {
                    labelArea = new Label();
                    labelArea.Text = string.Format(" - {0} : {1} / {2}", area.Key.ToLower(), _areas[area.Key], area.Value);
                    labelArea.Left = 20;
                    labelArea.Top = posY;
                    labelArea.ForeColor = System.Drawing.Color.White;
                    labelArea.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    labelArea.AutoSize = true;
                    panelStatUsers.Controls.Add(labelArea);
                    posY += labelArea.Height + 5;
                    panelStatUsers.Height += labelArea.Height + 5; ;
                }
            }
        }
        #endregion

        #region Event
        #endregion
    }
}
