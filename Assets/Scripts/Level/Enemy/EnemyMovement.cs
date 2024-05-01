using System;
using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Action OnCatchesUp;

    [SerializeField] private float speed = 5f;

    private Coroutine followCoroutine;

    public void StartFollow()
    {
        if (followCoroutine != null)
        {
            StopCoroutine(followCoroutine);
        }
        followCoroutine = StartCoroutine(FollowTarget());
    }

    public void StopFollow()
    {
        if (followCoroutine != null)
        {
            StopCoroutine(followCoroutine);
        }
    }

    private IEnumerator FollowTarget()
    {
        Transform target = SceneController.Instance.PlayerController.transform;
        while (true)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
            yield return null;
        }
    }
}