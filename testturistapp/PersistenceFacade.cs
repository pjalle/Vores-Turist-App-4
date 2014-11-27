using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Newtonsoft.Json;
using testturistapp.Model;
using testturistapp.Viewmodel;

namespace testturistapp
{
    class PersistenceFacade
    {
        private static string jsonFileName = "RatingsAsJson .dat";
        private static string xmlFileName = "RatingsAsXML.dat";

        public static async void SaveRatingsAsJsonAsync(ObservableCollection<Rating> ratings)
        {
            string ratingsJsonString = JsonConvert.SerializeObject(ratings);
            SerializeRatingsFileAsync(ratingsJsonString, jsonFileName);
        }

        public static async Task<List<Rating>> LoadRatingsFromJsonAsync()
        {
            string ratingsJsonString = await DeSerializeRatingsFileAsync(jsonFileName);
            return (List<Rating>)JsonConvert.DeserializeObject(ratingsJsonString, typeof(List<Rating>));
        }

        public static async void SaveRatingsAsXmlAsync(ObservableCollection<Rating> ratings)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ratings.GetType());
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, ratings);
            SerializeRatingsFileAsync(textWriter.ToString(), xmlFileName);
        }

        public static async Task<ObservableCollection<Rating>> LoadRatingsFromXmlAsync()
        {
            string ratingsXmlString = await DeSerializeRatingsFileAsync(xmlFileName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Rating>));
            return (ObservableCollection<Rating>)xmlSerializer.Deserialize(new StringReader(ratingsXmlString));
        }


        public static async void SerializeRatingsFileAsync(string RatingsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, RatingsString);
        }

        public static async Task<string> DeSerializeRatingsFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }
    }
}
