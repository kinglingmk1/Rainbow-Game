using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
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
    /// old code for start game
    /// already change to OnCollisionEnter
    /// </summary>
    /// <param name="col"></param>
    // public void goMain()
    // {
    //     SceneManager.LoadScene("Main");
    // }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Start")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
