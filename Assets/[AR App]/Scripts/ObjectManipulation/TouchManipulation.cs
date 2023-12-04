using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManipulation : MonoBehaviour
{
    private float lastTapTime = 0f;
    private float doubleTapTimeThreshold = 0.3f;
    
    private bool rotating = false;
    public float rotationSpeed = 0.3f;

    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        if (!objectIsTouched())
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }

        else
        {
            gameObject.GetComponent<Outline>().enabled = true;

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (Time.time - lastTapTime <= doubleTapTimeThreshold)
                    {
                        rotating = !rotating;
                        lastTapTime = 0f;
                    }

                    else
                    {
                        lastTapTime = Time.time;
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (rotating)
                    {
                        Quaternion initRotation = this.transform.rotation;
                        this.transform.Rotate(Input.GetTouch(0).deltaPosition.y * rotationSpeed,
                                             -Input.GetTouch(0).deltaPosition.x * rotationSpeed, 
                                             0, 
                                             Space.World);
                    }

                    else 
                    {
                        // Shoot a ray through the touch position
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);

                        // Make a plane at the object's position and perpendicular to the world Y-axis
                        Plane plane = new Plane(Vector3.up, transform.position);

                        float distanceFromCamera = 0; 
                        if (plane.Raycast(ray, out distanceFromCamera))
                        {
                            Vector3 pointPosition = ray.GetPoint(distanceFromCamera);
                            transform.position = new Vector3(pointPosition.x, pointPosition.y, pointPosition.z);
                        }
                    }
                }
            }

            if (Input.touchCount == 2)
            {
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);

                if (touchZero.phase == TouchPhase.Ended 
                || touchZero.phase == TouchPhase.Canceled
                || touchOne.phase == TouchPhase.Ended
                || touchOne.phase == TouchPhase.Canceled)
                {
                    return;
                }

                if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = this.transform.localScale;
                }

                else
                {
                    if (Mathf.Approximately(initialDistance, 0))
                    {
                        return;
                    }
                    
                    var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    var factor = currentDistance / initialDistance;
                    transform.localScale = initialScale * factor;
                }
            }
        } 
    }

    private bool objectIsTouched()
    {
        foreach (Touch touch in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.name == this.gameObject.name)
                {
                    return true;
                }     
            }
        }

        return false;
    }
}