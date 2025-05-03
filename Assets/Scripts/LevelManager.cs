using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OnLevelComplete(int currentLevelIndex)
    {
        Debug.Log("Level Complete!");

        int nextLevelIndex = currentLevelIndex + 1;

        SceneManager.LoadScene(nextLevelIndex);
        
    }

    public void RestartLevel(int currentLevelIndex)
    {
        SceneManager.LoadScene(currentLevelIndex);
    }
}
