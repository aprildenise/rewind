using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{

    private CanvasGroup canvas;

    public bool isShowing { get; private set; }

    public static ClockController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
        canvas = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        HideClock();
    }

    public void ToggleClock()
    {
        if (isShowing) HideClock();
        else ShowClock();
    }

    public void HideClock()
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        isShowing = false;
    }


    public void ShowClock()
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        isShowing = true;
    }
}
