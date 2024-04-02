using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABulletGenerator : MonoBehaviour
{
    [SerializeField]
    protected GameObject _bulletGameObject;


    protected abstract void GenerateBullets();
}
