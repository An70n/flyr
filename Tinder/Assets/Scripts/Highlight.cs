using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    //Text txt;
    Color baseColor;
    Button btn;
    SVGImage buttonSprite; 
    bool interactableDelay;

    void Start()
    {
        //txt = GetComponentInChildren<Text>();
        buttonSprite = gameObject.GetComponent<SVGImage>();
        baseColor = buttonSprite.color;
        btn = gameObject.GetComponent<Button>();
        interactableDelay = btn.interactable;
    }

    void Update()
    {
        if (btn.interactable != interactableDelay)
        {
            if (btn.interactable)
            {
                buttonSprite.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
            }
            else
            {
               buttonSprite.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
            }
        }
        interactableDelay = btn.interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            buttonSprite.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        }
        else
        {
            buttonSprite.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            buttonSprite.color = baseColor * btn.colors.pressedColor * btn.colors.colorMultiplier;
        }
        else
        {
            buttonSprite.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            buttonSprite.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        }
        else
        {
            buttonSprite.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            buttonSprite.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
        }
        else
        {
            buttonSprite.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

}

