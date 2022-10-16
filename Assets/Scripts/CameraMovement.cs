using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public void ShakeCamera()
    {
        LeanTween.value(gameObject, 5.0f, 4.7f, 0.05f).setOnUpdate((float val) =>
        {
            Camera.main.orthographicSize = val;
        }).setOnComplete(() =>
        {
            LeanTween.value(gameObject, 4.7f, 5.0f, 0.05f).setOnUpdate((float val) =>
            {
                Camera.main.orthographicSize = val;
            });
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ShakeCamera();
        }
    }
}
