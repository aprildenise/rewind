using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{

    public int sceneIndexToLoad;

    private PlayerController player;

    private void Start()
    {
        player = PlayerController.instance;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.hasKey) SceneManager.LoadScene(sceneIndexToLoad, LoadSceneMode.Single);
        }
    }

}
