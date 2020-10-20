using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using The_Debt_Book.Models;
namespace The_Debt_Book.Data
{
    public class Repository
    {
        internal static void ReadFile(string fileName, out ObservableCollection<Person> Person)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            TextReader reader = new StreamReader(fileName);
            // Deserialize all the agents.
            Person = (ObservableCollection<Person>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveFile(string fileName, ObservableCollection<Person> agents)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, agents);
            writer.Close();
        }
    }
}
}
