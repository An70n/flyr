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

    [SerializeField] private GameObject[] j_History;
    [SerializeField] private GameObject[] k_History;
    [SerializeField] private GameObject[] r_History;

    [SerializeField] private Text[] j_History_lines;
    [SerializeField] private Text[] k_History_lines;
    [SerializeField] private Text[] r_History_lines;

    private bool jHistory_activated = false;
    private bool kHistory_activated = false;
    private bool rHistory_activated = false;

    [SerializeField] private Text nPCmessageText;
    [SerializeField] private Text headingText;




    public void OpenDialogueR()
    {
        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
       
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("R");
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

        nPCmessageText.color = r_Color;
        headingText.text = "R";

        foreach (Text rH in r_History_lines)
        {
            rH.color = r_Color;
        }
    }

    public void OpenDialogueJ()
    {
        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("J"))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("J");
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

        nPCmessageText.color = j_Color;
        headingText.text = "J";

        foreach (Text jH in j_History_lines)
        {
            jH.color = j_Color;
        }
    }

    public void OpenDialogueK()
    {
        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("K"))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("K");
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

        nPCmessageText.color = k_Color;
        headingText.text = "K";

        foreach (Text kH in k_History_lines)
        {
            kH.color = k_Color;
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

    public void CloseDialogue()
    {
        PixelCrushers.DialogueSystem.DialogueManager.StopConversation();
        PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Close();
        appMenu.SetActive(true);

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
}
