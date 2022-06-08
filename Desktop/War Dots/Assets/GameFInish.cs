using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameFInish : MonoBehaviour
{
    [SerializeField]
    private int LevelNumber;
    public TMP_Text victorytext, defeattext;
    public bool victory_true, defeat_true;
    public GameObject PauseMenu, FireWorker, enemy_killer, player_killer, VictoryStatsPanel, playerBase, enemyBase;
    public GameObject[] endStatsText, endStatsNumber;
    bool pause_active=false, timerforStatsStarted, BattleEndScreenUsed=false;
    float t, t2, floatforVolume=1;
    int currentsceneindex, targetFrameRate = 144, loopStatArrayNumber, highestUnlockedLevel=1;
    public int DefeatedEnemies, LostUnits, EndTime;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        floatforVolume = PlayerPrefs.GetFloat("masterVolume");
        volumeSlider.value = floatforVolume;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0;
        pause_active = true;
        PauseMenu.SetActive(true);
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1;
        pause_active = false;
        PauseMenu.SetActive(false);
        PlayerPrefs.SetFloat("masterVolume", floatforVolume);
    }
    public void LevelRestart()
    {
        SceneManager.LoadScene(currentsceneindex);
    }
    public void ExitToMenu()
    {
        ResumeTheGame();
        SceneManager.LoadScene(0);     
    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        //audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        AudioListener.volume = volume;
        floatforVolume = volume;
    }
    void BattleEndScreen()
    {
        VictoryStatsPanel.SetActive(true);
        timerforStatsStarted = true;
        t2 = 0;
        if(enemyBase!=null)
        enemyBase.GetComponent<EnemySpawner>().enabled = false;
        LoadFile();
        if (highestUnlockedLevel == LevelNumber&&victory_true)
        {
            highestUnlockedLevel++;
            SaveFile();
        }
        else if(victory_true)
            Debug.Log("Data has not been saved, because you beat level " + LevelNumber + " and currently highest unlocked level is " + highestUnlockedLevel);
    }
    public void SaveFile()//zapisuje po zwycięstwie, trzeba dać warunek, aby zapisywało tylko jeżeli obecny odblokowany level jest równy obecnie zwyciężonemu 
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);

        else file = File.Create(destination);

            GameData data = new GameData(highestUnlockedLevel);
            Debug.Log("Data Saved Succesfully, level " + (LevelNumber+1) + " has been unlocked");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);

        file.Close();
    }
    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            highestUnlockedLevel = 1;
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        highestUnlockedLevel = data.BiggestUnlockedLevel;
        file.Close();
    }
    public void ShowBattleStats(int StatArrayNumber)
    {
        endStatsText[StatArrayNumber].SetActive(true);
        endStatsNumber[StatArrayNumber].SetActive(true);
        switch(StatArrayNumber+1)
        {
            case 1:
                endStatsNumber[StatArrayNumber].GetComponent<TMP_Text>().text = DefeatedEnemies.ToString();
                break;
            case 2:
                endStatsNumber[StatArrayNumber].GetComponent<TMP_Text>().text = LostUnits.ToString();
                break;
            case 3:
                if (EndTime % 60 >= 10)
                { 
                    endStatsNumber[StatArrayNumber].GetComponent<TMP_Text>().text = ((EndTime - (EndTime % 60)) / 60).ToString() + ":" + (EndTime % 60).ToString(); 
                }else
                {
                    endStatsNumber[StatArrayNumber].GetComponent<TMP_Text>().text = ((EndTime - (EndTime % 60)) / 60).ToString() + ":0" + (EndTime % 60).ToString();
                }
                break;


        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            ResumeTheGame();
            LevelRestart();
        }
        if (Input.GetButtonDown("GameMenu") && pause_active == false)
        {
            PauseTheGame();
        } else if (Input.GetButtonDown("GameMenu") && pause_active == true)
        {
            ResumeTheGame();
        }
        if(victory_true==true&&t<1)
        {

            enemy_killer.SetActive(true);
            t += Time.deltaTime;
            victorytext.transform.Rotate(0, 0, 1080 * Time.deltaTime);
            victorytext.fontSize =120*t;
            victorytext.characterSpacing = 630-t*600;
        }else if(defeat_true==true&&t<1)
        {
            player_killer.SetActive(true);
            t += Time.deltaTime;
            defeattext.fontSize = 120 * t;
            defeattext.characterSpacing = 630 - t * 600;
        }
        if(victory_true==true&&t>=1)
        {            
            victorytext.fontSize = 120;
            victorytext.characterSpacing = 30;
            victorytext.transform.localEulerAngles = new Vector3(0, 0, 0);
            FireWorker.GetComponent<FireWorker>().enabled=true;
            if (!BattleEndScreenUsed)
            {
                BattleEndScreen();
                BattleEndScreenUsed = true;
            }
        }
        if(defeat_true == true && t >= 1)
        {            
            defeattext.fontSize = 120;
            defeattext.characterSpacing = 30;
            if (!BattleEndScreenUsed)
            {
                BattleEndScreen();
                BattleEndScreenUsed = true;
            }
        }
        if(timerforStatsStarted&&t2<2.5f)
        {
            t2 += Time.deltaTime;
        }else if(timerforStatsStarted&&t2>=2.5f)
        {
            while (loopStatArrayNumber < endStatsText.Length)
            {
                ShowBattleStats(loopStatArrayNumber);
                loopStatArrayNumber++;
            }
        }
    }
}
