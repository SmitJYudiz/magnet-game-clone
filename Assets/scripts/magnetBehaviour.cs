using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetBehaviour : MonoBehaviour
{
    //smit's work

    public Canvas pickUpDialogCanvas;

    public Transform magnetHolder;

    bool magnetWithPlayer;

    Rigidbody2D magnetRB;
    //public Rigidbody2D rigidBodyToStoreInMagnetRB;

    private void Start()
    {
        //pickUpDialogCanvas.gameObject.SetActive(true);
        magnetRB = GetComponent<Rigidbody2D>();
        //rigidBodyToStoreInMagnetRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //magnetRB = rigidBodyToStoreInMagnetRB;
        //magnetRB = null;

        Vector2 horizontalDistanceBetweenPlayerAndmagnet = new Vector2(References.playerInstance.transform.position.x - transform.position.x, 0);

        if (!magnetWithPlayer)
        {
           
            //if (Vector2.Distance(References.playerInstance.transform.position, transform.position) <= 3f)
            if(Mathf.Abs(horizontalDistanceBetweenPlayerAndmagnet.magnitude)<= 1f)
            {
                //show the canvas
                pickUpDialogCanvas.gameObject.SetActive(true);
            }
            else
            {
                //dont show it
                pickUpDialogCanvas.gameObject.SetActive(false);
            }
        }
        else
        {
            //dont show it
            pickUpDialogCanvas.gameObject.SetActive(false);
        }
        //check if player is anywhere nearby the magnet
       


        //here if E is pressed the magnet's parent should be the magnet holder which inside the player
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(magnetWithPlayer)
            {
                //throw the magnet
                ThrowMagnet();
            }
            else if(horizontalDistanceBetweenPlayerAndmagnet.magnitude <= 1.5f)
            {
                //pick up the magnet
                //call the method to pickup the magnet
                GetPickedUpByPlayer();
            }
              
        }

        
        
    }

    public void GetPickedUpByPlayer()
    {
        //magnetRB = null;
        magnetRB.isKinematic = true;
        magnetRB.simulated = false;
        transform.SetParent(magnetHolder);
        transform.position = magnetHolder.position;
        //transform.localPosition = new Vector3(0,2.33f,0.074f);
        magnetWithPlayer = true;
        pickUpDialogCanvas.gameObject.SetActive(false);
    }

    public void ThrowMagnet()
    {
        // magnetRB = rigidBodyToStoreInMagnetRB;
        magnetRB.isKinematic = false;
        magnetRB.simulated = true;
        magnetRB.AddForce(transform.right * 3, ForceMode2D.Impulse);
        //magnetRB.detectCollision = true;
        //magnetRB.collisionDetectionMode = CollisionDetectionMode2D;
        //transform.localPosition = new Vector3(References.playerInstance.transform.position.x + new Vector3(0, 2.33f, 0.074f).x,0 );
        transform.parent = null;
        magnetWithPlayer = false;
    }
}
