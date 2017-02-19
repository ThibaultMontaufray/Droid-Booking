using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewWelcome : UserControl
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
        #endregion

        #region Methods private
        private void Init()
        {
            _nationalities = new Dictionary<string, int>();
            _areas = new Dictionary<string, int>();
            _areasCapacity = new Dictionary<string, int>();

            LoadNationalities();
            LoadGlobalStat();
        }
        private void LoadNationalities()
        {
            if (_intBoo != null)
            {
                Label labelNat;
                int posY = 30;
                _nationalities.Clear();
                foreach (User user in _intBoo.Users)
                {
                    if (!_nationalities.ContainsKey(user.Country)) { _nationalities.Add(user.Country, _intBoo.Users.Where(u => user.Country.Equals(u.Country)).Count()); }
                }
                foreach (var nat in _nationalities.OrderByDescending(n => n.Value))
                {
                    labelNat = new Label();
                    labelNat.Text = string.Format("{0} : {1}", nat.Key, nat.Value);
                    labelNat.Left = 5;
                    labelNat.Top = posY;
                    labelNat.ForeColor = System.Drawing.Color.White;
                    labelNat.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                List<Book> currentBooks = _intBoo.Books.Where(b => b.StartDate < DateTime.Now && b.EndDate > DateTime.Now).ToList();
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
                foreach (Book book in currentBooks)
                {
                    _areas[book.Area.Type.ToString()] += 1;
                }
                labelOccupancy.Text = string.Format("{0} / {1} ( rate {2} % )", currentBooks.Count, totalCapacity, currentBooks.Count * 100 / totalCapacity);
                
                foreach (var area in _areasCapacity.OrderByDescending(n => n.Value))
                {
                    labelArea = new Label();
                    labelArea.Text = string.Format(" - {0} : {1} / {2}", area.Key.ToLower(), _areas[area.Key], area.Value);
                    labelArea.Left = 20;
                    labelArea.Top = posY;
                    labelArea.ForeColor = System.Drawing.Color.White;
                    labelArea.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
