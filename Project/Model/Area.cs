using System.Drawing;

namespace Droid_Booking
{
    public class Area
    {
        #region Enum
        public enum TYPE
        {
            ROOM,
            DORM,
            PARKING,
            OTHER
        }
        #endregion

        #region Attribute
        private string _name;
        private int _floor;
        private int _capacity;
        private TYPE _type;
        private Color _color;
        private string _comment;
        #endregion

        #region Properties
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public TYPE Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        public int Floor
        {
            get { return _floor; }
            set { _floor = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constructor
        public Area()
        {
            _color = Color.DarkOrange;
            _type = TYPE.ROOM;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
