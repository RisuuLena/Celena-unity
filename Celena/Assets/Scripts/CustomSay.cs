using Fungus;

[CommandInfo("Narrative", 
    "Custom Say", 
    "Displays a character's dialogue, considering game pause.")]
public class CustomSay : Say
{
    public override void OnEnter()
    {
        // Check if the game is paused
        if (FindObjectOfType<TimeScaleManager>().IsGamePaused())
        {
            // Manually advance the text without using Time.deltaTime
            Continue();
        }
        else
        {
            base.OnEnter(); // Proceed with the default behavior of Say command
        }
    }
}