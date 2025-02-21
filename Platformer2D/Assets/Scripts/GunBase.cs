using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ProjectileBase prefabProjectile;

    [SerializeField] private Transform positionToShoot;
    [SerializeField] private float timeBetweenShots = 0.3f;

    private Coroutine currentCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        }
    }

    private IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position =  positionToShoot.transform.position;

        if (player.transform.localScale.x > 0)
            projectile.SetDirection(true);
        else
            projectile.SetDirection(false);
    }
}
