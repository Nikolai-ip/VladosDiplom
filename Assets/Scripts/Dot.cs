using System;
using TMPro;using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
public class Dot : MonoBehaviour
{
    private Resources.Vector3 _position;
    public Resources.Vector3 GetPosition()=> _position;
    private Dot _referenceDot;
    public event Action<Dot> Initialized;

    public void Init(Resources.Vector3 dotPos, Dot referenceDot = null)
    {
        _position = dotPos;
        _referenceDot = referenceDot;
        if (_referenceDot != null)
        {
            Vector3 offset = (Vector3)(_position - _referenceDot.GetPosition());
            transform.localPosition = _referenceDot.transform.localPosition + offset;
        }
        else
            transform.localPosition = Vector3.zero;

        Vector3 pos = transform.localPosition;
        pos.z = -1;
        transform.localPosition = pos;
        Initialized?.Invoke(this);
    }
}


