using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private int numberOfSamples = 30;
    [SerializeField] private float skillCooldown = 4.0f;

    
    private Queue<Vector3> playerPositionSamples;
    private bool isSkillUsable = true;

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
        if (Input.GetKeyDown(KeyCode.Space) && isSkillUsable)
        {
            UseSkill();
        }
    }

    private IEnumerator EnterCooldown()
    {
        isSkillUsable = false;
        sr.enabled = false;
        yield return new WaitForSeconds(skillCooldown);
        isSkillUsable = true;
        sr.enabled = true;
    }

    private void UseSkill()
    {
        PlayerInteractions pi = PlayerInteractions.Instance;
        pi.playerCollider.enabled = false;
        pi.IsControllable = false;
        pi.PlaySound(pi.rewindSound);
        LeanTween.move(pi.gameObject, transform.position, 0.05f).setOnComplete(() =>
        {
            pi.IsControllable = true;
            pi.playerCollider.enabled = true;

        });
        playerPositionSamples.Clear();
        StartCoroutine(EnterCooldown());
    }
}
