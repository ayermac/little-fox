using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameStatus status = LoadJson.LoadJsonFromFile();
            Debug.Log(status.statusList[0].name);
        }
    }
}
