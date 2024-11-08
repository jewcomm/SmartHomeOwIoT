using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public Animator Animator;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {       
        Animator.SetBool("IsOpen", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        Animator.SetBool("IsOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Animator.SetBool("IsOpen", false);
    }
}
