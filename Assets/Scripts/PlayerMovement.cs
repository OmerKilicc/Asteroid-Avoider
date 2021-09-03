using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Camera mainCamera;
    Rigidbody _rigidbody;
    
    [SerializeField] private float maxVelocity;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float rotationSpeed;

    Vector3 movementDirection;

    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ScreenWraparound();
        RotateToVelocity();
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPostion = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPostion);

            //Dokunulan yerin tersine gitmesi için
            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
        _rigidbody.AddForce(movementDirection * forceMagnitude,ForceMode.Force);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxVelocity);
    }

    void ScreenWraparound()
    {
        Vector3 newPostion = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        
        if (viewportPosition.x > 1)
        {
            newPostion.x = -newPostion.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPostion.x = -newPostion.x - 0.1f;
        }
        
        if (viewportPosition.y > 1)
        {
            newPostion.y = -newPostion.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPostion.y = -newPostion.y - 0.1f;
        }
        transform.position = newPostion;
    }

    void RotateToVelocity()
    {
        if (_rigidbody.velocity == Vector3.zero){ return; }
        Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity,Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
