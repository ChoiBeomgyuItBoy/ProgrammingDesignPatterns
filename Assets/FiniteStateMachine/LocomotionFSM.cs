using UnityEngine;

public class LocomotionFSM : MonoBehaviour
{
    enum State
    {
        Grounded,
        InAir,
        Crouching
    }

    State currentState = State.Grounded;

    public void Jump()
    {
        switch(currentState)
        {
            case State.Grounded:
                currentState = State.InAir;
                break;
            case State.Crouching:
                currentState = State.Grounded;
                break;
        }
    }

    public void Fall()
    {
        switch(currentState)
        {
            case State.Grounded:
                currentState = State.InAir;
                break;
            case State.Crouching:
                currentState = State.InAir;
                break;
        }
    }

    public void Land()
    {
        switch(currentState)
        {
            case State.InAir:
                currentState = State.Grounded;
                break;
        }
    }

    public void Crouch()
    {
        switch(currentState)
        {
            case State.Grounded:
                currentState = State.Crouching;
                break;

            case State.Crouching:
                currentState = State.Grounded;
                break;
        }
    }
}
