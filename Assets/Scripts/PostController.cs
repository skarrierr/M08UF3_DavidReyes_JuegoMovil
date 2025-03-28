using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostController : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private Vector2 touchStartPosition;
    private bool isSwiping = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        float deltaX = touch.position.x - touchStartPosition.x;
                        transform.Rotate(0, deltaX * rotationSpeed * Time.deltaTime, 0);
                        touchStartPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isSwiping = false;
                    break;
            }
           
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }
}
