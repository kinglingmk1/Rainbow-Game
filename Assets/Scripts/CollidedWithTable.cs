using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollidedWithTable : MonoBehaviour
{
    public GameObject Coins;
    public Text CoinHitTableCount;
    Vector3 GetSpawnPosition;
    bool tabletrigger;
    // Start is called before the first frame update
    void Start()
    {
        GetSpawnPosition = Coins.transform.position;
        tabletrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Collided with table -> out
        

        //Collided with table + red -> out
    }
    void OnCollisionEnter(Collision col)
    {
        //Collision with anything Count
        CoinHitTableCount.text = (int.Parse(CoinHitTableCount.text) + 1).ToString();
        Coins.transform.position = GetSpawnPosition;
        Debug.Log("Collision With Table");
    }
}
