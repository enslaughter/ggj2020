using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PlayerController;

public class JumpPad : MonoBehaviour
{
    public GameObject player;
    public float padPower;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Entering Collision");
        if(other.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, padPower));
        }
    }
}
