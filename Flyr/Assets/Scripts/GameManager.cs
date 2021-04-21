using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        GameObjectsList.gameObjectsList.startScreen.SetActive(false);
        AudioManager.audioManager.FadeIn("PianoMusic", .3f, 20f);
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
