using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    private bool isGamePaused = false;
    
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isGamePaused = false;
    }

    public bool IsGamePaused()
    {
        return isGamePaused;
    }
}