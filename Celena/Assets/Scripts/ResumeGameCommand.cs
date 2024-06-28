using Fungus;
using UnityEngine;

[CommandInfo("Game", "Resume Game", "Resumes the game by setting time scale back to 1.")]
[AddComponentMenu("")]
public class ResumeGameCommand : Command
{
    public override void OnEnter()
    {
        FindObjectOfType<TimeScaleManager>().ResumeGame();
        Continue();
    }
}