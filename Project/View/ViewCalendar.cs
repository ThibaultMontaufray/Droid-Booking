using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewCalendar : UserControl
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
        }
        public ViewCalendar(Interface_booking intBoo)
        {
            _startDate = DateTime.MinValue;
            _intBoo = intBoo;

            InitializeComponent();
            BuildCalendar();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
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
                column = new DataGridViewTextBoxColumn();
                column.Name = "Day" + i;
                column.HeaderText = string.Format("{0}\r\n{1}", _startDate.AddDays(i).DayOfWeek, _startDate.AddDays(i).Day);
                column.Width = 76;
                column.Tag = _startDate.AddDays(i);
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
                row.Tag = area;
                headerWidth = area.Type.ToString().Length * 15 + area.Name.Length * 15;
                if (_dataGridViewPreview.RowHeadersWidth < headerWidth) { _dataGridViewPreview.RowHeadersWidth = headerWidth; }
                _dataGridViewPreview.Rows.Add(row);
            }
        }
        private void LoadBookings()
        {
            int indexRow;
            int[] indexColumns;
            string val;
            foreach (Book book in _intBoo.Books)
            {
                indexRow = (from r in _dataGridViewPreview.Rows.Cast<DataGridViewRow>() where (r.Tag as Area).Equals(book.Area) select r.Index).First();
                indexColumns = (from c in _dataGridViewPreview.Columns.Cast<DataGridViewColumn>() where ((DateTime)c.Tag) >= book.StartDate && ((DateTime)c.Tag) <= book.EndDate select c.Index).ToArray();

                foreach (int indexColumn in indexColumns)
                {
                    _dataGridViewPreview.Rows[indexRow].Cells[indexColumn].Style.BackColor = book.Area.Color;
                    val = _dataGridViewPreview.Rows[indexRow].Cells[indexColumn].Value == null ? string.Empty : _dataGridViewPreview.Rows[indexRow].Cells[indexColumn].Value.ToString();
                    UpdateCellValue(ref val, book.Area.Capacity);
                    _dataGridViewPreview.Rows[indexRow].Cells[indexColumn].Value = val;
                }
            }
        }
        private void UpdateCellValue(ref string val, int capacity)
        {
            string[] tab;
            int count;
            if (string.IsNullOrEmpty(val))
            {
                val = string.Format("1 / {0}", capacity);
            }
            else
            {
                tab = val.Split('/');
                count = int.Parse(tab[0].Trim()) + 1;
                val = string.Format("{0} / {1}", count, capacity);
            }
        }
        #endregion
    }
}
