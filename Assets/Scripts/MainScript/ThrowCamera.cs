using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCamera : MonoBehaviour
{
    public GameObject coinCamera, vrCamera, coin;
    Vector3 coinPosition, cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        coinCamera.SetActive(false);
        coinPosition = coin.transform.position;
        cameraPosition = coinCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(coin.transform.position.z >= -34.55)
        {
            vrCamera.SetActive(false);
            coinCamera.SetActive(true);
            coinCamera.transform.position = new Vector3(coin.transform.position.x,coinCamera.transform.position.y,coin.transform.position.z);
        }
        else
        {
            vrCamera.SetActive(true);
            coinCamera.SetActive(false);
        }
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Debug.Log("Coin");
            
        }
    }
}
