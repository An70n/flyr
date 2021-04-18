using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationsHistory : MonoBehaviour
{
    void Start()
    {
        string k_History = "2;2;41;2;42";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_K", k_History);

        string j_History = "3;1;46;1;47;1;3";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_J", j_History);

        string r_History = "2;3;46;3;47";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_R", r_History);

        string mom_History = "6;4;19;4;20;4;21;4;22;4;23;4;24";
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_Mom", mom_History);
    }

}
