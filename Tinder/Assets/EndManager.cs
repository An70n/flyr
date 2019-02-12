using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    private Camera cam1;
    private Camera cam2;
    public bool skipToEnd; 
    // Start is called before the first frame update
    void Start()
    {
        cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam2 = GameObject.Find("EndCam").GetComponent<Camera>();

        cam2.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("endOfGame").asBool == true)
        {
            //do something
            cam2.enabled = true;
            cam1.enabled = false; 
        }

        if(skipToEnd == true)
        {
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("ConversationsDone", 3);
        }
    }
}
