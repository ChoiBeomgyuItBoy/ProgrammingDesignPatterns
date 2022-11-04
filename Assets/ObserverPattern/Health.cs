using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float fullHealth = 100f;
    [SerializeField] private float drainPerSecond = 2f;

    public event Action onHealthChange;

    private float currentHealth = 0;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    private void ResetHealth()
    {
        currentHealth = fullHealth;
    }

    private IEnumerator HealthDrain()
    {
        while(currentHealth > 0)
        {
            currentHealth -= drainPerSecond;

            onHealthChange?.Invoke();

            yield return new WaitForSeconds(1);
        }
    }
}
