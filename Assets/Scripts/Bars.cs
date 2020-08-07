using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{

    private BoxCollider2D box;
    private PlayerController player;

    private void Awake()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = PlayerController.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.states.currentState.GetComponent<PassThroughBars>() != null)
        {
            box.isTrigger = true;
        }
        else
        {
            box.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.states.currentState.GetComponent<PassThroughBars>() != null)
        {
            box.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.states.currentState.GetComponent<PassThroughBars>() != null)
        {
            box.isTrigger = false;
        }
    }

}
