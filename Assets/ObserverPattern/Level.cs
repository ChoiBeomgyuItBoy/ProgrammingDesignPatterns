using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    [SerializeField] private int pointsPerLevel = 200;

    public event Action onLevelUpAction;
    public event Action onExperienceChange;

    private int experiencePoints = 0;
    
    public void GainExperience(int points)
    {
        int level = GetLevel();

        experiencePoints += points;

        onExperienceChange?.Invoke();

        if(GetLevel() > level)
        {
            onLevelUpAction?.Invoke();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}
