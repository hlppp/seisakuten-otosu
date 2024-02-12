using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Photon.Pun;

public class GetData : MonoBehaviourPunCallbacks
{
    [System.Serializable]
    public class ServerResponse
    {
        public string image_data;
        public int frequency;
    }

    public Image text_image;
    // public string selectedDevice;
    public float Delay;
    // private string imageURL = "http://10.100.5.53:6789/images/"; // TokyoU000
    private string imageURL = "http://192.168.1.103:6789/images/"; // HomeA
    //private string imageURL = "http://10.100.132.68:6789/images/"; 
    private string _filename;
    public int tfreq;

    private GameObject voiceObj;
    private PostFile _postFile;
    private TextAlpha _textAlpha;
    private string end;
    
    private GameObject _freqManObj;
    private FreqMan _freqMan;
    private int _CdeviceFreq;
    
    void Start()
    {
        if (photonView.IsMine || !PhotonNetwork.IsConnected)
        {
            StartCoroutine(LoadFile());
            Debug.Log("HERE"+end);
        }
        voiceObj = GameObject.Find("Audio");
        _postFile = voiceObj.GetComponent<PostFile>();
        _textAlpha = GetComponent<TextAlpha>();
        
        _freqManObj = GameObject.Find("FrequencyManager");
        _freqMan = _freqManObj.GetComponent<FreqMan>();
        _CdeviceFreq = _freqMan.DeviceFreq;
        _textAlpha.TextFreq = _CdeviceFreq;
    }

    private IEnumerator LoadImageAndData(string endpoint)
    {
        // yield return new WaitForSeconds(delay);
        using (UnityWebRequest www = UnityWebRequest.Get(endpoint))
        {
            yield return www.SendWebRequest();
            // _filename = _postFile.filename;
            if (www.result == UnityWebRequest.Result.Success)
            {
                ServerResponse response = JsonUtility.FromJson<ServerResponse>(www.downloadHandler.text); 
                tfreq = response.frequency;
                Debug.Log("Frequency: " + tfreq);
                //change this step to make it depend on the current device frequency
                //_textAlpha.TextFreq = tfreq;
                byte[] imageBytes = Convert.FromBase64String(response.image_data);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageBytes); // Load the image

                Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                if (newSprite != null)
                {
                    text_image.enabled = true;
                    text_image.sprite = newSprite;
                    text_image.rectTransform.localScale = new Vector3(-newSprite.bounds.size.x / 2000f, newSprite.bounds.size.y / 2000f, 1f);
                }
                else
                {
                    Debug.LogError("Error creating sprite");
                }
            }
            else
            {
                Debug.LogError("Error in image data request: " + www.error);
            }
        }
    }
    
    private IEnumerator LoadFile()
    {
        yield return new WaitForSeconds(Delay);
        _filename = _postFile.filename;
        end = imageURL + _filename + ".png"; // Construct the URL
        Debug.Log("first HERE"+end);
        //StartCoroutine(LoadImageAndData(imageEndpoint));
        photonView.RPC(nameof(StartLoadData), RpcTarget.AllBuffered, end);
    }
    
    [PunRPC]
    public void StartLoadData(string url)
    {
        // string imageEndpoint = imageURL + _filename + ".png"; // Construct the URL
        StartCoroutine(LoadImageAndData(url));
        //StartCoroutine(LoadFile(Delay));
    }
    
}