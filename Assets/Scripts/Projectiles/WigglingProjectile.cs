using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WigglingProjectile : Projectile
{
    [SerializeField] private float wiggleAmplitude = 5.0f;
    [SerializeField] private float wiggleFrequency = 5.0f;
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
            Transform t = transform;
            t.Translate(t.up * Time.deltaTime * speed, Space.World);
            t.Translate(t.right * Mathf.Cos(Time.time * wiggleFrequency)* Time.deltaTime* wiggleAmplitude, Space.World);
        }
        
        private void Start()
        {
            Destroy(gameObject, lifetime);
        }
         
}
