using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartMenu : MonoBehaviour
{
    public Text bestScoreText;
    public Text nameField;

    public void Start()
    {
        PlayerData.Instance.Load();
        bestScoreText.text = "Best Score: "+PlayerData.Instance.bestName+": "+PlayerData.Instance.bestScore;
    }

    public void StartGame()
    {
        PlayerData.Instance.currentName = nameField.text;
        SceneManager.LoadScene(1);
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
