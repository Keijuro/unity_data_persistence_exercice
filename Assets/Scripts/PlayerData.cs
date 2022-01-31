using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string currentName;
    public int currentScore;
    public string bestName;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.name = currentName;
        data.score = currentScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentName = data.name;
            bestName = data.name;
            bestScore = data.score;
        }
        else
        {
            currentName = "";
            bestName = "";
            bestScore = 0;
        }
        
        currentScore = 0;
    }
}
