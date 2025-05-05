using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private GameObject gameWinScreen;

    [SerializeField] private Player player;

    private void Update()
    {
        if (player.GetPlayerLives() <= 0)
        {
            EndGame();
        }

        else if (player.HasPlayerEscaped())
        {
            GameWon();
        }
    }

    public void StartGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    private void GameWon()
    {
        //SoundManager.Instance.Play(Sounds.GameWin);
        gameWinScreen.SetActive(true);
        player.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        //SoundManager.Instance.Play(Sounds.GameOver);
        gameOverScreen.SetActive(true);
        player.gameObject.SetActive(false);
    }
}
