using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{


    private void Awake()
    {
        References.playerInstance = this;
    }
    //input code for player
    

    public float playerMovementSpeed;


    Vector2 inputVector;

    public Rigidbody2D playerRB;

    bool playerTouchedGround;

    public Transform magnetHolder;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerTouchedGround = true;
    }

    private void Update()
    {

        //inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputVector = new Vector2(Input.GetAxis("Horizontal"), 0);

        //using TIme.deltaTime in below line causes the speed of the player to be very low, and hence for now not using.
        //playerRB.velocity = inputVector * playerMovementSpeed * Time.deltaTime;
        playerRB.velocity = inputVector * playerMovementSpeed;

        if(Input.GetKeyDown(KeyCode.Space)&& playerTouchedGround)
        {
            playerRB.gravityScale = 0;
            playerRB.AddForce(Vector2.up * 5000);
            playerRB.gravityScale = 25;
            playerTouchedGround = false;                    
        }



        //if we are near any magnet, show a canvas: press E to pick magnet

    }
    
    private bool OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("ground"))
        {
            playerTouchedGround = true;
        }        
        return playerTouchedGround;
    }

}
