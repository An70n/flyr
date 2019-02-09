using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ConversationsManager : MonoBehaviour
{
    private Color iphoneMenuHeadingColor = new Color(0, 0, 0, 0);
    public Color messageMenuHeadingColor;
    public Color appMenuHeadingColor;

    [SerializeField] private GameObject appMenu;
    [SerializeField] private GameObject iphoneMenu;
    [SerializeField] private GameObject messageMenu;

    [SerializeField] private GameObject[] j_History;
    [SerializeField] private GameObject[] k_History;
    [SerializeField] private GameObject[] r_History; 

    private bool jHistory_activated = false;
    private bool kHistory_activated = false;
    private bool rHistory_activated = false;

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

    public GameObject returnButton;
    public GameObject time; 

    private Transform player;
    private Transform J;
    private Transform K;
    private Transform R;
    private Transform mom;

    void Start()
    {
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

    }

    private void Update()
    {
        timer += Time.deltaTime / 5; 

        if(iphoneScreen == true)
        {
            headingText.text = time.GetComponent<Text>().text;
            headingColor.color = iphoneMenuHeadingColor; 
        }

        //LastEntry();
    }

    public void OpenDialogueR()
    {
        appConversation = true;
        appScreen = false; 
        headingText.text = "R";

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
       
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("R", player, R);
            appMenu.SetActive(false);

            if (rHistory_activated == false)
            {foreach (GameObject rH in r_History)
                {rH.SetActive(true);
                    rHistory_activated = true;}}
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);

            if (rHistory_activated == false)
            {foreach (GameObject rH in r_History)
                {rH.SetActive(true);
                    rHistory_activated = true;}}
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

            if (jHistory_activated == false)
            {foreach (GameObject jH in j_History)
                {jH.SetActive(true);
                    jHistory_activated = true;}}

        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("J"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);

            if (jHistory_activated == false)
            {foreach (GameObject jH in j_History)
                {jH.SetActive(true);
                    jHistory_activated = true;}}

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

            if (kHistory_activated == false)
            {foreach (GameObject kH in k_History)
                {kH.SetActive(true);
                    kHistory_activated = true;}}

        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("K"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);

            if (kHistory_activated == false)
            {foreach (GameObject kH in k_History)
                {kH.SetActive(true);
                    kHistory_activated = true;}}
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

        if (jHistory_activated == true)
            {foreach (GameObject jH in j_History)
                {jH.SetActive(false);
                    jHistory_activated = false;}}

            if (kHistory_activated == true)
            {foreach (GameObject kH in k_History)
                {kH.SetActive(false);
                    kHistory_activated = false;}}

            if (rHistory_activated == true)
            {foreach (GameObject rH in r_History)
                {rH.SetActive(false);
                    rHistory_activated = false;}}//}

        //LastEntry();

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
            //time.SetActive(false);
            timeValue.enabled = false;
        }

        if(appScreen == true)
        {
            appMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            appScreen = false;
            returnButton.SetActive(false);
            iphoneScreen = true;
            //time.SetActive(false);
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

    public void openMessages()
    {
        messageScreen = true;
        messageMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = "Messages";
        //time.SetActive(true);
        timeValue.enabled = true;
        iphoneScreen = false;
        headingColor.color = messageMenuHeadingColor;
    }

    public void openApp()
    {
        appScreen = true;
        appMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = appName;
        //time.SetActive(true);
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

    public void LastEntry()
    {
        string history = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("DialogueEntryRecords_K").asString;
        string[] fields = history.Split(';');
        int conversationID = PixelCrushers.DialogueSystem.Tools.StringToInt(fields[fields.Length - 2]);
        int entryID = PixelCrushers.DialogueSystem.Tools.StringToInt(fields[fields.Length - 1]);
        PixelCrushers.DialogueSystem.DialogueEntry entry = PixelCrushers.DialogueSystem.DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
        Debug.Log("Last entry is: " + entry.id);
    }
}
