using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NotificationManagerBis : MonoBehaviour
{
    public Text nPC;
    public Text message;

    private void Update()
    {
        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("ConversationsDone").asInt == 3)
        {
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
