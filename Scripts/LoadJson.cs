using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static GameStatus LoadJsonFromFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string file = Application.dataPath + "/Resources/demo.json";

        if (!File.Exists(file))
        {
            return null;
        }

        StreamReader sr = new StreamReader(file);

        if (sr == null)
        {
            return null;
        }
        string json = sr.ReadToEnd();
        Debug.Log(json);

        if (json.Length > 0)
        {
            return JsonUtility.FromJson<GameStatus>(json);
        }

        return null;
    }
}
