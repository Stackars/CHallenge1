using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System;
#if UNITY_EDITOR

using System.IO;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_Text textDisplay;
    public Text theName;
    public GameObject inputField;
   
    public string bestName;
    public int bestScore;
    private string localName = "butthead";


    // Start is called before the first frame update
    void Start()
    {
        

        DisplayHighScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameAndStoreName()
    {
        Debug.Log(localName);
        localName = inputField.GetComponent<TMP_InputField>().text;
        Debug.Log("namn:" + localName);
    
        Statholder.Instance.CurrentName(localName);
       
        SceneManager.LoadScene(1);
    }
    public void ExitGame() {
   
    
            
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        }

   
 
   

    public void DisplayHighScore()
    {

        bestName = Statholder.Instance.highScorename;
        bestScore = Statholder.Instance.highScore;

        textDisplay.text = bestScore + bestName;

    }
}
