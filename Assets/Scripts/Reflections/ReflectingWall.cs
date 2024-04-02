using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReflectingWall : AReflection
{
    [SerializeField]
    Vector2 _normal = Vector2.up;


    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(_normal));
#endif
    }

    public override Vector2 GetReflection(Vector2 position, Vector2 velocity)
    {
        return Vector2.Reflect(velocity, GetNormal(position)) * _speedMultiplier;
    }

    protected override Vector2 GetNormal(Vector2 position)
    {
        return transform.TransformDirection(_normal);
    }
}
