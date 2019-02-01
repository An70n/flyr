using UnityEngine;
using System.Collections;

namespace PixelCrushers.DialogueSystem.MenuSystem
{

    public class MenuUtility : MonoBehaviour
    {

        [Tooltip("Open this URL to rate the app.")]
        public string rateURL;

        public void RateThisApp()
        {
            Application.OpenURL(rateURL);
        }

        public void OpenPauseMenu()
        {
            FindObjectOfType<Pause>().pausePanel.Open();
        }

        public void StartConversation(string title)
        {
            var saveHelper = FindObjectOfType<SaveHelper>();
            saveHelper.QuickSave();
            DialogueManager.StopConversation();
            var dialogueUI = FindObjectOfType<TextlineDialogueUI>();
            if (dialogueUI != null) dialogueUI.ClearRecords();
            DialogueLua.SetVariable("Conversation", title);
            dialogueUI.SendMessage("OnApplyPersistentData");
            if (!DialogueManager.IsConversationActive) DialogueManager.StartConversation(title);
        }

        public void SaveAndReturnToTitleMenu()
        {
            StartCoroutine(ReturnToTitleWhenDoneSaving());
        }

        private IEnumerator ReturnToTitleWhenDoneSaving()
        {
            var saveHelper = FindObjectOfType<SaveHelper>();
            saveHelper.QuickSave();
            yield return null;
            yield return new WaitForEndOfFrame();
            DialogueManager.StopConversation();
            var dialogueUI = FindObjectOfType<TextlineDialogueUI>();
            if (dialogueUI != null) dialogueUI.ClearRecords();
            saveHelper.ReturnToTitleMenu();
        }

    }
}