using System;
using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform tip;
    [SerializeField] private Transform target;
    [SerializeField] private Transform turretModel;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float rotationRateModifier;
    [SerializeField] private GameObject laser;

    private Vector3 direction;
    private Coroutine shootingCoroutine;

    public void Init()
    {
        player.InputValidator.OnTouchMoved += ReadInput;
    }
    public void StartShooting()
    {
        
        shootingCoroutine = StartCoroutine(ShootingCoroutine());
        laser.SetActive(true);
    }
    private void ReadInput(Vector2 rotation)
    {
        turretModel.Rotate(0f, 0f, rotation.x * rotationRateModifier);
    }
    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(rateOfFire);
            Fire();
        }
    }

    private void Fire()
    {
        BulletController bulletToShoot = SceneController.Instance.Puller.GetPooledObject();
        bulletToShoot.Init(tip);
        bulletToShoot.Shoot(target.position - tip.position);
    }

    internal void Stop()
    {
        StopCoroutine(shootingCoroutine);
        player.InputValidator.OnTouchMoved -= ReadInput;
    }
}
