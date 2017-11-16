using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Tools4Libraries;
using Droid_People;
using System.Reflection;
using Droid_financial;

namespace Droid_Booking
{
    public partial class ViewCalendar : UserControlCustom, IView
    {
        #region Enum
        public enum DisplayMode
        {
            STATUS,
            OCCUPANCY,
            PAYMENT
        }
        #endregion

        #region Attribute
        private Interface_booking _intBoo;
        private DateTime _startDate;
        private bool _lockCheckBox;
        private List<Area.TYPE> _filterType;
        private List<int> _filterCapacity;
        private int _selectedCheckInRow;
        private int _selectedCheckOutRow;
        private Area _currentArea;
        private DateTime _currentDate;
        private DisplayMode _currentDisplayMode;
        #endregion

        #region Properties
        public DisplayMode CurrentDisplayMode
        {
            get { return _currentDisplayMode; }
            set { _currentDisplayMode = value; }
        }
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
        public override void ChangeLanguage()
        {

        }
        public override void RefreshData()
        {
            LoadBookings();
            LoadFilter();
            LoadCheckIn();
            LoadCheckOut();
            LoadCurrentUsers();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _currentDisplayMode = DisplayMode.OCCUPANCY;
            _selectedCheckInRow = -1;
            _selectedCheckOutRow = -1;
            _dataGridViewPreview.Rows.Clear();

            BuildRows();
            ChangeLanguage();
        }
        private void BuildCalendar()
        {
            if (_startDate == DateTime.MinValue) { _startDate = DateTime.Now.AddDays(-7); }
            BuildColumns();
            BuildRows();

            RefreshData();
        }
        private void BuildColumns()
        {
            DataGridViewColumn column;

            _dataGridViewPreview.Columns.Clear();
            for (int i = 0; i < 90; i++)
            {
                column = new TextAndImageColumn();
                column.Name = "Day" + i;
                column.HeaderText = string.Format("{0}\r\n{1}", _startDate.AddDays(i).DayOfWeek.ToString().Substring(0, 3), _startDate.AddDays(i).Day);
                column.Width = 30;
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
            _intBoo.Areas.Sort(delegate(Area a, Area b) { return a.Name.CompareTo(b.Name); });
            foreach (Area area in _intBoo.Areas)
            {
                row = new DataGridViewRow();
                row.HeaderCell.Value = area.ToString();
                row.Tag = area;
                row.Height = 30;
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 64, 64, 64);
                headerWidth = area.Type.ToString().Length * 15 + area.Name.Length * 15;
                if (_dataGridViewPreview.RowHeadersWidth < headerWidth) { _dataGridViewPreview.RowHeadersWidth = headerWidth; }
                Image[] parameters = new Image[_dataGridViewPreview.Columns.Count];
                _dataGridViewPreview.Rows.Add(row);
            }
        }
        private void LoadBookings()
        {
            switch (_currentDisplayMode)
            {
                case DisplayMode.STATUS:
                    LoadBookingsStatus();
                    break;
                case DisplayMode.PAYMENT:
                    LoadBookingsPayment();
                    break;
                case DisplayMode.OCCUPANCY:
                default:
                    LoadBookingOccupancy();
                    break;
            }
        }
        private void LoadBookingOccupancy()
        {
            int indexRow;
            int seuilAM, seuilPM;
            int countBookingCheckIn;
            int countBookingCheckOut;
            int countBookingCountinuous;
            int capacityBooking;
            int[] indexColumns;

            foreach (Booking booking in _intBoo.Bookings)
            {
                var res = (from r in _dataGridViewPreview.Rows.Cast<DataGridViewRow>() where (((Area)r.Tag).Id).Equals(booking.AreaId) select r.Index).ToList();
                if (res.Count > 0)
                {
                    indexRow = res.First();
                    indexColumns = (from c in _dataGridViewPreview.Columns.Cast<DataGridViewColumn>() where ((DateTime)c.Tag) >= booking.CheckIn && ((DateTime)c.Tag) <= booking.CheckOut.AddDays(1) select c.Index).ToArray();

                    foreach (int indexColumn in indexColumns)
                    {
                        countBookingCountinuous = _intBoo.Bookings.Where(b =>
                            b.CheckIn.Date < ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.CheckOut.Date > ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).Count();

                        countBookingCheckIn = _intBoo.Bookings.Where(b =>
                            b.CheckIn.Date == ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.CheckOut.Date > ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).Count();
                        countBookingCheckIn += countBookingCountinuous;

                        countBookingCheckOut = _intBoo.Bookings.Where(b =>
                            b.CheckIn.Date < ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.CheckOut.Date == ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).Count();
                        countBookingCheckOut += countBookingCountinuous;

                        capacityBooking = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas).Capacity;
                        (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Value = string.Format("AM : {0}/{1} PM : {2}/{1}", countBookingCheckOut, capacityBooking, countBookingCheckIn);
                        
                        if (countBookingCheckIn == capacityBooking) { seuilPM = 0; }
                        else if (countBookingCheckIn <= capacityBooking / 2) { seuilPM = 2; }
                        else { seuilPM = 1; }
                        
                        if (countBookingCheckOut == capacityBooking) { seuilAM = 0; }
                        else if (countBookingCheckOut <= capacityBooking / 2) { seuilAM = 2; }
                        else { seuilAM = 1; }

                        ProcessColoration(countBookingCheckIn, countBookingCheckOut, seuilAM, seuilPM, indexRow, indexColumn);
                    }
                }
            }
        }
        private void LoadBookingsStatus()
        {
            int indexRow;
            //int seuilAM, seuilPM;
            //int countBookingCountinuous;
            //int capacityBooking;
            int[] indexColumns;

            foreach (Booking booking in _intBoo.Bookings)
            {
                var res = (from r in _dataGridViewPreview.Rows.Cast<DataGridViewRow>() where (((Area)r.Tag).Id).Equals(booking.AreaId) select r.Index).ToList();
                if (res.Count > 0)
                {
                    indexRow = res.First();
                    indexColumns = (from c in _dataGridViewPreview.Columns.Cast<DataGridViewColumn>() where ((DateTime)c.Tag) >= booking.CheckIn && ((DateTime)c.Tag) <= booking.CheckOut.AddDays(1) select c.Index).ToArray();

                    //foreach (int indexColumn in indexColumns)
                    //{
                    //    countBookingCountinuous = _intBoo.Bookings.Where(b =>
                    //        b.CheckIn.Date < ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                    //        b.CheckOut.Date > ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                    //        b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).Count();

                    //    countBookingCheckIn = _intBoo.Bookings.Where(b =>
                    //        b.CheckIn.Date == ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                    //        b.CheckOut.Date > ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                    //        b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).Count();
                    //    countBookingCheckIn += countBookingCountinuous;

                    //    countBookingCheckOut = _intBoo.Bookings.Where(b =>
                    //        b.CheckIn.Date < ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                    //        b.CheckOut.Date == ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                    //        b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).Count();
                    //    countBookingCheckOut += countBookingCountinuous;

                    //    capacityBooking = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas).Capacity;
                    //    (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Value = string.Format("AM : {0}/{1} PM : {2}/{1}", countBookingCheckOut, capacityBooking, countBookingCheckIn);

                    //    // level AM
                    //    if (countBookingCheckIn == capacityBooking) { seuilAM = 0; }
                    //    else if (countBookingCheckIn >= capacityBooking / 2) { seuilAM = 1; }
                    //    else { seuilAM = 2; }

                    //    // level PM
                    //    if (countBookingCheckOut == capacityBooking) { seuilPM = 0; }
                    //    else if (countBookingCheckOut >= capacityBooking / 2) { seuilPM = 1; }
                    //    else { seuilPM = 2; }

                    //    ProcessColoration(countBookingCheckIn, countBookingCheckOut, seuilAM, seuilPM, indexRow, indexColumn);
                    //}
                }
            }
        }
        private void LoadBookingsPayment()
        {
            int indexRow;
            int seuilAM, seuilPM;
            int paidAM, paidPM;
            int percentAM, percentPM;
            List<Booking> bookingContinuous;
            List<Booking> bookingCheckIn;
            List<Booking> bookingCheckOut;
            int[] indexColumns;

            foreach (Booking booking in _intBoo.Bookings)
            {
                var res = (from r in _dataGridViewPreview.Rows.Cast<DataGridViewRow>() where (((Area)r.Tag).Id).Equals(booking.AreaId) select r.Index).ToList();
                if (res.Count > 0)
                {
                    indexRow = res.First();
                    indexColumns = (from c in _dataGridViewPreview.Columns.Cast<DataGridViewColumn>() where ((DateTime)c.Tag) >= booking.CheckIn && ((DateTime)c.Tag) <= booking.CheckOut.AddDays(1) select c.Index).ToArray();

                    foreach (int indexColumn in indexColumns)
                    {
                        bookingContinuous = _intBoo.Bookings.Where(b =>
                            b.CheckIn.Date < ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.CheckOut.Date > ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).ToList();

                        bookingCheckIn = _intBoo.Bookings.Where(b =>
                            b.CheckIn.Date == ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.CheckOut.Date > ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).ToList();
                        bookingCheckIn.AddRange(bookingContinuous);

                        bookingCheckOut = _intBoo.Bookings.Where(b =>
                            b.CheckIn.Date < ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.CheckOut.Date == ((DateTime)_dataGridViewPreview.Columns[indexColumn].Tag).Date &&
                            b.AreaId.Equals(((Area)_dataGridViewPreview.Rows[indexRow].Tag).Id)).ToList();
                        bookingCheckOut.AddRange(bookingContinuous);

                        paidPM = bookingCheckIn.Where(b => Expense.GetExpenseFromId(b.ExpenseId, _intBoo.CurrentFinancialActivity.ListExpenses).Amount == Expense.GetExpenseFromId(b.ExpenseId, _intBoo.CurrentFinancialActivity.ListExpenses).Paid).Count();
                        paidAM = bookingCheckOut.Where(b => Expense.GetExpenseFromId(b.ExpenseId, _intBoo.CurrentFinancialActivity.ListExpenses).Amount == Expense.GetExpenseFromId(b.ExpenseId, _intBoo.CurrentFinancialActivity.ListExpenses).Paid).Count();
                        percentAM = (bookingCheckOut.Count > 0) ? ((paidAM * 100) / bookingCheckOut.Count) : 0;
                        percentPM = (bookingCheckIn.Count > 0) ? ((paidPM * 100) / bookingCheckIn.Count) : 0;

                        if (bookingCheckIn.Count > 0 && percentAM == 100) { seuilAM = 2; }
                        else if (bookingCheckIn.Count > 0 && percentAM > 50) { seuilAM = 0; }
                        else if (bookingCheckIn.Count > 0 ) { seuilAM = 1; }
                        else { seuilAM = 3; }

                        if (bookingCheckOut.Count > 0 && percentPM == 100) { seuilPM = 2; }
                        else if (bookingCheckOut.Count > 0 && percentPM > 50) { seuilPM = 0; }
                        else if (bookingCheckOut.Count > 0) { seuilPM = 1; }
                        else { seuilPM = 3; }

                        (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Value = string.Format("AM {0} - PM {1}", (bookingCheckOut.Count > 0) ? percentAM.ToString() + "%" : "N/A", (bookingCheckIn.Count > 0) ? percentPM.ToString() + "%" : "N/A");
                        
                        ProcessColoration(bookingCheckIn.Count, bookingCheckOut.Count, seuilAM, seuilPM, indexRow, indexColumn);
                    }
                }
            }
        }
        private void ProcessColoration(int countBookingCheckIn, int countBookingCheckOut, int seuilAM, int seuilPM, int indexRow, int indexColumn)
        {
            // coloration
            if (countBookingCheckIn == 0 && countBookingCheckOut == 0)
            {
                return;
            }
            else if (countBookingCheckIn != 0 && countBookingCheckOut != 0)
            {
                // full
                if (seuilAM == 2 && seuilPM == 2) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.CenterGreen; }
                if (seuilAM == 2 && seuilPM == 1) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startOrangeEndGreen; }
                if (seuilAM == 2 && seuilPM == 0) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startRedEndGreen; }

