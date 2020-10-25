using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public HUDManager hudManager;

    [SerializeField] TextMeshProUGUI minutesInput;
    [SerializeField] TextMeshProUGUI secondsInput;
    [SerializeField] TextMeshProUGUI minutesDisplay;
    [SerializeField] TextMeshProUGUI secondsDisplay;

    [SerializeField] float initialMinutes = 60, initialSeconds = 0.49f;

    [SerializeField] float minutes, seconds;

    [SerializeField] bool enabled, resetCounter;
    [SerializeField] float tempMinutes, tempSeconds;

    bool appliedTimeOver = false;
    int timeDirection = 1;

    public float Minutes { get { return minutes; } }
    public float Seconds { get { return seconds; } }
    public int TimeDirection { get { return timeDirection; } }

    void Awake()
    {
        minutes = initialMinutes;
        seconds = initialSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
            seconds -= Time.deltaTime * timeDirection;

        CalcDigits();

        minutesDisplay.text = string.Format("{0:00}", minutes);
        secondsDisplay.text = string.Format("{0:00}", seconds);

        if(resetCounter)
        {
            ResetCounter();
            resetCounter = false;
        }
    }

    void CalcDigits()
    {
        if(seconds < -0.49f) {
            seconds = 59.49f;

            if(minutes == 0 && !appliedTimeOver)
            {
                appliedTimeOver = true;
                timeDirection = -1;
            } 

            minutes --;
        }

        if(seconds > 59.49f) {
            seconds = -0.49f;
            minutes ++;
        }
    }

    public void ResetCounter() 
    {
        minutes = initialMinutes;
        seconds = initialSeconds;
        appliedTimeOver = false;
        timeDirection = 1;
    }

    public void PauseCounter()
    {
        enabled = false;
    }

    public void PlayCounter()
    {
        enabled = true;
        hudManager.ShowHideMenu();
    }

    public void SetCounter() 
    {
        minutes = tempMinutes;
        seconds = tempSeconds + 0.49f;
        appliedTimeOver = false;
        timeDirection = 1;
    }

    public void SetTempMinutes(string _minutes)
    {
        if(_minutes == "") return;
        tempMinutes = float.Parse(_minutes);
    }

    public void SetTempSeconds(string _seconds)
    {
        if(_seconds == "") return;
        tempSeconds = float.Parse(_seconds);
    }
}
