using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DemoJson
{
    public class JsonParseClass
    {
        private string OpenFile(string loclalFile)
        {
            return System.IO.File.ReadAllText(loclalFile);
        }
        private T Parse<T>(string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }

        private List<T> Search<T>(List<T> jsonObject, object objectSearch)
        {
            List<T> result = jsonObject;
            PropertyInfo[] listProperties = objectSearch.GetType().GetProperties();
            for (int a = 0; a < listProperties.Length; a++)
            {
                if (objectSearch.GetType().GetProperty(listProperties[a].Name).GetValue(objectSearch) != null)
                {
                    if (listProperties[a].PropertyType == typeof(string))
                        result = (from L in result where L.GetType().GetProperty(listProperties[a].Name).GetValue(L).ToString().ToLower().IndexOf(objectSearch.GetType().GetProperty(listProperties[a].Name).GetValue(objectSearch).ToString().ToLower()) > -1 select L).ToList<T>();
                    else
                        result = (from L in result where L.GetType().GetProperty(listProperties[a].Name).GetValue(L).Equals(objectSearch.GetType().GetProperty(listProperties[a].Name).GetValue(objectSearch)) select L).ToList<T>();
                }
            }
            return result;
        }

        public T FileJsonParse<T>(string loclalFile)
        {
           return Parse<T>(OpenFile(loclalFile));
        }

        public T StringJsonParse<T>(string loclalFile)
        {
            return Parse<T>(OpenFile(loclalFile));
        }

        public List<T> FileJsonParse<T>(string loclalFile, object objectSearch)
        {
            return Search(Parse<List<T>>(OpenFile(loclalFile)), objectSearch);
        }

        public List<T> StringJsonParse<T>(string value, object objectSearch)
        {
            return Search(Parse<List<T>>(value), objectSearch);
        }
    }
}
