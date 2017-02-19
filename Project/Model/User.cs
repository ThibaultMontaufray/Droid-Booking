using System.Drawing;

namespace Droid_Booking
{
    public class User
    {
        #region Enum
        public enum GENDER
        {
            MALE,
            FEMAL,
            OTHER,
            UNKNOW
        }
        #endregion

        #region Attribute
        private string _firstName;
        private string _familyName;
        private string _id;
        private string _country;
        private GENDER _gender;
        private string _comment;
        private string _mail;
        private Image _picture;
        #endregion

        #region Properties
        public Image Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string FamilyName
        {
            get { return _familyName; }
            set { _familyName = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public GENDER Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        #endregion

        #region Constructor
        public User()
        {
            _gender = GENDER.UNKNOW;
            _picture = Properties.Resources.shadow_man;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
