//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Xml;
//using System.Xml.Serialization;
//using Tools4Libraries;

//namespace Droid_Booking
//{
//    public class User
//    {
//        #region Enum
//        public enum GENDER
//        {
//            MALE,
//            FEMAL,
//            OTHER,
//            UNKNOW
//        }
//        #endregion

//        #region Attribute
//        private string _firstName;
//        private string _familyName;
//        private string _id;
//        private string _country;
//        private GENDER _gender;
//        private string _comment;
//        private string _mail;
//        private Image _picture;
//        private Image _passport;
//        #endregion

//        #region Properties
//        [XmlIgnore]
//        public Image Passport
//        {
//            get { return _passport; }
//            set { _passport = value; }
//        }
//        [XmlIgnore]
//        public Image Picture
//        {
//            get { return _picture; }
//            set { _picture = value; }
//        }
//        public string SerializedPicture
//        {
//            get { return Droid_Image.Interface_image.ACTION_136_serialize_image(_picture); }
//            set { _picture = Droid_Image.Interface_image.ACTION_137_unserialize_image(value); }
//        }
//        public string SerializedPassport
//        {
//            get { return Droid_Image.Interface_image.ACTION_136_serialize_image(_passport); }
//            set { _passport = Droid_Image.Interface_image.ACTION_137_unserialize_image(value); }
//        }
//        public string Comment
//        {
//            get { return _comment; }
//            set { _comment = value; }
//        }
//        public string Nationality
//        {
//            get { return _country; }
//            set { _country = value; }
//        }
//        public string FirstName
//        {
//            get { return _firstName; }
//            set { _firstName = value; }
//        }
//        public string FamilyName
//        {
//            get { return _familyName; }
//            set { _familyName = value; }
//        }
//        public string Id
//        {
//            get { return _id; }
//            set { _id = value; }
//        }
//        public GENDER Gender
//        {
//            get { return _gender; }
//            set { _gender = value; }
//        }
//        public string Mail
//        {
//            get { return _mail; }
//            set { _mail = value; }
//        }
//        #endregion

//        #region Constructor
//        public User()
//        {
//            Random rand = new Random((int)DateTime.Now.Ticks);
//            _id = string.Format("user.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

//            _gender = GENDER.UNKNOW;
//            Picture = Properties.Resources.shadow_man;
//            Passport = Properties.Resources.passeport;
//        }
//        #endregion

//        #region Methods public
//        public void Save(string path)
//        {
//            SaveFile(GenerateXml(), path);
//        }
//        public static Person GetUser(object o, List<User> users)
//        {
//            if (o == null) return null;
//            string userText = o.ToString();

//            foreach (Person user in users)
//            {
//                if (userText.Equals(string.Format("{0} {1}", user.FirstName, user.FamilyName)))
//                {
//                    return user;
//                }
//            }
//            return null;
//        }
//        public static Person GetUserFromId(string idUser, List<User> users)
//        {
//            return users.Where(u => u.Id.Equals(idPerson)).First();
//        }
//        #endregion

//        #region Methods private
//        private string GenerateXml()
//        {
//            string serializedObject = string.Empty;

//            XmlSerializer xsSubmit = new XmlSerializer(typeof(Person));
//            using (var sww = new StringWriter())
//            {
//                using (XmlWriter writer = XmlWriter.Create(sww))
//                {
//                    xsSubmit.Serialize(writer, this);
//                    serializedObject = sww.ToString();
//                }
//            }
//            return serializedObject;
//        }
//        private void SaveFile(string xmlObject, string path)
//        {
//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//            }
//            string filePath = Path.Combine(path, string.Format("{0}.{1}.{2}.xml", _firstName, _familyName, _id));
//            using (StreamWriter sw = new StreamWriter(filePath, false))
//            {
//                sw.Write(xmlObject);
//            }
//        }
//        #endregion
//    }
//}
