using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehavior : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && (Input.GetAxis("Vertical") != 0.0f))
        {
            player.GetComponent<PlayerController>().onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<PlayerController>().onLadder = false;
        }
    }
}
