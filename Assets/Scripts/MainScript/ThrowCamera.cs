using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCamera : MonoBehaviour
{
    public GameObject coinCamera, vrCamera, coin;
    public Camera coinCam;
    Vector3 coinPosition, cameraPosition;
    public RawImage coinImage;
    public Canvas coinCanvas;
    //Texture2D showcam;
    
    // Start is called before the first frame update
    void Start()
    {
        coinCamera.SetActive(false);
        coinPosition = coin.transform.position;
        cameraPosition = coinCamera.transform.position;
        coinCam = this.coinCamera.GetComponent<Camera>();
    }
    void Awake()
    {
        coinCam.targetTexture = RenderTexture.GetTemporary(1280, 720, 16);
        coinImage.texture = coinCam.targetTexture;
    }
    void OnDestroy()
    {
        if(coinImage != null)
        {
            coinImage.texture = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(coin.transform.position.z >= -34.55)
        {
            //vrCamera.SetActive(false);
            coinCamera.SetActive(true);
            coinCamera.transform.position = new Vector3(coin.transform.position.x,coinCamera.transform.position.y,coin.transform.position.z);
            
        }
        else
        {
            //vrCamera.SetActive(true);
            coinCamera.SetActive(false);
        }
        
    }
}
