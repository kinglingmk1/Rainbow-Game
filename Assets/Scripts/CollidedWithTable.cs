using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollidedWithTable : MonoBehaviour
{
    public GameObject Coin;
    public Text CoinHitTableCount, OwnCoin;
    Vector3 GetSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Get coin position when started.
        GetSpawnPosition = Coin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Collided with table -> out

        //Collided with table + red -> out
    }
    void OnCollisionEnter(Collision col)
    {
        //Collision enter with anything Count
        Debug.Log("Enter Table");
    }
    void OnCollisionStay(Collision col)
    {
        //Debug statement
        //Coin keep collision will in this state.
        //Coin collision with table will count 1 to hit table on canvas.
        CoinHitTableCount.text = (int.Parse(CoinHitTableCount.text) + 1).ToString();
        //Coin position willl reset to start position

        OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
        if (int.Parse(OwnCoin.text) > 0)
        {
            Coin.transform.position = GetSpawnPosition;
        } else
        {
            Coin.transform.position = GetSpawnPosition;
            Coin.SetActive(false);
        }

        Debug.Log("Collision With Table");
    }

    void OnCollisionExit(Collision col)
    {
        
    }
}
