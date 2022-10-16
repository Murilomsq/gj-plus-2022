using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private static PlayerInteractions _instance;
    public static PlayerInteractions Instance => _instance;

    public CircleCollider2D playerCollider;
    public ParticleSystem untouchableParticle;
    public AudioSource audioSource;
    public AudioSource audioSourceSong;
    public ScreenTransition screenTransition;
    public GameObject deathPanel;
    public bool easy;
    
    [SerializeField] private float untouchableSkillCooldown = 4.0f;
    [SerializeField] private float untouchableSkillDuration = 1.0f;

    [Header("Sounds")] 
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private AudioClip hurtSound;
    public AudioClip rewindSound;

    private bool isUntouchableSkillAvailable = true;
    public bool isDamageInv = false;

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
        if (easy) return;
        StartCoroutine(StayUntouchable());
        PlaySound(hurtSound);
        if (_playerHP <= 0)
            GameOver();
    }

    private void GameOver()
    {
        IsControllable = false;
        deathPanel.SetActive(true);
        Debug.Log("Game Over");
    }
    
    private IEnumerator EnterCooldown()
    {
        yield return new WaitForSeconds(untouchableSkillCooldown);
        isUntouchableSkillAvailable = true;
    }

    private IEnumerator StayUntouchable()
    {
        if (isDamageInv == true)
            yield break;
        isDamageInv = true;
        playerCollider.enabled = false;
        LeanTween.alpha(gameObject, 0.2f, 0.2f);
        untouchableParticle.Play();
        yield return new WaitForSeconds(untouchableSkillDuration);
        LeanTween.alpha(gameObject, 1.0f, 0.2f);
        playerCollider.enabled = true;
        isDamageInv = false;
    }

    public void PlaySound(AudioClip ac)
    {
        audioSource.PlayOneShot(ac);
    }
    public void PlaySong(AudioClip ac)
    {
        audioSourceSong.PlayOneShot(ac);
    }
    

    private void Awake()
    {
        _instance = this;
        onHPChanged += TakeDamage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isUntouchableSkillAvailable)
        {
            isUntouchableSkillAvailable = false;
            PlaySound(dashSound);
            StartCoroutine(StayUntouchable());
            StartCoroutine(EnterCooldown());
        }
    }
}
