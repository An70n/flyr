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

    public TextMeshProUGUI j_preview;
    public TextMeshProUGUI k_preview;
    public TextMeshProUGUI r_preview;

    public TextMeshProUGUI headingText;

    public GameObject returnButton;
    public GameObject returnButtonCredits;

    public GameObject flyrScreen;
    public GameObject homeScreen;
    public GameObject messagesScreen;

    public GameObject heading_Bg_HomeScreen;
    public GameObject heading_Bg_Messages;
    public GameObject heading_Bg_Flyr;

    public GameObject startScreen;
    public GameObject creditsScreen;

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

    // Start is called before the first frame update
    void Start()
    {
        j_Button = GameObject.Find("J_Button").GetComponent<Button>();
        k_Button = GameObject.Find("K_Button").GetComponent<Button>();
        r_Button = GameObject.Find("R_Button").GetComponent<Button>();

        j_preview = j_Button.transform.Find("PreviewText").transform.Find("J_Preview").GetComponent<TextMeshProUGUI>();
        k_preview = k_Button.transform.Find("PreviewText").transform.Find("K_Preview").GetComponent<TextMeshProUGUI>();
        r_preview = r_Button.transform.Find("PreviewText").transform.Find("R_Preview").GetComponent<TextMeshProUGUI>();

        returnButton = GameObject.Find("ReturnButton");
        returnButtonCredits = GameObject.Find("ReturnButtonCredits");

        headingText = GameObject.Find("Heading").GetComponent<TextMeshProUGUI>();

        heading_Bg_Flyr = GameObject.Find("Heading_Bg_Flyr");
        heading_Bg_HomeScreen = GameObject.Find("Heading_Bg_HomeScreen");
        heading_Bg_Messages = GameObject.Find("Heading_Bg_Messages");

        startScreen = GameObject.Find("StartScreen");
        creditsScreen = GameObject.Find("CreditsScreen");
        homeScreen = GameObject.Find("HomeScreen");
        messagesScreen = GameObject.Find("MessagesScreen");
        flyrScreen = GameObject.Find("FlyrScreen");
    }
}
