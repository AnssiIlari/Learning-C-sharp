using System.Xml.Serialization;

namespace Karelia.IO
{
    public class MyObjectSerializer
    {
        public static void SaveObject(string path, object value)
        {
            XmlSerializer writer = new XmlSerializer(value.GetType());
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, value);
            }
            //file.Dispose(); // tiedoston sulkeminen, ei tarvita using- lohkon sisällä
        }

        public static object ReadObject(string path, Type type)
        {
            XmlSerializer reader = new XmlSerializer(type);

            using (FileStream file = File.OpenRead(path))
            {
                return reader.Deserialize(file);
            }


        }



    }
}
