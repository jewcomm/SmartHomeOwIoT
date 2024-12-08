using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunRotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject go;
    [SerializeField] public float RotationSpeed = 1.0f;

    void FixedUpdate()
    {
        go.transform.Rotate(Vector3.forward, RotationSpeed);
    }
}
