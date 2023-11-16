using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeLanguage : MonoBehaviour
{
    public Text title, start, status, exit, language;
    bool isEnglish = false;
    
    // Start is called before the first frame update
    void Start()
    {
     changeLanguage();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeLanguage()
    {
        if (!isEnglish)
        {
            title.text = "Rainbow Game";
            start.text = "Start";
            status.text = "Status";
            exit.text = "Exit";
            language.text = "Language";
            isEnglish = true;
        }else
        {
            title.text = "レインボーゲーム";
            start.text = "スタート";
            status.text = "ステータス";
            exit.text = "出口";
            language.text = "言語";
            isEnglish = false;
        }
    }
}
