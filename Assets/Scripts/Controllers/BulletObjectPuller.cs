using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPuller : MonoBehaviour
{
    [SerializeField]private List<BulletController> pooledObjects;
    [SerializeField]private BulletController objectToPool;
    [SerializeField]private int amountToPool;

    public void Init()
    {
        pooledObjects = new List<BulletController>();
        BulletController bullet;
        for (int i = 0; i < amountToPool; i++)
        {
            bullet = Instantiate(objectToPool);
            bullet.gameObject.SetActive(false);
            pooledObjects.Add(bullet);
        }
    }

    public BulletController GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject bulletObject)
    {
        bulletObject.SetActive(false);
    }
}
