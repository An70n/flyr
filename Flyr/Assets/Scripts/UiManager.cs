using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    private TimeManager timeManager;

    private TextMeshProUGUI headingText;

    private GameObject returnButton;
    private GameObject returnButtonCredits;

    private GameObject flyrScreen;
    private GameObject homeScreen;
    private GameObject messagesScreen;

    private GameObject heading_Bg_HomeScreen;
    private GameObject heading_Bg_Messages;
    private GameObject heading_Bg_Flyr;

    private GameObject creditsScreen;

    void Start()
    {
        timeManager = gameObject.GetComponent<TimeManager>();

        creditsScreen = GameObjectsList.gameObjectsList.creditsScreen;
        creditsScreen.SetActive(false);

        homeScreen = GameObjectsList.gameObjectsList.homeScreen;
        homeScreen.SetActive(false);
        messagesScreen = GameObjectsList.gameObjectsList.messagesScreen;
        messagesScreen.SetActive(false);
        flyrScreen = GameObjectsList.gameObjectsList.flyrScreen;
        flyrScreen.SetActive(false);

        headingText = GameObjectsList.gameObjectsList.headingText;

        heading_Bg_HomeScreen = GameObjectsList.gameObjectsList.heading_Bg_HomeScreen;
        heading_Bg_HomeScreen.SetActive(false);
        heading_Bg_Messages = GameObjectsList.gameObjectsList.heading_Bg_Messages;
        heading_Bg_Messages.SetActive(false);
        heading_Bg_Flyr = GameObjectsList.gameObjectsList.heading_Bg_Flyr;
        heading_Bg_Flyr.SetActive(false);

        returnButton = GameObjectsList.gameObjectsList.returnButton;
        GameObjectsList.gameObjectsList.returnButton.SetActive(false);
        returnButtonCredits = GameObjectsList.gameObjectsList.returnButtonCredits;
        GameObjectsList.gameObjectsList.returnButtonCredits.SetActive(false);
    }

    public void PreviousScreen()
    {
        if (messagesScreen.activeInHierarchy)
        {
            OpenHomeScreen();
        }

        if (flyrScreen.activeInHierarchy)
        {
            OpenHomeScreen();
        }

        
    }

    public void OpenHomeScreen()
    {
        homeScreen.SetActive(true);
        messagesScreen.SetActive(false);
        flyrScreen.SetActive(false);
        timeManager.timeValue.enabled = false;
        headingText.text = timeManager.timeValue.text;
        heading_Bg_Flyr.SetActive(false);
        heading_Bg_Messages.SetActive(false);
        returnButton.SetActive(false);
    }

    public void OpenMessages()
    {
        messagesScreen.SetActive(true);
        homeScreen.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = "Messages";
        timeManager.timeValue.enabled = true;
        heading_Bg_Messages.SetActive(true);
    }

    public void OpenFlyr()
    {
        flyrScreen.SetActive(true);
        homeScreen.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = "Flyr";
        timeManager.timeValue.enabled = true;
        heading_Bg_Flyr.SetActive(true);
    }
}