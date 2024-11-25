using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointHider : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f,  0.5f);
        Gizmos.DrawSphere(gameObject.transform.position, 0.02f);
    }
}
