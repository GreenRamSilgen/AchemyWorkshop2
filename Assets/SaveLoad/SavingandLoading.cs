using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SavingandLoading : MonoBehaviour
{
    public static void Save<T>(T objectToSave, string key) //Save function takes object of "Type"
    {
        string path = Application.persistentDataPath + "/saves/";  //path to save to
        Directory.CreateDirectory(path);                           //create the save directory if it does not exist
    }
}
