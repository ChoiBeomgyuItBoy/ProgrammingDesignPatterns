using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private Button increaseXPButton;

    private void Start()
    {
        level.onExperienceChange += UpdateUI;

        increaseXPButton.onClick.AddListener(GainExperience);

        UpdateUI();
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }

    private void UpdateUI()
    {
        levelText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"XP: {level.GetExperience()}";
    }
}

