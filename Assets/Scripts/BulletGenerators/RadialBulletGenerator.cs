using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletGenerator : ABulletGenerator
{
    [SerializeField]
    private float[] _angles;

    [SerializeField]
    protected float _timeBetweenShots;

    private Coroutine _firingCoroutine;
    protected override void GenerateBullets()
    {
        foreach (var angle in _angles)
        {
            Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, angle);
            Instantiate(_bulletGameObject, transform.position, rotation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _firingCoroutine = StartCoroutine(Fire());
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;
        foreach (var angle in _angles)
        {
            Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, angle);
            Gizmos.DrawLine(transform.position, transform.position + rotation * Vector3.up * 3);
        }

#endif
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenShots);
            GenerateBullets();
        }
    }
}
