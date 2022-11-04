using UnityEngine.UI;
using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider healthBar;

    private void Start()
    {
        health.onHealthChange += UpdateUI;

        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.value = health.GetHealth() / health.GetFullHealth();
    }
}
