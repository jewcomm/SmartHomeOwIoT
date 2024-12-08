using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetLevel : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;
    [SerializeField]
    private float minLevel = 30.0f;
    [SerializeField]
    private float maxLevel = 70.0f;
    [SerializeField]
    private float decreaseLevelInSecond = 1.0f;
    [SerializeField]
    private float increaseLevelInSecondByVapor = 10.0f;

    private float currentlevel;
    private float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentlevel = maxLevel;
    }

    // Update is called once per frame
    void Update()
    {
        currentlevel -= (decreaseLevelInSecond * Time.deltaTime);
        if (currentlevel <= minLevel)
        {
            particleSystem.Play();
        }

        if (particleSystem.isPlaying)
        {
            currentlevel += (increaseLevelInSecondByVapor * Time.deltaTime);
        }

        if (currentlevel >= maxLevel)
        {
            particleSystem.Stop();
        }
    }
}
