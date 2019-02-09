using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NotificationManager : MonoBehaviour
{
    public Text nPC;
    public Text message; 

    private void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rConversationStart").asBool == true)
        {
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
