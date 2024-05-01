using UnityEngine;

public class PlayerRagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] pieceRigidBody;

    internal void PlayRagdoll()
    {
        for (int i = 0; i < pieceRigidBody.Length; i++)
        {
            pieceRigidBody[i].isKinematic = false;
        }
    }

}
