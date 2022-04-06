using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string highScore_name;
    public int highScore_point;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class DataToBeSaved
    {
        public string high_name;
        public int high_point;
    }

    public void SaveData()
    {
        DataToBeSaved data = new DataToBeSaved();
        data.high_name = highScore_name;
        data.high_point = highScore_point;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFileA.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saveFileA.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToBeSaved myData = JsonUtility.FromJson<DataToBeSaved>(json);
            highScore_name = myData.high_name;
            highScore_point = myData.high_point;
        }
    }



}
