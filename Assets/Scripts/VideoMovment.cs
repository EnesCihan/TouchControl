using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMovment : MonoBehaviour
{
    [SerializeField] private float movmentspeed;
    [SerializeField] private float rotationSpeed = 500;

    private Touch touch;

    private Vector3 touchDown;
    private Vector3 touchUp;

    private bool dragStarted;
    private bool isMoving;
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                isMoving = true;
                touchDown = touch.position;
                touchUp = touch.position;
            }
        }
        if (dragStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                touchDown = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchDown = touch.position;
                isMoving = false;
                dragStarted = false;
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime*movmentspeed);
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }
    Vector3 CalculateDirection()
    {
        Vector3 temp = (touchDown - touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
}
