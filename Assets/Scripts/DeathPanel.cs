using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    public Button retry;

    private void Awake()
    {
        retry.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
}
