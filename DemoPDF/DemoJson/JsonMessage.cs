using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DemoJson
{
    public class JsonMessage
    {
        public List<JsonMessageEntity> Obter(string localFile, Nullable<int> id, string tipo)
        {
            List<JsonMessageEntity> list = JsonConvert.DeserializeObject<List<JsonMessageEntity>>(System.IO.File.ReadAllText(localFile));
            return(from L in list where ((id == null ? id == null : L.id == id) && (tipo == null ? tipo == null : L.tipo.ToLower() == tipo.ToLower())) select L).ToList<JsonMessageEntity>();
        }
    }
}
