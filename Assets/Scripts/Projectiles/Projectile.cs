using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damageValue;
    [SerializeField] protected float direction;
    [SerializeField] protected float lifetime;

    public void DamagePlayer()
    {
        Debug.Log(damageValue);
        PlayerInteractions.Instance.PlayerHP -= damageValue;
    }

    public void SetInitalRotation()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, direction);
        transform.rotation *= rotation;
    }
}
