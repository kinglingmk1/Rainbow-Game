using System.Collections;
using System.Collections.Generic;
using Network;
using Singleton;
using UnityEngine;
using UnityEngine.UI;

public class CheckCoinUnderGround : Singleton<CheckCoinUnderGround>
{
    public GameObject Coin, Jumping, Joyful, Idle;
    public Text CoinMissCount, OwnCoin,HitTable;
    public Rigidbody rb; /* <-!- WTF is this don't use abbreviation */
    Vector3 GetSpawnPosition, vel;
    bool hit;
    float time;
    /* Naming convention violation in almost every symbol */
    /* WTF you shouldn't use texts to lookup a value! */ 
    
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.FetchProfile();
        time = 0;
        //Get coin start position.
        vel = rb.velocity;
        GetSpawnPosition = Coin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (HitTable.text.Equals("true"))
        {
            if(time <= 7)
            {
                time += Time.deltaTime;
            } else
            {
                Jumping.SetActive(false);
                Joyful.SetActive(false);
                Idle.SetActive(true);
                NetworkManager.Instance.GetCoin();
                HitTable.text = "false";
                time = 0;
            }
            
        }
        //If coin under the floor will reset the coin position and count miss++.
        if(Coin.activeSelf && Coin.transform.position.y <= 2)
        {
            Coin.SetActive(false);
            //Debug.Log(Coin.transform.position.y);
            
            CoinMissCount.text = (int.Parse(CoinMissCount.text) + 1).ToString();
            OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
            //If coin owned 0 will not give coin
            NetworkManager.Instance.GetCoin();
            Debug.Log("Coin Under Ground");
            Debug.Log("Coin Reset");
        }
    }

     public void resetCoin(bool regenerate) /* <-!- Naming Convention */
    {
        if(regenerate)
        {
            rb.velocity = vel.normalized * 1f;
            Coin.transform.position = GetSpawnPosition;
            Coin.SetActive(true);
        }
        else
        {
            rb.velocity = vel.normalized * 1f;
            Coin.transform.position = GetSpawnPosition;
            Coin.SetActive(false);
        }
    }
}
