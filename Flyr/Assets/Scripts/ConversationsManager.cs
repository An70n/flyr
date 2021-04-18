using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem.Extras;
using TMPro;

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

    public TextMeshProUGUI r_preview;
    public TextMeshProUGUI j_preview;
    public TextMeshProUGUI k_preview;

    private int j_value = 9;
    private int r_value = 6;
    private int k_value = 3;
    private int multiplier = 1; 

    private int[] convValues;

    private GameObject appMenu;
    private GameObject iphoneMenu;
    private GameObject messageMenu;

    private Dictionary<string, bool> whichScreenIsActive = new Dictionary<string, bool>();
    private Dictionary<string, Transform> actorTransforms = new Dictionary<string, Transform>();

    private bool conv_J;
    private bool conv_R;
    private bool conv_K; 

    private TextMeshProUGUI headingText;
    private TextMeshProUGUI timeValue;
    private TextMeshProUGUI timeValue_2; 

    private string appName;
    private Unity.VectorGraphics.SVGImage headingColor; 

    private float timer = 600f;

    private GameObject returnButton;
    private GameObject time;
    private GameObject time_2; 

    private Transform player;
    private Transform J;
    private Transform K;
    private Transform R;
    private Transform mom;
    private Transform flyr;

    void Start()
    {
        transformOne = k_Button.GetComponent<RectTransform>().localPosition;
        transformTwo = j_Button.GetComponent<RectTransform>().localPosition;
        transformThree = r_Button.GetComponent<RectTransform>().localPosition;

        SortConversations();

        whichScreenIsActive.Add("messageScreen", false);
        whichScreenIsActive.Add("messageConversation", false);
        whichScreenIsActive.Add("appScreen", false);
        whichScreenIsActive.Add("appConversation", false);
        whichScreenIsActive.Add("iphoneScreen", false);

        actorTransforms.Add("player", player);
        actorTransforms.Add("J", J);
        actorTransforms.Add("K", K);
        actorTransforms.Add("R", R);
        actorTransforms.Add("Mom", mom);
        actorTransforms.Add("Flyr", flyr);

        appMenu = GameObject.Find("app Menu");
        appMenu.SetActive(false);

        iphoneMenu = GameObject.Find("iphone Menu");
        whichScreenIsActive["iphoneScreen"] = true;

        messageMenu = GameObject.Find("message Menu");
        messageMenu.SetActive(false);

        returnButton = GameObject.Find("Menu Button");
        returnButton.SetActive(false);

        player = transform.Find("Player");
        J = transform.Find("J");
        K = transform.Find("K");
        R = transform.Find("R");
        mom = transform.Find("mom");
        flyr = transform.Find("flyr");

        time = GameObject.Find("time");
        time_2 = GameObject.Find("time (1)");
        timeValue = time.GetComponent<TextMeshProUGUI>();
        timeValue_2 = time_2.GetComponent<TextMeshProUGUI>();
        timeValue.enabled = false;

        headingText = GameObject.Find("Heading Panel").transform.Find("heading").GetComponent<TextMeshProUGUI>();
        headingColor = GameObject.Find("Heading Panel").GetComponent<Unity.VectorGraphics.SVGImage>();
        appName = "Flyr";
    }

    private void Update()
    {
        timer += Time.deltaTime / 5; 
        
        if(whichScreenIsActive["iphoneScreen"] == true)
        {
            headingText.text = time.GetComponent<TextMeshProUGUI>().text;
            headingColor.color = iphoneMenuHeadingColor;
            returnButton.SetActive(false);
        }

        if(iphoneMenu.activeInHierarchy)
        {
            whichScreenIsActive["iphoneScreen"] = true; 
        }else if(!iphoneMenu.activeInHierarchy)
        {
            whichScreenIsActive["iphoneScreen"] = false;
        }
    }

    public void CloseScreen(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void SetAllScreensFalse()
    {
        whichScreenIsActive["messageScreen"] = false;
        whichScreenIsActive["messageConversation"] = false;
        whichScreenIsActive["appScreen"] = false;
        whichScreenIsActive["appConversation"] = false;
        whichScreenIsActive["iphoneScreen"] = false;
    }

    public void WhichScreenIsActive(string screen)
    {
        SetAllScreensFalse();
        whichScreenIsActive[screen] = true;
    }

    public void OpenDialogue(string conversation)
    {
        headingText.text = conversation;

        if (conversation == "J")
        {
            conv_J = true;
            j_preview.fontStyle = TMPro.FontStyles.Normal;
        }

        if (conversation == "K")
        {
            conv_K = true;
            k_preview.fontStyle = TMPro.FontStyles.Normal;
        }

        if (conversation == "R")
        {
            conv_R = true;
            r_preview.fontStyle = TMPro.FontStyles.Normal;
        }
        

        if (PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry(conversation))

        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation(conversation, player, actorTransforms[conversation]);
        }
        else if (!PixelCrushers.DialogueSystem.DialogueManager.ConversationHasValidEntry(conversation))
        {
            PixelCrushers.DialogueSystem.DialogueManager.dialogueUI.Open();

        }
    }

    public void ResumeConversation(string conversation)
    {
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Conversation", conversation);
        FindObjectOfType<TextlineDialogueUI>().OnApplyPersistentData();
    }


    private void CloseDialogue()
    {
        FindObjectOfType<TextlineDialogueUI>().OnRecordPersistentData();
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
        if (whichScreenIsActive["messageScreen"] == true)
        {
            messageMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            whichScreenIsActive["messageScreen"] = false;
            returnButton.SetActive(false);
            appMenu.SetActive(false);
            whichScreenIsActive["iphoneScreen"] = true;
            timeValue.enabled = false;
        }

        if (whichScreenIsActive["messageConversation"] == true)
        {
            whichScreenIsActive["messageConversation"] = false;
            whichScreenIsActive["messageScreen"] = true;
            messageMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
            headingText.text = "Messages";
        }

        if (whichScreenIsActive["appScreen"] == true)
        {
            appMenu.SetActive(false);
            iphoneMenu.SetActive(true);
            whichScreenIsActive["appScreen"] = false;
            returnButton.SetActive(false);
            whichScreenIsActive["iphoneScreen"] = true;
            timeValue.enabled = false;
        }

        if (whichScreenIsActive["appConversation"] == true)
        {
            whichScreenIsActive["appConversation"] = false;
            whichScreenIsActive["appScreen"] = true;
            appMenu.SetActive(true);
            CloseDialogue();
            iphoneMenu.SetActive(false);
            headingText.text = appName;
        }
    }

    public void OpenMessages()
    {
        whichScreenIsActive["messageScreen"] = true;
        messageMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = "Messages";
        timeValue.enabled = true;
        whichScreenIsActive["iphoneScreen"] = false;
        headingColor.color = messageMenuHeadingColor;
    }

    public void OpenApp()
    {
        whichScreenIsActive["appScreen"] = true;
        appMenu.SetActive(true);
        iphoneMenu.SetActive(false);
        returnButton.SetActive(true);
        headingText.text = appName;
        timeValue.enabled = true;
        whichScreenIsActive["iphoneScreen"] = false;
        headingColor.color = appMenuHeadingColor; 
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeValue.text = niceTime;
        timeValue_2.text = niceTime; 
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
