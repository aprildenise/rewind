using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    /// <summary>
    /// Rigidbody of the PARENT object.
    /// </summary>
    [SerializeField] private Rigidbody rb;
    public float moveSpeed;

    private bool isMoving;
    private Vector3 moveVelocity;
    private ClockController clock;

    private void Start()
    {
        clock = ClockController.instance;
    }


    private void Update()
    {
        // Get axis input for movement.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = moveInput != Vector3.zero;
        moveVelocity = moveInput.normalized * moveSpeed;


    }

    private void FixedUpdate()
    {

        // Check for clock input.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            clock.ToggleClock();
        }

        if (clock.isShowing) return; // Restrict movement if the clock is up.

        // Apply movement.
        if (isMoving) rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
