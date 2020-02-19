using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float jumpPower;

    public enum Tool
    {
        Screwdriver,
        Wrench,
        Extinguisher,
        Tape
    }

    Tool currentTool;

    Rigidbody2D rb;

    public bool onLadder;

    Animator anim;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        onLadder = false;
        currentTool = Tool.Screwdriver;
       
    }

    // Update is called once per frame
    void Update()
    {     
        HandleInputs();
        HandleAnimation();
        if(rb.velocity[0] > 0f)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    private void HandleInputs()
    {
        if (!onLadder)
        {
            float horizontalForce = Input.GetAxis("Horizontal");

            if (horizontalForce == 0f)
            {
                rb.velocity = new Vector2(0f, rb.velocity[1]);
            }

            bool isJumping = Input.GetKeyDown(KeyCode.Space);

            Vector2 appliedVelocity = new Vector2(horizontalForce * moveSpeed * Time.deltaTime, 0f);

            //rb.MovePosition(rb.transform.position + new Vector3(horizontalForce * moveSpeed * Time.deltaTime, 0f, 0f));

            if (isJumping && rb.velocity[1] == 0f)
            {
                appliedVelocity.y = jumpPower * Time.deltaTime;
            }

            rb.velocity = (rb.velocity + appliedVelocity);

            if (rb.velocity[0] >= maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity[1]);

            }
        }
        else
        {
            float hLadder = Input.GetAxis("Horizontal");
            float vLadder = Input.GetAxis("Vertical");

            Vector2 ladPos = new Vector2(hLadder * Time.deltaTime * moveSpeed, vLadder * Time.deltaTime * moveSpeed);
            Vector2 oldPos = new Vector2(rb.transform.position[0], rb.transform.position[1]);


            rb.MovePosition(oldPos + ladPos);
        }
        }

    void HandleAnimation()
    {
        if (rb.velocity == new Vector2(0f, 0f))
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        if (rb.velocity[1] >= 1.0f)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    /*
    public static void ApplyVelocity(float x, float y)
    {
        rb.velocity = rb.velocity + new Vector2(x, y);
    }
    */

    public void SetTool(string toolType)
    {
        switch (toolType)
        {
            case "Screwdriver":
                currentTool = Tool.Screwdriver;
                break;

            case "Wrench":
                currentTool = Tool.Wrench;
                break;

            case "Extinguisher":
                currentTool = Tool.Extinguisher;
                break;

            case "Tape":
                currentTool = Tool.Tape;
                break;
        }
    }
}
