using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCoinUnderGround : MonoBehaviour
{
    public GameObject Coin;
    public Text CoinMissCount;
    Vector3 GetSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        GetSpawnPosition = Coin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Coin.transform.position.y <= 0)
        {
            //Debug.Log(Coin.transform.position.y);
            Coin.transform.position = GetSpawnPosition;
            CoinMissCount.text = (int.Parse(CoinMissCount.text) + 1).ToString();
            Debug.Log("Coin Under Ground");
            Debug.Log("Coin Reset");
        }
    }
}
