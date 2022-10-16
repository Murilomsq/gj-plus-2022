using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button easy;
    [SerializeField] private Button credits;
    [SerializeField] private Button quit;

    private void Quit() => Application.Quit();
    private void Easy() => SceneManager.LoadScene("SampleSceneEasy");
    private void Play() => SceneManager.LoadScene("SampleScene 1");

    private void Credits()
    {
        
    }

    private void Awake()
    {
        play.onClick.AddListener(Play);
        easy.onClick.AddListener(Easy);
        quit.onClick.AddListener(Quit);
        credits.onClick.AddListener(Credits);
    }
}
