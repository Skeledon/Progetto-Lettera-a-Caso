using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;

    public float speed = 15;
    RaycastHit hit;
    Ray ray;

    //https://www.youtube.com/watch?v=u_p5H0wEN8Y
    void Start()
    {
        
    }


    void Update()
    {
        Vector2 movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, movement.normalized);

        if (Physics.Raycast(ray, out hit, movement.magnitude + .5f, collisionMask))
        {
            Debug.Log("Collision detected with: " + hit.transform.gameObject.name);

            //        Vector3 reflectDirection = Vector2.Reflect(ray.direction, hit.normal);
            //        float rot = 90 - Mathf.Atan2(reflectDirection.z, reflectDirection.x) * Mathf.Rad2Deg;
            //        transform.eulerAngles = new Vector2(0, rot);
        }
        Debug.DrawRay(transform.position, movement.normalized * (movement.magnitude + .5f), Color.green);

    }

}
