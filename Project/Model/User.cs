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
        #endregion

        #region Properties
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

        #endregion

        #region Constructor
        public User()
        {
            Gender = GENDER.UNKNOW;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
