using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingHandler : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public TextMeshProUGUI endTextInputPrompt;

    private void Start()
    {
        endText.SetText("");
        endTextInputPrompt.SetText("");
    }

    private void Update()
    {
        if (GameStateManager.currentState == GameStateManager.GameState.GameEnded)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }

            else if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void EndGame(string endingType)
    {
        if (GameStateManager.currentState != GameStateManager.GameState.GameEnded)
        {
            switch (endingType)
            {
                case "MachineBreak":
                    endText.SetText("The Machine Broke! Try Again");
                    GameStateManager.ChangeGameState("GameEnded");
                    break;

                case "GlobalBreak":
                    endText.SetText("The Rocket Overloaded! Try Again");
                    GameStateManager.ChangeGameState("GameEnded");
                    break;

                case "Victory":
                    endText.SetText("Congratulations! You Win!");
                    GameStateManager.ChangeGameState("GameEnded");
                    break;
            }
        }
        endTextInputPrompt.SetText("Press R to retry, or Escape to quit.");
    }

    
}
