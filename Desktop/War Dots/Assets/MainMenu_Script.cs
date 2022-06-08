using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class MainMenu_Script : MonoBehaviour
{
    public GameObject Menu_Main, Menu_options, Menu_campaign, Menu_quit, Menu_level_brief;
    public GameObject[] LevelButton, LevelBriefText, LevelBrief_unitData, LevelBrief_lore;
    public Button LeftBriefButton, RightBriefButton, Fight_Button;
    public AudioSource audioSourcee;
    int ChosenLevel, highestUnlockedLevel=1, a;


    private void Awake()
    {
        LoadFile();
        a = 0;
        while(a<highestUnlockedLevel)
        {
            LevelButton[a].SetActive(true);  
            a++;
        }
    }
    private void Start()
    {
        PlayButton();
        ChosenLevelBrief(1);
    }

    public void PlayButton()
    {
        Menu_campaign.SetActive(true);
        Menu_Main.SetActive(false);
        PlaySound();
    }
    public void OptionsButton()
    {
        Menu_options.SetActive(true);
        Menu_Main.SetActive(false);
        PlaySound();
    }
    public void QuitButton()
    {
        Menu_quit.SetActive(true);
        Menu_Main.SetActive(false);
        PlaySound();
    }
    public void CloseAppButton()
    {
        Application.Quit();
    }
    public void BackButton_Main()
    {
        Menu_Main.SetActive(true);
        Menu_options.SetActive(false);
        Menu_campaign.SetActive(false);
        Menu_quit.SetActive(false);
        PlaySound();
    }
    public void BackButton_Play()
    {
        Menu_campaign.SetActive(true);
        Menu_level_brief.SetActive(false);
        LevelBrief_unitData[ChosenLevel - 1].SetActive(false);
        LevelBriefText[ChosenLevel - 1].SetActive(false);
        LevelBrief_lore[ChosenLevel - 1].SetActive(false);
        LeftBriefButton.interactable = false;
        RightBriefButton.interactable = true;
        PlaySound();
    }
    public void ChosenLevelBrief(int level)
    {
        Menu_level_brief.SetActive(true);
        Menu_campaign.SetActive(false);
        ChosenLevel = level;
        LevelBriefText[ChosenLevel - 1].SetActive(true);
        LevelBrief_lore[ChosenLevel - 1].SetActive(true);
        Fight_Button.GetComponent<LoadTheScene>().scenebuildindex = level;
        PlaySound();
    }
    public void clickLeftBriefButton()
    {
        LeftBriefButton.interactable = false;
        RightBriefButton.interactable = true;
        LevelBrief_lore[ChosenLevel - 1].SetActive(true);
        LevelBrief_unitData[ChosenLevel - 1].SetActive(false);
        PlaySound();
    }
    public void clickRightBriefButton()
    {
        LeftBriefButton.interactable = true;
        RightBriefButton.interactable = false;
        LevelBrief_lore[ChosenLevel - 1].SetActive(false);
        LevelBrief_unitData[ChosenLevel - 1].SetActive(true);
        PlaySound();
    }


    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        highestUnlockedLevel = data.BiggestUnlockedLevel;
        file.Close();
    }
    public void PlaySound()
    {
        audioSourcee.Play();
    }
}
