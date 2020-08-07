using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public CanvasGroup gameOver;

    public bool gamePaused { get; private set; }

    private ClockController clock;

    public static GameManager instance { get; private set; }
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
        clock = ClockController.instance;
        HideGameOver();
    }

    public void HideGameOver()
    {
        gameOver.gameObject.SetActive(false);
        gamePaused = false;
        gameOver.alpha = 0;
        gameOver.interactable = false;
        gameOver.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        clock.HideClock();
        gamePaused = true;
        gameOver.alpha = 1;
        gameOver.interactable = true;
        gameOver.gameObject.SetActive(true) ;
    }

    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void ReloadCurrentScene()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
