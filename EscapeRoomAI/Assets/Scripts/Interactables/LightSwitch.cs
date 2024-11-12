using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightSwitch : Interactable
{
    [SerializeField] private Light[] lightSources; // Array of light sources to be controlled
    private bool isOn = false;


    void Start()
    {
        promptMessage = "Click to toggle light"; // Assign a specific prompt message for light switch
    }

    protected override void Interact()
    {
        // Toggle the isOn state
        isOn = !isOn;

        // Loop through each light source and set its enabled state based on isOn
        foreach (Light light in lightSources)
        {
            light.enabled = isOn;
        }

        Debug.Log("Lights turned " + (isOn ? "on" : "off"));
    }
}