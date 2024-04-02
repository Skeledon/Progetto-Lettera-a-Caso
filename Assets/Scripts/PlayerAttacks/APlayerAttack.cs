using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class APlayerAttack : MonoBehaviour
{
    [SerializeField]
    protected float _energyNeeded;


    protected float _currentEnergy;

    public float EnergyNeeded { get { return _energyNeeded; } }
    public float CurrentEnergy { get { return _currentEnergy; } }

    public bool CanAttack { get { return CurrentEnergy >= EnergyNeeded; } }

    public virtual bool TryAttacking()
    {
        if(CanAttack)
        { 
            Attack(); 
            return true; 
        }
        return false;

    }

    public virtual void IncreaseEnergy(float energy)
    {
        _currentEnergy += energy;
        _currentEnergy = Mathf.Clamp(_currentEnergy, 0, _energyNeeded);
    }

    protected abstract void Attack();

    protected abstract void Update();
    protected abstract void FixedUpdate();
}
