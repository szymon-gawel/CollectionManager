using CollectionManager.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CollectionManager.App.Concrete
{
    public class SavingService
    {
        string path = @".\items.txt";

        public void SaveToFile(List<Item> items)
        {
            string output = JsonConvert.SerializeObject(items);
            var toSave = JsonConvert.DeserializeObject<List<Item>>(output);

            using StreamWriter sw = new StreamWriter(path);
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, toSave);
        }
    }
}
