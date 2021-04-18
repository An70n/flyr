using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem.Extras;

public class ConversationEnd : TextlineDialogueUI
{
    public override void Close()
    {
        OnRecordPersistentData();
        base.Close();
        Debug.Log("conversation end");
    }
}
