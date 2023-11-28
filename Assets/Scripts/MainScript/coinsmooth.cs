using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsmooth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;
    Vector3 coinvelocity;
    Vector3 velscale;
    
    
    void Start()
    {
        coin = this.gameObject;
        coinvelocity = coin.GetComponent<Rigidbody>().velocity;
        velscale = new Vector3(1,2.6f,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        if (coinvelocity != Vector3.zero)
        {
            coin.GetComponent<Rigidbody>().velocity = Vector3.Lerp(coinvelocity, velscale, 0.1f);
        }
    }
}
