using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsShow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameObject;
    Transform[] children;

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        children = findAllTargets(gameObject);

        foreach (Transform child in children)
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0f, 0.5f);
            Gizmos.DrawSphere(child.position, 0.5f);
        }
    }

    private Transform[] findAllTargets(GameObject gameObject)
    {
        return gameObject.transform.GetComponentsInChildren<Transform>(includeInactive: true);
    }
}
