using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    public void SetDirection(bool isRight)
    {
        if (isRight)
            speed *= 1;
        else
            speed *= -1;
    }
}
