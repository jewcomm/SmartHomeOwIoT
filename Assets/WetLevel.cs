using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Image statusImage;
    [SerializeField] private TextMeshProUGUI statusText;

    private float currentlevel;
    private float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentlevel = maxLevel;
        statusImage.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        currentlevel -= (decreaseLevelInSecond * Time.deltaTime);
        statusText.text = "Влажность: " + (int)Math.Round(currentlevel);
        if (currentlevel <= minLevel)
        {
            particleSystem.Play();
            statusImage.color = Color.green;
        }

        if (particleSystem.isPlaying)
        {
            currentlevel += (increaseLevelInSecondByVapor * Time.deltaTime);
        }

        if (currentlevel >= maxLevel)
        {
            particleSystem.Stop();
            statusImage.color = Color.gray;
        }
    }
}
