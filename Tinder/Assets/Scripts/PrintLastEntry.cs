using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI; 

public class PrintLastEntry : MonoBehaviour
{
    [ConversationPopup]
    public string conversation;

    void Update()
    {
            string history = DialogueLua.GetVariable("DialogueEntryRecords_" + conversation).asString;
            string[] fields = history.Split(';');
            var numRecords = (fields.Length > 0) ? Tools.StringToInt(fields[0]) : 0;
            Debug.Log("Conversation has " + fields[0] + " records.");
            if (numRecords > 0)
            {
                int conversationID = Tools.StringToInt(fields[fields.Length - 3]);
                int entryID = Tools.StringToInt(fields[fields.Length - 2]);
                Debug.Log("Last record is [" + conversationID + ":" + entryID + "] -- " + history);
                DialogueEntry entry = DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
                if (entry != null)
                {
                this.GetComponent<Text>().text = entry.DialogueText;
                }
            }
    }
}
