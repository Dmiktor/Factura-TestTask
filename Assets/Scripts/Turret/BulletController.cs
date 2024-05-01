using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private CollisionTrigger trigger;

    public void Init(Transform tip)
    {
        transform.position = tip.position;
        gameObject.SetActive(true);
        trailRenderer.Clear();
        trailRenderer.emitting = true;
        trigger.OnTrigger += DealDamage;
    }

    private void DealDamage(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
        ReturnToPool();
    }

    public void Shoot(Vector3 direction)
    {
        StartCoroutine(ReturnToPoolCoroutine());
        rigidBody.AddForce(direction * speed, ForceMode.VelocityChange);
    }

    private IEnumerator ReturnToPoolCoroutine()
    {
        yield return new WaitForSeconds(lifetime);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        StopAllCoroutines();
        rigidBody.velocity = Vector3.zero;
        trailRenderer.emitting = false;
        trigger.OnTrigger -= DealDamage;
        SceneController.Instance.Puller.ReturnToPool(gameObject);
    }
}
