using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;

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
        if (other.gameObject.CompareTag("Login"))
        {
            if (loginUI.activeSelf == false)
            {
                Debug.Log("Active Login");
                loginUI.SetActive(true);
                NetworkManager.Instance.RequestCode();
            }else if (loginUI.activeSelf)
            {
                Debug.Log("UnActive Login");
                loginUI.SetActive(false);
            }
        }
    }
}
