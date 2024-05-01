using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GroundTileController[] tiles;

    private Transform[] playerPath;

    public Transform[] PlayerPath => playerPath;
    public void Init()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].Init();
        }
        GetPlayerPath();
    }

    private void GetPlayerPath()
    {
        playerPath = new Transform[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            playerPath[i] = tiles[i].PathWaypoint;
        }
    }
}
