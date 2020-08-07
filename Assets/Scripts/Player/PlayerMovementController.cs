using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    /// <summary>
    /// Rigidbody of the PARENT object.
    /// </summary>
    [SerializeField] private Rigidbody2D rb;
    public float moveSpeed;

    private bool isMoving;
    private float moveVelocity;
    private ClockController clock;
    private GameManager game;


    private void Start()
    {
        clock = ClockController.instance;
        game = GameManager.instance;
    }


    private void Update()
    {
        if (game.gamePaused) return;

        // Check for clock input.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            clock.ToggleClock();
        }

        // Get axis input for movement.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        isMoving = moveInput != Vector3.zero;
        moveVelocity = moveInput.x * moveSpeed;

    }

    private void FixedUpdate()
    {
        if (game.gamePaused) return;

        if (clock.isShowing) return; // Restrict movement if the clock is up.

        // Apply movement.
        //if (isMoving) rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }
}
