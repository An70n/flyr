using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ConversationsManager : MonoBehaviour
{
    private Color iphoneMenuHeadingColor = new Color(0, 0, 0, 0);
    public Color messageMenuHeadingColor;
    public Color appMenuHeadingColor;

    private Vector3 transformeOne;
    private Vector3 transformTwo;
    private Vector3 transformThree;

    public Button r_Button;
    public Button j_Button;
    public Button k_Button;

    private int max; 

    private int j_value = 1;
    private int r_value = 1;
    private int k_value = 1;

    private List<int> convValues; 

    private GameObject appMenu;
    private GameObject iphoneMenu;
    private GameObject messageMenu;

    private bool messageScreen = false;
    private bool motherScreen = false;
    private bool appScreen = false;
    private bool appConversation = false;
    private bool iphoneScreen = false;

    private Text headingText;
    private Text timeValue; 

    private string appName;
    private SVGImage headingColor; 

    private float timer = 600f;

    private GameObject returnButton;
    private GameObject time;

    private Transform player;
    private Transform J;
    private Transform K;
    private Transform R;
    private Transform mom;

    void Start()
    {
        appMenu = GameObject.Find("app Menu");
        appMenu.SetActive(false);
        iphoneMenu = GameObject.Find("iphone Menu");
        messageMenu = GameObject.Find("message Menu");
        messageMenu.SetActive(false);
        returnButton = GameObject.Find("Menu Button");
        returnButton.SetActive(false);

        player = this.transform.Find("Player");
        J = this.transform.Find("J");
        K = this.transform.Find("K");
        R = this.transform.Find("R");
        mom = this.transform.Find("mom");

        time = GameObject.Find("time");
        timeValue = time.GetComponent<Text>();
        timeValue.enabled = false;
        iphoneScreen = true;

        headingText = GameObject.Find("Heading Panel").transform.Find("heading").GetComponent<Text>();
        headingColor = GameObject.Find("Heading Panel").GetComponent<SVGImage>();
        appName = "nom de l'app";

        string k_History = "2;2;41;2;42";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_K", k_History);

        string j_History = "2;1;46;1;47";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_J", j_History);

        string r_History = "2;3;46;3;47";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_R", r_History);

        transformeOne = k_Button.GetComponent<RectTransform>().localPosition;
        transformTwo = j_Button.GetComponent<RectTransform>().localPosition;
        transformThree = r_Button.GetComponent<RectTransform>().localPosition;

        //convValues.Add(j_value);
        //convValues.Add(r_value);
        //convValues.Add(k_value);

        convValues = new List<int>() { j_value, r_value, k_value };
    }

    private void Update()
    {
        timer += Time.deltaTime / 5; 

        if(iphoneScreen == true)
        {
            headingText.text = time.GetComponent<Text>().text;
            headingColor.color = iphoneMenuHeadingColor;
            returnButton.SetActive(false);
        }

        GetMax();
        //Debug.Log(max);
        

        /*if (r_value > j_value && r_value > k_value)
        {
            r_Button.GetComponent<RectTransform>().localPosition = transformeOne;
        }*/
    }

    int GetMax()
    {
        convValues.Sort();
        max = convValues[convValues.Count - 1];
        return max; 
    }

    public void OpenDialogueR()
    {
        appConversation = true;
        appScreen = false; 
        headingText.text = "R";

        convValues[r_value] += 2;

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
       
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("R", player, R);
            appMenu.SetActive(false);
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void OpenDialogueJ()
    {
        appConversation = true;
        appScreen = false;
        headingText.text = "J";

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("J"))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("J", player, J);
            appMenu.SetActive(false);

        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("J"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void OpenDialogueK()
    {
        appConversation = true;
        appScreen = false;
        headingText.text = "K";

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("K"))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("K", player, K);
            appMenu.SetActive(false);

        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("K"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void OpenDialogueMom()
    {
        messageMenu.SetActive(false);
        motherScreen = true;
        messageScreen = false;
        headingText.text = "Mom"; 

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("Mom"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Mom", player, mom);
            appMenu.SetActive(false);
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("Mom"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void ResumeConversationJ()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "J");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    public void ResumeConversationK()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "K");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    public void ResumeConversationR()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "R");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    private void CloseDialogue()
    {
        PixelCrushers.DialogueSystem.DialogueManager.StopConversation();
        PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Close();
    }

    public void PreviousScreen()
    {
        if(messageScreen == true)
        {
            messageMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            messageScreen = false;
            returnButton.SetActive(false);
            appMenu.SetActive(false);
            iphoneScreen = true;
            timeValue.enabled = false;
        }

        if(appScreen == true)
        {
            appMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            appScreen = false;
            returnButton.SetActive(false);
            iphoneScreen = true;
            timeValue.enabled = false;
        }

        if(appConversation == true)
        {
            appConversation = false;
            appScreen = true;
            appMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
            headingText.text = appName; 

        }

        if(motherScreen == true)
        {
            motherScreen = false;
            messageScreen = true;
            messageMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
            headingText.text = "Messages";
        }

    }

    public void OpenMessages()
    {
        messageScreen = true;
        messageMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = "Messages";
        timeValue.enabled = true;
        iphoneScreen = false;
        headingColor.color = messageMenuHeadingColor;
    }

    public void OpenApp()
    {
        appScreen = true;
        appMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = appName;
        timeValue.enabled = true;
        iphoneScreen = false;
        headingColor.color = appMenuHeadingColor; 
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeValue.text = niceTime;
    }
}
