using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rConversationStart").asBool == true)
        {
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
        yield return new WaitForSeconds(1f);
        this.enabled = false; 
    }
}
