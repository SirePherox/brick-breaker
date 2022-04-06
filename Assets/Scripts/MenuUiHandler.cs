using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

//this is helpful for UI as other things may need to be initialized before UI
[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour
{
    //public static MenuUiHandler menuInstance;
    public static string userName;
    public void SubmitName(string name)
    {
        userName = name;
        Debug.Log(name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ResetGame()
    {
        string path = Application.persistentDataPath + "/saveFileA.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            SceneManager.LoadScene(0);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
