using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Backend.Xml
{
    /// <summary>
    /// Class to Deserialize objects
    /// </summary>
    public static class ObjectSerializer
    {
        /// <summary>
        /// Deserializes an object
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="url">URL for XML sheet</param>
        /// <returns>Deserialized object</returns>
        public static T FromXML<T>(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
