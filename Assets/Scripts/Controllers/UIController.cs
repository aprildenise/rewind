using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Image[] clockMarkings;
    public int markingsLeft;
    public readonly int totalMarkings = 3;

    private GameManager game;
    
    public static UIController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
        markingsLeft = totalMarkings;
    }

    private void Start()
    {
        game = GameManager.instance;
    }

    public void RemoveMarking()
    {
        if (markingsLeft <= 0)
        {
            game.ShowGameOver();
            return;
        }
        clockMarkings[markingsLeft - 1].gameObject.SetActive(false);
        markingsLeft--;
    }

    public void ResetMarkings()
    {
        markingsLeft = totalMarkings;
        foreach (Image image in clockMarkings)
        {
            image.gameObject.SetActive(true);
        }
    }
}
