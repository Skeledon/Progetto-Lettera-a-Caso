using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{

    public string tagToDeflectFrom = "DeflectWall";
    public Vector2 deflectionDirection;

    private Rigidbody2D rb;
    public new Vector2 initialDirection;  //Test   
    new Vector2 currentDirection;

    public float speed = 2f;
    Vector2 currentVelocity;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = initialDirection;
    }

    void Update()
    {
        rb.velocity = currentDirection * speed * Time.deltaTime;
        currentVelocity = rb.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(tagToDeflectFrom))
        {           
            deflectionDirection = Vector2.Reflect(currentVelocity, collision.contacts[0].normal);
            currentDirection = deflectionDirection; //multiply by a value to give a boost after deflect
        }
    }
}
