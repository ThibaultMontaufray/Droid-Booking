using System;

namespace Droid_Booking
{
    public class Book
    {
        #region Attribute
        private User _user;
        private Area _area;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _confirmed;
        private decimal _price;
        private decimal _paid;
        #endregion

        #region Properties
        public decimal Paid
        {
            get { return _paid; }
            set { _paid = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public Area Area
        {
            get { return _area; }
            set { _area = value; }
        }
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        #endregion

        #region Constructor
        public Book()
        {
            _confirmed = false;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
