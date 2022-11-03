using UnityEngine;

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class DelayedDecorator : IAbility
{
    private IAbility wrappedAbility;

    public DelayedDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        wrappedAbility.Use(currentGameObject);
    }
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
    [SerializeField] IAbility currentAbility = new DelayedDecorator(new RageAbility());

    public void UseAbility()
    {
        currentAbility?.Use(gameObject);
    }

    private void Start()
    {
        UseAbility();
    }
}