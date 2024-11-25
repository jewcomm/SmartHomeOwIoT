using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    [SerializeField]
    public float turnSpeed = 2000.0f;
    public float moveSpeed = 80.0f;
    private float rotY;

    void Update()
    {
        MouseAiming();
    }

    void FixedUpdate()
    {
        KeyboardMovement();
    }
    void MouseAiming()
    {
        // get the mouse inputs
        rotY += (Input.GetAxis("Mouse X") * turnSpeed);
        // rotate the figure
        transform.eulerAngles = new Vector3(0, rotY, 0);
    }
    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        transform.Translate(dir / moveSpeed);
    }
}
