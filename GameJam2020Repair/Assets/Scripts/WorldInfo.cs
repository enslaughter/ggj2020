using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldInfo : MonoBehaviour
{
    public float timeLimit;
    public float pressureLimit;
    public float tempLimit;

    public GameObject[] machines;
    public GameObject endManager;
    public TextMeshProUGUI pressureGauge;
    public TextMeshProUGUI tempGauge;
   // public TextMeshProUGUI 

    public TextMeshProUGUI timeDisplay;
    private float timeLeft;
    private float currentPressure;
    private float currentTemperature;

    private float pressureFactor;
    private float temperatureFactor;

    void Start()
    {
        timeLeft = timeLimit;
        pressureFactor = 0f;
        temperatureFactor = 0f;

        for (int i = 0; i < machines.Length; i++)
        {

        }
    }

    void Update()
    {
        if (GameStateManager.currentState == GameStateManager.GameState.GameRunning)
        {


            //Set Global Level Countdown
            timeLeft -= Time.deltaTime;
            timeDisplay.SetText("Time Left:" + timeLeft.ToString("F0"));

            currentPressure = RecalculatePressure();
            currentTemperature = RecalculateTemperature();

            pressureFactor = 100f * currentPressure / pressureLimit;
            temperatureFactor = 100f * currentTemperature / tempLimit;

            if (pressureFactor > 100f || temperatureFactor > 100f)
            {
                endManager.GetComponent<EndingHandler>().EndGame("GlobalBreak");
            }

            pressureGauge.SetText("Pressure Damage:    " + pressureFactor.ToString("F2") + " %");
            tempGauge.SetText("Temperature Damage:    " + temperatureFactor.ToString("F2") + " %");

            if (timeLeft <= 0f)
            {
                endManager.GetComponent<EndingHandler>().EndGame("Victory");
            }
        }
    }

    private float RecalculatePressure()
    {
        float cp = 0f;
        for (int i = 0; i < machines.Length; i++)
        {
            cp +=  machines[i].GetComponent<MachineScript>().GetPressure();
        }

        return cp;

    }

    private float RecalculateTemperature()
    {
        float ct = 0f;
        for (int i = 0; i < machines.Length; i++)
        {
            ct += machines[i].GetComponent<MachineScript>().GetTemp();
        }

        return ct;
    }

    

}
