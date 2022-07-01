using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera Camera;
    public float Length;

    private Ray _mouseRay;
    private Vector3 _position;
    private Vector3 _direction;
    private Quaternion _rotation;

    private void Update()
    {
        if(Camera != null)
        {
            _mouseRay = Camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_mouseRay.origin, _mouseRay.direction, out RaycastHit hit, Length))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = _mouseRay.GetPoint(Length);
                RotateToMouseDirection(gameObject, pos);
            }
        }
    }

    private void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        _direction = destination - obj.transform.position;
        _rotation = Quaternion.LookRotation(_direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, _rotation, 1.0f);
    }

    public Quaternion GetQuar()
    {
        return _rotation;
    }
}
