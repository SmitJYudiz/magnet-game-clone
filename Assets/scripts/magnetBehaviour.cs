using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class magnetBehaviour : MonoBehaviour
{
    public static magnetBehaviour instance;

    private void Awake()
    {
        instance = this;
    }

 

    public Canvas pickUpDialogCanvas;

    public Transform magnetHolder;

    public bool magnetWithPlayer;

    Rigidbody2D magnetRB;

    bool isDrag;

    float controlBtnHoldTimeToRestartlevel;

    public Transform originOfArc;

    private void Start()
    {
       
        magnetRB = GetComponent<Rigidbody2D>();
       
        controlBtnHoldTimeToRestartlevel = 1f;

        
    }

    private void Update()
    {
        //to restart level:
        if(Input.GetKey(KeyCode.LeftControl))
        {
            controlBtnHoldTimeToRestartlevel -= Time.deltaTime;
            if(controlBtnHoldTimeToRestartlevel<=0)
            {
                SceneManager.LoadScene(0);
                controlBtnHoldTimeToRestartlevel = 1f;
            }
        }

      

        Vector2 horizontalDistanceBetweenPlayerAndmagnet = new Vector2(References.playerInstance.transform.position.x - transform.position.x, 0);

        if (!magnetWithPlayer)
        {

            if(Mathf.Abs(horizontalDistanceBetweenPlayerAndmagnet.magnitude)<= 1f)
            {
                //show the canvas
                pickUpDialogCanvas.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    GetPickedUpByPlayer();
                }
            }
            else
            {
                //dont show it
                pickUpDialogCanvas.gameObject.SetActive(false);
            }
        }
        else if(magnetWithPlayer)
        {
          
            //dont show it
            pickUpDialogCanvas.gameObject.SetActive(false);

            if (Input.GetKey(KeyCode.E))
            {
                isDrag = true;
                OnMouseDrag();
            }
            else
            {
                isDrag = false;
               
                //ThrowMagnet(directionToThrowIn);
            }

            if(Input.GetMouseButtonDown(0))
            {
                isDrag = false;

                ThrowMagnet();
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                
                //ThrowMagnet();
            }
        }
    }


  

    private void OnMouseDrag()
    {
        //if(isDrag)
        //{
        //    //Debug.Log("mouse dragged");
        //}

    }

    public void GetPickedUpByPlayer()
    {
        
        magnetRB.isKinematic = true;
        magnetRB.simulated = false;
        transform.SetParent(magnetHolder);
        transform.position = magnetHolder.position;
    
        magnetWithPlayer = true;
        pickUpDialogCanvas.gameObject.SetActive(false);
    }

    public void ThrowMagnet()
    {
       
            magnetRB.isKinematic = false;
            magnetRB.simulated = true;
          
            transform.parent = null;
            magnetWithPlayer = false;
            magnetRB.velocity = BowBehaviour.instance.shotPoint.transform.right * BowBehaviour.instance.launchForce;
    }
}
