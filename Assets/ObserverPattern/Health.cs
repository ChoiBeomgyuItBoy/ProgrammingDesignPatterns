using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;

    float currentHealth = 0;

    void Awake()
    {
        healthBar.value = maxHealth;

        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    void OnDisable()
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    IEnumerator HealthDrain()
    {
        while(currentHealth > 0)
        {
            currentHealth -= drainPerSecond;

            UpdateUI();

            yield return new WaitForSeconds(1);
        }
    }

    void UpdateUI()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
