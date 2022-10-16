using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShooter : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private float rate = 1.0f;

    private float cooldown = 0.0f;

    void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= rate)
        {
            cooldown = 0.0f;
            Instantiate(bullet, transform.position, transform.rotation);
        }
        
    }
}
