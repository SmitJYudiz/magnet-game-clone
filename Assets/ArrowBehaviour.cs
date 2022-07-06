using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    //smit's work
    Rigidbody2D rb;
    bool isCollided;

    float arrowLifeTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrowLifeTime = 3;
    }
    private void Update()
    {
        arrowLifeTime -= Time.deltaTime;
        if(arrowLifeTime<=0)
        {
            Destroy(gameObject);
        }

        if(!isCollided)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollided = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
