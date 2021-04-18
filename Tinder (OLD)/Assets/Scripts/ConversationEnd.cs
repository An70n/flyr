using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationEnd : TextlineDialogueUI
{
    public override void Close()
    {
        OnRecordPersistentData();
        base.Close();
        Debug.Log("conversation end");
    }
}
