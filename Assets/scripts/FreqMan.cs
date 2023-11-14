using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreqMan : MonoBehaviour
{
    public Slider freqSlider;
    [HideInInspector] public int DeviceFreq = 0;

    // Start is called before the first frame update
    void Start()
    {
        freqSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ValueChangeCheck()
    {
        DeviceFreq = (int)freqSlider.value;
        Debug.Log("Device Freq: " + DeviceFreq);
    }
}
