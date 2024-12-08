using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHandler : MonoBehaviour
{
    public Animator Animator;
    public bool isOpen;

    [SerializeField] private Image statusImage;

    // Start is called before the first frame update
    void Start()
    {       
        Animator.SetBool("IsOpen", false);
        if(statusImage != null) statusImage.color = Color.gray;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Box" && other.gameObject.name != "Ball") 
        { 
            Animator.SetBool("IsOpen", true);
            if (statusImage != null) statusImage.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Box" && other.gameObject.name != "Ball")
        {
            Animator.SetBool("IsOpen", false);
            if (statusImage != null) statusImage.color = Color.gray;
        }
    }
}