                if (seuilAM == 1 && seuilPM == 2) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startGreenEndOrange; }
                if (seuilAM == 1 && seuilPM == 1) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.CenterOrange; }
                if (seuilAM == 1 && seuilPM == 0) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startRedEndOrange; }

                if (seuilAM == 0 && seuilPM == 2) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startGreenEndRed; }
                if (seuilAM == 0 && seuilPM == 1) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startOrangeEndRed; }
                if (seuilAM == 0 && seuilPM == 0) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.CenterRed; }
            }
            else if (countBookingCheckIn == 0 && countBookingCheckOut != 0)
            {
                // end only
                if (seuilAM == 2) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.endGreen; }
                if (seuilAM == 1) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.endOrange; }
                if (seuilAM == 0) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.endRed; }
            }
            else if (countBookingCheckIn != 0 && countBookingCheckOut == 0)
            {
                // start only
                if (seuilPM == 2) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startGreen; }
                if (seuilPM == 1) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startOrange; }
                if (seuilPM == 0) { (_dataGridViewPreview.Rows[indexRow].Cells[indexColumn] as TextAndImageCell).Image = Properties.Resources.startRed; }
            }
        }
        private void LoadCheckIn()
        {
            Person user;
            Area area;
            DataGridViewRow row;

            _dataGridViewCheckIn.Rows.Clear();
            foreach (var booking in _intBoo.Bookings.Where(b => b.CheckIn.Date.Equals(DateTime.Now.Date)).ToList())
            {
                user = Person.GetPersonFromId(booking.UserId, _intBoo.Persons);
                area = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas);

                if (user != null)
                { 
                    _dataGridViewCheckIn.Rows.Add();
                    row = _dataGridViewCheckIn.Rows[_dataGridViewCheckIn.Rows.Count - 1];
                    row.Tag = user;
                    row.Cells[ColumnCheckIn.Index].Value = user.ToString();
                    row.Cells[ColumnArea.Index].Value = area.Name;
                    row.Cells[ColumnStatus.Index].Value = booking.Confirmed;
                }
            }
        }
        private void LoadCheckOut()
        {
            Person user;
            Area area;
            DataGridViewRow row;

            _dataGridViewCheckOut.Rows.Clear();
            foreach (var booking in _intBoo.Bookings.Where(b => b.CheckOut.Date.Equals(DateTime.Now.Date)).ToList())
            {
                user = Person.GetPersonFromId(booking.UserId, _intBoo.Persons);
                area = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas);

                if (user != null)
                {
                    _dataGridViewCheckOut.Rows.Add();
                    row = _dataGridViewCheckOut.Rows[_dataGridViewCheckOut.Rows.Count - 1];
                    row.Tag = user;
                    row.Cells[ColumnCheckIn.Index].Value = user.ToString();
                    row.Cells[ColumnArea.Index].Value = area.Name;
                    row.Cells[ColumnStatus.Index].Value = booking.Confirmed;
                }
            }
        }
        private void LoadCurrentUsers()
        {
            Person pers;
            _comboBoxCurrentUsers.Items.Clear();
            foreach (var persId in _intBoo.Bookings.Where(b => b.CheckIn.Date <= DateTime.Now.Date && b.CheckOut.Date >= DateTime.Now.Date).Select(o => o.UserId).Distinct().ToList())
            {
                pers = Person.GetPersonFromId(persId, _intBoo.Persons);
                if (pers != null) _comboBoxCurrentUsers.Items.Add(pers);
            }
            _comboBoxCurrentUsers.Sorted = true;
        }
        private void LoadFilter()
        {
            int top = 42;
            CheckBox cb;
            _filterType = _intBoo.Areas.Select(o => o.Type).Distinct().ToList();
            _filterCapacity = _intBoo.Areas.Select(o => o.Capacity).Distinct().ToList();

            _filterType.Sort();
            _filterCapacity.Sort();

            panelTypes.Controls.Clear();
            panelTypes.Controls.Add(checkBoxType);
            panelTypes.Controls.Add(pictureBoxType);
            foreach (Area.TYPE type in _filterType)
            {
                cb = new CheckBox();
                cb.Top = top;
                cb.Left = 15;
                cb.Text = type.ToString();
                cb.Checked = true;
                cb.Name = type.ToString();
                cb.CheckedChanged += CbType_CheckedChanged;
                panelTypes.Controls.Add(cb);

                top += 24;
            }

            top = 42;
            panelCapacities.Controls.Clear();
            panelCapacities.Controls.Add(checkBoxCapa);
            panelCapacities.Controls.Add(pictureBoxCapacity);
            foreach (int val in _filterCapacity)
            {
                cb = new CheckBox();
                cb.Top = top;
                cb.Left = 15;
                cb.Text = val.ToString();
                cb.Checked = true;
                cb.Name = val.ToString();
                cb.CheckedChanged += CbCapa_CheckedChanged;
                panelCapacities.Controls.Add(cb);

                top += 24;
            }
        }
        private void PanelTypeExpand()
        {
            panelTypes.Height = (panelTypes.Controls.Count * 24) + 30;
        }
        private void PanelTypeReduce()
        {
            panelTypes.Height = 42;
        }
        private void PanelCapacityExpand()
        {
            panelCapacities.Height = (panelCapacities.Controls.Count * 24) + 30;
        }
        private void PanelCapacityReduce()
        {
            panelCapacities.Height = 42;
        }
        private void ApplyFilter()
        {
            Person guest;
            if (_selectedCheckInRow != -1) { guest = (Person)_dataGridViewCheckIn.Rows[_selectedCheckInRow].Tag; }
            else if (_selectedCheckOutRow != -1) { guest = (Person)_dataGridViewCheckOut.Rows[_selectedCheckOutRow].Tag; }
            else { guest = (Person)_comboBoxCurrentUsers.SelectedItem; }
            
            if (guest != null)
            {
                List<string> userArea = _intBoo.Bookings.Where(b => b.UserId.Equals(guest.Id)).Select(o => o.AreaId).ToList();

                foreach (DataGridViewRow row in _dataGridViewPreview.Rows)
                {
                    row.Visible = (_filterType.Contains(((Area)row.Tag).Type) && _filterCapacity
                        .Contains(((Area)row.Tag).Capacity) &&
                        userArea.Contains(((Area)row.Tag).Id));
                }
            }
            else
            { 
                foreach (DataGridViewRow row in _dataGridViewPreview.Rows)
                {
                    row.Visible = (_filterType.Contains(((Area)row.Tag).Type) && _filterCapacity.Contains(((Area)row.Tag).Capacity));
                }
            }
        }
        private void UpdateTypeCheck()
        {
            bool checkFull = true;
            bool checkEmpty = true;

            _filterType.Clear();

            foreach (Control ctrl in panelTypes.Controls)
            {
                if (ctrl is CheckBox && !((CheckBox) ctrl).Name.Equals("checkBoxType"))
                {
                    if (((CheckBox) ctrl).Checked )
                    {
                        _filterType.Add((Area.TYPE)Enum.Parse(typeof(Area.TYPE), ctrl.Name));
                        checkEmpty = false;
                    }
                    else
                    {
                        checkFull = false;
                    }
                }
            }

            checkBoxType.CheckedChanged -= checkBoxType_CheckedChanged;
            if (checkFull) { checkBoxType.CheckState = CheckState.Checked; }
            else if (checkEmpty) { checkBoxType.CheckState = CheckState.Unchecked; }
            else { checkBoxType.CheckState = CheckState.Indeterminate; }
            checkBoxType.CheckedChanged += checkBoxType_CheckedChanged;

            ApplyFilter();
        }
        private void UpdateCapaCheck()
        {
            bool checkFull = true;
            bool checkEmpty = true;

            _filterCapacity.Clear();

            foreach (Control ctrl in panelCapacities.Controls)
            {
                if (ctrl is CheckBox && !((CheckBox)ctrl).Name.Equals("checkBoxCapa"))
                {
                    if (((CheckBox)ctrl).Checked)
                    {
                        _filterCapacity.Add(int.Parse(ctrl.Name));
                        checkEmpty = false;
                    }
                    else
                    {
                        checkFull = false;
                    }
                }
            }

            checkBoxCapa.CheckedChanged -= checkBoxCapa_CheckedChanged;
            if (checkFull) { checkBoxCapa.CheckState = CheckState.Checked; }
            else if (checkEmpty) { checkBoxCapa.CheckState = CheckState.Unchecked; }
            else { checkBoxCapa.CheckState = CheckState.Indeterminate; }
            checkBoxCapa.CheckedChanged += checkBoxCapa_CheckedChanged;

            ApplyFilter();
        }
        private void ChangeDate()
        {
            _startDate = monthCalendar.SelectionStart.Date;
            BuildColumns();

            _dataGridViewPreview.ClearSelection();
            foreach (DataGridViewColumn column in _dataGridViewPreview.Columns)
            {
                if (((DateTime)column.Tag).Date.Equals(_startDate))
                {
                    _dataGridViewPreview.Columns[column.Index].Selected = true;
                    break;
                }
            }
        }
        private void BuildConctextMenu(int top, int left)
        {
            Person user;
            ToolStripMenuItem tsmItem;
            List<Booking> bookingsFilter;
            List<Booking> bookings = _intBoo.Bookings.Where(b => b.AreaId.Equals(_currentArea.Id) && b.CheckIn.Date <= _currentDate.Date && b.CheckOut.Date >= _currentDate.Date).ToList();

            if (_currentArea != null)
            {
                ContextMenuStrip m = new ContextMenuStrip();
                foreach (var place in _currentArea.Place)
                {
                    bookingsFilter = bookings.Where(b => b.Place.Equals(place.Key)).ToList();
                    if (bookingsFilter.Count() == 0)
                    {
                        tsmItem = new ToolStripMenuItem(string.Format("Create booking place \"{0}\"", place.Key));
                        tsmItem.Image = Tools4Libraries.Resources.ResourceIconSet16Default.user_silhouette;
                        tsmItem.Click += TsmItem_Click;

                        m.Items.Add(tsmItem);
                    }
                    else
                    {
                        foreach (Booking booking in bookingsFilter)
                        {
                            user = Person.GetPersonFromId(booking.UserId, _intBoo.Persons);

                            tsmItem = new ToolStripMenuItem(string.Format("Edit booking place \"{0}\" for {1}", place.Key, user.ToString()));
                            tsmItem.Image = Tools4Libraries.Resources.ResourceIconSet16Default.user_edit;
                            tsmItem.Tag = booking;
                            tsmItem.Click += TsmItem_Click;

                            m.Items.Add(tsmItem);
                        }
                    }
                }
                m.Show(_dataGridViewPreview, new Point(left, top));
            }
        }
        private void CreateBooking(Booking booking , string place)
        {
            Booking b = new Booking();
            b.CheckIn = _currentDate;
            b.CheckOut = _currentDate.AddDays(1);
            b.AreaId = _currentArea.Id;
            b.Place = place;
            _intBoo.CurrentBooking = b;
            _intBoo.GoAction("bookedit");
        }
        private void EditBooking(Booking booking)
        {
            _intBoo.CurrentBooking = booking;
            _intBoo.GoAction("bookedit");
        }
        #endregion

        #region Event
        private void type_Click(object sender, EventArgs e)
        {
            if (panelTypes.Height == 42)
            {
                PanelTypeExpand();
            }
            else
            {
                PanelTypeReduce();
            }
        }
        private void capacities_Click(object sender, EventArgs e)
        {
            if (panelCapacities.Height == 42)
            {
                PanelCapacityExpand();
            }
            else
            {
                PanelCapacityReduce();
            }
        }
        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            _lockCheckBox = true;
            foreach (Control ctrl in panelTypes.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = checkBoxType.Checked;
                }
            }
            _lockCheckBox = false;
            UpdateTypeCheck();
        }
        private void checkBoxCapa_CheckedChanged(object sender, EventArgs e)
        {
            _lockCheckBox = true;
            foreach (Control ctrl in panelCapacities.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = checkBoxCapa.Checked;
                }
            }
            _lockCheckBox = false;
            UpdateCapaCheck();
        }
        private void CbType_CheckedChanged(object sender, EventArgs e)
        {
            if (!_lockCheckBox)
            { 
                UpdateTypeCheck();
            }
        }
        private void CbCapa_CheckedChanged(object sender, EventArgs e)
        {
            if (!_lockCheckBox)
            {
                UpdateCapaCheck();
            }
        }
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            ChangeDate();
        }
        private void panel_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.HSplit;
        }
        private void panel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            _selectedCheckInRow = -1;
            _selectedCheckOutRow = -1;
            _comboBoxCurrentUsers.SelectedItem = null;
            _dataGridViewCheckIn.ClearSelection();
            _dataGridViewCheckOut.ClearSelection();
            ApplyFilter();
        }
        private void _comboBoxCurrentUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCheckInRow = -1;
            _selectedCheckOutRow = -1;
            _dataGridViewCheckIn.ClearSelection();
            _dataGridViewCheckOut.ClearSelection();
            ApplyFilter();
        }
        private void _dataGridViewCheckIn_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _dataGridViewCheckOut.ClearSelection();
            _comboBoxCurrentUsers.SelectedItem = null;
            _selectedCheckInRow = e.RowIndex;
            ApplyFilter();
        }
        private void _dataGridViewCheckOut_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _dataGridViewCheckIn.ClearSelection();
            _comboBoxCurrentUsers.SelectedItem = null;
            _selectedCheckOutRow = e.RowIndex;
            ApplyFilter();
        }
        private void _dataGridViewPreview_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _dataGridViewPreview.HitTest(e.X, e.Y).RowIndex != -1 && _dataGridViewPreview.HitTest(e.X, e.Y).ColumnIndex != -1)
            {
                _currentArea = (Area) _dataGridViewPreview.Rows[_dataGridViewPreview.HitTest(e.X, e.Y).RowIndex].Tag;
                _currentDate = (DateTime)_dataGridViewPreview.Columns[_dataGridViewPreview.HitTest(e.X, e.Y).ColumnIndex].Tag;
                BuildConctextMenu(e.Y, e.X);
            }
        }
        private void TsmItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmItem = (ToolStripMenuItem)sender;
            string place = tsmItem.Text.Split('"')[1];
            if (tsmItem.Text.StartsWith("Create"))
            {
                CreateBooking((Booking)tsmItem.Tag, place);
            }
            else
            {
                EditBooking((Booking)tsmItem.Tag);
            }
        }
        private void buttonStatus_Click(object sender, EventArgs e)
        {
            buttonPayment.BackColor = Color.LightGray;
            buttonStatus.BackColor = Color.DarkGray;
            buttonOccupancy.BackColor = Color.LightGray;
            _currentDisplayMode = DisplayMode.STATUS;
            LoadBookings();
        }
        private void buttonOccupancy_Click(object sender, EventArgs e)
        {
            buttonPayment.BackColor = Color.LightGray;
            buttonStatus.BackColor = Color.LightGray;
            buttonOccupancy.BackColor = Color.DarkGray;
            _currentDisplayMode = DisplayMode.OCCUPANCY;
            LoadBookings();
        }
        private void buttonPayment_Click(object sender, EventArgs e)
        {
            buttonPayment.BackColor = Color.DarkGray;
            buttonStatus.BackColor = Color.LightGray;
            buttonOccupancy.BackColor = Color.LightGray;
            _currentDisplayMode = DisplayMode.PAYMENT;
            LoadBookings();
        }
        #endregion
    }
}
