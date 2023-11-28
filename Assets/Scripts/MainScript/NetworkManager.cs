using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Timers;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace MainScript
{
    public class NetworkManager : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        private const string APIURL = "https://www.hashtag071629.com";
        
        [CanBeNull] private string _loginCode;

        private void Start()
        {
            StartCoroutine(RequestLoginCode());
        }

        private IEnumerator RequestLoginCode()
        {
            var form = new WWWForm();
            form.AddField("applicationNamePost", "RainbowGame");
            
            using var req = UnityWebRequest.Post($"{APIURL}/compassportal/create", form);
            yield return req.SendWebRequest();
            
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Debug.Log(req.result != UnityWebRequest.Result.Success ? req.error : req.downloadHandler.text);
            
            _loginCode = req.downloadHandler.text.Substring("SUCCESS_".Length);
            StartCoroutine(RequestLogin());
        }
        
        private IEnumerator RequestLogin()
        {
            var form = new WWWForm();
            form.AddField("tokenPost", _loginCode);
            
            using var req = UnityWebRequest.Post($"{APIURL}/compassportal/verifytoken", form);
            
            yield return req.SendWebRequest();
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Debug.Log(req.result != UnityWebRequest.Result.Success ? req.error : req.downloadHandler.text);

            if (req.downloadHandler.text.Contains("NO_LOGIN_DATA"))
            {
                StartCoroutine(RequestLogin());
            }
            else
            {
                Debug.Log(req.downloadHandler.text.Contains("SUCCESS")
                    ? $"Login Success: {req.downloadHandler.text.Substring("SUCCESS_".Length)}"
                    : "Login Failed");
                StopAllCoroutines();
            }
        }
    }
}