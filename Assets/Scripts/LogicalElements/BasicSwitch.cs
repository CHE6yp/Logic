using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSwitch : LogicalElement
{
    public bool value;

    public AudioClip[] audioClips;
    public AudioSource audioSource;


    protected override void Awake()
    {
        base.Awake();
        logicalInput.valueChanged += Switch;
    }

    void Switch(bool v)
    {
        UpdateOutput();
    }

    public void Toggle()
    {
        value = !value;
        UpdateOutput();

        GetComponent<MeshRenderer>().material.color = (value) ? Color.green : Color.red;
        AudioClip clip = (value) ? audioClips[0] : audioClips[1];
        audioSource.PlayOneShot(clip);
    }

    void UpdateOutput()
    {
        logicalOutput.value = value && logicalInput.value;
    }
}
