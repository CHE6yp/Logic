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

        UpdateOutput();
        UpdateLook();
    }

    void Switch(bool v)
    {
        UpdateOutput();
        UpdateLook();
    }

    public void Toggle()
    {
        value = !value;
        UpdateOutput();
        UpdateLook();
        AudioClip clip = (value) ? audioClips[0] : audioClips[1];
        audioSource.PlayOneShot(clip);
    }

    void UpdateLook()
    {
        //GetComponent<MeshRenderer>().material.color = (value) ? Color.green : Color.red;
        GetComponent<Animator>().SetBool("value", value);
    }

    void UpdateOutput()
    {
        logicalOutput.value = value && logicalInput.value;
    }
}
