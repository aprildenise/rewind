using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public CanvasGroup gameOver;
    public GameObject[] vfx;
    public Animator sceneTransition;

    public bool gamePaused { get; private set; }

    private ClockController clock;
    private JournalController journal;

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
        journal = JournalController.instance;
        HideGameOver();
    }

    public bool HasScreenShowing()
    {
        return clock.isShowing || journal.isShowing || gamePaused;
    }

    public void HideGameOver()
    {
        if (gameOver == null) return;
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

    private IEnumerator LoadLevelWithTransition(int scene)
    {
        sceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadLevel(int scene)
    {
        StartCoroutine(LoadLevelWithTransition(scene));
    }


    public void ReloadCurrentScene()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void InitPrefab(Vector3 position, int prefab)
    {
        GameObject effect = vfx[prefab];
        Instantiate(effect, position, effect.transform.rotation, transform);
    }
}
