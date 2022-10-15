using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : Projectile
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Here");
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            DamagePlayer();
        }

        if (other.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
    }
    
    private void Start()
    {
        Destroy(gameObject, lifetime);
        SetInitalRotation();
    }
    
}
