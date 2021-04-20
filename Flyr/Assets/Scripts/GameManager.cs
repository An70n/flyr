using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rConversationStart").asBool == true)
        {
            AudioManager.audioManager.ReducePitch("PianoMusic", -1f, 20f);

            //AudioManager.audioManager.audioSources[2].pitch = -1f;

            //Debug.Log("pitch");

        }
    }

    public void StartGame()
    {
        GameObjectsList.gameObjectsList.startScreen.SetActive(false);
        AudioManager.audioManager.Play("PianoMusic");
        AudioManager.audioManager.FadeIn("PianoMusic", .5f, 20f);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
