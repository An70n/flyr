using UnityEngine;
using TMPro;

public class LastEntryPreview : MonoBehaviour
{
    public string conversation;

    void Update()
    {
            string history = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("DialogueEntryRecords_" + conversation).asString;
            string[] fields = history.Split(';');
            var numRecords = (fields.Length > 0) ? PixelCrushers.DialogueSystem.Tools.StringToInt(fields[0]) : 0;
            //Debug.Log( conversation + "has" + fields[0] + " records.");
            if (numRecords > 0)
            {
                int conversationID = PixelCrushers.DialogueSystem.Tools.StringToInt(fields[fields.Length - 3]);
                int entryID = PixelCrushers.DialogueSystem.Tools.StringToInt(fields[fields.Length - 2]);
                //Debug.Log("Last record is [" + conversationID + ":" + entryID + "] -- " + history);
                PixelCrushers.DialogueSystem.DialogueEntry entry = PixelCrushers.DialogueSystem.DialogueManager.masterDatabase.GetDialogueEntry(conversationID, entryID);
                if (entry != null)
                {
                    GetComponent<TextMeshProUGUI>().text = entry.DialogueText;
                }
            }
    }
}