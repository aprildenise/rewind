using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieByFire : MonoBehaviour
{

    private GameManager game;

    private void Start()
    {
        game = GameManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Fire>() != null)
        {
            gameObject.SetActive(false);
            game.ShowGameOver();
        }
    }
}
