using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public string tagToDeflectFrom = "DeflectWall";
    public float deflectForce = 10f;
    public Vector2 deflectionDirection;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.collider.CompareTag(tagToDeflectFrom))
        {
            Debug.Log("Deflect");

            deflectionDirection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);

            rb.velocity = deflectionDirection * deflectForce;
            //rb.AddForce(deflectionDirection);
        }
    }
}
