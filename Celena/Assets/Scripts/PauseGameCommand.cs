using Fungus;
using UnityEngine;

[CommandInfo("Game", "Pause Game", "Pauses the game by setting time scale to 0.")]
[AddComponentMenu("")]
public class PauseGameCommand : Command
{
    public override void OnEnter()
    {
        FindObjectOfType<TimeScaleManager>().PauseGame();
        Continue();
    }
}

