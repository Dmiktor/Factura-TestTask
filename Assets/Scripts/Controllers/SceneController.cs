using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoSingleton<SceneController>
{
    [SerializeField] private BulletObjectPuller puller;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LevelController levelController;
    [Scene][SerializeField] private int gameSceneId;
    [SerializeField] private UiController uiController;

    public LevelController LevelController => levelController;
    public BulletObjectPuller Puller => puller;

    public PlayerController PlayerController => playerController;

    private void Start()
    {
        levelController.Init();
        puller.Init();
        playerController.Init();
        uiController.Init();
    }

    private void Update()
    {
        playerController.DoUpdate();
    }

    internal void RestartGame()
    {
        SceneManager.LoadScene(gameSceneId);
    }

    internal void Lose()
    {
        uiController.OnLose();
    }

    internal void Win()
    {
        uiController.OnWin();
    }
}
