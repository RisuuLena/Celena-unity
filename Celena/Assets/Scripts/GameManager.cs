using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int targetKillCount = 2; // The number of kills needed to transition
    private int currentKillCount = 0;

    // This method will be called when an enemy is killed
    public void EnemyKilled()
    {
        currentKillCount++;
        Debug.Log("Enemies killed: " + currentKillCount);

        if (currentKillCount >= targetKillCount)
        {
            Debug.Log("Transitioning to the next scene in 2 seconds...");
            Invoke("LoadNextScene", 2f); // Delay for 2 seconds
        }
    }

    // This method handles loading the next scene
    private void LoadNextScene()
    {
        // Make sure the next scene is added in the Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}