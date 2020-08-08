using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    public float interactionRadius;
    public LayerMask allowInteractions;

    private PlayerController player;
    private GameManager game;

    private void Start()
    {
        game = GameManager.instance;
        player = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, interactionRadius, allowInteractions))
        {
            Destroyer destroyer = player.states.currentState.gameObject.GetComponent<Destroyer>();
            if (destroyer != null)
            {
                if (game.gamePaused) return;

                if (Input.GetKey(KeyCode.Space))
                {
                    destroyer.Hit();
                    game.InitPrefab(transform.position, 2);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
