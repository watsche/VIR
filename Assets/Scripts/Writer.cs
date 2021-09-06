using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Writer : MonoBehaviour
{
    public Transform player;
    public void Create()
    {
        string path = Application.dataPath + "/Cordinate.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        string content = "x: " + player.position.x + "\n y: " + player.position.y + "\n z: " + player.position.z;
        File.WriteAllText(path, content);
        
    }
   

    // Update is called once per frame
    void Update()
    {
        Create();
    }
}
