using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationsManager : MonoBehaviour
{
    [SerializeField] private GameObject appMenu;

    [SerializeField] private GameObject[] j_History;
    [SerializeField] private GameObject[] k_History;
    [SerializeField] private GameObject[] r_History;

    private bool jHistory_activated = false;
    private bool kHistory_activated = false;
    private bool rHistory_activated = false;

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
