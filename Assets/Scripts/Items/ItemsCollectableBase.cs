using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public AudioSource audioSource;

    private void Awake()
    {
        if(particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        Destroy(gameObject);
    }

    protected virtual void OnCollect()
    {
        if(audioSource != null) audioSource.Play();
        if (particleSystem != null) particleSystem.Play();
    }
}
