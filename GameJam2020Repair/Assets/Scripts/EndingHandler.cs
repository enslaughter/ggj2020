using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingHandler : MonoBehaviour
{
    public float transitionTime = 1.0f;
    public TextMeshProUGUI endText;

    private bool gameEnded;

    private void Start()
    {
        endText.SetText("");
        gameEnded = false;
    }
    public void EndGame(string endingType)
    {
        if (gameEnded != true)
        {
            switch (endingType)
            {
                case "MachineBreak":
                    endText.SetText("The Machine Broke! Try Again");
                    gameEnded = true;
                    break;

                case "GlobalBreak":
                    endText.SetText("The Rocket Overloaded! Try Again");
                    gameEnded = true;
                    break;

                case "Victory":
                    endText.SetText("Congratulations! You Win!");
                    gameEnded = true;
                    break;
            }
        }

    }
}
