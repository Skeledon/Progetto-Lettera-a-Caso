using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShieldAttack : APlayerAttack
{
    [SerializeField]
    private GameObject _sphereGameObject;

    [SerializeField]
    private float _energyReductionRate = 5f;

    private bool _isAttacking = false;
    
    protected override void Attack()
    {
        _isAttacking = true;
        _sphereGameObject.SetActive(true);
    }

    protected override void FixedUpdate()
    {
    }

    protected override void Update()
    {
        if (_isAttacking)
        {
            _currentEnergy -= _energyReductionRate * Time.deltaTime;
            if( _currentEnergy <= 0 )
            {
                DestroyShield();
            }
        }
    }

    private void DestroyShield()
    {
        _isAttacking = false;
        _sphereGameObject.SetActive(false);
    }
}
