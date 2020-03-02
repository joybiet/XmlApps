using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComparionApps
{
    public class GenericXmlSerializer<T>
    {
        private static System.Xml.Serialization.XmlSerializer _serializer;
        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((_serializer == null))
                {
                    _serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                }
                return _serializer;
            }
        }

        /// <summary>
        /// Serializes current object into an XML document
        /// </summary>
        // <returns>string XML value</returns>
        public static string Serialize(T obj)
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, obj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an T object
        /// </summary>
        // <param name="xml">string workflow markup to deserialize</param>
        // <param name="obj">Output OrderRequest object</param>
        // <param name="exception">output Exception value if deserialize failed</param>
        // <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out T obj, out System.Exception exception)
        {
            exception = null;
            obj = default(T);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out T obj)
        {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static T Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((T)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current T object into file
        /// </summary>
        // <param name="fileName">full path of outupt xml file</param>
        // <param name="exception">output Exception value if failed</param>
        // <returns>true if can serialize and save into file; otherwise, false</returns>
        //public virtual bool SaveToFile(string fileName, out System.Exception exception)
        //{
        //    exception = null;
        //    try
        //    {
        //        SaveToFile(fileName);
        //        return true;
        //    }
        //    catch (System.Exception e)
        //    {
        //        exception = e;
        //        return false;
        //    }
        //}

        //public virtual void SaveToFile(string fileName)
        //{
        //    System.IO.StreamWriter streamWriter = null;
        //    try
        //    {
        //        string xmlString = Serialize();
        //        System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
        //        streamWriter = xmlFile.CreateText();
        //        streamWriter.WriteLine(xmlString);
        //        streamWriter.Close();
        //    }
        //    finally
        //    {
        //        if ((streamWriter != null))
        //        {
        //            streamWriter.Dispose();
        //        }
        //    }
        //}

        /// <summary>
        /// Deserializes workflow markup from file into an T object
        /// </summary>
        // <param name="xml">string workflow markup to deserialize</param>
        // <param name="obj">Output OrderRequest object</param>
        // <param name="exception">output Exception value if deserialize failed</param>
        // <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out T obj, out System.Exception exception)
        {
            exception = null;
            obj = default(T);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out T obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static T LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }
}
