using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private Vector3 _targetVector;
    private Vector3 _interpolatedVector;
    private Vector2 _mousePosition;

    [SerializeField]

    [Range(1f, 8f)]
    private float _interpolation = 1f;

    private void Start()
    {
        _targetVector = _interpolatedVector = transform.position - _target.position;
        _mousePosition = Input.mousePosition;
    }

    private void Update()
    {
        Move();
        Rotate();
        InterpolatedVector();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _targetVector, _interpolation * Time.deltaTime);
    }

    private void InterpolatedVector()
    {
        _interpolatedVector = Vector3.Lerp(_interpolatedVector, _targetVector, _interpolation * Time.deltaTime).normalized * _targetVector.magnitude;
        transform.rotation = Quaternion.LookRotation(-_interpolatedVector);
    }

    private void Rotate()
    {
        var delta = (Vector2)Input.mousePosition - _mousePosition;

        var yRotation = Quaternion.Euler(0f, delta.x, 0f);
        _targetVector = yRotation * _targetVector;

        _mousePosition = Input.mousePosition;
    }
}
