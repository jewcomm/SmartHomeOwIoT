using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerHider : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f,  0.5f);
        Gizmos.DrawCube(gameObject.transform.position, gameObject.transform.localScale);
    }
}
