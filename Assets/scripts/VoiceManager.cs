using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public double FadeOutSeconds = 1.0; // フェードアウトにかかる時間（秒）
    private bool IsFadeOut = true;
    private double FadeDeltaTime = 0;
    public AudioClip C2;
    public AudioClip C2sharp;
    public AudioClip D2;
    public AudioClip D2sharp;
    public AudioClip E2;
    public AudioClip F2;
    public AudioClip F2sharp;
    public AudioClip G2;
    public AudioClip G2sharp;
    public AudioClip A2;
    public AudioClip A2sharp;
    public AudioClip B2;
    public AudioClip C3;
    public AudioClip C3sharp;
    public AudioClip D3;
    public AudioClip D3sharp;
    public AudioClip E3;
    public AudioClip F3;
    public AudioClip F3sharp;
    public AudioClip G3;
    public AudioClip G3sharp;
    public AudioClip A3;
    public AudioClip A3sharp;
    public AudioClip B3;
    public AudioClip C4;
    public AudioClip C4sharp;
    public AudioClip D4;
    public AudioClip D4sharp;
    public AudioClip E4;
    public AudioClip F4;
    public AudioClip F4sharp;
    public AudioClip G4;
    public AudioClip G4sharp;
    public AudioClip A4;
    public AudioClip A4sharp;
    public AudioClip B4;
    public AudioClip C5;

    void Start()
    {

    }

    void Update()
    {
        // フェードアウト機能
        if (IsFadeOut)
        {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime >= FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;
                IsFadeOut = false;
            }
            audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float pitch = other.gameObject.GetComponent<TextAlpha>().TextFreq;

        switch (pitch)
        {
            case { } val when (val <=67.35):
                audioSource.PlayOneShot(C2);
                break;
            case { } val when (val <= 71.36):
                audioSource.PlayOneShot(C2sharp);
                break;
            case { } val when (val <= 75.6):
                audioSource.PlayOneShot(D2);
                break;
            case { } val when (val <= 80.1):
                audioSource.PlayOneShot(D2sharp);
                break;
            case { } val when (val <= 84.85):
                audioSource.PlayOneShot(E2);
                break;
            case { } val when (val <= 89.90):
                audioSource.PlayOneShot(F2);
                break;
            case { } val when (val <= 95.24):
                audioSource.PlayOneShot(F2sharp);
                break;
            case { } val when (val <= 100.92):
                audioSource.PlayOneShot(G2);
                break;
            case { } val when (val <= 106.91):
                audioSource.PlayOneShot(G2sharp);
                break;
            case { } val when (val <= 113.27):
                audioSource.PlayOneShot(A2);
                break;
            case { } val when (val <= 120.00):
                audioSource.PlayOneShot(A2sharp);
                break;
            case { } val when (val <= 127.14):
                audioSource.PlayOneShot(B2);
                break;
            case { } val when (val <= 134.702):
                audioSource.PlayOneShot(C3);
                break;
            case { } val when (val <= 142.71):
                audioSource.PlayOneShot(C3sharp);
                break;
            case { } val when (val <= 151.20):
                audioSource.PlayOneShot(D3);
                break;
            case { } val when (val <= 160.18):
                audioSource.PlayOneShot(D3sharp);
                break;
            case { } val when (val <= 169.714):
                audioSource.PlayOneShot(E3);
                break;
            case { } val when (val <= 179.80):
                audioSource.PlayOneShot(F3);
                break;
            case { } val when (val <= 190.50):
                audioSource.PlayOneShot(F3sharp);
                break;
            case { } val when (val <= 201.83):
                audioSource.PlayOneShot(G3);
                break;
            case { } val when (val <= 213.82):
                audioSource.PlayOneShot(G3sharp);
                break;
            case { } val when (val <= 226.54):
                audioSource.PlayOneShot(A3);
                break;
            case { } val when (val <= 240.012):
                audioSource.PlayOneShot(A3sharp);
                break;
            case { } val when (val <= 254.28):
                audioSource.PlayOneShot(B3);
                break;
            case { } val when (val <= 269.40):
                audioSource.PlayOneShot(C4);
                break;
            case { } val when (val <= 285.42):
                audioSource.PlayOneShot(C4sharp);
                break;
            case { } val when (val <= 302.40):
                audioSource.PlayOneShot(D4);
                break;
            case { } val when (val <= 320.37):
                audioSource.PlayOneShot(D4sharp);
                break;
            case { } val when (val <= 339.42):
                audioSource.PlayOneShot(E4);
                break;
            case { } val when (val <= 359.61):
                audioSource.PlayOneShot(F4);
                break;
            case { } val when (val <= 381.00):
                audioSource.PlayOneShot(F4sharp);
                break;
            case { } val when (val <= 403.65):
                audioSource.PlayOneShot(G4);
                break;
            case { } val when (val <= 427.65):
                audioSource.PlayOneShot(G4sharp);
                break;
            case { } val when (val <= 453.08):
                audioSource.PlayOneShot(A4);
                break;
            case { } val when (val <= 480.02):
                audioSource.PlayOneShot(A4sharp);
                break;
            case { } val when (val <= 508.567):
                audioSource.PlayOneShot(B4);
                break;
            default:
                audioSource.PlayOneShot(C5);
                break;
        }
    }

}