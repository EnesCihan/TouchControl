using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    public float smootSpeed;
    void Start()
    {
        offset = transform.position - ball.position;
    }


    void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + ball.position, smootSpeed);
        transform.position = newPos;
    }
}
