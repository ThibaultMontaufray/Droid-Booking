﻿using System;
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
        #endregion

        #region Methods public
        public void Save(string path)
        {
            SaveFile(GenerateXml(), path);
        }
        #endregion

        #region Methods private
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
        private void SaveFile(string xmlObject, string path)
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
