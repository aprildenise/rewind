using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{

    private CanvasGroup canvas;

    public bool isShowing { get; private set; }

    public static JournalController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        HideJournal();
    }

    public void ToggleJournal()
    {
        if (isShowing) HideJournal();
        else ShowJournal();
    }

    public void HideJournal()
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;

        isShowing = false;
    }

    public void ShowJournal()
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
        isShowing = true;
    }



}
