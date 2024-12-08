using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class MapShower : MonoBehaviour
{
    [SerializeField] private RawImage miniMap;
    [SerializeField] private KeyCode openMiniMapKey;

    private bool isMiniMapOpen = false;

    private void Start()
    {
        miniMap.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(openMiniMapKey))
        {
            OpenMiniMap();
        }

        if (Input.GetKeyUp(openMiniMapKey))
        {
            CloseMiniMap();
        }
    }

    private void OpenMiniMap()
    {
        if (!isMiniMapOpen)
        {
            miniMap.enabled = true;
            isMiniMapOpen = true;
        }
    }

    private void CloseMiniMap()
    {
        if (isMiniMapOpen)
        {
            miniMap.enabled = false;
            isMiniMapOpen = false;
        }
    }
}
