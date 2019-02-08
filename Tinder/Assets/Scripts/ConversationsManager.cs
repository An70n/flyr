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

    [SerializeField] private bool jHistory_activated = false;
    [SerializeField] private bool kHistory_activated = false;
    [SerializeField] private bool rHistory_activated = false;

    [SerializeField] private bool iphoneScreen = true;
    [SerializeField] private bool messageScreen = false;
    [SerializeField] private bool motherScreen = false;
    [SerializeField] private bool appScreen = false;
    [SerializeField] private bool appConversation = false;

    [SerializeField] private bool r_Conv_started = false;
    //private Animator notifAnim; 

    [SerializeField] private Text headingText;

    [SerializeField] private GameObject returnButton; 

    [SerializeField] private Transform player;
    [SerializeField] private Transform J;
    [SerializeField] private Transform K;
    [SerializeField] private Transform R;
    [SerializeField] private Transform mom;

    void Start()
    {
        //notifAnim = GameObject.Find("Smartphone").GetComponent<Animator>();
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

    }

    public void PreviousScreen()
    {
        if(messageScreen == true)
        {
            messageMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            messageScreen = false;
            iphoneScreen = true;
            returnButton.SetActive(false);
            appMenu.SetActive(false); //make sure the app menu is inactive when returning, as it was sometimes for some reason
        }

        if(appScreen == true)
        {
            appMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            appScreen = false;
            iphoneScreen = true;
            returnButton.SetActive(false);
        }

        if(appConversation == true)
        {
            appConversation = false;
            appScreen = true;
            appMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
        }

        if(motherScreen == true)
        {
            motherScreen = false;
            messageScreen = true;
            messageMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
        }

    }

    public void openMessages()
    {
        messageScreen = true;
        iphoneScreen = false;
        messageMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
    }

    public void openApp()
    {
        appScreen = true;
        iphoneScreen = false; 
        appMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
    }

    /*public void PlayNotification()
    {
        //notifAnim.SetTrigger("notifPlaying");
    }*/
}
