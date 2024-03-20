using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public LayerMask layerMask;
    public float raycastDistance = 10f;

    void Update()
    {
        Vector2 movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement);

        Ray ray = new Ray(transform.position, transform.right);
        // Shoot a raycast from the GameObject's position in the forward direction
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance, layerMask);

        //Debug.DrawRay(transform.position, transform.right * raycastDistance, Color.green);

        // Check if the raycast hit a collider on the specified layer mask
        if (hit.collider != null)
        {
            ////TO DO: fixare la rotazione
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            Debug.Log("reflectDir " + reflectDir);
            float rot = Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, rot);
        }
    }
}
