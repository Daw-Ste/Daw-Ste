using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Recruit_Button_Script : MonoBehaviour
{
    public GameObject RecruitButton, /*SwordsmanButton, ArcherButton, SpearmanButton, AxeThrowerButton, KnightButton, HorseArcherButton,*/ Buttons;
    [SerializeField]
    private TMP_Text thisButtonText;
    Color ClickedColor, UnclickedColor;
    bool Clicked=true;
    private void Start()
    {
        ClickedColor.r = 1;
        ClickedColor.g = 0.5f;
        ClickedColor.b = 0.5f;
        ClickedColor.a = 1;

        UnclickedColor.r = 0.7158f;
        UnclickedColor.g = 1;
        UnclickedColor.b = 0.6273f;
        UnclickedColor.a = 1;
    }
    public void Unroll()
    {
        if (Clicked == false)
        {
            RecruitButton.GetComponent<Image>().color = ClickedColor;
            Buttons.SetActive(true);
            thisButtonText.text = "Hide Unit Buttons";
            Clicked = true;
        } else if (Clicked==true)
        {            
            RecruitButton.GetComponent<Image>().color = UnclickedColor;
            Buttons.SetActive(false);
            thisButtonText.text = "Show Unit Buttons";
            Clicked = false;
        }
    }
}
