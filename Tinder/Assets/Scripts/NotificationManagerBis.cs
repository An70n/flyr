using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NotificationManagerBis : MonoBehaviour
{
    public Text nPC;
    public Text message;
    public Text preview; 

    private void Update()
    {
        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("ConversationsDone").asInt == 3)
        {
            string mom_History = "7;4;19;4;20;4;21;4;22;4;23;4;24;4;1";
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_Mom", mom_History);
            preview.text = "How are you?";
            preview.fontStyle = FontStyle.Bold;
            nPC.text = "Mom";
            message.text = "How are you?";
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
