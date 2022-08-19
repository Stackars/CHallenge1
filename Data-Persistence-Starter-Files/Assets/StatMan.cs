using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class StatMan : MonoBehaviour
{
    public static StatMan Instance;
    public int highScore = 0;
    public string currentName;
    private void Awake()

    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    [System.Serializable]
    class SaveData
    {
        public int score;
        public string playerName;
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            highScore = data.score;
        }
    }
    public void CurrentName(string name)
    {
        currentName = name;
    }
    public void SaveHighScoreWithName(int contender)
    {
        if (contender > highScore)
        {
            SaveData data = new SaveData();
            data.score = contender;
            data.playerName = currentName;


            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
}
