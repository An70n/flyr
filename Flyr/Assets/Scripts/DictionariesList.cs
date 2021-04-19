using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionariesList : MonoBehaviour
{
    public static DictionariesList dictionariesList;

    public Dictionary<string, bool> whichScreenIsActive = new Dictionary<string, bool>();
    public Dictionary<string, int> charactersList = new Dictionary<string, int>();

    void Awake()
    {
        if (dictionariesList == null)
        {
            DontDestroyOnLoad(gameObject);
            dictionariesList = this;
        }
        else if (dictionariesList != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        whichScreenIsActive.Add("messagesScreen", false);
        whichScreenIsActive.Add("messagesConversation", false);
        whichScreenIsActive.Add("flyrScreen", false);
        whichScreenIsActive.Add("flyrConversation", false);
        whichScreenIsActive.Add("homeScreen", false);

        charactersList.Add("player", 0);
        charactersList.Add("J", 1);
        charactersList.Add("K", 2);
        charactersList.Add("R", 3);
        charactersList.Add("Mom", 4);
        charactersList.Add("Flyr", 5);
    }
}
