using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    [SerializeField] private Queue<Vector3> playerPositionSamples;
    [SerializeField] private int numberOfSamples = 30;

    private void Awake()
    {
        playerPositionSamples = new Queue<Vector3>();
    }
    

    private void FixedUpdate()
    {
        playerPositionSamples.Enqueue(PlayerInteractions.Instance.transform.position);
        if (playerPositionSamples.Count >= numberOfSamples)
        {
            transform.position = playerPositionSamples.Peek();
            playerPositionSamples.Dequeue();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
