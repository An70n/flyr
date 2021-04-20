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
        Lua.RegisterFunction("ReducePitchLuaSpecific", this, SymbolExtensions.GetMethodInfo(() => ReducePitchLuaSpecific(string.Empty, double.NaN, double.NaN)));
        Lua.RegisterFunction("AugmentPitchLuaSpecific", this, SymbolExtensions.GetMethodInfo(() => AugmentPitchLuaSpecific(string.Empty, double.NaN, double.NaN)));
    }

    public void Play(string name) 
    {
        foreach(AudioSource s in audioSources)
        {
            if(s.name == name)
            {
                s.Play();
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

            yield return null;
        }
    }

    private void ReducePitchLuaSpecific(string name, double minPitch, double fadeTime)
    {
        float pitch = (float)minPitch;
        float time = (float)fadeTime;

        ReducePitch(name, pitch, time);
    }

    public void AugmentPitch(string name, float maxPitch, float fadeTime)
    {
        foreach (AudioSource s in audioSources)
        {
            if (s.name == name)
            {
                StartCoroutine(StartAugmentingPitch(s, maxPitch, fadeTime));
                break;
            }
        }
    }

    private IEnumerator StartAugmentingPitch(AudioSource source, float maxPitch, float fadeTime)
    {
        while (source.pitch < maxPitch)
        {
            source.pitch += 1 * Time.deltaTime / fadeTime;

            yield return null;
        }
    }

    private void AugmentPitchLuaSpecific(string name, double maxPitch, double fadeTime)
    {
        float pitch = (float)maxPitch;
        float time = (float)fadeTime;

        AugmentPitch(name, pitch, time);
    }
}
