using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] Animator menuPanel;
    [SerializeField] Animator Display;
    [SerializeField] Cronometro cron;

    bool showHide = false;

    void Update()
    {
        if(cron.TimeDirection < 0)
        {
            Display.SetBool("timeOver", true);
        } 
        else 
        {
            Display.SetBool("timeOver", false);
        }
    }

    public void ShowHideMenu()
    {
        showHide = !showHide;
        menuPanel.SetBool("showHide", showHide);
    }
}
