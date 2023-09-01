using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    TofuData nowPlayer = TofuData.instance;
    string path;
    string filename = "TofuPlayerData.json";

    void Awake()
    {
        //SINGLETONE
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/";
    }

    // Start is called before the first frame update
    void Start()
    {
        if (IsSaveDataExists())
        {
            LoadData();
        }
        else
        {
            TofuData.instance.ResetData();
        }

    }

    public void SaveData()
    {
        string playerData = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + filename, playerData);
        Debug.Log("Data Saved to " + path + filename);
    }

    public void LoadData()
    {
        if (IsSaveDataExists())
        {
            string playerData = File.ReadAllText(path + filename);
            nowPlayer = JsonUtility.FromJson<TofuData>(playerData);

            TofuData.instance.ApplyLoadedData(nowPlayer);
        } else
        {
            Debug.Log("No save file found at " + path + filename);
        }
    }

    public void ClearData()
    {
        TofuData.instance.ResetData(); // TODO: FIX Wrong value
        Debug.Log("Data is cleared");
        SaveData();
    }

    public bool IsSaveDataExists()
    {
        return File.Exists(path + filename);
    }
}
