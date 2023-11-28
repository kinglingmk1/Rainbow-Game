using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsmooth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;
    Vector3 coinvelocity;
    
    
    void Start()
    {
        coin = this.gameObject;
        coinvelocity = coin.GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        if (coinvelocity != Vector3.zero)
        {
            coinvelocity = coin.GetComponent<Rigidbody>().velocity;
            coin.GetComponent<Rigidbody>().velocity = Vector3.Lerp(coinvelocity, Vector3.zero, 0.1f);
        }
    }
}
