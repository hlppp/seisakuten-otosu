using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.Networking;

public class SetImage : MonoBehaviourPunCallbacks
{
    private Sprite newSprite;
    public Image text_image;
    public string selectedDevice;
    public float Delay;
    private string imageURL = "http://10.100.5.53:6789/images/"; // commons hanlin

    // Start is called before the first frame update
    void Start()
    {
        
        if (photonView.IsMine || !PhotonNetwork.IsConnected)
        {
            // Debug.Log("ready to load image");
            photonView.RPC(nameof(StartLoadImage), RpcTarget.All);
        }
        
        //photonView.RPC(nameof(StartLoadImage), RpcTarget.All);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadImage(string url, float delay)
    {
        yield return new WaitForSeconds(delay);
        // Debug.Log("start loading image");
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                // Debug.Log("New sprite created. Size: " + newSprite.rect.size);
            }
            else
            {
                Debug.Log("Unable to load image: " + www.error);
            }
        }

        while (newSprite == null)
        {
            yield return null;  // wait for the next frame
        }
        
        text_image.enabled = true;
        /*
        if (text_image == null)
        {
            Debug.Log("imagechild is null");
        }
        */
        
        text_image.sprite = newSprite;
        text_image.rectTransform.localScale = new Vector3(-text_image.sprite.bounds.size.x / 1000f, text_image.sprite.bounds.size.y / 1000f, 1f);
        
        newSprite = null;
    }

    [PunRPC]
    public void StartLoadImage()
    {
        string imageFilename = selectedDevice + ".png";
        StartCoroutine(LoadImage(imageURL + imageFilename, Delay));
    }
}
