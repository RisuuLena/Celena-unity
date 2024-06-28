using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int targetKillCount = 2; // The number of kills needed to transition
    private int currentKillCount = 0;
    
    public Flowchart flowchart; // Reference to the Fungus Flowchart
    public string dialogueBlockName = "EnemyDefeatedDialogue";
    public GameObject gameOverUI;

    // This method will be called when an enemy is killed
    public void EnemyKilled()
    {
        currentKillCount++;
        Debug.Log("Enemies killed: " + currentKillCount);

        if (currentKillCount >= targetKillCount)
        {
            Invoke("TriggerDialogue", 5f);
        }
    }
    
    void TriggerDialogue()
    {
        if (flowchart != null)
        {
            flowchart.ExecuteBlock(dialogueBlockName);
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}