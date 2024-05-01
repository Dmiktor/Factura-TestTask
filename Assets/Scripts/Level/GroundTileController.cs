using System;
using UnityEngine;

public class GroundTileController : MonoBehaviour
{
    [SerializeField] private Transform pathWaypoint;
    [SerializeField] private float randomRangeMin = -1f;
    [SerializeField] private float randomRangeMax = 1f;
    public Transform PathWaypoint => pathWaypoint;
    public void Init()
    {
        float randomOffset = UnityEngine.Random.Range(randomRangeMin, randomRangeMax);

        Vector3 waypointPosition = PathWaypoint.position;
        waypointPosition.x += randomOffset;
        PathWaypoint.position = waypointPosition;
    }
}
