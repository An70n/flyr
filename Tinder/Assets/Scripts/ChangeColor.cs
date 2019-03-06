using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeColor : MonoBehaviour
{

    public Color flyrColor;
    public Color messagesColor;

    public GameObject appMenu;
    public GameObject messagesMenu;

    public Highlight firstResponseHighlight, secondResponseHighlight, thirdResponseHighlight; 

    public Image pcMessageBgd;
    public SVGImage firstChoice, secondChoice, thirdChoice; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(appMenu.activeInHierarchy)
        {
            pcMessageBgd.color = flyrColor;
        }else if(messagesMenu.activeInHierarchy)
        {
            pcMessageBgd.color = messagesColor;
        }*/
    }

    public void ChangeToAppColor()
    {
        pcMessageBgd.color = flyrColor;
        firstChoice.color = flyrColor;
        secondChoice.color = flyrColor;
        thirdChoice.color = flyrColor;
        firstResponseHighlight.baseColor = flyrColor;
        secondResponseHighlight.baseColor = flyrColor;
        thirdResponseHighlight.baseColor = flyrColor;
    }

    public void ChangeToMessagesColor()
    {
        pcMessageBgd.color = messagesColor;
        firstChoice.color = messagesColor;
        secondChoice.color = messagesColor;
        thirdChoice.color = messagesColor;
        firstResponseHighlight.baseColor = messagesColor;
        secondResponseHighlight.baseColor = messagesColor;
        thirdResponseHighlight.baseColor = messagesColor;
    }
}
