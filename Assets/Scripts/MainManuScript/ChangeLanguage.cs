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

    public void changeLanguage()
    {
        if (!isEnglish)
        {
            title.text = "RainbowGame";
            start.text = "Start";
            status.text = "Login";
            exit.text = "Exit";
            language.text = "Language";
            isEnglish = false;
        }
        if(isEnglish)
        {
            title.text = "レインボーゲーム";
            start.text = "スタート";
            status.text = "ログイン";
            exit.text = "出口";
            language.text = "言語";
            isEnglish = true;
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Language")
        {
            changeLanguage();
        }
    }
}
