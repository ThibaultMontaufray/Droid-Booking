using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

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
        private readonly string AREA_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\Droid-Booking\Cloud\Area\";

        private string _id;
        private string _name;
        private int _floor;
        private int _capacity;
        private TYPE _type;
        private Color _color;
        private string _comment;
        #endregion

        #region Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
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
        public string ColorName
        {
            get { return _color.Name; }
            set { _color = Color.FromName(value); }
        }
        [XmlIgnore]
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion

        #region Constructor
        public Area()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("area.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

            _color = Color.DarkOrange;
            _type = TYPE.ROOM;

            System.Threading.Thread.Sleep(1);
        }
        #endregion

        #region Methods public
        public void Save()
        {
            SaveFile(GenerateXml());
        }
        public static Area GetArea(object o, List<Area> areas)
        {
            if (o == null) return null;
            string areaText = o.ToString();

            foreach (Area area in areas)
            {
                if (areaText.Equals(string.Format("{0} - {1}", area.Type, area.Name)))
                {
                    return area;
                }
            }
            return null;
        }
        public static Area GetAreaFromId(string idArea, List<Area> areas)
        {
            return areas.Where(a => a.Id.Equals(idArea)).First();
        }
        #endregion

        #region Methods private
        private string GenerateXml()
        {
            string serializedObject = string.Empty;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Area));
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
        private void SaveFile(string xmlObject)
        {
            if (!Directory.Exists(AREA_DIRECTORY))
            {
                Directory.CreateDirectory(AREA_DIRECTORY);
            }
            string filePath = Path.Combine(AREA_DIRECTORY, string.Format("{0}.{1}.xml", _type, _name));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(xmlObject);
            }
        }
        #endregion
    }
}
