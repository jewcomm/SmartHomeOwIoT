using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeTexture : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] private Renderer meshRenderer; //Also attempted with MeshRenderer


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((agent.destination - target.transform.position).magnitude < 1)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                meshRenderer.material = newMaterial;
            }
        }
    }
}
