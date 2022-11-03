using UnityEngine;

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class RageAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class FireAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Thowing fireball");
    }
}

public class HealAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Healing");
    }
}

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = new RageAbility();

    public void UseAbility()
    {
        currentAbility?.Use(gameObject);
    }

    private void Start()
    {
        UseAbility();
    }
}
