using System.Collections.Generic;

public class JsonObject 
{
    public Dictionary<string, object> dict = new Dictionary<string, object>();

    public void Add(string key,object value)
    {
        if(dict.ContainsKey(key))
            dict[key] = value;
        else
            dict.Add(key,value);
    }

    public void Remove(string key) => dict.Remove(key);

    public string Json
    {
        get {
            string json = "{ ";

            foreach (var item in dict)
                json += item.Key + " : " + item.Value;

            json += " } ";

            return json;
        }

        set {
        

        }
    }


}
