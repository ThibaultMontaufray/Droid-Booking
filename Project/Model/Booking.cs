using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Droid.financial;

namespace Droid.Booking
{
    public class Booking
    {
        #region Enum
        public enum Status
        {
            CREATED,   // yellow
            CONFIRMED, // orange
            CHECKIN,   // green
            CHECKOUT   // gray
        }
        #endregion

        #region Attribute
        private readonly string WORKINGDIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\Assistant-Booking\";

        private string _id;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private string _areaId;
        private string _userId;
        private bool _confirmed;
        private string _place;
        private Status _status;
        private string _expenseId;
        #endregion

        #region Properties
        public string ExpenseId
        {
            get { return _expenseId; }
            set { _expenseId = value; }
        }
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }
        public DateTime CheckOut
        {
            get { return _checkOut; }
            set { _checkOut = value; }
        }
        public DateTime CheckIn
        {
            get { return _checkIn; }
            set { _checkIn = value; }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string AreaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }
        public Status CurrentStatus
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

        #region Constructor
        public Booking()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("booking.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());
            _confirmed = false;
            _checkIn = DateTime.Now;
            _checkOut = DateTime.Now.AddDays(7);
            System.Threading.Thread.Sleep(1);
        }
        public Booking(string path)
        {
            Load(path);
        }
        #endregion

        #region Methods public
        public void Save(string path)
        {
            SaveFile(path);
        }
        public void Load(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    var json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<Booking>(json);
                    if (data != null) { Import(data, this); }
                }
            }
            else if (Directory.Exists(pathFile))
            {
                foreach (string file in Directory.GetFiles(pathFile))
                {
                    if (Path.GetFileName(file).StartsWith("booking.") && Path.GetExtension(file).Equals(".xml"))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            var json = sr.ReadToEnd();
                            var data = JsonConvert.DeserializeObject<Booking>(json);
                            if (data != null)
                            {
                                Import(data, this);
                            }
                        }
                        break;
                    }
                }
            }
        }
        public string GenerateXml()
        {
            string serializedObject = string.Empty;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Booking));
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, this);
                    serializedObject = sww.ToString();
                }
            }
            return serializedObject;
        }
        public string GenerateJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string GenerateCsv()
        {
            string ret = string.Empty;
            return ret;
        }
        public string GenerateIcal()
        {
            string ret = string.Empty;
            return ret;
        }
        #endregion

        #region Methods private
        private void Import(Booking source, Booking target)
        {
            target._areaId = source._areaId;
            target._checkIn = source._checkIn;
            target._checkOut = source._checkOut;
            target._confirmed = source._confirmed;
            target._id = source._id;
            target._userId = source._userId;
            target._place = source._place;
            target._status = source._status;
            target._expenseId = source._expenseId;

            source = null;
        }
        private void SaveFile(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(Path.Combine(path, _id)))
            {
                Directory.CreateDirectory(Path.Combine(path, _id));
            }
            string filePath = Path.Combine(path, string.Format("{0}//{0}.xml", _id));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(JsonConvert.SerializeObject(this));
            }
        }
        private void SaveFileXml(string xmlObject, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, string.Format("{0}//{0}.xml", _id));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(xmlObject);
            }
        }
        #endregion
    }
}
