using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class TextAlpha : MonoBehaviour
{
    private FreqMan _freqMan;
    private int _deviceFreq;
    private int _exdeviceFreq;
    private Image _textImage;
    private float _alpha;
    
    public float TextFreq;
    
    // Start is called before the first frame update
    void Start()
    {
        _freqMan = FindObjectOfType<FreqMan>();
        _deviceFreq = _freqMan.DeviceFreq;
        _exdeviceFreq = _deviceFreq;
        Image textImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _exdeviceFreq = _deviceFreq;
        _deviceFreq = _freqMan.DeviceFreq;
        if (Mathf.Abs(_deviceFreq - _exdeviceFreq) > 5)
        {
            UpdateAlpha();
        }
    }
    
    private void UpdateAlpha()
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
