using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour
{
    public InputField name, age, extra;
    string path = "/save.dat";

    BinaryFormatter bf = new BinaryFormatter();
    
    public void Save()
    {
        FileStream file = File.Create(Application.persistentDataPath + path);
        Data data = new Data();

        data.s = name.text;
        data.i = Int32.Parse(age.text);
        data.extra = extra.text;
        bf.Serialize(file, data);
        file.Close();

        ShowData("Data saved: ", data);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();
            ShowData("Data read: ", data);
        }
        else
            Debug.Log("No saved data");
    }

    public void Reset()
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            File.Delete(Application.persistentDataPath + path);
            Debug.Log("Data deleted "+File.Exists(Application.persistentDataPath + path));
        }
    }

    public void ShowData(string str, Data d)
    {
        Debug.Log(str + d.s + " " + d.i + ". Extra: " + d.extra);
    }

}
