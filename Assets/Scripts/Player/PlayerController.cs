using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputValidator inputValidator;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHpBar playerHpBar;
    [SerializeField] private TurretController turret;
    [SerializeField] private Health playerHealth;
    [SerializeField] private PlayerRagdollController playerRagdollController;
    [SerializeField] private GameObject playerCamera;
    public InputValidator InputValidator => inputValidator;

    public void Init()
    {
        turret.Init();
        playerHealth.Init();
        playerHealth.OnDeath += Die;
        playerHealth.OnDamageTaken += playerHpBar.OnDamageTaken;
        inputValidator.OnFirstTouch += StartLevel;
    }

    public void DoUpdate()
    {
        inputValidator.DoUpdate();
    }

    private void Die()
    {
        playerMovement.Stop();
        turret.Stop();
        playerRagdollController.PlayRagdoll();
        SceneController.Instance.Lose();
    }

    internal void StartLevel()
    {
        inputValidator.OnFirstTouch -= StartLevel;
        turret.StartShooting();
        playerMovement.StartMoving();
        playerCamera.SetActive(true);
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= Die;
        inputValidator.OnFirstTouch -= StartLevel;
        playerHealth.OnDamageTaken -= playerHpBar.OnDamageTaken;
    }
}
