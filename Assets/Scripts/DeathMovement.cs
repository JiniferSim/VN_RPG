using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public Animator animator;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            if (levelLoader != null)
            {
                levelLoader.LoadNextLevel();
            }
        }
    }
}
