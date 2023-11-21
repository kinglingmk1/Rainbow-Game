using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// old code for exit game
    /// already change to OnCollisionEnter
    /// </summary>
    /// <param name="col"></param>
    // public void OnQuit()
    // {
    //     Application.Quit();
    // }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Exit")
        {
            Application.Quit();
        }
    }
}
