using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : LogicalElement
{
    public MeshRenderer meshRenderer;

    public Material[] mats;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
        logicalInput.valueChanged += Switch;
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
