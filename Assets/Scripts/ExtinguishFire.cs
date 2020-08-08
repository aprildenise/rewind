using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour
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
            game.InitPrefab(transform.position, 3);
            Destroy(collision.gameObject);
        }
    }

}
