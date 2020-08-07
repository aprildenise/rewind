using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    public Transform feetPos;
    public bool allowInfiniteJump = false;
    public float jumpTime;
    public float jumpForce;
    public float checkRadius;
    public LayerMask ground;

    private bool isJumping;
    private bool isGrounded;
    private float jumpTimeCounter;

    private GameManager game;
    private ClockController clock;


    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.instance;
        clock = ClockController.instance;
        if (allowInfiniteJump) isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (game.gamePaused || clock.isShowing) return;

        if (!allowInfiniteJump)
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Debug.Log("Jump!");
            rb.velocity = Vector3.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = new Vector3(feetPos.position.x, feetPos.position.y, 0);
        Gizmos.DrawWireSphere(pos, checkRadius);
    }
}
