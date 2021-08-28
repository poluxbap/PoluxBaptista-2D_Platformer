using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public GameObject projectileBase;

    public Transform startPosition;
    public float timeBetweenShoot = .3f;
    public Transform playerSide;

    private Coroutine _currentCoroutine;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = startPosition.position;
        projectile.transform.localScale = playerSide.localScale;
    }
}
