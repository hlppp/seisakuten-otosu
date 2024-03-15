// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;

// public class PostFile : MonoBehaviour
// {
//     // private string url = "http://10.100.176.125:5000/upload";
//     // private string url = "http://192.168.100.137:5050/upload";
//     private string url = "http://10.100.5.53:6789/upload";
    
//     // private string url = "http://192.168.1.153:6789/upload"; 
//     public string selectedDevice;

//     public void UploadWavFile(string filePath)
//     {
//         StartCoroutine(SendRequest(filePath));
//     }

//     private IEnumerator SendRequest(string filePath)
//     {
//         byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        
//         //Create a new WWWForm, to hold the form data.
//         WWWForm form = new WWWForm();
        
//         //Add binary data to the form. Key is 'audio'
//         // form.AddBinaryData("audio", fileData, filePath, "audio/wav");
//         form.AddBinaryData("audio", fileData,  selectedDevice + ".wav", "audio/wav");
        
//         using (UnityWebRequest request = UnityWebRequest.Post(url, form))
//         {
//             yield return request.SendWebRequest();

//             if(request.result != UnityWebRequest.Result.Success)
//             {
//                 Debug.LogError("Failed to upload the file: " + request.error);
//             }
//             else
//             {
//                 Debug.Log("File upload completed");
//                 Debug.Log("Server response: " + request.downloadHandler.text);
//             }
//         }
//     }
// }




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;


public class PostFile : MonoBehaviour
{
    // public PlaceText placeText;
    public string selectedDevice;
    [HideInInspector] public string filename;
    
    // private string url = "http://10.100.20.78:6789/upload"; 
    // private string url = "http://10.100.20.78:6788/upload"; 
    // private string url = "http://192.168.100.170:6789/upload"; 
    //private string url = "http://192.168.1.103:6789/upload"; //HomeA
    // private string url = "http://10.100.5.53:6789/upload"; // TokyoU000
    // private string url = "http://10.100.132.68:6789/upload";
    private string url = "http://192.168.100.89:6789/upload"; //Inami5G
    
    private GameObject _freqManObj;
    private FreqMan _freqMan;
    private int CdeviceFreq;
    
    void Start()
    {
        _freqManObj = GameObject.Find("FrequencyManager");
        _freqMan = _freqManObj.GetComponent<FreqMan>();
        CdeviceFreq = _freqMan.DeviceFreq;
    }


    public void UploadWavFile(string filePath)
    {
        StartCoroutine(SendRequest(filePath));
    }

    private IEnumerator SendRequest(string filePath)
    {
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        
        WWWForm form = new WWWForm();
        
        // form.AddBinaryData("audioA", fileData, "No1audio.wav", "audio/wav");//hanlin iphone14
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        CdeviceFreq = _freqMan.DeviceFreq;
        filename = CdeviceFreq + selectedDevice + timestamp; 

        form.AddBinaryData("audioA", fileData, filename+ ".wav", "audio/wav");//hanlin iPad
        
        // form.AddBinaryData("audioB", fileData, filePath, "audio/wav");

        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to upload the files: " + request.error);
            }
            else
            {
                Debug.Log("File upload completed");
                Debug.Log("Server response: " + request.downloadHandler.text);
            }
        }
    }
}

