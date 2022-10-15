using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private static PlayerInteractions _instance;
    public static PlayerInteractions Instance => _instance;

    #region UI

    

    #endregion

    private int _playerHP = 3;
    private bool _isControllable = true;

    public Action onHPChanged;
    public int PlayerHP
    {
        get => _playerHP;
        set
        {
            _playerHP = value;
            onHPChanged?.Invoke();
        }
    }

    public bool IsControllable
    {
        get => _isControllable;
        set => _isControllable = value;
    }

    private void TakeDamage()
    {
        if (_playerHP <= 0)
            GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }

    private void Awake()
    {
        _instance = this;
        onHPChanged += TakeDamage;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
