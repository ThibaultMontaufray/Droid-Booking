using Newtonsoft.Json;
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

        private string _id;
        private string _name;
        private int _floor;
        private int _capacity;
        private TYPE _type;
        private Color _color;
        private string _comment;
        private KeyValuePair<string, bool>[] _place; // place name, and true if place available
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
            set
            {
                _capacity = value;
                InitPlaces();
            }
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
        public KeyValuePair<string, bool>[] Place
        {
            get { return _place; }
            set { _place = value; }
        }
        #endregion

        #region Constructor
        public Area()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("area.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

            _capacity = 0;
            _color = Color.DarkOrange;
            _type = TYPE.ROOM;
            InitPlaces();

            System.Threading.Thread.Sleep(1);
        }
        public Area(string fileName)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("area.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

            _capacity = 0;
            _color = Color.DarkOrange;
            _type = TYPE.ROOM;
            InitPlaces();
            Load(fileName);

            System.Threading.Thread.Sleep(1);
        }
        #endregion

        #region Methods public
        public override string ToString()
        {
            return string.Format("{0} - {1}", _type, _name);
        }
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
                    var data = JsonConvert.DeserializeObject<Area>(json);
                    if (data != null) { Import(data, this); }
                }
            }
            else if (Directory.Exists(pathFile))
            {
                foreach (string file in Directory.GetFiles(pathFile))
                {
                    if (Path.GetFileName(file).StartsWith("area.") && Path.GetExtension(file).Equals(".xml"))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            var json = sr.ReadToEnd();
                            var data = JsonConvert.DeserializeObject<Area>(json);
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
            if (idArea == null || areas == null) return null;
            return areas.Where(a => a.Id.Equals(idArea)).First();
        }
        #endregion

        #region Methods private
        private void Import(Area source, Area target)
        {
            target._capacity = source._capacity;
            target._color = source._color;
            target._comment = source._comment;
            target._floor = source._floor;
            target._id = source._id;
            target._name = source._name;
            target._place = source._place;
            target._type = source._type;

            source = null;
        }
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
        private void SaveXml(string xmlObject, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, string.Format("{0}.{1}.xml", _type, _name));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(xmlObject);
            }
        }
        private void InitPlaces()
        {
            _place = new KeyValuePair<string, bool>[_capacity];
            for (int i = 1; i <= _capacity; i++)
            {
                _place[i-1] = new KeyValuePair<string, bool>(i.ToString(), true);
            }
        }
        #endregion
    }
}
