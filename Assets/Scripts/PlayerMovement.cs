using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] AudioClip sfx_jump;

    Rigidbody2D playerRB;
    SpriteRenderer playerSpriteRenderer;
    Animator playerAnimator;
    AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); //Reference the Rigidbody2D component
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); // Reference the SpriteRenderer component
        playerAnimator = GetComponent<Animator>(); //Reference the Animator component
        playerAudio = GetComponent<AudioSource>(); //Reference the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerJump();
    }

    public void PlaySound(AudioClip sfx)
    {
        playerAudio.PlayOneShot(sfx);
    }

    void MovePlayer()
    {
        //Get player Input
        if (Input.GetKey("right"))
        {
            playerRB.velocity = new Vector2(speed, playerRB.velocity.y); //Move player to the right
            playerSpriteRenderer.flipX = false; //Flip player sprite right
            playerAnimator.SetBool("isRunning", true); //Play run animation
        }
        else if (Input.GetKey("left"))
        {
            playerRB.velocity = new Vector2(-speed, playerRB.velocity.y); //Move player to the left
            playerSpriteRenderer.flipX = true; //Flip player sprite left
            playerAnimator.SetBool("isRunning", true); //Play run animation
        }
        else
        {
            playerRB.velocity = new Vector2(0f, playerRB.velocity.y); //Player stays still
            playerAnimator.SetBool("isRunning", false); //Stop run animation
        }
        
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown("space") && GroundCheck.isOnGround)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            PlaySound(sfx_jump);
        }

        //Jump Animation control
        if (GroundCheck.isOnGround == false)
        {
            playerAnimator.SetBool("isJumping", true);
            playerAnimator.SetBool("isRunning", false);
        }
        else
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }
}
