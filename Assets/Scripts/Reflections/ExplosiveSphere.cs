using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSphere : AReflection
{
    public override Vector2 GetReflection(Vector2 position, Vector2 velocity)
    {
        return GetNormal(position) * _speedMultiplier;
    }

    protected override Vector2 GetNormal(Vector2 position)
    {
        return (position - (Vector2)transform.position).normalized;
    }
}
