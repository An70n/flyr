using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeColor : MonoBehaviour
{

    public Color flyrColor;
    public Color messagesColor;

    public Highlight firstResponseHighlight, secondResponseHighlight, thirdResponseHighlight; 

    public Image pcMessageBgd;
    public Unity.VectorGraphics.SVGImage firstChoice, secondChoice, thirdChoice; 

    public void ChangeToFlyrColor()
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
