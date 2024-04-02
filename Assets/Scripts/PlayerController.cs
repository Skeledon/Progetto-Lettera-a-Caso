using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player movement
    [SerializeField]
    private float _playerSpeed;

    [SerializeField]
    private Vector2 _moveInput;

    [SerializeField]
    private AttacksController _attackController;

    [HideInInspector] public Rigidbody2D _playerRb;



    void Start()
    {
        _playerRb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        GetInput();
        IncreaseEnergy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetFixedInput();

        _moveInput.Normalize();

        _playerRb.velocity = _moveInput * _playerSpeed;

        if (_moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(_moveInput.y, _moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TODO Temporary. Index needed in case of future multiple attacks
            _attackController.TryAttack(0);
        }
    }
    private void GetFixedInput()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");

    }

    private void IncreaseEnergy()
    {
        //TODO Temporary, just for debug
        _attackController.IncreaseEnergy(20 * Time.deltaTime);
    }
}
