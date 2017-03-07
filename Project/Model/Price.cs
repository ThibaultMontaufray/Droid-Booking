using System;

namespace Droid_Booking
{
    public class Price
    {
        #region Attribute
        private decimal _amount;
        private string _place;
        private string _type;
        private string _name;
        private int _priority; // 0 is the worst
        private DateTime _dateStart;
        private DateTime _dateEnd;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        #endregion

        #region Constructor
        public Price()
        {
            _dateEnd = DateTime.MaxValue;
            _dateStart = DateTime.MinValue;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
