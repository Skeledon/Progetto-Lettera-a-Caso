using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AReflection : MonoBehaviour
{
    [SerializeField]
    protected float _speedMultiplier = 1;

    public abstract Vector2 GetReflection(Vector2 position, Vector2 velocity);


    protected abstract Vector2 GetNormal(Vector2 position);

}
