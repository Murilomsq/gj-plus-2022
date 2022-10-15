using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image[] heartList;

    private void UpdateHeartUI()
    {
        int hp = PlayerInteractions.Instance.PlayerHP >= 0 ? PlayerInteractions.Instance.PlayerHP : 0;

        for (int i = heartList.Length - 1; i >= hp; i--)
        {
            heartList[i].enabled = false;
        }
    }

    private void Start()
    {
        PlayerInteractions.Instance.onHPChanged += UpdateHeartUI;
    }
}
