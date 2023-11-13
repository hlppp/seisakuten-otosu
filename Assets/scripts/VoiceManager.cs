using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VoiceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip b3;
    //public AudioClip a3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //StringController stringController = other.gameObject.GetComponent<StringController>();  // 弦にアタッチされたスクリプトを取得
        //float strPitch = stringController.pitch;    // 弦から鳴る音の高さについての値を取得

        // 文字から鳴らす音の高さを取得
        //SetImage setimage = other.gameObject.Getcomponent<SetImage>();
        //int pitch = setimage.freq;
        int pitch = 100;

        switch (pitch)
        {
            case 100: // B3（シ）を表す値
                audioSource.PlayOneShot(b3);    // B3を鳴らす
                break;
            /*
            case xxx; // A3（ラ）を表す値
                audioSource.PlayOneShot(a3);    // A3を鳴らす
                break;
            */
        }
    }

}