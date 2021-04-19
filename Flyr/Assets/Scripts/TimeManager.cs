using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeValue;
    private TextMeshProUGUI timeValue_2;

    public GameObject time;
    private GameObject time_2;

    private float timer = 600f;

    void Start()
    {
        time = GameObject.Find("Time");
        time_2 = GameObject.Find("Time_1");
        timeValue = time.GetComponent<TextMeshProUGUI>();
        timeValue_2 = time_2.GetComponent<TextMeshProUGUI>();
        timeValue.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime / 5;
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeValue.text = niceTime;
        timeValue_2.text = niceTime;
    }
}
