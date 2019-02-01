using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InterfaceManager : MonoBehaviour
{


    [SerializeField] private Color j_Color;
    [SerializeField] private Color k_Color;
    [SerializeField] private Color r_Color;

    [SerializeField] private Text nPCmessageText;
    [SerializeField] private Text headingText;

    [SerializeField] private Text[] j_History;
    [SerializeField] private Text[] k_History;
    [SerializeField] private Text[] r_History;

    public void J_Parameters()
    {
        nPCmessageText.color = j_Color;
        headingText.text = "J";

        foreach (Text jH in j_History)
        {
            jH.color = j_Color; 
        }
    }

    public void K_Parameters()
    {
        nPCmessageText.color = k_Color;
        headingText.text = "K";

        foreach (Text kH in k_History)
        {
            kH.color = k_Color;
        }
    }

    public void R_Parameters()
    {
        nPCmessageText.color = r_Color;
        headingText.text = "R";

        foreach (Text rH in r_History)
        {
            rH.color = r_Color;
        }
    }
}
