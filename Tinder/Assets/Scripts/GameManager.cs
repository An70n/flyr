using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject creditsMenu; 

    private bool credits = false; 
    // Start is called before the first frame update
    void Start()
    {
        creditsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            startMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
    }

    public void CreditsMenu()
    {
        if(credits == false)
        {
            startMenu.SetActive(false);
            creditsMenu.SetActive(true);
            credits = true;
        }else if(credits == true)
        {
            startMenu.SetActive(true);
            creditsMenu.SetActive(false);
            credits = false;
        }
    }


}
