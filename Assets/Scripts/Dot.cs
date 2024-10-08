using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private double _x;
    [SerializeField] private double _y;
    [SerializeField] private double _z;
    [SerializeField] private float _scale;
    [SerializeField] private float _radius;
    private void OnValidate()
    {
        transform.position = new Vector3((float)_x, (float)_y, (float)_z) / _scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
