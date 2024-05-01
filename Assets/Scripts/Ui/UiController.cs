using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject winUi;
    [SerializeField] private GameObject loseUi;
    [SerializeField] private Button winUiRestart;
    [SerializeField] private Button loseUiRestart;

    public void Init()
    {
        winUiRestart.onClick.AddListener(SceneController.Instance.RestartGame);
        loseUiRestart.onClick.AddListener(SceneController.Instance.RestartGame);
        winUi.SetActive(false);
        loseUi.SetActive(false);
    }

    public void OnWin()
    {
        winUi.SetActive(true);
    }
    public void OnLose()
    {
        loseUi.SetActive(true);
    }
}
