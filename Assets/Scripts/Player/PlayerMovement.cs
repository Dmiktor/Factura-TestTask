using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float timePerPathPoint;
    [SerializeField] private PathType pathType;
    [SerializeField] private PathMode pathMode;
    [SerializeField] private Ease pathEase = Ease.InCubic;
    [SerializeField] private float lookAhead = 0.15f;

    private Tween movingTween;

    public void StartMoving()
    {
        Vector3[] pathWayPoints = new Vector3[SceneController.Instance.LevelController.PlayerPath.Length];
        for (int i = 0; i < SceneController.Instance.LevelController.PlayerPath.Length; i++)
        {
            pathWayPoints[i] = SceneController.Instance.LevelController.PlayerPath[i].position;
        }
        movingTween = player.transform.DOPath(pathWayPoints, SceneController.Instance.LevelController.PlayerPath.Length * timePerPathPoint, pathType, pathMode, 10, Color.green).SetEase(pathEase)
            .SetLookAt(lookAhead)
            .OnComplete(SceneController.Instance.Win);
    }

    public void Stop()
    {
        movingTween.Kill();
    }
}
