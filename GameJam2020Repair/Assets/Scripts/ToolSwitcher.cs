using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolSwitcher : MonoBehaviour
{

    public GameObject player;

    public GameObject[] tools;
    

    private void Start()
    {
     
        
    }

    public void SetActiveTool()
    {
        for(int i = 0; i<tools.Length; i++)
        {
            tools[i].GetComponent<ToolClicker>().Deselect();
        }
    }
}
