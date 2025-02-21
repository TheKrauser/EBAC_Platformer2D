using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private HealthBase healthBase;

    [SerializeField] private float speed;
    [SerializeField] private float speedRun;
    [SerializeField] private float jumpForce;

    private float scaleX;

    [SerializeField] private Vector2 friction;

    private float currentSpeed;

    private bool isRunning = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBase = GetComponent<HealthBase>();

        scaleX = transform.localScale.x;
    }

    private void Update()
    {
        if (healthBase.IsDead)
        {
            anim.SetBool("isDead", healthBase.IsDead);
            rb.velocity = Vector2.zero;
            return;
        }

        HandleJump();
        HandleMovement();
        HandleAnimations();
    }

    private void HandleMovement()
    {
        isRunning = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(!isRunning ? -speed : -speedRun, rb.velocity.y);
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(!isRunning ? speed : speedRun, rb.velocity.y);
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }

        if (rb.velocity.x > 0)
        {
            rb.velocity += friction;
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("Jump");
        }
    }

    private void HandleAnimations()
    {
        if (isRunning)
            anim.speed = 2;
        else
            anim.speed = 1;

        anim.SetFloat("X", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Y", rb.velocity.y);
    }
}
