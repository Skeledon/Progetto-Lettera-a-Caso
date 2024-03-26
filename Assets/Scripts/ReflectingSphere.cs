using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingSphere : AReflection
{


    public override Vector2 GetReflection(Vector2 position, Vector2 velocity)
    {
        return Vector2.Reflect(velocity, GetNormal(position)) * _speedMultiplier;
    }

    protected override Vector2 GetNormal(Vector2 position)
    {
        return (position - (Vector2)transform.position).normalized;
    }
}
