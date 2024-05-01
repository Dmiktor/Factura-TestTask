using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyAnimationController enemyAnimationController;
    [SerializeField] private CollisionTrigger agroTrigger;
    [SerializeField] private CollisionTrigger attackTrigger;
    [SerializeField] private ParticleSystem deathParticles;


    private void Start()
    {
        health.Init();
        health.OnDeath += Die;
        health.OnDamageTaken += TakeDamage;
        agroTrigger.OnTrigger += StartFollow;
        attackTrigger.OnTrigger += DealDamage;
    }

    private void TakeDamage(int maxHealth, int currentHealt)
    {
        enemyAnimationController.PlayTakeDamage();
    }

    private void Die()
    {
        deathParticles.transform.parent = null;
        deathParticles.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void DealDamage(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(1);
            this.gameObject.SetActive(false);
        }
    }

    private void StartFollow(GameObject gameObject)
    {
        enemyMovement.StartFollow();
        enemyAnimationController.PlayRun();
    }

    private void OnDisable()
    {
        agroTrigger.OnTrigger -= StartFollow;
        attackTrigger.OnTrigger -= DealDamage;
        health.OnDeath -= Die;
        health.OnDamageTaken -= TakeDamage;
    }
}
