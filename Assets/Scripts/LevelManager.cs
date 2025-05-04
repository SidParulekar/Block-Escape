using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;
    private int finalLevelIndex;

    [SerializeField] private LevelUIController levelUIController;

    private void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        finalLevelIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (currentLevelIndex > 0)
        {
            UpdateLevel();
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

    public void OnLevelComplete(int currentLevelIndex)
    {
        Debug.Log("Level Complete!");

        int nextLevelIndex = currentLevelIndex + 1;

        SceneManager.LoadScene(nextLevelIndex);
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void UpdateLevel()
    {
        levelUIController.UpdateLevelText(currentLevelIndex);
    }
}
