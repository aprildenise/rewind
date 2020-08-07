using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private PlayerController player;

    private void Start()
    {
        player = PlayerController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.hasKey = true;
            Destroy(this.gameObject);
        }
    }
}
