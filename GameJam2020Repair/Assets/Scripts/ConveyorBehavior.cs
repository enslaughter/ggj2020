using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBehavior : MonoBehaviour
{
    public GameObject player;
    public float beltStrength;
    public bool movingRight;

    private float moveDir;
    private bool playerOnBelt;

    private void Start()
    {
        moveDir = SetDirection(movingRight);
        playerOnBelt = false;
    }

    private void FixedUpdate()
    {
        if (playerOnBelt)
        {
            //player.GetComponent<Rigidbody2D>().AddForce(new Vector2(beltStrength * moveDir * Time.deltaTime, 0f));
            player.GetComponent<Rigidbody2D>().MovePosition(player.GetComponent<Rigidbody2D>().position + new Vector2(beltStrength * moveDir * Time.deltaTime, 0f));
            //player.GetComponent<Rigidbody2D>().velocity += new Vector2(beltStrength * moveDir * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == player)
        {
            playerOnBelt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            playerOnBelt = false;
        }
    }

    private float SetDirection(bool isMovingRight)
    {
        if (isMovingRight)
        {
            return 1.0f;
        }

        else
        {
            return -1.0f;
        }
    }
}
