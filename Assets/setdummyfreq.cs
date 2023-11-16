using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setdummyfreq : MonoBehaviour
{
    private TextAlpha _textAlpha;
    public int dummyFreq;
    // Start is called before the first frame update
    void Start()
    {
        _textAlpha = GetComponent<TextAlpha>();
        _textAlpha.TextFreq = dummyFreq;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
