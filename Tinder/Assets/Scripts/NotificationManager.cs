using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NotificationManager : MonoBehaviour
{
    public Text nPC;
    public Text message;
    public Text preview; 

    private void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rConversationStart").asBool == true)
        {
            string r_History = "3;3;46;3;47;3;3";
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_R", r_History);
            preview.text = "Are you ok?";
            preview.fontStyle = FontStyle.Bold;
            nPC.text = "R";
            message.text = "Are you ok?";
            StartCoroutine(Notification());
        }
    }

    private void PlayNotification()
    {
        this.gameObject.GetComponentInChildren<Animator>().SetTrigger("notifPlaying");
 
    }

    private IEnumerator Notification()
    {
        PlayNotification();
        this.enabled = false;
        yield return null; 
    }
}
