using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 speed;

    public float timeToDestroy = 2f;

    public int damageAmount = 1;

    public void StartProjectile()
    {
        Invoke(nameof(FinishUsage), timeToDestroy);
    }

    private void FinishUsage()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(speed * transform.localScale.x * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.Damage(damageAmount);
            gameObject.SetActive(false);
        }
    }
}
