using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksController : MonoBehaviour
{
    public APlayerAttack[] Attacks;
    public bool TryAttack(int attackId)
    {
        if (attackId < Attacks.Length)
        {
            return Attacks[attackId].TryAttacking();
        }
        else { return false; }
    }
    /// <summary>
    /// Increases energy for all attacks by the specified amount
    /// </summary>
    /// <param name="energy">amount of energy to add (negative values can remove energy)</param>
    public void IncreaseEnergy(float energy)
    {
        foreach (var attack in Attacks)
        {
            attack.IncreaseEnergy(energy);
        }
    }

    /// <summary>
    /// Increases energy for the attack specified by the specified amount
    /// </summary>
    /// <param name="energy">amount of energy to add (negative values can remove energy)</param>
    /// <param name="attackId">ID for the attack in the array. Nothing happens if the ID doesn't exist</param>
    public void IncreaseEnergy(float energy, int attackId)
    {
        if (attackId < Attacks.Length)
        {
            Attacks[attackId].IncreaseEnergy(energy);
        }
    }
}
