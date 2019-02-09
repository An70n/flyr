using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ConversationsManager : MonoBehaviour
{

    [SerializeField] private Color j_Color;
    [SerializeField] private Color k_Color;
    [SerializeField] private Color r_Color;

    [SerializeField] private GameObject appMenu;
    [SerializeField] private GameObject iphoneMenu;
    [SerializeField] private GameObject messageMenu;

    [SerializeField] private GameObject[] j_History;
    [SerializeField] private GameObject[] k_History;
    [SerializeField] private GameObject[] r_History;

    [SerializeField] private Text[] j_History_lines;
    [SerializeField] private Text[] k_History_lines;
    [SerializeField] private Text[] r_History_lines;

    private bool jHistory_activated = false;
    private bool kHistory_activated = false;
    private bool rHistory_activated = false;

    //private bool iphoneScreen = true;
    private bool messageScreen = false;
    private bool motherScreen = false;
    private bool appScreen = false;
    private bool appConversation = false;

    private Text headingText;
    private string baseHeadingText;
    private string appName;  
    public GameObject returnButton; 

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
        headingText = GameObject.Find("Heading Panel").GetComponentInChildren<Text>();
        baseHeadingText = headingText.text;
        appName = "nom de l'app";
    }

    public void OpenDialogueR()
    {
        appConversation = true;
        appScreen = false; 
        headingText.text = "R";

        foreach (Text rH in r_History_lines)
        {
            rH.color = r_Color;
        }

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
       
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("R", player, R);
            appMenu.SetActive(false);

            if (rHistory_activated == false)
            {foreach (GameObject rH in r_History)
                {rH.SetActive(true);
                    rHistory_activated = true;}}

            foreach (Text rH in r_History_lines)
            {
                rH.color = r_Color;
            }
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);

            if (rHistory_activated == false)
            {foreach (GameObject rH in r_History)
                {rH.SetActive(true);
                    rHistory_activated = true;}}

            foreach (Text rH in r_History_lines)
            {
                rH.color = r_Color;
            }
        }
    }

    public void OpenDialogueJ()
    {
        appConversation = true;
        appScreen = false;
        headingText.text = "J";

        foreach (Text jH in j_History_lines)
        {
            jH.color = j_Color;
        }

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

        foreach (Text kH in k_History_lines)
        {
            kH.color = k_Color;
        }

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
                    rHistory_activated = false;}}

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
            headingText.text = baseHeadingText;
        }

        if(appScreen == true)
        {
            appMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            appScreen = false;
            returnButton.SetActive(false);
            headingText.text = baseHeadingText;
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
    }

    public void openApp()
    {
        appScreen = true; 
        appMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = appName;
    }
}
