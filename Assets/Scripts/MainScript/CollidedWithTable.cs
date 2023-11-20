using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollidedWithTable : MonoBehaviour
{
    public GameObject Coin, CoinIn, CoinOut;
    public Text CoinHitTableCount, OwnCoin;
    public Rigidbody rb;
    Vector3 GetSpawnPosition, vel;
    bool tableHit, redHit, yellowHit, greenHit, blueHit, rainbowBoundaryHit;
    float time, gameGravity, scaleGravity;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        //Get coin position when started.
        count = 0;
        vel = rb.velocity;
        GetSpawnPosition = Coin.transform.position;
        time = 0f;
        CoinIn.SetActive(false);
        CoinOut.SetActive(false);
        gameGravity = -9.8f;
        scaleGravity = 2.6f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravity = gameGravity * scaleGravity * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
        //Collided with table -> out

        //Collided with table + red -> out
        if (tableHit)
        {
            if (time >= 3)
            {
                isCollision();
                count = 0;
                time = 0;
            } else
            {
                time += Time.deltaTime;
            }
        }
        if (!tableHit)
        {
            if(time <= 3)
            {
                time += Time.deltaTime;
            } else
            {
                InOutTextReset();
                time = 0;
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        switch(col.gameObject.tag)
        {
            case "Red":
                redHit = true;
                break;
            case "Yellow":
                yellowHit = true;
                break;
            case "Green":
                greenHit = true;
                break;
            case "Blue":
                blueHit = true;
                break;
            case "RainbowTable":
                tableHit = true;
                break;
          }
        Debug.Log("Enter " + col.gameObject.tag+ col.gameObject.transform.GetInstanceID());

        for(int i = 0; i < col.contacts.Length;i++)
        {
            new GameObject(col.gameObject.tag + " Collision point 0"+ i).transform.position = col.contacts[i].point;
        }
    }
    void OnCollisionExit(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "Red":
                redHit = false;
                break;
            case "Yellow":
                yellowHit = false;
                break;
            case "Green":
                greenHit = false;
                break;
            case "Blue":
                blueHit = false;
                break;
            case "RainbowTable":
                tableHit = false;
                break;
        }
        Debug.Log("Leave " + col.gameObject.tag + col.gameObject.transform.GetInstanceID());
    }
    void isCollision()
    {
        //Collision check
        CoinHitTableCount.text = (int.Parse(CoinHitTableCount.text) + 1).ToString();
        OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
        if ((redHit == true && yellowHit == false && greenHit == false && blueHit == false) || (redHit == false && yellowHit == true && greenHit == false && blueHit == false) || (redHit == false && yellowHit == false && greenHit == true && blueHit == false)|| (redHit == false && yellowHit == false && greenHit == false && blueHit == true))
        {
            CoinIn.SetActive(true);
            CoinOut.SetActive(false);
            Debug.Log("In");
        }
        else
        {
            CoinOut.SetActive(true);
            CoinIn.SetActive(false);
            Debug.Log("Out");
        }
        if (int.Parse(OwnCoin.text) > 0)
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
        count = 0;
        Debug.Log("Collision With Table");
    }
    void InOutTextReset()
    {
        CoinIn.SetActive(false);
        CoinOut.SetActive(false);
    }
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
}
