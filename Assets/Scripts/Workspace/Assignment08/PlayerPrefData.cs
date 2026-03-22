using UnityEngine;

public class PlayerPrefData : MonoBehaviour
{
    public string playerName = "Unknow";
    public int highscore = 0;
    public float Volume = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //saveDataplayer();
        LoadDataPlayer();
    }

    public void saveDataplayer()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.SetFloat("Volume", Volume);

        PlayerPrefs.Save();
        Debug.Log("Save playyer data");
    }
    // Update is called once per frame
    public void LoadDataPlayer()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName","No name");
            highscore = PlayerPrefs.GetInt("HighScore", 0);
            Volume = PlayerPrefs.GetFloat("Volume", 0);
            Debug.Log("Load Player data");
        }
        else
        {
            Debug.Log("Not found data");
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear all save");
    }

   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            saveDataplayer();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadDataPlayer();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ResetData();
        }
    }
}
