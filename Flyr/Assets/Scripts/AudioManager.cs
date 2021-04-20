using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

    public AudioSource[] audioSources;

    void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Lua.RegisterFunction("Play", this, SymbolExtensions.GetMethodInfo(() => Play(string.Empty)));
    }

    public void Play(string name) 
    {
        foreach(AudioSource s in audioSources)
        {
            if(s.name == name)
            {
                s.Play();
                Debug.Log(name);
                break;
            }
        }
    }

    public void FadeIn(string name, float maxVolume, float fadeTime)
    {
        foreach (AudioSource s in audioSources)
        {
            if (s.name == name)
            {
                StartCoroutine(StartFadeIn(s, maxVolume, fadeTime));
                break;
            }
        }
    }

    private IEnumerator StartFadeIn(AudioSource source, float maxVolume, float fadeTime)
    {
        while (source.volume < maxVolume)
        {
            source.volume += 1 * Time.deltaTime / fadeTime;

            yield return null;
        }
    }

    public void ReducePitch(string name, float minPitch, float fadeTime)
    {
        foreach (AudioSource s in audioSources)
        {
            if (s.name == name)
            {
                StartCoroutine(StartReducingPitch(s, minPitch, fadeTime));
                break;
            }
        }
    }

    private IEnumerator StartReducingPitch(AudioSource source, float minPitch, float fadeTime)
    {
        while(source.pitch > minPitch)
        {
            source.pitch -= 1 * Time.deltaTime / fadeTime;
            Debug.Log("reducing pitch");

            yield return null;
        }
    }
}
