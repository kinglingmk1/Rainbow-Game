using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageBack : MonoBehaviour
{
    [SerializeField] private GameObject languageBlock;
    Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = languageBlock.transform.position;
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Language")
        {
            if (languageBlock.transform.position != pos)
            {
                languageBlock.transform.position = pos;
            }
        }
    }
}
