using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCoinUnderGround : MonoBehaviour
{
    public GameObject Coin, Jumping, Joyful, Idle;
    public Text CoinMissCount, OwnCoin,HitTable;
    public Rigidbody rb;
    Vector3 GetSpawnPosition, vel;
    bool hit;
    float time;
    // Start is called before the first frame update
    void Start()
    {
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
            if(time < 5)
            {
                time += Time.deltaTime;
            } else
            {
                Jumping.SetActive(false);
                Joyful.SetActive(false);
                Idle.SetActive(true);
                resetCoin();
                HitTable.text = "false";
                time = 0;
            }
            
        }
        //If coin under the floor will reset the coin position and count miss++.
        if(Coin.transform.position.y <= 0)
        {
            //Debug.Log(Coin.transform.position.y);
            
            CoinMissCount.text = (int.Parse(CoinMissCount.text) + 1).ToString();
            OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
            //If coin owned 0 will not give coin
            resetCoin();
            Debug.Log("Coin Under Ground");
            Debug.Log("Coin Reset");
        }
    }

    void resetCoin()
    {
        if(int.Parse(OwnCoin.text) > 0)
        {
            rb.velocity = vel.normalized * 1f;
            Coin.transform.position = GetSpawnPosition;
        }
        else
        {
            rb.velocity = vel.normalized * 1f;
            Coin.transform.position = GetSpawnPosition;
            Coin.SetActive(false);
        }
    }
}
