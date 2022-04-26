using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;

[System.Serializable]

public class Manager : MonoBehaviour
{
    public string PlayerName { get; private set; }
    public ScoreData BestPlayer { get; private set; }
    private void Awake()
    {
        Load();
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
        Save();
    }

    public void Save()
    {
        SaveData data = new SaveData
        {
            currentPlayerName = PlayerName,
            best = BestPlayer
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.currentPlayerName;
            BestPlayer = data.best;
        }
    }
    /**
    public void LastPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (playerName == null)
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerNameDisplay.text;
            Debug.Log("LastPlayer called");
        }
    }
    **/
    public void SubmitScore(string name, int score)
    {
        if (score > BestPlayer.score)
        {
            BestPlayer = new ScoreData()
            {
                score = score,
                playerName = name
            };
            Save();
        }
    }

    [Serializable]
    public class SaveData
    {
        public string currentPlayerName;
        public ScoreData best;
    }
    [Serializable]
    public class ScoreData
    {
        public string playerName;
        public int score;
    }

}
