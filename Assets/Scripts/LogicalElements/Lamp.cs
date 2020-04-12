using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : LogicalElement
{
    public Light light;

    protected override void Awake()
    {
        base.Awake();
        logicalInput.valueChanged += Switch;
        Switch(logicalInput.value);
    }

    void Switch(bool v)
    {
        logicalOutput.value = v;
        if (v)
        {
            light.intensity = 1.5f;
            GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            light.intensity = 0;
            GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }
    }
}
