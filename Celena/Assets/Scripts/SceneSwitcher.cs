using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public SceneFader sceneFader; // Reference to the SceneFader script

    public void SwitchScene()
    {
        if (sceneFader != null)
        {
            sceneFader.FadeToScene("BossFight"); // Specify the target scene
        }
        else
        {
            Debug.LogError("SceneFader is not assigned.");
        }
    }
}