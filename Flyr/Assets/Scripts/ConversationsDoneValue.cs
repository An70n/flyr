using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class ConversationsDoneValue : MonoBehaviour
{

    private string conversationsDone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        conversationsDone = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("ConversationsDone").luaValue.ToString();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 100), "conversations done: " + conversationsDone);
    }

}
