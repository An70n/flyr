using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ConversationsHistory : MonoBehaviour
{

    [SerializeField] private GameObject[] j_History;
    [SerializeField] private GameObject[] k_History;
    [SerializeField] private GameObject[] r_History;

    private bool jHistory_activated = false;
    private bool kHistory_activated = false;
    private bool rHistory_activated = false;

    public void ShowJHistory()
    {
        if(jHistory_activated == false)
        {
            foreach(GameObject jH in j_History)
            {
                jH.SetActive(true);
                jHistory_activated = true; 
            }
        }

    }

    public void ShowKHistory()
    {
        if (kHistory_activated == false)
        {
            foreach (GameObject kH in k_History)
            {
                kH.SetActive(true);
                kHistory_activated = true;
            }
        }
    }

    public void ShowRHistory()
    {
        if (rHistory_activated == false)
        {
            foreach (GameObject rH in r_History)
            {
                rH.SetActive(true);
                rHistory_activated = true;
            }
        }
    }

    public void HideHistory()
    {
        if (jHistory_activated == true)
        {
            foreach (GameObject jH in j_History)
            {
                jH.SetActive(false);
                jHistory_activated = false; 
            }
        }

        if (kHistory_activated == true)
        {
            foreach (GameObject kH in k_History)
            {
                kH.SetActive(false);
                kHistory_activated = false;
            }
        }

        if (rHistory_activated == true)
        {
            foreach (GameObject rH in r_History)
            {
                rH.SetActive(false);
                rHistory_activated = false;
            }
        }
    }

}
