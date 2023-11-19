using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFreeGenerate : MonoBehaviour
{
    public GameObject Coin;
    public Text CoinOwned, CoinMax, NextCoin;
    public int CoinOwneds, CoinMaxs;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 60;
        CoinOwneds = 50;
        CoinMaxs = 50;
        CoinOwned.text = CoinOwneds.ToString();
        CoinMax.text = CoinMaxs.ToString();
        NextCoin.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CoinOwneds = int.Parse(CoinOwned.text);
        if(CoinOwneds != CoinMaxs)
        {
            time -= Time.deltaTime;
            if(time < 10)
            {
                NextCoin.text = "0" + time.ToString().Substring(0, 1);
            } else
            {
                NextCoin.text = time.ToString().Substring(0,2);
            }
            
        } else
        {
            time = 60;
            NextCoin.text = time.ToString().Substring(0, 2);
        }
        
        if(CoinOwneds < CoinMaxs && time <= 0)
        {
            CoinOwneds++;
            CoinOwned.text = CoinOwneds.ToString();
            time = 60;
            if(Coin.activeSelf == false)
            {
                Coin.SetActive(true);
            }
        }
    }
}
