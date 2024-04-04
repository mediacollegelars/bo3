using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingPlayermovement  : MonoBehaviour
{

    public float walkSpeed = 3f; // Speed for walking
    public float runSpeed = 6f; // Speed for running
    public float smoothingFactor = 0.5f; // Smoothing factor for movement and rotation

    private Vector3 movement;


    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentSpeed = isShiftPressed ? runSpeed : walkSpeed;

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * currentSpeed;

        // Calculate the new position of the object
        Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;

        // Use Vector3.Lerp for a smooth transition to the new position
        rb.MovePosition(Vector3.Lerp(rb.position, newPosition, smoothingFactor));

        if (movement != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, smoothingFactor));

        }
        Debug.Log(movement);
    }
}