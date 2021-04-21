using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    private ConversationsManager conversationsManager;
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
    private GameObject creditsPage_2;

    void Start()
    {
        conversationsManager = transform.parent.transform.Find("ConversationsManager").GetComponent<ConversationsManager>();
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

        creditsPage_2 = GameObjectsList.gameObjectsList.creditsPage_2;
        creditsPage_2.SetActive(false);
        GameObjectsList.gameObjectsList.previousCreditsPageButton.SetActive(false);

        GameObjectsList.gameObjectsList.endSceneCreditsPage_2.SetActive(false);
        GameObjectsList.gameObjectsList.endScenePreviousCreditsPageButton.SetActive(false);
    }

    public void PreviousScreen()
    {
        if(conversationsManager.activeDialogue == false)
        {
            if (messagesScreen.activeInHierarchy)
            {
                OpenHomeScreen();
            }

            if (flyrScreen.activeInHierarchy)
            {
                OpenHomeScreen();
            }

            if(creditsScreen.activeInHierarchy)
            {
                CloseCreditsScreen();
            }
        }

        else if(conversationsManager.activeDialogue == true)
        {
            conversationsManager.CloseDialogue();

            if(conversationsManager.messagesDialogue == true)
            {
                OpenMessages();
                conversationsManager.messagesDialogue = false;
            }

            else if(conversationsManager.flyrDialogue == true)
            {
                OpenFlyr();
                conversationsManager.flyrDialogue = false; 
            }
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

    public void OpenConversation()
    {
        messagesScreen.SetActive(false);
        flyrScreen.SetActive(false);
    }

    public void OpenCreditsScreen()
    {
        creditsScreen.SetActive(true);
        GameObjectsList.gameObjectsList.startScreen.SetActive(false);
        headingText.text = "Credits";
        returnButton.SetActive(true);
    }

    public void CloseCreditsScreen()
    {
        creditsScreen.SetActive(false);
        GameObjectsList.gameObjectsList.startScreen.SetActive(true);
    }

    public void NextCreditsPage()
    {
        creditsPage_2.SetActive(true);
        GameObjectsList.gameObjectsList.previousCreditsPageButton.SetActive(true);
        GameObjectsList.gameObjectsList.nextCreditsPageButton.SetActive(false);
    }

    public void PreviousCreditsPage()
    {
        creditsPage_2.SetActive(false);
        GameObjectsList.gameObjectsList.previousCreditsPageButton.SetActive(false);
        GameObjectsList.gameObjectsList.nextCreditsPageButton.SetActive(true);
    }

    public void NextCreditsPageEndScene()
    {
        GameObjectsList.gameObjectsList.endSceneCreditsPage_2.SetActive(true);
        GameObjectsList.gameObjectsList.endScenePreviousCreditsPageButton.SetActive(true);
        GameObjectsList.gameObjectsList.endSceneNextCreditsPageButton.SetActive(false);
    }

    public void PreviousCreditsPageEndScene()
    {
        GameObjectsList.gameObjectsList.endSceneCreditsPage_2.SetActive(false);
        GameObjectsList.gameObjectsList.endScenePreviousCreditsPageButton.SetActive(false);
        GameObjectsList.gameObjectsList.endSceneNextCreditsPageButton.SetActive(true);
    }
}