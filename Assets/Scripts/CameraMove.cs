using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    public void Start()
    {
        var position = target.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void Update()
    {
        var destination = target.position;
        var position = transform.position;
        position = Vector3.Lerp(
            position,
            new Vector3(destination.x, destination.y, position.z),
            Time.deltaTime * speed
        );
        transform.position = position;
    }
}