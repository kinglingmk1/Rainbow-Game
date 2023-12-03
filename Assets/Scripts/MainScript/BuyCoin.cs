using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCoin : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 GetSpawnPosition, vel;
    public Text OwnCoin, RedText, YellowText, GreenText, BlueText;
    public GameObject BuyCoins;
    // Start is called before the first frame update
    void Start()
    {
        vel = rb.velocity;
        GetSpawnPosition = BuyCoins.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BuyCoin")
        {
            Debug.Log("BuyCoin");
            OwnCoin.text = (int.Parse(BlueText.text)*30 + int.Parse(GreenText.text) * 15 + int.Parse(YellowText.text) * 5 + int.Parse(RedText.text) * 1 + int.Parse(OwnCoin.text)).ToString();
            BlueText.text = "0";
            GreenText.text = "0";
            YellowText.text = "0";
            RedText.text = "0";
            rb.velocity = vel.normalized * 1f;
            BuyCoins.transform.position = GetSpawnPosition;

        }
    }
}
