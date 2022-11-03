using UnityEngine;

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class SequenceComposite : IAbility
{
    private IAbility[] children;

    public SequenceComposite(IAbility[] children)
    {
        this.children = children;
    }

    public void Use(GameObject currentGameObject)
    {
        foreach(var child in children)
        {
            child.Use(currentGameObject);
        }
    }
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
    [SerializeField] IAbility currentAbility = 
        new SequenceComposite
        (
            new IAbility[] 
            { 
                new HealAbility(), 
                new RageAbility(),
                new DelayedDecorator(new FireAbility())
            }
        );

    public void UseAbility()
    {
        currentAbility?.Use(gameObject);
    }

    private void Start()
    {
        UseAbility();
    }
}