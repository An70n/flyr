using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameObjectsList : MonoBehaviour
{
    public static GameObjectsList gameObjectsList;

    public Button j_Button;
    public Button k_Button;
    public Button r_Button;
    public Button mom_Button;
    public Button flyr_Button; 

    public TextMeshProUGUI j_preview;
    public TextMeshProUGUI k_preview;
    public TextMeshProUGUI r_preview;
    public TextMeshProUGUI mom_preview;
    public TextMeshProUGUI flyr_preview; 
    public TextMeshProUGUI headingText;
    public TextMeshProUGUI notificationNpcName;
    public TextMeshProUGUI notificationText;

    public GameObject returnButton;
    public GameObject returnButtonCredits;
    public GameObject startScreen;
    public GameObject creditsScreen;
    public GameObject flyrScreen;
    public GameObject homeScreen;
    public GameObject messagesScreen;
    public GameObject heading_Bg_HomeScreen;
    public GameObject heading_Bg_Messages;
    public GameObject heading_Bg_Flyr;
    public GameObject creditsPage_1;
    public GameObject creditsPage_2;
    public GameObject nextCreditsPageButton;
    public GameObject previousCreditsPageButton;
    public GameObject endSceneCreditsPage_1;
    public GameObject endSceneCreditsPage_2;
    public GameObject endSceneNextCreditsPageButton;
    public GameObject endScenePreviousCreditsPageButton;

    void Awake()
    {
        if (gameObjectsList == null)
        {
            DontDestroyOnLoad(gameObject);
            gameObjectsList = this;
        }
        else if (gameObjectsList != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        j_Button = GameObject.Find("J_Button").GetComponent<Button>();
        k_Button = GameObject.Find("K_Button").GetComponent<Button>();
        r_Button = GameObject.Find("R_Button").GetComponent<Button>();
        mom_Button = GameObject.Find("MomButton").GetComponent<Button>();
        flyr_Button = GameObject.Find("FlyrButton").GetComponent<Button>();

        j_preview = j_Button.transform.Find("PreviewText").transform.Find("J_Preview").GetComponent<TextMeshProUGUI>();
        k_preview = k_Button.transform.Find("PreviewText").transform.Find("K_Preview").GetComponent<TextMeshProUGUI>();
        r_preview = r_Button.transform.Find("PreviewText").transform.Find("R_Preview").GetComponent<TextMeshProUGUI>();
        mom_preview = mom_Button.transform.Find("Mom_Preview").GetComponent<TextMeshProUGUI>();
        flyr_preview = flyr_Button.transform.Find("Flyr_Preview").GetComponent<TextMeshProUGUI>();

        headingText = GameObject.Find("Heading").GetComponent<TextMeshProUGUI>();

        notificationNpcName = GameObject.Find("NpcName").GetComponent<TextMeshProUGUI>();
        notificationText = GameObject.Find("NotificationText").GetComponent<TextMeshProUGUI>();

        returnButton = GameObject.Find("ReturnButton");
        returnButtonCredits = GameObject.Find("ReturnButtonCredits");

        startScreen = GameObject.Find("StartScreen");
        creditsScreen = GameObject.Find("CreditsScreen");
        homeScreen = GameObject.Find("HomeScreen");
        messagesScreen = GameObject.Find("MessagesScreen");
        flyrScreen = GameObject.Find("FlyrScreen");
        creditsScreen = GameObject.Find("CreditsScreen");

        heading_Bg_Flyr = GameObject.Find("Heading_Bg_Flyr");
        heading_Bg_HomeScreen = GameObject.Find("Heading_Bg_HomeScreen");
        heading_Bg_Messages = GameObject.Find("Heading_Bg_Messages");

        creditsPage_1 = creditsScreen.transform.Find("Wallpaper_1").gameObject;
        creditsPage_2 = creditsScreen.transform.Find("Wallpaper_2").gameObject;
        nextCreditsPageButton = creditsScreen.transform.Find("NextCreditsPage").gameObject;
        previousCreditsPageButton = creditsScreen.transform.Find("PreviousCreditsPage").gameObject;

        endSceneCreditsPage_1 = GameObject.Find("Panel_1");
        endSceneCreditsPage_2 = GameObject.Find("Panel_2");
        endSceneNextCreditsPageButton = GameObject.Find("EndSceneNextCreditsPage");
        endScenePreviousCreditsPageButton = GameObject.Find("EndScenePreviousCreditsPage");
    }
}
