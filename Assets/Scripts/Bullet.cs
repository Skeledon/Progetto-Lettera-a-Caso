using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AReflection reflection;
        if(collision.TryGetComponent<AReflection>(out reflection))
        {
            Vector2 newSpeed = reflection.GetReflection(transform.position, transform.up * _speed);
            _speed = newSpeed.magnitude;
            float angle = Vector2.SignedAngle(transform.up, newSpeed);
            transform.Rotate(Vector3.forward, angle);
        }
    }
}
