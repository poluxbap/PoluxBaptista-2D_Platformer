using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public PoolManager poolManager;

    public Transform startPosition;
    public float timeBetweenShoot = .3f;
    public Transform playerSide;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();    
    }

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
        var projectile = poolManager.GetPooledObject();

        if(projectile != null)
        {
            projectile.SetActive(true);
            projectile.GetComponent<ProjectileBase>().StartProjectile();
            projectile.transform.position = startPosition.position;
            projectile.transform.localScale = playerSide.localScale;
        }
    }
}
