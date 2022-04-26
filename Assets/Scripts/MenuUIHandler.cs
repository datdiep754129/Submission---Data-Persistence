using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI playerNameDisplay;
    public Button start;
    public Button quit;
    public static string playerNameStr;
    private Manager controller;

    // Start is called before the first frame update


    private void Awake()
    {
        controller = FindObjectOfType<Manager>();
    }
    private void Start()
    {
        /**
        Debug.Log("Name: " + playerNameStr);
        LoadName();
        **/
        playerNameDisplay.text = ("Best Player: ")+ controller.BestPlayer.playerName + " / Score: " + controller.BestPlayer.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        start.onClick.AddListener(OnStartClick);
        quit?.onClick.AddListener(Quit);
    }


    private void OnDisable()
    {
        start.onClick.RemoveListener(OnStartClick);
        quit?.onClick.RemoveListener(Quit);
    }
    private void OnStartClick()
    {
        controller.SetPlayerName(playerNameInput.text);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);
    }

    public void Quit()
    {
        //SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
        // original code to quit Unity player
#endif
    }

    class SaveData
    {
        public string playerNameStr;
        public int playerScore;
    }

    /**
    
    public void StartMenu()
    {
        //LoadName();
        controller.SetPlayerName(playerNameInput.text);
        SceneManager.LoadScene(0,LoadSceneMode.Additive);
    }


    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerNameStr = playerNameStr;
        data.playerScore = playerNameInput;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("SavePlayerName saved " + json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameStr = data.playerNameStr;

            Debug.Log("LoadPlayerName worked & loaded data: " + playerNameStr);
        }
    }

    public void LastPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(playerNameStr == null)
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerNameStr = data.playerNameDisplay.text;
            Debug.Log("LastPlayer called");
        }
    }
    **/
}
