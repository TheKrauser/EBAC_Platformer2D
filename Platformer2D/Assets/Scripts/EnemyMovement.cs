using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : EnemyBase
{
    [SerializeField] private float speed;
    [SerializeField] private float maxHorizontalMovement;

    private Vector3 initialPosition;
    private bool isGoingRight = true;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (isGoingRight)
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        else
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x >= initialPosition.x + maxHorizontalMovement && isGoingRight)
        {
            isGoingRight = false;
            Flip();
        }
        else if (transform.position.x <= initialPosition.x - maxHorizontalMovement && !isGoingRight)
        {
            isGoingRight = true;
            Flip();
        }
    }

    private void Flip()
    {
        if (transform.eulerAngles.y == 180)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 180, transform.localEulerAngles.z);
            return;
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 180, transform.localEulerAngles.z);
    }
}
