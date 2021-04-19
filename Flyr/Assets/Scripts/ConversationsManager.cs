using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem.Extras;

public class ConversationsManager : MonoBehaviour
{
    private int j_value = 9;
    private int r_value = 6;
    private int k_value = 3;
    private int multiplier = 1; 

    private bool conv_J;
    private bool conv_R;
    private bool conv_K;

    public bool activeDialogue;
    public bool flyrDialogue;
    public bool messagesDialogue; 

    void Start()
    {
        //SortConversations();
    }

    public void OpenDialogue(string conversation)
    {
        GameObjectsList.gameObjectsList.headingText.text = conversation;
        activeDialogue = true;

        if(conversation == "J" || conversation == "K" || conversation == "R")
        {
            flyrDialogue = true;

            if (conversation == "J")
            {
                conv_J = true;
                GameObjectsList.gameObjectsList.j_preview.fontStyle = TMPro.FontStyles.Normal;
            }

            if (conversation == "K")
            {
                conv_K = true;
                GameObjectsList.gameObjectsList.k_preview.fontStyle = TMPro.FontStyles.Normal;
            }

            if (conversation == "R")
            {
                conv_R = true;
                GameObjectsList.gameObjectsList.r_preview.fontStyle = TMPro.FontStyles.Normal;
            }
        }

        if(conversation == "Mom" || conversation == "Flyr")
        {
            messagesDialogue = true; 
        }
        
        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry(conversation))
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation(conversation, Characters.charactersTransforms[0], Characters.charactersTransforms[DictionariesList.dictionariesList.charactersList[conversation]]);
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry(conversation))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
        }

        activeDialogue = true;
        ResumeConversation(conversation);
    }

    public void ResumeConversation(string conversation)
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", conversation);
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    public void CloseDialogue()
    {
        FindObjectOfType<TextlineDialogueUI>().OnRecordPersistentData();
        PixelCrushers.DialogueSystem.DialogueManager.StopConversation();
        PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Close();

        //checks if conversation has been opened and if player has responded 
        //if that's the case, the value of the conversation is increased 
        //conversations has sorted by decreasing value
        //resets all bools to false
        if (conv_J == true && PixelCrushers.DialogueSystem.DialogueLua.GetVariable("hasResponded").asBool == true)
        {
            multiplier = multiplier * 3;
            j_value += multiplier;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("hasResponded", false);
            if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rConversationStart").asBool == true)
            {
                multiplier = multiplier * 3;
                r_value += multiplier;
            }
        }

        if (conv_R == true && PixelCrushers.DialogueSystem.DialogueLua.GetVariable("hasResponded").asBool == true)
        {
            multiplier = multiplier * 3;
            r_value += multiplier;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("hasResponded", false);
        }

        if (conv_K == true && PixelCrushers.DialogueSystem.DialogueLua.GetVariable("hasResponded").asBool == true)
        {
            multiplier = multiplier * 3;
            k_value += multiplier;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("hasResponded", false);
        }

        conv_J = false;
        conv_K = false;
        conv_R = false;

        activeDialogue = false; 

        //SortConversations();

        if(r_value > 3000 || j_value > 3000 || k_value > 3000)
        {
            r_value /= 100;
            j_value /= 100;
            k_value /= 100; 
        }
    }

    public void SortConversations()
    {

        if(r_value > j_value && r_value > k_value)
        {
            GameObjectsList.gameObjectsList.r_Button.transform.SetSiblingIndex(0);
        }

        else if (r_value > j_value && r_value < k_value)
        {
            GameObjectsList.gameObjectsList.r_Button.transform.SetSiblingIndex(1);
        }

        else if (r_value > k_value && r_value < j_value)
        {
            GameObjectsList.gameObjectsList.r_Button.transform.SetSiblingIndex(1);
        }

        else if (r_value < j_value && r_value < k_value)
        {
            GameObjectsList.gameObjectsList.r_Button.transform.SetSiblingIndex(2);
        }

        if (j_value > r_value && j_value > k_value)
        {
            GameObjectsList.gameObjectsList.j_Button.transform.SetSiblingIndex(0);
        }

        if(j_value > r_value && j_value < k_value)
        {
            GameObjectsList.gameObjectsList.j_Button.transform.SetSiblingIndex(1);
        }

        if (j_value > k_value && j_value < r_value)
        {
            GameObjectsList.gameObjectsList.j_Button.transform.SetSiblingIndex(1);
        }

        else if (j_value < r_value && j_value < k_value)
        {
            GameObjectsList.gameObjectsList.j_Button.transform.SetSiblingIndex(2);
        }

        if (k_value > r_value && k_value > j_value)
        {
            GameObjectsList.gameObjectsList.k_Button.transform.SetSiblingIndex(0);
        }

        if (k_value > r_value && k_value < j_value)
        {
            GameObjectsList.gameObjectsList.k_Button.transform.SetSiblingIndex(1);
        }

        if (k_value > j_value && k_value < r_value)
        {
            GameObjectsList.gameObjectsList.k_Button.transform.SetSiblingIndex(1);
        }

        else if (k_value < r_value && k_value < j_value)
        {
            GameObjectsList.gameObjectsList.k_Button.transform.SetSiblingIndex(1);
        }
    }
}
