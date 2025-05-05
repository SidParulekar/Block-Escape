using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    private TextMeshProUGUI levelText;

    [SerializeField] private LivesController livesController;

    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private Player player;

    private int level;

    private void Awake()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (livesController.GetLives() <= 0)
        {
            EndGame();
        }
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

    private void EndGame()
    {
        //SoundManager.Instance.Play(Sounds.GameOver);
        gameOverScreen.SetActive(true);
        player.gameObject.SetActive(false);
    }
}
