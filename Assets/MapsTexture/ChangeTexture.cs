using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ChangeTexture : MonoBehaviour
{
    //[SerializeField] private Material baseMaterial;
    [SerializeField] private Material newMaterial;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] private Renderer meshRenderer; //Also attempted with MeshRenderer

    [SerializeField] private TextMeshProUGUI statusText;

    private static int counter = 0;
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((agent.destination - target.transform.position).magnitude < 0.5 && agent.remainingDistance <= agent.stoppingDistance)
        {
                meshRenderer.GetComponent<Renderer>().material = newMaterial;
                counter++;
                if (statusText != null) { 
                    statusText.text = "Убрано комнат: \n" + counter + " / 6";
                }
    }
}
}
