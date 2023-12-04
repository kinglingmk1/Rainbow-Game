using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCion : MonoBehaviour /* <-!- Typo */
{
    // Start is called before the first frame update
    GameObject coin;
    Vector3 coinoriginalPos; /* <-!- Naming Convention */
    void Start()
    {
        coin = this.gameObject;
        coinoriginalPos = coin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(coin.transform.position.y <= 0.07)
        {
            coin.transform.position = coinoriginalPos;
        }
    }
}
