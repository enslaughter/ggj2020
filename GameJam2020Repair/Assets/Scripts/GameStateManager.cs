using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public enum GameState
    {
        Menu,
        Pause,
        GameRunning,
        GameEnded
    }

   public static GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.GameRunning;
    }

    public static void ChangeGameState(string gamestateID)
    {
        switch (gamestateID)
        {
            case "Menu":
                currentState = GameState.Menu;
                break;

            case "Pause":
                currentState = GameState.Pause;
                break;

            case "GameRunning":
                currentState = GameState.GameRunning;
                break;

            case "GameEnded":
                currentState = GameState.GameEnded;
                break;
        } 
    }
}
