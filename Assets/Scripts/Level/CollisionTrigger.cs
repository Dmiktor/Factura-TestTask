using System;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public Action<GameObject> OnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        OnTrigger?.Invoke(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnTrigger?.Invoke(collision.gameObject);
    }
}
