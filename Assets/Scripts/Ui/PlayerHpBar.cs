using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private float duration = 0.1f;

    public void OnDamageTaken(int maxHealth, int currentHealth)
    {
        float fill =  ((float) currentHealth) / ((float)maxHealth);
        hpBar.DOFillAmount(fill, duration);
    }
}
