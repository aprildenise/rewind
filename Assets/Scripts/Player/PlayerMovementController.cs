﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    /// <summary>
    /// Rigidbody of the PARENT object.
    /// </summary>
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem dust;
    public float moveSpeed;

    private bool isMoving;
    private float moveVelocity;
    private ClockController clock;
    private JournalController journal;
    private SpriteRenderer sprite;
    private GameManager game;
    private Animator anim;


    private void Start()
    {
        clock = ClockController.instance;
        journal = JournalController.instance;
        game = GameManager.instance;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (game.gamePaused) return;

        // Check for clock input.
        if (Input.GetKeyDown(KeyCode.C))
        {
            clock.ToggleClock();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            journal.ToggleJournal();
            return;
        }
        else
        {
            // Get axis input for movement.
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            isMoving = moveInput != Vector3.zero;
            moveVelocity = moveInput.x * moveSpeed;

            if (isMoving) dust.Play();
        }
    }

    private void FixedUpdate()
    {
        if (game.gamePaused)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Apply movement.
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);

        // Apply animation.
        anim.SetBool("isMoving", isMoving);
        if (rb.velocity.x < 0) sprite.flipX = true;
        if (rb.velocity.x > 0) sprite.flipX = false;
    }
}
