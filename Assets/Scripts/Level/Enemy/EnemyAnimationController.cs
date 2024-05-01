using DG.Tweening;
using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakePower;
    [SerializeField] private int vibrato;


    private const string RUN = "Run";
    private const string EXIT = "Exit";

    public void PlayRun()
    {
        animator.SetTrigger(RUN);
    }

    public void Exit()
    {
        animator.SetTrigger(EXIT);
    }

    internal void PlayTakeDamage()
    {
        transform.DOKill();
        transform.DOShakeScale(shakePower, shakeDuration, vibrato).SetEase(Ease.InOutCubic);
    }
}
