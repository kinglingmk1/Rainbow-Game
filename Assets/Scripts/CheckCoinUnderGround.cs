using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCoinUnderGround : MonoBehaviour
{
    public GameObject Coin;
    public Text CoinMissCount, OwnCoin;
    Vector3 GetSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Get coin start position.
        GetSpawnPosition = Coin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If coin under the floor will reset the coin position and count miss++.
        if(Coin.transform.position.y <= 0)
        {
            //Debug.Log(Coin.transform.position.y);
            
            CoinMissCount.text = (int.Parse(CoinMissCount.text) + 1).ToString();
            OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
            //If coin owned 0 will not give coin
            if(int.Parse(OwnCoin.text) > 0)
            {
                Coin.transform.position = GetSpawnPosition;
            }
            else
            {
                Coin.transform.position = GetSpawnPosition;
                Coin.SetActive(false);
            }
            Debug.Log("Coin Under Ground");
            Debug.Log("Coin Reset");
        }
    }
}
