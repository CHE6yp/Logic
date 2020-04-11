using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LogicalInput))]
[RequireComponent(typeof(LogicalOutput))]
public class BasicSwitch : MonoBehaviour
{
    public LogicalInput logicalInput;
    public LogicalOutput logicalOutput;
    public bool value;


    public AudioClip[] audioClips;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        logicalInput = GetComponent<LogicalInput>();
        logicalOutput = GetComponent<LogicalOutput>();

    }

    // Update is called once per frame
    void Update()
    {
        logicalOutput.value = (value) ? logicalInput.value : false;
    }

    public void Toggle()
    {
        value = !value;

        GetComponent<MeshRenderer>().material.color = (value) ? Color.green : Color.red;
        AudioClip clip = (value) ? audioClips[0] : audioClips[1];
        audioSource.PlayOneShot(clip);
    }
}
