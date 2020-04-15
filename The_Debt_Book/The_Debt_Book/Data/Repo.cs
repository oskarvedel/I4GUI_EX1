using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using Prism.Mvvm;


namespace The_Debt_Book.Data
{
    public class Repo : BindableBase
    {
        internal static void ReadFile(string fileName, out ObservableCollection<Debtor> debtor)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextReader reader = new StreamReader(fileName);
            debtor = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveFile(string fileName, ObservableCollection<Debtor> debtor)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, debtor);
            writer.Close();
        }
    }
}
