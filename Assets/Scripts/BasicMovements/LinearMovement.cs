using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _distance;

    [SerializeField]
    private Vector2 _startingDirection;

    private float _currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float amount = _speed * Time.fixedDeltaTime;
        transform.Translate(_startingDirection * amount);
        _currentDistance += amount;

        if(_currentDistance >= _distance)
        {
            _currentDistance = 0f;
            _startingDirection *= -1;
        }
    }
}
