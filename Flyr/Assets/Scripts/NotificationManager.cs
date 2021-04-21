using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("notificationAlertR").asBool == true)
        {
            string r_History = "3;3;46;3;47;3;3";
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_R", r_History);

            GameObjectsList.gameObjectsList.notificationNpcName.text = "R";
            GameObjectsList.gameObjectsList.notificationText.text = "Are you ok?";
            GameObjectsList.gameObjectsList.r_preview.text = "Are you ok?";
            GameObjectsList.gameObjectsList.r_preview.fontStyle = TMPro.FontStyles.Bold;

            PlayNotification();
            AudioManager.audioManager.ReducePitch("PianoMusic", -1f, 20f);
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("notificationAlertR", false); 
        }

        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("notificationAlertMom").asInt == 3)
        {
            string mom_History = "7;4;19;4;20;4;21;4;22;4;23;4;24;4;1";
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("DialogueEntryRecords_Mom", mom_History);

            GameObjectsList.gameObjectsList.notificationNpcName.text = "Mom";
            GameObjectsList.gameObjectsList.notificationText.text = "How are you?";
            GameObjectsList.gameObjectsList.mom_preview.text = "How are you?";
            GameObjectsList.gameObjectsList.mom_preview.fontStyle = TMPro.FontStyles.Bold;

            PlayNotification();
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("notificationAlertMom", 0);
        }
    }

    private void PlayNotification()
    {
        gameObject.GetComponentInChildren<Animator>().SetTrigger("play_notification");
        AudioManager.audioManager.Play("BuzzSound");
        AudioManager.audioManager.Play("NotificationSound");
    }
}
