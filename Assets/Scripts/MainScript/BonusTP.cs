using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTP : MonoBehaviour
{
    public GameObject bonusTP;
    public Text BonusEnter, blueCount;
    // Start is called before the first frame update
    void Start()
    {
        bonusTP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(blueCount.text) >= 5)
        {
            BonusEnter.text = "true";
        } 
        if (BonusEnter.text.Equals("true")){
            bonusTP.SetActive(true);
        } else
        {
            bonusTP.SetActive(false);
        }
    }
}
