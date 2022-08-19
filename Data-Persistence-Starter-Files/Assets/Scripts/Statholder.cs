using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UI;
using System.IO;
#endif

public class Statholder : MonoBehaviour
{
   
  
        public static Statholder Instance;
        public int highScore = 0;
        public string currentName = "a";
   public string highScorename;
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
            highScorename = data.playerName;
            }
        }
        public void CurrentName(string name)
        {
        Debug.Log("Ett namn sparas...");
            currentName = name;
        Debug.Log("Och namnet blev.." + highScore + highScorename );
        }
        public void SaveHighScoreWithName(int contender)
        {
            if (contender > highScore)
            {
                SaveData data = new SaveData();
                data.score = contender;
                data.playerName = currentName;
            highScorename = currentName;
            highScore = contender;

                string json = JsonUtility.ToJson(data);
                File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            }
        }
    }


