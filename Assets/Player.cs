using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]

    private Camera _camera;

    [SerializeField]
    [Range(1f, 100f)]
    private float speed = 1f;

    [SerializeField]
    [Range(1f, 100f)]
    private float interpolation = 1f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var view = _camera.transform.forward;
        view.y = 0f;
        view.Normalize();

        if (vertical != 0 || horizontal != 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(view), interpolation * Time.deltaTime);

        transform.position += vertical * view * Time.deltaTime * speed;
        transform.position += horizontal * _camera.transform.right * Time.deltaTime * speed;
    }
}
