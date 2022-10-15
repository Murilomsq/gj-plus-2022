using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private Image blackScreenImage;
    
    
    // Making this to couple isTweening to player.IsControllable, that way
    // isControllable = false when isTweening = true
    private bool _isTweening;
    public bool IsTweening
    {
        get => _isTweening;
        set
        {
            _isTweening = value;
            PlayerInteractions.Instance.IsControllable = !value;
        } 
            
    }

    private void Start()
    {
        FadeOut(3.0f);
    }

    public void FadeIn(float time)
    {
        if (IsTweening) return;

        IsTweening = true;
        LeanTween.value(gameObject, 0.0f, 1.0f, time).setOnUpdate((float val) =>
        {
            Color c = blackScreenImage.color;
            c.a = val;
            blackScreenImage.color = c;
        }).setOnComplete(() =>
        {
            IsTweening = false;
        });
    }
    public void FadeOut(float time)
    {
        if (IsTweening) return;
        
        IsTweening = true;
        LeanTween.value(gameObject, 1.0f, 0.0f, time).setOnUpdate((float val) =>
        {
            Color c = blackScreenImage.color;
            c.a = val;
            blackScreenImage.color = c;
        }).setOnComplete(() =>
        {
            IsTweening = false;
        });
    }

    public void FadeInOut(float totalTime, Action a)
    {
        if (IsTweening) return;
        
        IsTweening = true;
        LeanTween.value(gameObject, 0.0f, 1.0f, totalTime / 2).setOnUpdate((float val) =>
        {
            Color c = blackScreenImage.color;
            c.a = val;
            blackScreenImage.color = c;
        }).setOnComplete(() =>
        {
            a.Invoke();
            LeanTween.value(gameObject, 1.0f, 0.0f, totalTime / 2).setOnUpdate((float val) =>
            {
                Color c = blackScreenImage.color;
                c.a = val;
                blackScreenImage.color = c;
            }).setOnComplete(() =>
            {
                IsTweening = false;
            });
        });
    }
}
