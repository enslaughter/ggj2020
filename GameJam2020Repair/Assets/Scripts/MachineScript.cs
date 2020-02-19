using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public PlayerController.Tool toolChoice;
    public GameObject player;
    public GameObject worldInfo;
    public GameObject endManager;

    public float tempFactor;
    public float pressureFactor;
    public float factorLimit;
    public float repairFactor;
    public float currentTemp;
    public float currentPressure;

    private bool canRepair;
    private bool inRepair;
    public float currentFactor;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        inRepair = false;
        canRepair = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRepair && Input.GetKey(KeyCode.E))
        {
            inRepair = true;
        }

        else
        {
            inRepair = false;
        }

        if (!inRepair)
        {
            currentTemp += tempFactor * Time.deltaTime;
            currentPressure += pressureFactor * Time.deltaTime;
            currentFactor = currentTemp + currentPressure;
        }
        else
        {
            currentTemp -= repairFactor * Time.deltaTime;
            if(currentTemp < 0.0f)
            {
                currentTemp = 0.0f;
            }
            currentPressure -= repairFactor * Time.deltaTime;
            if(currentPressure < 0.0f)
            {
                currentPressure = 0.0f;
            }
            currentFactor = currentTemp + currentPressure;
        }

        if(currentFactor > factorLimit)
        {
            endManager.GetComponent<EndingHandler>().EndGame("MachineBreak");
        }

        UpdateRedness();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            canRepair = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            canRepair = false;
        }
    }

    void UpdateRedness()
    {
        float rednessFactor = currentFactor / factorLimit;
        if(rednessFactor > 1.0f)
        {
            rednessFactor = 1.0f;
        }
        sr.color = new Color(1.0f, 0.0f, 0.0f, rednessFactor);
    }

    public float GetTemp()
    {
        return currentTemp;
    }

    public float GetPressure()
    {
        return currentPressure;
    }

}
