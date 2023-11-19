using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollidedWithTable : MonoBehaviour
{
    public GameObject Coin;
    public Text CoinHitTableCount, OwnCoin;
    public Rigidbody rb;
    Vector3 GetSpawnPosition, vel;
    bool tableHit, redHit, yellowHit, greenHit, blueHit, rainbowBoundaryHit;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        //Get coin position when started.
        vel = rb.velocity;
        GetSpawnPosition = Coin.transform.position;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Collided with table -> out

        //Collided with table + red -> out
        if (tableHit)
        {
            if (time >= 3)
            {
                isCollision();
                time = 0;
            } else
            {
                time += Time.deltaTime;
            }
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "RainbowTable")
        {
            tableHit = true;
            Debug.Log("Enter Table");
        }
        else
        {
            if (col.gameObject.tag == "Red")
            {
                redHit = true;
                Debug.Log("Enter Red");
            }
            else
            {
                if (col.gameObject.tag == "Yellow")
                {
                    yellowHit = true;
                    Debug.Log("Enter Yellow");
                }
                else
                {
                    if (col.gameObject.tag == "Green")
                    {
                        greenHit = true;
                        Debug.Log("Enter Green");
                    }
                    else
                    {
                        if (col.gameObject.tag == "Blue")
                        {
                            blueHit = true;
                            Debug.Log("Enter Blue");
                        }
                    }
                }
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "RainbowTable")
        {
            tableHit = false;
            Debug.Log("Leave Table");
        }
        else
        {
            if (col.gameObject.tag == "Red")
            {
                redHit = false;
                Debug.Log("Leave Red");
            }
            else
            {
                if (col.gameObject.tag == "Yellow")
                {
                    yellowHit = false;
                    Debug.Log("Leave Yellow");
                }
                else
                {
                    if (col.gameObject.tag == "Green")
                    {
                        greenHit = false;
                        Debug.Log("Leave Green");
                    }
                    else
                    {
                        if (col.gameObject.tag == "Blue")
                        {
                            blueHit = false;
                            Debug.Log("Leave Blue");
                        }
                    }
                }
            }
        }
    }
    void isCollision()
    {
        //Collision check
        CoinHitTableCount.text = (int.Parse(CoinHitTableCount.text) + 1).ToString();
        OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
        if (int.Parse(OwnCoin.text) > 0)
        {
            rb.velocity = vel.normalized * 1f;
            Coin.transform.position = GetSpawnPosition;
        } else
        {
            rb.velocity = vel.normalized * 1f;
            Coin.transform.position = GetSpawnPosition;
            Coin.SetActive(false);
        }

        Debug.Log("Collision With Table");
    }
}
