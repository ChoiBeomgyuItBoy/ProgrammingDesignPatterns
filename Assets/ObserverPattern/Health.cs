using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;

    float currentHealth = 0;

    void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    IEnumerator HealthDrain()
    {
        while(currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
}
