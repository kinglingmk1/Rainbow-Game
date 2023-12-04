using System.Collections;
using System.Linq;
using JetBrains.Annotations;
using Singleton;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
    public class NetworkManager : Singleton<NetworkManager>
    {
        [SerializeField] private TextMeshProUGUI loginCodeDisplay;
        [SerializeField] private GameObject online;
        [SerializeField] private GameObject offline;

        [SerializeField] private TextMeshProUGUI username;

        public int uid;
        
        public int red;
        public int yellow;
        public int green;
        public int blue;
        public int miss;

        public int coinCount;
        
        // ReSharper disable once InconsistentNaming
        private const string APIURL = "https://www.hashtag071629.com";
        
        [CanBeNull] private string _loginCode;

        public void RequestCode()
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
            _loginCode = req.downloadHandler.text.Split('_')[1];
            loginCodeDisplay.text = _loginCode;
            loginCodeDisplay.characterSpacing = 25;
            
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

                if (req.downloadHandler.text.Contains("SUCCESS"))
                {
                    uid = int.Parse(req.downloadHandler.text.Split('_')[1]);
                    username.text = req.downloadHandler.text.Split('_')[2];
                    online.SetActive(true);
                    offline.SetActive(false);
                    FetchProfile();
                }
            }
        }

        public void FetchProfile()
        {
            StartCoroutine(FetchProfileRequest());
        }

        private IEnumerator FetchProfileRequest()
        {
            var form = new WWWForm();
            form.AddField("uidPost", uid);
            
            using var req = UnityWebRequest.Post($"{APIURL}/rainbowgame/download", form);
            Debug.Log("Sent");
            yield return req.SendWebRequest();

            var result = req.downloadHandler.text;
            Debug.Log(result);
            if (result.Contains("SUCCESS"))
            {
                var data = result.Split('_');
                coinCount = int.Parse(data[1]);
                red = int.Parse(data[2]);
                yellow = int.Parse(data[3]);
                green = int.Parse(data[4]);
                blue = int.Parse(data[5]);
                miss = int.Parse(data[6]);

                yield break;
            }

            if (result.Contains("PROFILE_NOT_FOUND"))
            {
                StartCoroutine(CreateProfileRequest());
            }
        }

        private IEnumerator CreateProfileRequest()
        {
            var form = new WWWForm();
            form.AddField("uidPost", uid);
            form.AddField("coinPost", 0);
            form.AddField("redPost", 0);
            form.AddField("yellowPost", 0);
            form.AddField("greenPost", 0);
            form.AddField("bluePost", 0);
            form.AddField("missPost", 0);
            
            using var req = UnityWebRequest.Post($"{APIURL}/rainbowgame/create", form);
            yield return req.SendWebRequest();

            var result = req.downloadHandler.text;

            if (result.Contains("SUCCESS"))
            {
                Debug.Log("Profile Created");
                StartCoroutine(FetchProfileRequest());
            }
        }

        public void UploadData(string status)
        {
            StartCoroutine(UploadDataRequest(status));
        }

        private IEnumerator UploadDataRequest(string status)
        {
            var form = new WWWForm();
            form.AddField("uidPost", uid);
            form.AddField("statusPost", status);
            
            using var req = UnityWebRequest.Post($"{APIURL}/rainbowgame/upload", form);
            yield return req.SendWebRequest();
            
            Debug.Log(req.result != UnityWebRequest.Result.Success ? req.error : req.downloadHandler.text);
            
            if (req.downloadHandler.text.Contains("SUCCESS"))
            {
                StartCoroutine(FetchProfileRequest());
            }
        }
    }
}