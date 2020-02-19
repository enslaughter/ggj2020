using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPortal : MonoBehaviour
{

    public GameObject player;
    public GameObject sisterPortal;

    public bool canWarp;
    public bool ExitOnly;
    public float teleDelay;

    void Start()
    {
        if (!ExitOnly)
        {
            canWarp = true;
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player && canWarp)
        {
            Invoke("WarpPlayer", teleDelay);
        }
    }
   
    void WarpPlayer()
    {
        player.transform.position = sisterPortal.transform.position;
        sisterPortal.GetComponent<WarpPortal>().canWarp = false;
        canWarp = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player && !ExitOnly)
        {
            canWarp = true;
        }
       
    }
}
