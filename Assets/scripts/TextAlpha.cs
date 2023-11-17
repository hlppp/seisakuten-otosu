using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class TextAlpha : MonoBehaviour
{
    private GameObject _freqManObj;
    private FreqMan _freqMan;
    private int _deviceFreq;
    private int _exdeviceFreq;
    private Image _textImage;
    private float _alpha;
    
    public int TextFreq{ get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _freqManObj = GameObject.Find("FrequencyManager");
        _freqMan = _freqManObj.GetComponent<FreqMan>();
        _deviceFreq = _freqMan.DeviceFreq;
        _exdeviceFreq = _deviceFreq;
        _textImage = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _exdeviceFreq = _deviceFreq;
        _deviceFreq = _freqMan.DeviceFreq;
        if (_deviceFreq != _exdeviceFreq)
        {
            Debug.Log("Begin updating alpha");
            // Debug.Log("text Freq: " + TextFreq);
            UpdateAlpha();
        }
        
        //UpdateAlpha();
    }
    
    private void UpdateAlpha()
    {
        Debug.Log("Begin updating alpha");
        if (_deviceFreq == 0)
        {
            _alpha = 1;
            _textImage.color = new Color(1, 1, 1, _alpha);
        }
        else
        {
            float d = Mathf.Abs(_deviceFreq - TextFreq);
            if (d > 50)
            {
                d = 50;
            }
            _alpha = (50-d)/ 50;
            _textImage.color = new Color(1, 1, 1, _alpha);
        }
    }
}
