using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    private TextMeshProUGUI livesText;

    [SerializeField] private int lives = 3;

    private void Awake()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        RefreshUI();
    }

    public void ReduceLives(int decrement)
    {
        lives -= decrement;

        RefreshUI();
    }

    public int GetLives()
    {
        return lives;
    }

    private void RefreshUI()
    {
        livesText.text = "LIVES:" + lives;
    }
}
