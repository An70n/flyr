﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ConversationsManager : MonoBehaviour
{
    private Color iphoneMenuHeadingColor = new Color(0, 0, 0, 0);
    public Color messageMenuHeadingColor;
    public Color appMenuHeadingColor;

    private Vector3 transformOne;
    private Vector3 transformTwo;
    private Vector3 transformThree;

    public Button r_Button;
    public Button j_Button;
    public Button k_Button;

    public Text r_preview;
    public Text j_preview;
    public Text k_preview;

    private int j_value = 9;
    private int r_value = 6;
    private int k_value = 3;
    private int multiplier = 1; 

    private int[] convValues;

    private GameObject appMenu;
    private GameObject iphoneMenu;
    private GameObject messageMenu;

    private bool messageScreen = false;
    private bool motherScreen = false;
    private bool appScreen = false;
    private bool appConversation = false;
    private bool iphoneScreen = false;

    private bool conv_J;
    private bool conv_R;
    private bool conv_K; 

    private Text headingText;
    private Text timeValue; 

    private string appName;
    private SVGImage headingColor; 

    private float timer = 600f;

    private GameObject returnButton;
    private GameObject time;

    private Transform player;
    private Transform J;
    private Transform K;
    private Transform R;
    private Transform mom;

    void Start()
    {
        transformOne = k_Button.GetComponent<RectTransform>().localPosition;
        transformTwo = j_Button.GetComponent<RectTransform>().localPosition;
        transformThree = r_Button.GetComponent<RectTransform>().localPosition;

        SortConversations();

        appMenu = GameObject.Find("app Menu");
        appMenu.SetActive(false);

        iphoneMenu = GameObject.Find("iphone Menu");
        iphoneScreen = true;

        messageMenu = GameObject.Find("message Menu");
        messageMenu.SetActive(false);

        returnButton = GameObject.Find("Menu Button");
        returnButton.SetActive(false);

        player = this.transform.Find("Player");
        J = this.transform.Find("J");
        K = this.transform.Find("K");
        R = this.transform.Find("R");
        mom = this.transform.Find("mom");

        time = GameObject.Find("time");
        timeValue = time.GetComponent<Text>();
        timeValue.enabled = false;

        headingText = GameObject.Find("Heading Panel").transform.Find("heading").GetComponent<Text>();
        headingColor = GameObject.Find("Heading Panel").GetComponent<SVGImage>();
        appName = "nom de l'app";


    }

    private void Update()
    {
        timer += Time.deltaTime / 5; 

        if(iphoneScreen == true)
        {
            headingText.text = time.GetComponent<Text>().text;
            headingColor.color = iphoneMenuHeadingColor;
            returnButton.SetActive(false);
        }
    }

    public void OpenDialogueR()
    {
        appConversation = true;
        appScreen = false; 
        headingText.text = "R";
        conv_R = true; 

        r_preview.fontStyle = FontStyle.Normal; 

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
       
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("R", player, R);
            appMenu.SetActive(false);
        }
        else if(!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("R"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void OpenDialogueJ()
    {
        appConversation = true;
        appScreen = false;
        headingText.text = "J";
        conv_J = true; 

        j_preview.fontStyle = FontStyle.Normal;

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("J"))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("J", player, J);
            appMenu.SetActive(false);

        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("J"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void OpenDialogueK()
    {
        appConversation = true;
        appScreen = false;
        headingText.text = "K";
        conv_K = true; 

        k_preview.fontStyle = FontStyle.Normal;

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("K"))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("K", player, K);
            appMenu.SetActive(false);

        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("K"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void OpenDialogueMom()
    {
        messageMenu.SetActive(false);
        motherScreen = true;
        messageScreen = false;
        headingText.text = "Mom"; 

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("Mom"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Mom", player, mom);
            appMenu.SetActive(false);
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry("Mom"))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();
            appMenu.SetActive(false);
        }
    }

    public void ResumeConversationJ()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "J");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    public void ResumeConversationK()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "K");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    public void ResumeConversationR()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "R");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    public void ResumeConversationMom()
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", "Mom");
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }

    private void CloseDialogue()
    {
        PixelCrushers.DialogueSystem.DialogueManager.StopConversation();
        PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Close();

        //checks if conversation has been opened and if player has responded 
        //if that's the case, the value of the conversation is increased 
        //conversations has sorted by decreasing value
        //resets all bools to false
        if (conv_J == true && PixelCrushers.DialogueSystem.DialogueLua.GetVariable("hasResponded").asBool == true)
        {
            multiplier = multiplier * 3;
            j_value += multiplier;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("hasResponded", false);
            if(PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rConversationStart").asBool == true)
            {
                multiplier = multiplier * 3;
                r_value += multiplier;
            }
        }

        if (conv_R == true && PixelCrushers.DialogueSystem.DialogueLua.GetVariable("hasResponded").asBool == true)
        {
            multiplier = multiplier * 3;
            r_value += multiplier;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("hasResponded", false);
        }

        if (conv_K == true && PixelCrushers.DialogueSystem.DialogueLua.GetVariable("hasResponded").asBool == true)
        {
            multiplier = multiplier * 3;
            k_value += multiplier;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("hasResponded", false);
        }


        conv_J = false;
        conv_K = false;
        conv_R = false;

        SortConversations();

        //divides the values to make sure they don't get too big
        if(r_value > 3000 || j_value > 3000 || k_value > 3000)
        {
            r_value /= 100;
            j_value /= 100;
            k_value /= 100; 
        }
    }

    public void PreviousScreen()
    {
        if(messageScreen == true)
        {
            messageMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            messageScreen = false;
            returnButton.SetActive(false);
            appMenu.SetActive(false);
            iphoneScreen = true;
            timeValue.enabled = false;
        }

        if(appScreen == true)
        {
            appMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            appScreen = false;
            returnButton.SetActive(false);
            iphoneScreen = true;
            timeValue.enabled = false;
        }

        if(appConversation == true)
        {
            appConversation = false;
            appScreen = true;
            appMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
            headingText.text = appName; 

        }

        if(motherScreen == true)
        {
            motherScreen = false;
            messageScreen = true;
            messageMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
            headingText.text = "Messages";
        }

    }

    public void OpenMessages()
    {
        messageScreen = true;
        messageMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = "Messages";
        timeValue.enabled = true;
        iphoneScreen = false;
        headingColor.color = messageMenuHeadingColor;
    }

    public void OpenApp()
    {
        appScreen = true;
        appMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = appName;
        timeValue.enabled = true;
        iphoneScreen = false;
        headingColor.color = appMenuHeadingColor; 
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeValue.text = niceTime;
    }

    public void SortConversations()
    {

        if(r_value > j_value && r_value > k_value)
        {
            r_Button.GetComponent<RectTransform>().localPosition = transformOne; 
        }

        else if (r_value > j_value && r_value < k_value)
        {
            r_Button.GetComponent<RectTransform>().localPosition = transformTwo;
        }

        else if (r_value > k_value && r_value < j_value)
        {
            r_Button.GetComponent<RectTransform>().localPosition = transformTwo;
        }

        else if (r_value < j_value && r_value < k_value)
        {
            r_Button.GetComponent<RectTransform>().localPosition = transformThree;
        }


        if (j_value > r_value && j_value > k_value)
        {
            j_Button.GetComponent<RectTransform>().localPosition = transformOne;
        }

        if(j_value > r_value && j_value < k_value)
        {
            j_Button.GetComponent<RectTransform>().localPosition = transformTwo;
        }

        if (j_value > k_value && j_value < r_value)
        {
            j_Button.GetComponent<RectTransform>().localPosition = transformTwo;
        }

        else if (j_value < r_value && j_value < k_value)
        {
            j_Button.GetComponent<RectTransform>().localPosition = transformThree;
        }


        if (k_value > r_value && k_value > j_value)
        {
            k_Button.GetComponent<RectTransform>().localPosition = transformOne;
        }

        if (k_value > r_value && k_value < j_value)
        {
            k_Button.GetComponent<RectTransform>().localPosition = transformTwo;
        }

        if (k_value > j_value && k_value < r_value)
        {
            k_Button.GetComponent<RectTransform>().localPosition = transformTwo;
        }

        else if (k_value < r_value && k_value < j_value)
        {
            k_Button.GetComponent<RectTransform>().localPosition = transformThree;
        }
    }
}
