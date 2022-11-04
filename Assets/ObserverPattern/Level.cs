using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    [SerializeField] TMP_Text displayText;
    [SerializeField] TMP_Text experienceText;
    [SerializeField] Button increaseXPButton;

    [SerializeField] int pointsPerLevel = 200;

    public event Action onLevelUpAction;

    int experiencePoints = 0;

    void Start()
    {
        UpdateUI();

        increaseXPButton.onClick.AddListener(() => GainExperience(10));
    }

    void GainExperience(int points)
    {
        int level = GetLevel();

        experiencePoints += points;

        UpdateUI();

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

    void UpdateUI()
    {
        displayText.text = $"Level: {GetLevel()}";
        experienceText.text = $"XP: {experiencePoints}";
    }
}
