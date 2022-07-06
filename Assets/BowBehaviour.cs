using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehaviour : MonoBehaviour
{

    public static BowBehaviour instance;

    private void Awake()
    {
        instance = this;
    }

    //smit's work
    public GameObject arrow;

    

    public Transform shotPoint;
    public float launchForce;

    public GameObject pointPrefab;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;

    private void Start()
    {
        if(launchForce<=0)
        {
            launchForce = 20;
        }

        points = new GameObject[numberOfPoints];

        for(int i=0; i<numberOfPoints; i++)
        {
           points[i] = Instantiate(pointPrefab, shotPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        direction = -transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = direction;
        if(Input.GetKey(KeyCode.E) && magnetBehaviour.instance.magnetWithPlayer)
        {
            
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                points[i].SetActive(true);
            }
        }
        else
        {
            foreach(GameObject point in points)
            {
                point.SetActive(false);
            }
            
        }
        
    }

   

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2) shotPoint.transform.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
