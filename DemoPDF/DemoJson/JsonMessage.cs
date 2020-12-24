using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DemoJson
{
    public class JsonMessage
    {
        public static List<JsonMessageEntity> Obter(string localFile, int id, string tipo = "V")
        {
            List<JsonMessageEntity> list = JsonConvert.DeserializeObject<List<JsonMessageEntity>>(System.IO.File.ReadAllText(localFile));
            return(from L in list where (L.id.Equals(id) && L.tipo.Equals(tipo)) select L).ToList<JsonMessageEntity>();

            //string.Equals(StringA, StringB, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
