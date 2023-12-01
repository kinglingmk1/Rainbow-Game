using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class CollidedWithTable : MonoBehaviour
{
    public GameObject Coin, CoinIn, CoinOut, Idle, Joyful, Jumping, Dump;
    public Text CoinHitTableCount, OwnCoin,RedText,YellowText,GreenText,BlueText,HitTableText;
    public Rigidbody rb;
    Vector3 GetSpawnPosition, vel;
    bool tableHit, redHit, yellowHit, greenHit, blueHit, rainbowBoundaryHit;
    public int[] goalArray = new int[4];
    float time, gameGravity, scaleGravity;
    public int count;
    public AudioListener audioListener;
    public AudioSource audioSource;
    public ParticleSystem system;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get coin position when started.
        audioSource = GetComponent<AudioSource>();
        count = 0;
        vel = rb.velocity;
        GetSpawnPosition = Coin.transform.position;
        time = 0f;
        CoinIn.SetActive(false);
        CoinOut.SetActive(false);
        gameGravity = -9.8f;
        scaleGravity = 2.6f;
        for(int i=0; i<4; i++)
        {
            goalArray[i] = 0;
        }
        
        ParticleSystem system = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        audioListener.enabled = true;
        
        Vector3 gravity = gameGravity * scaleGravity * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
        //Collided with table -> out

        //Collided with table + red -> out
        if (tableHit)
        {
            if (time >= 5)
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
            if(time <= 5)
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
        
        if (!audioSource.isPlaying && col.gameObject.tag != "Player")
        {
            audioSource.Play();
        }
        switch (col.gameObject.tag)
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
            case "BlackBoundary":
                rainbowBoundaryHit = true;
                break;
            case "RainbowTable":
                tableHit = true;
                HitTableText.text = "true";
                break;
          }
        //Debug.Log("Enter " + col.gameObject.tag+ col.gameObject.transform.GetInstanceID());
        //for(int i = 0; i < col.contacts.Length;i++)
        //{
        //    new GameObject(col.gameObject.tag + " Collision point 0"+ i).transform.position = col.contacts[i].point;
        //}
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
            case "BlackBoundary":
                rainbowBoundaryHit = false;
                break;
            case "RainbowTable":
                tableHit = false;
                HitTableText.text = "false";
                break;
        }
        //Debug.Log("Leave " + col.gameObject.tag + col.gameObject.transform.GetInstanceID());
    }
    void isCollision()
    {
        //Collision check
        CoinHitTableCount.text = (int.Parse(CoinHitTableCount.text) + 1).ToString();
        OwnCoin.text = (int.Parse(OwnCoin.text) - 1).ToString();
        if (rainbowBoundaryHit) // Hit the boundary
        {
            redHit = false;
            yellowHit = false;
            greenHit = false;
            blueHit = false;
            rainbowBoundaryHit = false;
        }
        if ((redHit == true && yellowHit == false && greenHit == false && blueHit == false) || (redHit == false && yellowHit == true && greenHit == false && blueHit == false) || (redHit == false && yellowHit == false && greenHit == true && blueHit == false) || (redHit == false && yellowHit == false && greenHit == false && blueHit == true))
        {
            Idle.SetActive(false);
            
            if (redHit)
            {
                goalArray[0]++;
                RedText.text = goalArray[0].ToString();
                Jumping.SetActive(true);
            }
            if (yellowHit)
            {
                goalArray[1]++;
                YellowText.text = goalArray[1].ToString();
                Jumping.SetActive(true);
            }
            if (greenHit)
            {
                goalArray[2]++;
                GreenText.text = goalArray[2].ToString();
                Joyful.SetActive(true);
            }
            if (blueHit)
            {
                goalArray[3]++;
                BlueText.text = goalArray[3].ToString();
                Joyful.SetActive(true);
            }
            CoinIn.SetActive(true);
            CoinOut.SetActive(false);
            Debug.Log("In");
            
            //play particle
            system.Play();
        }
        else
        {
            Jumping.SetActive(false);
            Joyful.SetActive(false);
            Idle.SetActive(true);
            CoinOut.SetActive(true);
            CoinIn.SetActive(false);
            Debug.Log("Out");
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
