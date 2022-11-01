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
            yield return new WaitForSeconds(1);
        }
    }
}
