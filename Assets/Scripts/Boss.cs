using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Wiggle,
    Simple
}
public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject wiggleBullet;
    [SerializeField] private GameObject simpleBullet;

    [SerializeField] private GameObject fiveSimpleBullets;
    [SerializeField] private GameObject fiveRealSimpleBullets;
    
    private Dictionary<BulletType, GameObject> bulletToPrefabTable;
    private Dictionary<string, GameObject> bulletStringToPrefabTable;
    private void Awake()
    {
        bulletToPrefabTable = new Dictionary<BulletType, GameObject>()
        {
            {BulletType.Wiggle, wiggleBullet},
            {BulletType.Simple, simpleBullet}
        };
        bulletStringToPrefabTable = new Dictionary<string, GameObject>()
        {
            {"Wiggle", wiggleBullet},
            {"Simple", simpleBullet}
        };
    }
    
    public void ShootBullet(BulletType type, float angle)
    {
        Instantiate(bulletToPrefabTable[type], transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
    }
    public void ShootBullet(string type, float angle)
    {
        Instantiate(bulletStringToPrefabTable[type], transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
    }

    public void ShootBulletAtPlayer(BulletType type)
    {
        Vector3 dir = transform.position - PlayerInteractions.Instance.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90.0f;
        Instantiate(bulletToPrefabTable[type], transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
    }
    public void ShootBulletAtPlayerAtSpeed(float speed)
    {
        Vector3 dir = transform.position - PlayerInteractions.Instance.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90.0f;
        var obj = Instantiate(bulletToPrefabTable[BulletType.Simple], transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
        obj.GetComponent<Projectile>().speed = speed;
    }
    public void ShootBulletAtPlayer(string type)
    {
        Debug.Log("here");
        Vector3 dir = transform.position - PlayerInteractions.Instance.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90.0f;
        Instantiate(bulletStringToPrefabTable[type], transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
    }

    public void ShootFiveSimpleBullets()
    {
        Instantiate(fiveSimpleBullets, transform.position, Quaternion.identity);
    }

    public void FiveBulletRain(bool direction)
    {
        StopAllCoroutines();
        StartCoroutine(FiveBulletRainCoroutine(direction));
    }
    private IEnumerator FiveBulletRainCoroutine(bool direction)
    {
        float duration = 3.0f;
        int numberOfShots = 20;
        int angularIncrement = 3;

        int startVal = direction ? -angularIncrement * numberOfShots / 2 : angularIncrement * numberOfShots / 2;

        for (int i = 0, val = startVal ; i < numberOfShots; i++)
        {
            if (direction)
            {
                val += angularIncrement;
            }
            else
            {
                val -= angularIncrement;
            }
            Instantiate(fiveRealSimpleBullets, transform.position, Quaternion.Euler(0.0f, 0.0f, val));
            yield return new WaitForSeconds(duration / numberOfShots);
        }
    }
    
}
