using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBonus : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player,coin,canvas,tv;
    public Text enterLevel, blue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BonusLevel")
        {
            Debug.Log("BonusLevel");
            player.transform.position = new Vector3(84, 0, -56); ;
            coin.transform.position = new Vector3(90, 6, -43);
            canvas.transform.position = new Vector3(84f,5.37f,-15.57f);
            tv.transform.position = new Vector3(97.46f, 15.67f, -17.33f);
            enterLevel.text = "true";
            blue.text = (int.Parse(blue.text) - 5).ToString();
        }
        if (col.gameObject.tag == "BackToNormal")
        {
            Debug.Log("BackToNormal");
            player.transform.position = new Vector3(0, 0, -50); ;
            coin.transform.position = new Vector3(11, 6, -43);
            canvas.transform.position = new Vector3(4.16f, 5.37f, -15.57f);
            tv.transform.position = new Vector3(17.48f, 15.67f, -20.12f);
            coin.SetActive(true);
        }
    }
}
