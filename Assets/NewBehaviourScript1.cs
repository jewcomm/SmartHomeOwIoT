using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] public float RotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        go.transform.Rotate(Vector3.forward, RotationSpeed);
    }
}
