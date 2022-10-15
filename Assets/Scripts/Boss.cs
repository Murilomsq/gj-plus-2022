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
    public void ShootBulletAtPlayer(string type)
    {
        Debug.Log("here");
        Vector3 dir = transform.position - PlayerInteractions.Instance.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90.0f;
        Instantiate(bulletStringToPrefabTable[type], transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
    }
    
}
