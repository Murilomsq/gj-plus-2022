using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;

    [SerializeField] private float speed = 50.0f;

    private float horizontalMove = 0.0f;
    private bool jump = false;
    private void Update()
    {
        if (!PlayerInteractions.Instance.IsControllable)
            return;
        
        horizontalMove = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
