using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Droid_Booking
{
    public class Booking
    {
        #region Attribute
        private string _id;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private string _areaId;
        private string _userId;
        private bool _confirmed;
        private decimal _price;
        private decimal _paid;
        #endregion

        #region Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
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
        #endregion

        #region Constructor
        public Booking()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("booking.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());
            _confirmed = false;
            System.Threading.Thread.Sleep(1);
        }
        public Booking(string path)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("booking.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());
            _confirmed = false;
            System.Threading.Thread.Sleep(1);

            Save(path);
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
                    if (Path.GetFileName(file).StartsWith("book.") && Path.GetExtension(file).Equals(".xml"))
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
        #endregion

        #region Methods private
        private void Import(Booking source, Booking target)
        {
            target._areaId = source._areaId;
            target._checkIn = source._checkIn;
            target._checkOut = source._checkOut;
            target._confirmed = source._confirmed;
            target._id = source._id;
            target._paid = source._paid;
            target._price = source._price;
            target._userId = source._userId;

            source = null;
        }
        private string GenerateXml()
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
            string filePath = Path.Combine(path, string.Format("{0}.xml", _id));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(xmlObject);
            }
        }
        #endregion
    }
}
