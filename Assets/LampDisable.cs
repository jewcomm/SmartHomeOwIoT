using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using UnityEngine.UI;

public class LampDisable : MonoBehaviour
{
    [SerializeField]
    public Light light;
    public Material material;

    private float timeLeft = 0.0f;
    private bool timerEnable = false;

    [SerializeField] private Image statusImage;

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
        material.SetColor("_EmissionColor", Color.black);
        if (statusImage != null) statusImage.color = Color.gray;
    }

    private void Update()
    {
        if (timerEnable)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0.0f)
            {
                lampDisable();
                timerEnable = false;
            }
        }
    }

    private void lampDisable()
    {
        light.enabled = false;
        material.SetColor("_EmissionColor", Color.black);
        if (statusImage != null) statusImage.color = Color.gray;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Box" && other.gameObject.name != "Ball")
        {
            light.enabled = true;
            material.SetColor("_EmissionColor", Color.white);
            if (statusImage != null) statusImage.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Box" && other.gameObject.name != "Ball")
        {
            timeLeft = 3.0f;
            timerEnable = true;
        }
    }
}
