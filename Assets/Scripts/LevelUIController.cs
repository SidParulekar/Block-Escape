using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    private TextMeshProUGUI levelText;

    private int level;

    private void Awake()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }


    public void UpdateLevelText(int currentLevel)
    {
        level = currentLevel;

        RefreshUI();
    }

    private void RefreshUI()
    {
        levelText.text = "LEVEL " + level;
    }

    
}
