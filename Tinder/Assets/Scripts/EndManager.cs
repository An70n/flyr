using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public bool skipToEnd;
    public bool skipMom; 

    private Camera cam1;
    private Camera cam2;

    private GameObject player;
    private GameObject smartphone; 


    //private Animator playerAnim;
    private Animator camAnim;
    private Animator endCharAnim; 



    void Start()
    {
        cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam2 = GameObject.Find("EndCam").GetComponent<Camera>();
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        cam2.enabled = false;

        player = GameObject.FindWithTag("Player");
        //playerAnim = player.GetComponent<Animator>();

        smartphone = GameObject.Find("Smartphone");
        endCharAnim = GameObject.Find("EndPerso").GetComponent<Animator>();
 
    }


    void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("endOfGame").asBool == true)
        {
            StartCoroutine(EndingScene());
        }

        if (skipToEnd == true)
        {
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("ConversationsDone", 3);
        }

        if(skipMom == true)
        {
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("endOfGame", true);
        }
    }

    private IEnumerator EndingScene ()
    {
        camAnim.SetTrigger("goingUp");

        smartphone.SetActive(false);

        yield return new WaitForSeconds(5f);


        cam1.enabled = false; 
        cam2.enabled = true;
        yield return new WaitForSeconds(5f);

        endCharAnim.SetTrigger("endChar"); 
    }
}
