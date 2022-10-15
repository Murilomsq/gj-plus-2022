using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : Projectile
{
    [SerializeField] private float wiggleAmplitude = 5.0f;
    [SerializeField] private float wiggleFrequency = 5.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
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
        Transform t = transform;
        //t.Translate(t.up * Time.deltaTime * speed, Space.World);
        float x = Mathf.Cos(Time.time * wiggleFrequency) * wiggleAmplitude;
        float y = Mathf.Sin(Time.time * wiggleFrequency) * wiggleAmplitude;
        Debug.Log(new Vector3(x, y));
        
        transform.position += new Vector3(x, y);

    }
    
        
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
