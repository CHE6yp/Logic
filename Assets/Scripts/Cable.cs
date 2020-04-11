using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LogicalInput))]
[RequireComponent(typeof(LogicalOutput))]
public class Cable : MonoBehaviour
{
    public LogicalInput logicalInput;
    public LogicalOutput logicalOutput;
    public MeshRenderer meshRenderer;

    public Material[] mats;

    private void Awake()
    {
        logicalInput = GetComponent<LogicalInput>();
        logicalOutput = GetComponent<LogicalOutput>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        logicalOutput.value = logicalInput.value;
        if (logicalInput.value)
            meshRenderer.material = mats[0];
        else
            meshRenderer.material = mats[1];
    }
}
