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
    public string selectedDevice;
    public float Delay;
    private string imageURL = "http://10.100.5.53:6789/images/"; // Replace with your server's image endpoint
    
    private string _filename;

    private GameObject voiceObj;
    private PostFile _postFile;
    void Start()
    {
        if (photonView.IsMine || !PhotonNetwork.IsConnected)
        {
            photonView.RPC(nameof(StartLoadData), RpcTarget.AllBuffered);
        }
        voiceObj = GameObject.Find("Audio");
        _postFile = voiceObj.GetComponent<PostFile>();
    }

    private IEnumerator LoadImageAndData(float delay)
    {
        yield return new WaitForSeconds(delay);
        _filename = _postFile.filename;
        string imageEndpoint = imageURL + _filename + ".png"; // Construct the URL
        using (UnityWebRequest www = UnityWebRequest.Get(imageEndpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                ServerResponse response = JsonUtility.FromJson<ServerResponse>(www.downloadHandler.text);
                int freq = response.frequency;
                Debug.Log("Frequency: " + freq);

                byte[] imageBytes = Convert.FromBase64String(response.image_data);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageBytes); // Load the image

                Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                if (newSprite != null)
                {
                    text_image.enabled = true;
                    text_image.sprite = newSprite;
                    text_image.rectTransform.localScale = new Vector3(-newSprite.bounds.size.x / 1000f, newSprite.bounds.size.y / 1000f, 1f);
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
    
    [PunRPC]
    public void StartLoadData()
    {
        StartCoroutine(LoadImageAndData(Delay));
    }
}