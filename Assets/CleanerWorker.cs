using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CleanerWorker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject targetParent;

    [SerializeField] private KeyCode runKey;
    [SerializeField] private KeyCode ctrlKey;

    [SerializeField] private GameObject homePosition;

    [SerializeField] private AudioSource workSound;
    [SerializeField] private AudioSource repairSound;

    [SerializeField] private Image statusImage;


    private Transform[] targets;
    private int currentTargetIndex = 0;
    private bool isProcessRunning = false;
    private bool backToBase = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targets = findAllTargets(targetParent);

        System.Array.Sort(targets,
             (a, b) => { return a.name.CompareTo(b.name); });

        workSound.Stop();
        repairSound.Stop();
        statusImage.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(runKey))
        {
            StartCleaning();
        }

        if (Input.GetKeyDown(ctrlKey))
        {
            StopCleaning();
        }

        ExecuteCleaning();
    }

    protected Transform[] findAllTargets(GameObject gameObject)
    {
        return gameObject.transform.GetComponentsInChildren<Transform>(includeInactive: true);
    }

    void StartCleaning()
    {
        if (!isProcessRunning)
        {
            isProcessRunning = true;
            statusImage.color = Color.green;
        }

        workSound.Play(0);
        repairSound.Stop();
    }

    void StopCleaning()
    {
        if (isProcessRunning)
        {
            print("StopCleaning");
            isProcessRunning = false;
            statusImage.color = Color.gray;
            currentTargetIndex = 0;
            agent.SetDestination(homePosition.transform.position);
            backToBase = true;
        }
    }

    void ExecuteCleaning()
    {
        if (isProcessRunning && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            GoToNextTarget();
        }

        if (!isProcessRunning && ((agent.destination - homePosition.transform.position).magnitude < 1))
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                workSound.Stop();
                if (backToBase)
                {
                    backToBase = false;
                    repairSound.Play();
                }
            }
        }
    }

    void GoToNextTarget()
    {
        currentTargetIndex = (currentTargetIndex + 1);
        print("Current targer" + currentTargetIndex);
        print("targets.Length" + targets.Length);
        if (currentTargetIndex == (targets.Length - 2))
        {
            StopCleaning();
            return;
        }
        agent.SetDestination(targets[currentTargetIndex].position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box" || collision.gameObject.name == "Ball")
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            sphere.transform.position = collision.transform.position;
            sphere.transform.localScale = new Vector3(1f, 1f, 1f);
            sphere.layer = LayerMask.NameToLayer("Minimap");

            MeshRenderer meshRenderer = sphere.GetComponent<MeshRenderer>();
            meshRenderer.material = new Material(Shader.Find("Standard"));
        }
    }
}
