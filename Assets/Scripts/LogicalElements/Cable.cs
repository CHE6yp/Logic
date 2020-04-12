using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : LogicalElement
{
    MeshRenderer meshRenderer;

    public Material[] mats;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        logicalInput.valueChanged += Switch;
        Switch(logicalInput.value);
    }

    void Switch(bool v)
    {
        logicalOutput.value = v;
        if (v)
            meshRenderer.material = mats[0];
        else
            meshRenderer.material = mats[1];
    }
}
