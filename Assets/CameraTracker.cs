using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTracker : MonoBehaviour
{
    public Transform trackedObject;
    private float rotX;
    public float turnSpeed = 2000.0f;

    // Update is called once per frame
    void Update()
    {
        //transform.position = trackedObject.position;
        transform.position = new Vector3(trackedObject.position.x, trackedObject.position.y + 0.6f, trackedObject.position.z);
        rotX += Input.GetAxis("Mouse Y") * Time.deltaTime * turnSpeed;
        rotX = Mathf.Clamp(rotX, -90, 90);
        transform.eulerAngles = new Vector3(-rotX, trackedObject.eulerAngles.y, 0);
    }
}
