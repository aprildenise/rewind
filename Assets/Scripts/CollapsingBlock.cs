using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBlock : MonoBehaviour
{

    public float timeUntilCollapse;
    public float timeUntilDespawn;
    private float timer;
    private Rigidbody2D rb;
    private bool allowCountdown = false;

    private void Start()
    {
        timer = timeUntilCollapse;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            allowCountdown = true;
        }
    }

    private void Update()
    {
        if (!allowCountdown) return;

        // Countdown the fallout.
        timer -= Time.fixedUnscaledDeltaTime;
        if (timer <= 0)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 50f;
        }

        // Eventually, destroy this object.
        if (timer <= timeUntilDespawn * -1)
        {
            Destroy(this.gameObject);
            return;
        }
    }


}
