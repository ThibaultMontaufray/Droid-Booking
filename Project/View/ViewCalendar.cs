using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Tools4Libraries;

namespace Droid_Booking
{
    public partial class ViewCalendar : UserControl, IView
    {
        #region Attribute
        private Interface_booking _intBoo;
        private DateTime _startDate;
        #endregion

        #region Properties
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        #endregion

        #region Constructor
        public ViewCalendar()
        {
            _startDate = DateTime.MinValue;
            InitializeComponent();
            Init();
        }
        public ViewCalendar(Interface_booking intBoo)
        {
            _startDate = DateTime.MinValue;
            _intBoo = intBoo;

            InitializeComponent();
            BuildCalendar();
            Init();
        }
        #endregion

        #region Methods public
        public void ChangeLanguage()
        {

        }
        public void RefreshData()
        {

        }
        #endregion

        #region Methods private
        private void Init()
        {
            ChangeLanguage();
        }
        private void BuildCalendar()
        {
            if (_startDate == DateTime.MinValue) { _startDate = DateTime.Now.AddDays(-7); }
            BuildColumns();
            BuildRows();
            LoadBookings();
        }
        private void BuildColumns()
        {
            DataGridViewColumn column;
            for (int i = 0; i < 30; i++)
            {
                //column = new DataGridViewTextBoxColumn();
                column = new TextAndImageColumn();
                column.Name = "Day" + i;
                column.HeaderText = string.Format("{0}\r\n{1}", _startDate.AddDays(i).DayOfWeek, _startDate.AddDays(i).Day);
                column.Width = 76;
                column.Tag = _startDate.AddDays(i);
                (column as TextAndImageColumn).Image = Properties.Resources.CenterWhite;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (_startDate.AddDays(i).DayOfWeek == DayOfWeek.Saturday || _startDate.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                {
                    column.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
                _dataGridViewPreview.Columns.Add(column);
            }
        }
        private void BuildRows()
        {
            DataGridViewRow row;
            int headerWidth = _dataGridViewPreview.RowHeadersWidth;
            foreach (Area area in _intBoo.Areas)
            {
                row = new DataGridViewRow();
                row.HeaderCell.Value = string.Format("{0} - {1}", area.Type.ToString(), area.Name);
                row.Tag = area.Id;
                row.Height = 30;
                headerWidth = area.Type.ToString().Length * 15 + area.Name.Length * 15;
                if (_dataGridViewPreview.RowHeadersWidth < headerWidth) { _dataGridViewPreview.RowHeadersWidth = headerWidth; }
                Image[] parameters = new Image[_dataGridViewPreview.Columns.Count];
                _dataGridViewPreview.Rows.Add(row);
            }
        }
        private void LoadBookings()
        {
            int indexRow;
            int countBooking;
            int capacityBooking;
            int[] indexColumns;
            foreach (Booking booking in _intBoo.Bookings)
            {
                var res = (from r in _dataGridViewPreview.Rows.Cast<DataGridViewRow>() where (r.Tag).Equals(booking.AreaId) select r.Index).ToList();
                if (res.Count > 0)
                { 
                    indexRow = res.First();
                    indexColumns = (from c in _dataGridViewPreview.Columns.Cast<DataGridViewColumn>() where ((DateTime)c.Tag) >= booking.CheckIn && ((DateTime)c.Tag) <= booking.CheckOut select c.Index).ToArray();

                    foreach (int indexColumn in indexColumns)
                    {
                        countBooking = _intBoo.Bookings.Where(b => b.CheckIn.Date <= ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date && b.CheckOut.Date >= ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date).Count();
                        capacityBooking = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas).Capacity;
                        (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Value = string.Format("{0} / {1}", countBooking, capacityBooking);
                        if (countBooking == capacityBooking)
                        {
                            (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.CenterRed;
                        }
                        else if (countBooking >= capacityBooking / 2)
                        {
                            (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.CenterOrange;
                        }
                        else
                        {
                            (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.CenterGreen;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
