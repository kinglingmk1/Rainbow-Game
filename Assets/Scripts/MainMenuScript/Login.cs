using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject loginUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Login")
        {
            if (loginUI.activeSelf == false)
            {
                Debug.Log("Active Login");
                loginUI.SetActive(true);
            }else if (loginUI.activeSelf == true)
            {
                Debug.Log("UnActive Login");
                loginUI.SetActive(false);
            }
        }
    }
}
