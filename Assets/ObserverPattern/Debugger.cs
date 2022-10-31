using System.Collections;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    IEnumerator Start()
    {
        Health health = GetComponent<Health>();
        Level level = GetComponent<Level>();

        while(true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log($"EXP: {level.GetExperience()},Level: {level.GetLevel()},Health: {health.GetHealth()}");
        }
    }
}
