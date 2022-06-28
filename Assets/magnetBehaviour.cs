using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetBehaviour : MonoBehaviour
{
    //smit's work

    public Canvas pickUpDialogCanvas;

    public Transform magnetHolder;

    bool magnetWithPlayer;
    

    private void Start()
    {
        //pickUpDialogCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {

        if (!magnetWithPlayer)
        {
            Vector2 horizontalDistanceBetweenPlayerAndmagnet = new Vector2(References.playerInstance.transform.position.x - transform.position.x, 0);
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
            else
            {
                //pick up the magnet
                //call the method to pickup the magnet
                GetPickedUpByPlayer();
            }
              
        }

        
        
    }

    public void GetPickedUpByPlayer()
    {
        transform.SetParent(magnetHolder);
        transform.localPosition = new Vector3(0,2.33f,0.074f);
        magnetWithPlayer = true;
        pickUpDialogCanvas.gameObject.SetActive(false);
    }

    public void ThrowMagnet()
    {
        transform.parent = null;
        magnetWithPlayer = false;
    }
}
